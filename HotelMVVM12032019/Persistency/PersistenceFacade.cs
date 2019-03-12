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

    }
}
