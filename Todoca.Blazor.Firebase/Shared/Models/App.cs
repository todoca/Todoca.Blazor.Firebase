using System;
using System.Collections.Generic;

namespace Todoca.Blazor.Firebase.Shared.Models
{
    public class App
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string LogoHeader { get; set; }
        public string LogoHeaderBlob { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }

        public IEnumerable<ClientApp> ClientApps { get; set; }
    }
}
