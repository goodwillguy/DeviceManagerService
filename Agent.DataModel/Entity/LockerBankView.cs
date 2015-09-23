using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataModel
{
    public class LockerBankView:IReadonlyEntity
    {

        public Guid LockerBankId { get; set; }

        public Guid PropertyId { get; set; }

        public string LockerBankCode { get; set; }


    }
}
