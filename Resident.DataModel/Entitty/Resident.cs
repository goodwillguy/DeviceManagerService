using Tz.Common.DataModel;
using Tz.Common.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Resident.DataModel
{
    public class Resident : Base
    {
        [Key]
        public Guid ResidentId { get; set; }

        public string SignInPin { get; set; }

        public string ResidentCode { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public bool IsResidentDisabled { get; set; }

        public Guid BuildingPropertyId { get; set; }

        [ForeignKey("BuildingPropertyId")]
        public virtual BuildingPropertyView Property { get; set; }

    }
}
