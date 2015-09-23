using Common.DataModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tz.Parcel.DataModel.ParcelEnitities
{
    public class LockerView:IReadonlyEntity
    {
        [Key]
        public Guid LockerId { get; set; }

        public int LockerState { get; set; }

        public string Number { get; set; }
    }
}
