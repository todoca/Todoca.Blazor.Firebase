using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todoca.Blazor.Firebase.Server.Firebase.DataAccess;

namespace Todoca.Blazor.Firebase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        ClientDataAccessLayer objClient = new ClientDataAccessLayer();

        [HttpGet]
        public Task<List<Shared.Models.Client>> GetClients()
        {
            return objClient.GetAllClients();
        }

        [HttpGet("{id}")]
        public Task<Shared.Models.Client> GetClient(string id)
        {
            return objClient.GetClientData(id);
        }

        [HttpPost]
        public void PostClient([FromBody] Shared.Models.Client client)
        {
            objClient.AddClient(client);
        }
        [HttpPut]
        public void PutClient([FromBody] Shared.Models.Client client)
        {
            objClient.UpdateClient(client);
        }

        [HttpDelete("{id}")]
        public void DeletClient(string id)
        {
            objClient.DeleteClient(id);
        }
    }
}
