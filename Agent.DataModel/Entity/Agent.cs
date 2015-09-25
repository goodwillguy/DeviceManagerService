﻿using Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataModel
{
    public class Agent : Base, IAuditable
    {
        [Key]
        public Guid AgentId { get; set; }

        public string SignInPin { get; set; }

        public string CardId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public Guid OrganisationId { get; set; }


    }
}