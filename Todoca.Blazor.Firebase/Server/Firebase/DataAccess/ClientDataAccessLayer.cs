using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace Todoca.Blazor.Firebase.Server.Firebase.DataAccess
{
    public class ClientDataAccessLayer
    {
        string projectId;
        FirestoreDb firestoreDb;
        public ClientDataAccessLayer()
        {
            string filePath = @"..\Server\FireBase\todocadb.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filePath);
            projectId = "todocadb";
            firestoreDb = FirestoreDb.Create(projectId);
        }
        public async Task<List<Shared.Models.Client>> GetAllClients()
        {
            try
            {
                Query clientQuery = firestoreDb.Collection("Clients");
                QuerySnapshot clientQuerySnapshot = await clientQuery.GetSnapshotAsync();
                List<Shared.Models.Client> listClients = new List<Shared.Models.Client>();
                foreach (DocumentSnapshot documentSnapshot in clientQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {

                        Dictionary<string, object> client = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(client);
                        Shared.Models.Client newClient =
                            JsonConvert.DeserializeObject<Shared.Models.Client>(json);
                        newClient.Id = documentSnapshot.Id;
                        newClient.Date = documentSnapshot.CreateTime.Value.ToDateTimeOffset();
                        listClients.Add(newClient);
                    }
                }
                List<Shared.Models.Client> storedClientList =
                    listClients.OrderBy(x => x.Date).ToList();
                return storedClientList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void AddClient(Shared.Models.Client client)
        {
            try
            {
                await firestoreDb
                    .Collection("Clients")
                    .Document(client.Id)
                    .SetAsync(client);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void UpdateClient(Shared.Models.Client client)
        {
            try
            {
                DocumentReference updateclient = 
                    firestoreDb.Collection("Clients").Document(client.Id);
                await updateclient.SetAsync(client, SetOptions.Overwrite);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Shared.Models.Client> GetClientData(string id)
        {
            try
            {
                DocumentReference docRef = firestoreDb.Collection("Clients").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    Dictionary<string, object> client = snapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(client);
                    Shared.Models.Client clientById = 
                        JsonConvert.DeserializeObject<Shared.Models.Client>(json);
                    clientById.Id = snapshot.Id;
                    clientById.Date = snapshot.CreateTime.Value.ToDateTimeOffset();
                    return clientById;
                }
                else
                    return new Shared.Models.Client();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void DeleteClient(string id)
        {
            try
            {
                DocumentReference cliRef = firestoreDb.Collection("Clients").Document(id);
                await cliRef.DeleteAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
