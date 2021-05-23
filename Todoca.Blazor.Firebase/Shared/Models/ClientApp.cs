using System;

namespace Todoca.Blazor.Firebase.Shared.Models
{
    public class ClientApp
    {
        public Guid AppId { get; set; }
        public App App { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public bool IsPrimaryApp { get; set; }
        public string Notes { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
