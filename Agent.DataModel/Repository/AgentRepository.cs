using Agent.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agent.Common.Dto;
using Common.Modules.DataModel.Interface;
using Common;

namespace Agent.DataModel.Repository
{
    public class AgentRepository : IAgentRepository
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
        private readonly IDateTime _dateTime;

        public AgentRepository(IConnectionStringFactory connectionStringFactory, IDateTime dateTime)
        {
            _connectionStringFactory = connectionStringFactory;
            _dateTime = dateTime;
        }
        public AgentDto GetAgentByCardNo(Guid lockerBankId, string cardNumber)
        {
            AgentDbContext context = new AgentDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBank = context.LockerBank.FirstOrDefault(lb => lb.LockerBankId == lockerBankId);


            var agentDto = context.Agents
                   .Where(ag => ag.Properties.Any(prop => prop.PropertyId == lockerBank.PropertyId))
                   .Where(ag => ag.IsDisabled == false)
                   .Where(ag => ag.AgentCards.Any(agCard => agCard.AgentId == ag.AgentId &&
                                                  agCard.CardNumber.ToLower() == cardNumber.ToLower() && !agCard.IsLocked &&
                                                  agCard.EffectiveFrom > _dateTime.GetCurrentDate() &&
                                                  (agCard.EffectiveTo == null || !(_dateTime.GetCurrentDate() > agCard.EffectiveTo.Value))))
                   .Select(agent => new AgentDto
                   {
                       AgentId = agent.AgentId,
                       EmailAddress = agent.EmailAddress,
                       FirstName = agent.FirstName,
                       LastName = agent.LastName,
                       MobileNumber = agent.MobileNumber,
                       OrganisationId = agent.OrganisationId
                   }).FirstOrDefault();

            return agentDto;

        }

        public AgentDto GetAgentById(Guid lockerBankId, Guid agentId)
        {
            AgentDbContext context = new AgentDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBank = context.LockerBank.FirstOrDefault(lb => lb.LockerBankId == lockerBankId);


            var agentDto = context.Agents
                   .Where(ag => ag.Properties.Any(prop => prop.PropertyId == lockerBank.PropertyId))
                   .Where(ag => ag.IsDisabled == false && ag.AgentId == agentId)
                   .Select(agent => new AgentDto
                   {
                       AgentId = agent.AgentId,
                       EmailAddress = agent.EmailAddress,
                       FirstName = agent.FirstName,
                       LastName = agent.LastName,
                       MobileNumber = agent.MobileNumber,
                       OrganisationId = agent.OrganisationId
                   }).FirstOrDefault();

            return agentDto;
        }

        public AgentDto GetAgentByUserName(Guid lockerBankId, string agentUserName)
        {
            AgentDbContext context = new AgentDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBank = context.LockerBank.FirstOrDefault(lb => lb.LockerBankId == lockerBankId);


            var agentDto = context.Agents
                   .Where(ag => ag.Properties.Any(prop => prop.PropertyId == lockerBank.PropertyId))
                   .Where(ag => ag.IsDisabled == false && ag.Username.ToLower() == agentUserName.ToLower())
                   .Select(agent => new AgentDto
                   {
                       AgentId = agent.AgentId,
                       EmailAddress = agent.EmailAddress,
                       FirstName = agent.FirstName,
                       LastName = agent.LastName,
                       MobileNumber = agent.MobileNumber,
                       OrganisationId = agent.OrganisationId
                   }).FirstOrDefault();

            return agentDto;

        }

        public bool IsAgentAuthorised(Guid lockerBankId, string cardNumber)
        {
            AgentDbContext context = new AgentDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBank = context.LockerBank.FirstOrDefault(lb => lb.LockerBankId == lockerBankId);


            var isAgentAuthorised = context.Agents
                   .Any(ag => ag.Properties.Any(prop => prop.PropertyId == lockerBank.PropertyId) &&
                              ag.IsDisabled == false &&
                               ag.AgentCards.Any(agCard => agCard.AgentId == ag.AgentId &&
                                                  agCard.CardNumber.ToLower() == cardNumber.ToLower() && !agCard.IsLocked &&
                                                  agCard.EffectiveFrom > _dateTime.GetCurrentDate() &&
                                                  (agCard.EffectiveTo == null || !(_dateTime.GetCurrentDate() > agCard.EffectiveTo.Value))));

            return isAgentAuthorised;
        }

        public bool IsAgentAuthorised(Guid lockerBankId, string agentUserName, string agentPassword)
        {
            AgentDbContext context = new AgentDbContext(_connectionStringFactory.GetConnectionString());

            var lockerBank = context.LockerBank.FirstOrDefault(lb => lb.LockerBankId == lockerBankId);


            var isAgentAuthorised = context.Agents
                   .Any(ag => ag.Properties.Any(prop => prop.PropertyId == lockerBank.PropertyId) &&
                              ag.IsDisabled == false && ag.Username.ToLower() == agentUserName.ToLower() && ag.SignInPin == agentPassword);

            return isAgentAuthorised;
        }
    }
}
