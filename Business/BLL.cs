﻿using Newtonsoft.Json;
using PSL.BO;
using PSL.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static PSL.BO.Enums;

namespace PSL
{
    public partial class BLL
    {
        LinqToSqlDBDataContext dc = new LinqToSqlDBDataContext();
        readonly string Api = "https://www.zipcodeapi.com/rest/FnrgOOYnIgxhz4WX24ectZE5bCfsBu35KQIRq2dFECYj5Wk4AeIbhyG6jWzP6cx8/";

        #region  *** Clinicians ***

        public List<tblClinician> GetClinicians()
        {
            return dc.tblClinicians.ToList();
        }               

        public List<tblClinician> GetClinicians(Status status)
        {
            return dc.tblClinicians.Where(x => x.StatusID == (int)status).ToList();
        }

        public tblClinician GetClinician(int clinicianID)
        {
            return dc.tblClinicians.FirstOrDefault(x => x.ClinicianID == clinicianID);
        }

        public tblClinician GetClinician(string userID)
        {
            return dc.tblClinicians.FirstOrDefault(x => x.UserID == userID);
        }

        public List<tblClinicianLanguage> GetClinicianLanguages(int clinicianID)
        {
            return dc.tblClinicianLanguages.Where(x => x.ClinicianID == clinicianID).ToList();
        }

        public List<tblJobClinicianMatch> GetJobMatchesByClinician(int clinicianID)
        {
            return dc.tblJobClinicianMatches.Where(x => x.ClinicianID == clinicianID).ToList();
        }


        #endregion *** Clinicians ***

        #region  *** Employers ***

        public List<tblEmployer> GetEmployers()
        {
            return dc.tblEmployers.ToList();
        }

        public List<tblEmployer> GetEmployers(Status status)
        {
            return dc.tblEmployers.Where(x => x.StatusID == (int)status).ToList();
        }

        public tblEmployer GetEmployer(int employerID)
        {
            return dc.tblEmployers.FirstOrDefault(x => x.EmployerID == employerID);
        }

        #endregion *** Employers ***

        #region *** Jobs ***

        public List<tblJob> GetJobs(int employerID)
        {
            return dc.tblJobs.Where(x => x.EmployerID == employerID).ToList();
        }

        public List<tblJobLanguage> GetJobLanguages(int jobID)
        {
            return dc.tblJobLanguages.Where(x => x.JobID == jobID).ToList();
        }

        public List<tblJobJobExperienceType> GetJobJobExperienceTypes(int jobID)
        {
            return dc.tblJobJobExperienceTypes.Where(x => x.JobID == jobID).ToList();
        }

        public List<tblJobPatientPopulationType> GetJobPatientPopulationTypes(int jobID)
        {
            return dc.tblJobPatientPopulationTypes.Where(x => x.JobID == jobID).ToList();
        }

        #endregion *** Jobs ***                

        #region *** Addresses ***

        public tblAddress GetAddress(UserType userType, int addressID)
        {
            return dc.tblAddresses.FirstOrDefault(x => x.AddressID == addressID);
        }

       

        #endregion *** Addresses ***

        #region *** General Fields ***
        public List<tblEmployerClinicianStatus> GetStatuses()
        {
            return dc.tblEmployerClinicianStatus.OrderBy(x=>x.Order).ToList();
        }

        public List<tblAvailability> GetAvailabilities()
        {
            return dc.tblAvailabilities.OrderBy(x => x.Order).ToList();
        }

        public List<tblClinicianType> GetClinicianTypes()
        {
            return dc.tblClinicianTypes.OrderBy(x => x.Order).ToList();
        }

        public List<tblLanguage> GetLanguages()
        {
            return dc.tblLanguages.OrderBy(x => x.Order).ToList();
        }

        public List<tblEmrErxExperienceType> GetEmrErxExperienceTypes()
        {
            return dc.tblEmrErxExperienceTypes.ToList();
        }

        public List<tblJobExperienceType> GetJobExperienceTypes()
        {
            return dc.tblJobExperienceTypes.OrderBy(x=>x.Order).ToList();
        }
        
