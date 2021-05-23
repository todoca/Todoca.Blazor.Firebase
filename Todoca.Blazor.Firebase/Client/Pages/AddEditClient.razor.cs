using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Todoca.Blazor.Firebase.Client.Pages
{
    public partial class AddEditClient : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        public NavigationManager urlNavigationManager { get; set; }
        [Parameter]
        public string cliID { get; set; }
        [Parameter]
        public bool isVisible { get; set; }
        [Parameter]
        public string Title { get; set; } = "Add";

        public Firebase.Shared.Models.Client cli = new Firebase.Shared.Models.Client();


        protected override async Task OnParametersSetAsync()
        {
            if (!String.IsNullOrEmpty(cliID))
            {
                Title = "Edit";
                cli = await Http.GetFromJsonAsync<Firebase.Shared.Models.Client>("api/Clients/" + cliID);
                isVisible = true;
            }
            else
            {
                isVisible = false;
            }
        }
        protected async Task SaveClient()
        {

            if (cli.Id != null)
            {
                await Http.PutAsJsonAsync("api/Clients/", cli);
            }
            else
            {
                var id = Guid.NewGuid();
                cli.Id = id.ToString();
                await Http.PostAsJsonAsync("api/Clients/", cli);
            }
            Cancel();
        }

        async Task Cancel()
        {
            urlNavigationManager.NavigateTo("/clientrecords", true);
        }
    }
}
