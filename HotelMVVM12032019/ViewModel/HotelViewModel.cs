using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM12032019.Model;

namespace HotelMVVM12032019.ViewModel
{
    public class HotelViewModel
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }

        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
        }
    }
}
