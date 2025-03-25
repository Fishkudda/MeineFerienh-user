
using System.Runtime.CompilerServices;

namespace MeineFerienhäuser.Services
{
    public class HouseFactory
    {
        private static List<House> _houses;
        private static List<House> _error_houses;


        public static List<House> GetHouseList()
        {
            if(_houses == null)
            {
                _houses = new List<House>();
            }
            return _houses;
        }

        public static void SetHouseList(List<House> house)
        {
            if(house == null)
            {
                return;
            }

            _houses=house;

        }

        public static List<House> GetErrorHouses() { 
            if(_error_houses == null)
            {
                return new List<House>();
            }

            return _error_houses;
        }

        public static void SetErrorHouses(List<House> error_houses)
        {
            if(error_houses == null)
            {
                return;
            }

            _error_houses = error_houses;


        }


    }
}
