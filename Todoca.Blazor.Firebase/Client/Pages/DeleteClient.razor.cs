using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Todoca.Blazor.Firebase.Client.Pages
{
    public partial class DeleteClient : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        public NavigationManager urlNavigationManager { get; set; }
        [Parameter]
        public string cliID { get; set; }
        protected string Title = "Delete";
        public Firebase.Shared.Models.Client cli = new Firebase.Shared.Models.Client();

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(cliID))
            {
                Title = "Delete";
                cli = await Http.GetFromJsonAsync<Firebase.Shared.Models.Client>("api/clients/" + cliID);
            }

        }
        protected async Task DeleteClients()
        {
            await Http.DeleteAsync("api/clients/" + cliID);
            Cancel();
        }

        public void Cancel()
        {
            urlNavigationManager.NavigateTo("/clientrecords");

        }
    }
}
