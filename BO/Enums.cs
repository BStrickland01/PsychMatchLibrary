using System;
using System.Collections.Generic;
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

        public enum ClinicianType
        {
            Psychiatrist,
            MedicalPsychologist,
            NursePractitioner,
            PsychiatricNurse,
            PhysicianAssistant,
            RegisteredNurse,
            Additionologist
        }
    }
}
