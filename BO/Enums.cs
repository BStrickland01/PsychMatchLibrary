using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.BO
{
    public class Enums
    {
        public enum UserType
            {
                Employer,
                Clinician
            }

        public enum Status
        {
            InActive = 1,
            Pending,
            Verified,
            Interviewed,
            ContractSigned,
            DocumentsRecieved,
            EnQueue,
            JobMatched,
            Closed,
        }

        public enum PositionType
        {
            [Description("Psychiatric Supervisor")]
            PsychiatricSupervisor = 1,
            [Description("Medical Director")]
            MedicalDirector,
            [Description("Psychiatric prescriber / Clinician")]
            PsychiatricPrescriberClinician,
            [Description("Psychiatric unit / Clinic nurse")]
            PsychiatricUnitClinicNurse
        }

        public enum ClinicianType
        {
            Psychiatrist,
            MedicalPsychologist,
            NursePractitioner,
            PsychiatricNurse,
            PhysicianAssistant,
            RegisteredNurse,
            Addictionologist
        }

        public enum EmployerClinicianStatus
        {
            InActive,
            Pending,
            Verified,
            Interviewed,
            ContractSigned,
            DocumentsRecieved,
            EnQueue,
            JobMatched,
            Closed,
            Active
        }

        public enum EmployerTypes
        {
            Hospital,
            Clinic
        }

        public enum AdminUsers
        {
            BStrickland,
            DRoberson,
            KJordan,
            RBrown,
        }

        public enum Languages
        {
            English =1,
            Spanish,
            French,
            Russian,
            Japanese,
            Chinese,
            Hindi,
            Arabic,
            Bengali,
            Portuguese
        }

        public enum DocumentType
        {
            DriversLicense = 1
        }

        public enum Availability
        {
            WeekdaysAM = 1,
            WeekdaysPM,
            WeekendsAM,
            WeekendsPM
        }

        public enum YearsExperience
        {
            [Description("0-1")]
            ZeroToOneYears,
            [Description("1-2")]
            OneToTwoYears,
            [Description("2-3")]
            TwoToThreeYears,
            [Description("3-4")]
            ThreeToFourYears,
            [Description("4-5")]
            FourToFiveYears,
            [Description("5-6")]
            FiveToSixYears,
            [Description("6-7")]
            SixToSevenYears,
            [Description("7-8")]
            SevenToEightYears,
            [Description("8-9")]
            EightToNineYears,
            [Description("9-10")]
            NineToTenYears,
            [Description("10+")]
            TenPlusYears
        }

        public enum ServiceType
        {
            Onsite = 1,
            Telemed,
            All
        }

        public enum EmrErxExperienceType
        {
            emr,
            erx,
            Both
        }
    }
}
