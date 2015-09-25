using System;

namespace Resident.Common.Dto
{
    public class ResidentDto
    {
        public Guid ResidentId { get; set; }

        public string SignInPin { get; set; }

        public string CardId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public Guid PropertyId { get; set; }

        public bool IsResidentDisabled { get; set; }


    }
}