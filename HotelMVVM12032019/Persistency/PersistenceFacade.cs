using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PortableHotel;

namespace HotelMVVM12032019.Persistency
{
    public class PersistenceFacade
    {
        private const string URI = "http://localhost:55075/api/hotels";

        public List<Hotel> GetAll()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI);
                String jsonStr = resTask.Result;
                hoteller = JsonConvert.DeserializeObject<List<Hotel>>(jsonStr);
            }
            return hoteller;
        }


        public bool Post(Hotel hotel)
        {
            bool ok = true;

            using (HttpClient client = new HttpClient())
            {
                String jsonStr = JsonConvert.SerializeObject(hotel);
                StringContent content = new StringContent(jsonStr, Encoding.ASCII, "application/json");

                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);

                HttpResponseMessage resp = postAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    String jsonResStr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
                }
                else
                {
                    ok = false;
                }
            }

 
            return ok;
        }

    }
}
