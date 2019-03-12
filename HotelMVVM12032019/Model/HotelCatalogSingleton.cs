using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM12032019.Persistency;
using PortableHotel;

namespace HotelMVVM12032019.Model
{
    public class HotelCatalogSingleton
    {
        private static HotelCatalogSingleton _instance = null;

        public ObservableCollection<Hotel> Hotels { get; set; }
        public static HotelCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance= new HotelCatalogSingleton();
                }
                return _instance;
            }
        }

        private HotelCatalogSingleton()
        {
            Hotels = new ObservableCollection<Hotel>(new PersistenceFacade().GetAll());
            //Hotels = new ObservableCollection<Hotel>();
            //Hotels.Add(new Hotel(12,"Peters hytte", "Sorøvej 123"));
            //Hotels.Add(new Hotel(13, "Sofus's Badehotel", "Søvej 321"));
        }

    }
}
