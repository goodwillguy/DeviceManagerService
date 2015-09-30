using Tz.Locker.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Locker.Common.Dto;
using Common.Modules.DataModel.Interface;
using Tz.Common.Values.Enums;

namespace Tz.Locker.DataModel.Repository
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
                                State = locker.State,
                                Column=locker.Column,
                                LockerNumber=locker.LockerNumber
                            }).ToList();

            return lockersList;
        }

        public LockerAndDeviceDto GetDeviceSerialNumberForLocker(Guid lockerBankId, Guid lockerId)
        {
            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBank = context.LockerBanks
                                    .Where(bank => bank.LockerBankId == lockerBankId)
                                    .FirstOrDefault();

            var deviceAddress = context.LockerToDevices
                                        .Where(loc => loc.LockerId == lockerId)
                                        .Select(loc => loc.DeviceData.SerialNumber)
                                        .FirstOrDefault();


            var dto = new LockerAndDeviceDto
            {
                LockerBankId = lockerBank.LockerBankId,
                LockerBankCode = lockerBank.LockerBankCode,
                LockerBankIpAddress = lockerBank.IpAddress,
                DeviceSerialNumber = deviceAddress

            };

            return dto;
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

        public bool IsLockerAvailable(Guid lockerBankId, Guid lockerId)
        {

            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            return context.Lockers.Any(lo => lo.LockerId == lockerId && lo.LockerBankId == lockerBankId && lo.State == LockerState.Available);

        }

        public void UpdateLockerAsOccupied(Guid lockerBankId, Guid lockerId)
        {
            LockerDbContext context = new LockerDbContext(_connectionStringFactory.GetConnectionString());

            var locker=context.Lockers.FirstOrDefault(lo => lo.LockerId == lockerId && lo.LockerBankId == lockerBankId);

            if(locker==null)
            {
                throw new ApplicationException("Locker not present in system for update");
            }

            locker.State = LockerState.Occupied;

            context.SaveChanges();

        }
    }
}
