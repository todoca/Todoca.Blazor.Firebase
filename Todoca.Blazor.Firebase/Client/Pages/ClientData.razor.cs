using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Todoca.Blazor.Firebase.Client.Pages
{
    public partial class ClientData : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        protected List<Firebase.Shared.Models.Client> cliList { get; set; }
        protected Firebase.Shared.Models.Client cli { get; set; }

        protected string SearchString { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetClientList();
        }

        protected async Task GetClientList()
        {
            cliList = await Http.GetFromJsonAsync<List<Firebase.Shared.Models.Client>>("api/Clients");
        }
        protected async Task SearchClient()
        {
            await GetClientList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                cliList = cliList
                    .Where(x => x.FirstName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
        }
    }
}