        public List<tblPositionType> GetPositionTypes()
        {
            return dc.tblPositionTypes.OrderBy(x => x.Order).ToList();
        }

        public List<tblServiceType> GetServiceTypes()
        {
            return dc.tblServiceTypes.OrderBy(x => x.Order).ToList();
        }

        public List<tblYearsExperience> GetTblYearsExperiences()
        {
            return dc.tblYearsExperiences.OrderBy(x => x.Order).ToList();
        }

        public List<tblPatientPopulationType> GetPatientPopulationTypes()
        {
            return dc.tblPatientPopulationTypes.OrderBy(x => x.Order).ToList();
        }

        public string GenerateUserID(int recordID, UserType type)
        {
            string cUID = string.Empty;

            if (type == UserType.Clinician)
            {
                cUID = string.Format("{0}-{1}", "PM", recordID.ToString().PadLeft(6,'0'));
            }
            else if(type == UserType.Employer)
            {
                cUID = string.Format("{0}-{1}", "ABM", recordID.ToString().PadLeft(6, '0'));
            }
            return cUID;
        }

        ///// <summary>
        ///// Returns a list of PopulationTypes for a given job
        ///// </summary>
        ///// <param name="jobID"></param>
        ///// <returns></returns>
        //public List<tblJobPatientPopulationType> GetJobPatientPopulationTypes(int jobID)
        //{
        //    return dc.tblJobPatientPopulationTypes.Where(x => x.JobID == jobID).ToList();
        //}

        ///// <summary>
        ///// Returns a list of Job Exp types for a given job
        ///// </summary>
        ///// <param name="jobID"></param>
        ///// <returns></returns>
        //public List<tblJobJobExperienceType> GetJobJobExperienceTypes(int jobID)
        //{
        //    return dc.tblJobJobExperienceTypes.Where(x => x.JobID == jobID).ToList();
        //}

        #endregion *** General Fields *** 

        #region *** Inserts ***

