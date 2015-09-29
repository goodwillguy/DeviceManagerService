using Tz.Resident.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Resident.Common.Dto;
using Common.Modules.DataModel.Interface;

namespace Tz.Resident.DataModel.Respository
{
    public class ResidentRespository : IResidentRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;

        public ResidentRespository(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
        public List<ResidentDto> GetResidentByName(Guid lockerBankId, string name)
        {
            ResidentDbContext context = new ResidentDbContext(_connectionStringFactory.GetConnectionString());


            var lockerBank = context.LockerBanks.Where(lb => lb.LockerBankId == lockerBankId).FirstOrDefault();


            var query = context.Residents
                        .Where(res => res.BuildingPropertyId == lockerBank.BuildingPropertyId);

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(res => res.FirstName.Contains(name) || res.LastName.Contains(name));
            }

            var a = query.ToList();
            var residents = query.Select(res => new ResidentDto
            {
                ResidentCode = res.ResidentCode,
                EmailAddress = res.EmailAddress,
                FirstName = res.FirstName,
                LastName=res.LastName,
                IsResidentDisabled = res.IsResidentDisabled,
                MobileNumber = res.MobileNumber,
                ResidentId = res.ResidentId
            }).ToList();


            return residents;
        }
    }
}
