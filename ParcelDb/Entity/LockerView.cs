using Common.DataModel;
using Common.Values.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tz.Tz.Parcel.DataModel.ParcelEnitities
{
    [ReadonlyTable]
    public class LockerView
    {
        [Key]
        public Guid LockerId { get; set; }

        public LockerState LockerState { get; set; }

        public string Number { get; set; }
    }
}
