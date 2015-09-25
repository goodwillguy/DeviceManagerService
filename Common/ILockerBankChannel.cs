﻿namespace LockerBank.Common.Interface
{
    public interface ILockerBankChannelFactory
    {
        T CreateChannel<T>(string ipAddress);
    }
}