using Tz.Common.DataModel;
using Tz.Common.Values.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Tz.Parcel.DataModel.ParcelEnitities
{
    [ReadonlyTable]
    [Table("Locker")]
    public class LockerView
    {
        [Key]
        public Guid LockerId { get; set; }

        public LockerState LockerState { get; set; }

        public string Number { get; set; }
    }
}
