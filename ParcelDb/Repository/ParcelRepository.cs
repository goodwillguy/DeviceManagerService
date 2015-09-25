using Parcel.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcel.Common.Dto;
using Common.Modules.DataModel.Interface;

namespace Tz.Parcel.DataModel.Repository
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly IConnectionStringFactory _connectionFactory;

        public ParcelRepository(IConnectionStringFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddNewParcel(ParcelDto newParcel)
        {
            ParcelDbContext context = new ParcelDbContext(_connectionFactory.GetConnectionString());
            var agentOrganisation = context.Agents.FirstOrDefault(agent => agent.AgentId == newParcel.SenderId);

            var parcel = new ParcelEnitities.Parcel
            {
                ConsignmentNumber = newParcel.ConsignmentNumber,
                CreateUserId = newParcel.CreateUserId,
                UpdateUserId=newParcel.UpdateUserId,
                LastUpdateTime=newParcel.LastUpdateTime,
                SenderId = newParcel.SenderId,
                CreationTime = DateTime.Now,
                ExpiryTime = newParcel.ExpiryTime,
                IsExpired = newParcel.IsExpired,
                LockerBankId = newParcel.LockerBankId,
                LockerId = newParcel.LockerId,
                OrganizationId = agentOrganisation.OrganisationId,
                ParcelId = newParcel.ParcelId,
                Size = newParcel.Size,
                RecipientId = newParcel.RecipientId
            };

            foreach(var transaction in newParcel.ParcelTransactions)
            {
                parcel.ParcelTransactions.Add(new ParcelEnitities.ParcelTransaction
                {
                    CreateUserId = transaction.CreateUserId,
                    CreationTime = transaction.CreationTime,
                    DropOffAgentId = transaction.DropOffAgentId,
                    DropoffTime = transaction.DropoffTime,
                    LastUpdateTime = transaction.LastUpdateTime,
                    LockerId = transaction.LockerId,
                    ParcelId = transaction.ParcelId,
                    ParcelTransactionId = transaction.ParcelTransactionId,
                    TransactionState = transaction.TransactionState,
                    UpdateUserId = transaction.UpdateUserId
                });
            }


            context.SaveChanges();
        }

        public ParcelDto GetParcelByConsignmentNumber(Guid lockerBankId, string consignmentNo)
        {
            ParcelDbContext context = new ParcelDbContext(_connectionFactory.GetConnectionString());

            var parcelData = context.Parcels
                            .Where(parcel => parcel.LockerBankId == lockerBankId && parcel.ConsignmentNumber.ToLower() == consignmentNo.ToLower())
                            .Select(parcelEnt => new ParcelDto
                            {
                                ConsignmentNumber = parcelEnt.ConsignmentNumber,
                                ExpiryTime = parcelEnt.ExpiryTime,
                                IsExpired = parcelEnt.IsExpired,
                                LockerBankId = parcelEnt.LockerBankId,
                                LockerId = parcelEnt.LockerId,
                                OrganizationId = parcelEnt.OrganizationId,
                                ParcelId = parcelEnt.ParcelId,
                                RecipientId = parcelEnt.RecipientId,
                                SenderId = parcelEnt.SenderId,
                                Size = parcelEnt.Size
                            }).FirstOrDefault();

            return parcelData;
        }

        public ParcelDto GetParcelById(Guid lockerBankId, Guid parcelId)
        {
            ParcelDbContext context = new ParcelDbContext(_connectionFactory.GetConnectionString());

            var parcelData = context.Parcels
                            .Where(parcel => parcel.ParcelId == parcelId && parcel.LockerBankId==lockerBankId)
                            .Select(parcelEnt => new ParcelDto
                            {
                                ConsignmentNumber = parcelEnt.ConsignmentNumber,
                                ExpiryTime = parcelEnt.ExpiryTime,
                                IsExpired = parcelEnt.IsExpired,
                                LockerBankId = parcelEnt.LockerBankId,
                                LockerId = parcelEnt.LockerId,
                                OrganizationId = parcelEnt.OrganizationId,
                                ParcelId = parcelEnt.ParcelId,
                                RecipientId = parcelEnt.RecipientId,
                                SenderId = parcelEnt.SenderId,
                                Size = parcelEnt.Size
                            }).FirstOrDefault();

            return parcelData;
        }
    }
}
