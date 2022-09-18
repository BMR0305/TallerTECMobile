﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MobileTallerTEC.Models
{
    public class Client
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string User { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public List<ClientAddress> Address { get; set; }
        
        public List<ClientPhones> Phone { get; set; }

    }

    public class ClientAddress
    {
        public string ClientId { get; set; }
        public string Nstreet { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Canton { get; set; }

    }

    public class ClientPhones
    {
        public string ClientId { get; set; }

        public string Phone { get; set; }
    }
}
