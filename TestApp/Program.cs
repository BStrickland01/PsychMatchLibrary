using PSL;
using PSL.BO;
using System;
using System.Collections.Generic;

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
           // GenerateUserID(4, Enums.UserType.Employer);
            InsertNewClinician(Enums.AdminUsers.BStrickland);  //This inserts a new Address & new Clinician
            InsertEmployer(Enums.AdminUsers.BStrickland);
            InsertJob(2, Enums.AdminUsers.BStrickland);
        }

        private static void InsertJob(int employerID, Enums.AdminUsers lastupdatedBy)
        {
            var Job = new PSL.DAL.tblJob()
            {
                Title = "Test Job",
                Description = "This represents the job description",
                tblAddress = new PSL.DAL.tblAddress()
                {
                    AddressLine1 = "222 Test Street",
                    City = "Atlanta",
                    State = "Georiga",
                    Zip = "30030",
                    LastModifiedBy = Enums.AdminUsers.BStrickland.ToString(),
                    LastModifiedDate = DateTime.Now
                },
                YearsExpID = (int)Enums.YearsExperience.FiveToSixYears,
                EmployerID = employerID,
                PositionTypeID = (int)Enums.PositionType.PsychiatricPrescriberClinician,
                LanguageID = (int)Enums.Languages.English,
                ServiceTypeID = (int)Enums.ServiceType.Telemed,
                EmrErxExperienceTypeID = (int)Enums.EmrErxExperienceType.emr,
                AvailabilityID = (int)Enums.Availability.WeekdaysAM,
                StatusID = (int)Enums.Status.Verified,
                LastModifiedBy = lastupdatedBy.ToString(),
                LastModifiedDate = DateTime.Now
            };

           var id= _psl.UpsertJob(Job);
        }

        private static void InsertEmployer(Enums.AdminUsers lastupdatedBy)
        {
            var Employer = new PSL.DAL.tblEmployer()
            {
                CompanyName = "Test Company",
                EmployerTypeID = (int)Enums.EmployerTypes.Clinic,
                PhoneNumber = "7703221234",
                StatusID = (int)Enums.EmployerClinicianStatus.Active,
                UserName = "TCompany",
                tblAddress = new PSL.DAL.tblAddress()
                {
                    AddressLine1 = "222 Test Ave2",
                    City = "Riverdale",
                    State = "Georiga",
                    Zip = "30334",
                    LastModifiedBy = Enums.AdminUsers.BStrickland.ToString(),
                    LastModifiedDate = DateTime.Now
                }
            };

           var id = _psl.UpsertEmployer(Employer);
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
                AddressLine1 = "123 Test Ave2",
                City = "Atlanta",
                State = "Georiga",
                Zip = "30331",
                LastModifiedBy = Enums.AdminUsers.BStrickland.ToString(),
                LastModifiedDate = DateTime.Now
            };

            var id = _psl.UpsertAddress(address);
        }

        private static void InsertNewClinician(Enums.AdminUsers lastUpdatedBy)
        {
            var clinician = new PSL.DAL.tblClinician()
            {
                ClinicianID = 0,
                UserName = "JSmith2",
                ClinicianTypeID = (int)Enums.ClinicianType.Addictionologist,
                EmailAddress = "test@test.com",
                FirstName = "Test",
                LastName = "Account",
                PhoneNumber = "7707779311",
                AvailabilityID = (int)Enums.Availability.WeekdaysAM,               
                //ClinicianDocumentID = 0,
                RegistrationDate = DateTime.Now.AddDays(-15),
                StatusID = (int)Enums.EmployerClinicianStatus.Verified,
                LastModifiedBy = lastUpdatedBy.ToString(),
                LastModifiedDate = DateTime.Now,
                YearsExpID = (int)Enums.YearsExperience.EightToNineYears,
                tblAddress = new PSL.DAL.tblAddress()
                {
                    AddressLine1 = "123 Test Ave",
                    City = "Atlanta",
                    State = "Georiga",
                    Zip = "30331",
                    LastModifiedBy = lastUpdatedBy.ToString(),
                    LastModifiedDate = DateTime.Now
                }                
            };

            var id = _psl.UpsertClinician(clinician);

            InsertClinicianLanguage(id, lastUpdatedBy);
        }

        private static void InsertClinicianLanguage(int id, Enums.AdminUsers lastUpdatedBy)
        {
            List<PSL.DAL.tblClinicianLanguage> languages = new List<PSL.DAL.tblClinicianLanguage>();
            languages.Add(new PSL.DAL.tblClinicianLanguage()
                { 
                ClinicianID = id,
                LanguageID = (int)Enums.Languages.English,
                LastUpdateBy = lastUpdatedBy.ToString(),
                LastUpdatedDate = DateTime.Now
            });

            languages.Add(new PSL.DAL.tblClinicianLanguage()
            {
                ClinicianID = id,
                LanguageID = (int)Enums.Languages.French,
                LastUpdateBy = lastUpdatedBy.ToString(),
                LastUpdatedDate = DateTime.Now
            });

           var _id = _psl.InsertClinicianLanguages(languages);
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
