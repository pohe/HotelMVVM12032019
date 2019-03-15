using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelMVVM12032019.Common;
using HotelMVVM12032019.Handler;
using HotelMVVM12032019.Model;
using PortableHotel;

namespace HotelMVVM12032019.ViewModel
{
    public class HotelViewModel
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }

        public HotelHandler HotelHandler { get; set; }
        public HotelViewModel()
        {
            _newHotel = new Hotel();
            HotelHandler = new HotelHandler(this);
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
            CreateHotelCommand = new RelayCommand(HotelHandler.CreateHotel);
        }
        public ICommand CreateHotelCommand { get; set; }

        private Hotel _newHotel;
        public Hotel NewHotel
        {
            get { return _newHotel; }
            set { _newHotel = value; }
        }
    }
}
