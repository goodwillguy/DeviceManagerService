using System;

namespace Common.DataModel
{
    public class Base
    {

        public Guid CreateUserId { get; set; }

        public Guid UpdateUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

    }
}