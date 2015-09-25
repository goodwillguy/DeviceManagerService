﻿using Locker.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locker.Common.Dto;
using Common.Modules.DataModel.Interface;
using Common.Values.Enums;

namespace Locker.DataModel.Repository
{
    public class LockerRepository : ILockerRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;

        public LockerRepository(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
        public List<LockerDto> GetAllLockers(Guid lockerBankId)
        {
            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            var lockersList = context.Lockers
                            .Where(locker => locker.LockerBankId == lockerBankId && locker.State != LockerState.Deleted)
                            .Select(locker => new LockerDto
                            {
                                LockerId = locker.LockerId,
                                LockerBankId = locker.LockerBankId,
                                LockerOfflineReasonId = locker.LockerOfflineReasonId,
                                Size = locker.Size,
                                State = locker.State
                            }).ToList();

            return lockersList;
        }

        public Guid? GetLockerBankByCode(string lockerBankCode)
        {
            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBankId = context.LockerBanks
                                    .Where(bank => bank.LockerBankCode.ToLower() == lockerBankCode.ToLower())
                                    .Select(bank => bank.LockerBankId)
                                    .FirstOrDefault();

            return lockerBankId;
        }

        public LockerDto GetLockerById(Guid lockerBankId, Guid lockerId)
        {
            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            var lockerData = context.Lockers
                            .Where(locker => locker.LockerBankId == lockerBankId && locker.LockerId == lockerId)
                            .Select(locker => new LockerDto
                            {
                                LockerId = locker.LockerId,
                                LockerBankId = locker.LockerBankId,
                                LockerOfflineReasonId = locker.LockerOfflineReasonId,
                                Size = locker.Size,
                                State = locker.State
                            }).FirstOrDefault();

            return lockerData;
        }

        public LockerDto GetLockerById(string lockerBankCode, Guid lockerId)
        {
            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            var lockerData = context.Lockers
                            .Where(locker => locker.LockerBanks.LockerBankCode.ToLower() == lockerBankCode.ToLower() && locker.LockerId == lockerId)
                            .Select(locker => new LockerDto
                            {
                                LockerId = locker.LockerId,
                                LockerBankId = locker.LockerBankId,
                                LockerOfflineReasonId = locker.LockerOfflineReasonId,
                                Size = locker.Size,
                                State = locker.State
                            }).FirstOrDefault();

            return lockerData;
        }
    }
}
