using PSL;
using PSL.BO;
using System;

namespace TestApp
{
    class Program
    {
        static readonly BLL _psl = new BLL();
        static void Main(string[] args)
        {

            //GetZipCodesByRadius(30331, 10);
            //GetZipCodesWithRadius_All(30331, 5);
            //GetLocationInfo(30331);
            //InsertNewAddress();
            GenerateUserID(4, Enums.UserType.Employer);
            //InsertNewClinician(1);
        }

        private static void GenerateUserID(int value, Enums.UserType type)
        {
            var result = _psl.GenerateUserID(value, type);
        }

        private static void InsertNewAddress()
        {
            var address = new PSL.DAL.tblAddress()
            {
                AddressID = 0,
                AddressLine1 = "123 Test Ave",
                City = "Atlanta",
                State = "Georiga",
                Zip = "30331",
                LastModifiedBy = Enums.AdminUsers.BStrickland.ToString(),
                LastModifiedDate = DateTime.Now
            };

            var id = _psl.UpsertAddress(address);
        }

        private static void InsertNewClinician(int addressID)
        {
            var clinician = new PSL.DAL.tblClinician()
            {
                ClinicianID = 0,
                UserName = "JSmith",
                ClinicianTypeID = (int)Enums.ClinicianType.Addictionologist,
                EmailAddress = "test@test.com",
                FirstName = "Test",
                LastName = "Account",
                PhoneNumber = "7707779311",
                AvailabilityID = (int)Enums.Availability.WeekdaysAM,
                AddressID = addressID,
                //ClinicianDocumentID = 0,
                RegistrationDate = DateTime.Now.AddDays(-15),
                StatusID = (int)Enums.EmployerClinicianStatus.Verified,
                LastModifiedBy = "BStrickland",
                LastModifiedDate = DateTime.Now,
                YearsExpID = (int)Enums.YearsExperience.EightToNineYears                
            };

            var id = _psl.UpsertClinician(clinician);
        }
    

    //private static void InsertNewClinician()
    //{
    //    var clinician = new PSL.DAL.tblClinician()
    //    {
    //        AddressID = 1,
    //        ClinicianID = 0,
    //        ClinicianTypeID = (int)Enums.ClinicianType.Addictionologist,
    //        EmailAddress = "test@test.com",
    //        FirstName = "Test",
    //        LastName = "Account",
    //        LanguageID = (int)Enums.Languages.English,
    //        LiscenseID = 0,
    //        PhoneNumber = "(770)777-9311",


    //    }
    //    var result = _psl.UpSertClinician()
    //}

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
