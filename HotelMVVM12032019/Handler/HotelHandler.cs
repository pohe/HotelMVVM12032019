using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM12032019.Persistency;
using HotelMVVM12032019.ViewModel;
using PortableHotel;

namespace HotelMVVM12032019.Handler
{
    public class HotelHandler
    {
        public HotelViewModel HotelViewModel { get; set; }

        public HotelHandler(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;
        }


        public async void CreateHotel()
        {
            int hotelNr = HotelViewModel.NewHotel.HotelNr;
            string hotelName = HotelViewModel.NewHotel.Navn;
            string hotelAddress = HotelViewModel.NewHotel.Adresse;
            Hotel aHotel = new Hotel(hotelNr, hotelName, hotelAddress);
            new PersistenceFacade().Post(aHotel);

            var hotels = await new PersistenceFacade().GetAllAsync();
            HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
            foreach (var h in hotels)
            {
                HotelViewModel.HotelCatalogSingleton.Hotels.Add(h);
            }

        }

    }
}
