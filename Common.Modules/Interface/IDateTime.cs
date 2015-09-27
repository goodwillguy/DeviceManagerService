using System;

namespace Common.Modules.Interface
{
    public class IDateTime
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}