using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSL;

namespace TestApp
{
    class Program
    {
        static BLL _psl = new BLL();
        static void Main(string[] args)
        {
            
           //GetZipCodesByRadius(30331, 10);
            //GetZipCodesWithRadius_All(30331, 5);
            GetLocationInfo(30331);
        }

        private static void GetLocationInfo(int zipCode)
        {
            var data = _psl.GetLocationInfo(zipCode);
        }

        private static void GetZipCodesByRadius(int zipCode, int radius)
        {
            var data = _psl.GetZipCodesWithinRadius(zipCode, radius);
        }

        private static void GetZipCodesWithRadius_All(int zipCode, int radius)
        {
            var data = _psl.GetZipCodesWithRadius_All(zipCode, radius);
        }
    }
}
