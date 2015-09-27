using System;

namespace Tz.Resident.Common.Dto
{
    public class ResidentDto
    {
        public Guid ResidentId { get; set; }

        public string SignInPin { get; set; }

        public string ResidentCode { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public Guid BuildingPropertyId { get; set; }

        public bool IsResidentDisabled { get; set; }


    }
}