        /// <summary>
        /// Updates / Inserts new Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public int UpsertAddress(tblAddress address)
        {
            if (address.AddressID == 0) //new record
            {
                try
                {
                    dc.tblAddresses.InsertOnSubmit(address);
                    dc.SubmitChanges();
                    return address.AddressID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    var record = dc.tblAddresses.FirstOrDefault(x => x.AddressID == address.AddressID);
                    record = address;
                    dc.SubmitChanges();
                    return address.AddressID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Updates / Inserts new Clinincian
        /// </summary>
        /// <param name="clinician"></param>
        /// <returns></returns>
        public int UpsertClinician(tblClinician clinician)
        {
            if(clinician.ClinicianID == 0) //new record
            {
                try
                {
                    dc.tblClinicians.InsertOnSubmit(clinician);
                    dc.SubmitChanges();

                    var Id = clinician.ClinicianID;
                    clinician.UserID = GenerateUserID(Id, UserType.Clinician);

                    UpsertClinician(clinician);  //2nd call updates the UserID
                    return Id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }
            else
            {
                try
                {
                    var record = dc.tblClinicians.FirstOrDefault(x => x.ClinicianID == clinician.ClinicianID);
                    record = clinician;
                    dc.SubmitChanges();
                    return record.ClinicianID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }               

        /// <summary>
        /// Inserts list of languages spoken by a clinician
        /// </summary>
        /// <param name="clinicianLanguages"></param>
        /// <returns></returns>
        public int InsertClinicianLanguages(List<tblClinicianLanguage> clinicianLanguages)
        {
            try
            {
                dc.tblClinicianLanguages.InsertAllOnSubmit(clinicianLanguages);
                dc.SubmitChanges();

                var id = clinicianLanguages.LastOrDefault().ID;
                return id;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        /// <summary>
        /// Updates / Inserts new Employer
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        public int UpsertEmployer(tblEmployer employer)
        {
            if(employer.EmployerID == 0) //new record
            {
                try
                {
                    dc.tblEmployers.InsertOnSubmit(employer);
                    dc.SubmitChanges();

                    var Id = employer.EmployerID;
                    employer.UserID = GenerateUserID(Id, UserType.Employer);

                    UpsertEmployer(employer); //2nd call updates the UserID
                    return Id;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else //update
            {
                try
                {
                    var record = dc.tblEmployers.FirstOrDefault(x => x.EmployerID == employer.EmployerID);
                    record = employer;
                    dc.SubmitChanges();
                    return record.EmployerID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Updates / Inserts new Job
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public int UpsertJob(tblJob job)
        {
            if (job.JobID == 0) //new record
            {
                try
                {
                    dc.tblJobs.InsertOnSubmit(job);
                    dc.SubmitChanges();

                    return job.JobID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else // update
            {
                try
                {
                    var record = dc.tblJobs.FirstOrDefault(x => x.JobID == job.JobID);
                    record = job;
                    dc.SubmitChanges();

                    return record.JobID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Insert matches a Job to a Clinician
        /// </summary>
        /// <param name="jobClinicianMatch"></param>
        /// <returns></returns>
        public int InsertJobClinicianMatch(tblJobClinicianMatch jobClinicianMatch)
        {
            try
            {
                dc.tblJobClinicianMatches.InsertOnSubmit(jobClinicianMatch);
                dc.SubmitChanges();

                var id = jobClinicianMatch.JobClinicianMatchID;
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion *** Inserts ***

        #region *** Deletes *** 

        public bool DeleteClinicianLanguage(int id)
        {
            try
            {
                var record = dc.tblClinicianLanguages.FirstOrDefault(x => x.ID == id);

                if (record != null)
                {
                    dc.tblClinicianLanguages.DeleteOnSubmit(record);
                    dc.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteClinicianLanguage(List<int> ids)
        {
            try
            {
                var records = dc.tblClinicianLanguages.Where(x=>ids.Contains(x.ID));

                if (records != null)
                {
                    dc.tblClinicianLanguages.DeleteAllOnSubmit(records);
                    dc.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteJobClinicianMatch(int id)
        {
            try
            {
                var record = dc.tblJobClinicianMatches.FirstOrDefault(x => x.JobClinicianMatchID == id);

                if (record != null)
                {
                    dc.tblJobClinicianMatches.DeleteOnSubmit(record);
                    dc.SubmitChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region *** ZipCode API Calls ***

        /// <summary>
        /// Will return a list of zipcodes based on the provided zipcode & radius
        /// </summary>
        /// <param name="zipCode"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public ZipCodesByRadius_Min GetZipCodesWithinRadius(int zipCode, int radius)
        {
            //"{\"zip_codes\":[\"30331\",\"31136\",\"30311\",\"30336\"]}"
            var endPoint = string.Format("radius.json/{0}/{1}/mile/?minimal", zipCode, radius);
            var json = PostMethod(endPoint);
            ZipCodesByRadius_Min result = JsonConvert.DeserializeObject<ZipCodesByRadius_Min>(json);
            
            return result;
        }

        /// <summary>
        /// Will return the city, state zip & distance for the Zipcodes within the radius
        /// </summary>
        /// <param name="zipCode"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public ZipCodesByRadius_All GetZipCodesWithRadius_All(int zipCode, int radius)
        {
            var endPoint = string.Format("radius.json/{0}/{1}/mile/", zipCode, radius);
            var json = PostMethod(endPoint);
            ZipCodesByRadius_All result = JsonConvert.DeserializeObject<ZipCodesByRadius_All>(json);

            return result;
        }

        /// <summary>
        /// This can be used to either populate the City & State based on the ZipCode or to validate the City & State
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public LocationInfo GetLocationInfo(int zipCode)
        {
            var endPoint = string.Format("info.json/{0}/degrees/", zipCode);
            var json = PostMethod(endPoint);
            LocationInfo result = JsonConvert.DeserializeObject<LocationInfo>(json);

            return result;
        }

        private string PostMethod ( string endPoint)
        {
            var url = Api + endPoint;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            string result;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, Encoding.UTF8);
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        #endregion *** ZipCode API Calls ***

        #region *** UserManagement ***

        private Guid CreateNewGuid()
        {
            Guid value = Guid.NewGuid();
            return value;
        }
        #endregion *** UserManagement ***


    }
}
