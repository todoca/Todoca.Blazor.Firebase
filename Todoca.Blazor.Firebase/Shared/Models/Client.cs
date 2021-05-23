using System;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace Todoca.Blazor.Firebase.Shared.Models
{
    [FirestoreData]
    public class Client
    {
        [FirestoreProperty]
        public string Id { get; set; }
        public int CntDevices { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        [FirestoreProperty]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Instagram { get; set; }
        public string Web { get; set; }
        public decimal Factor { get; set; }
        public string Logo { get; set; }
        public string LogoBlob { get; set; }
        public string LogoHeader { get; set; }
        public string LogoHeaderBlob { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }

        public IEnumerable<ClientApp> ClientApps { get; set; }
    }
}
