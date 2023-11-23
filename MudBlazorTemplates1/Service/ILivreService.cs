using ManagementBooks.Classes.Models;

namespace MudBlazorTemplates1.Service
{
    public interface ILivreService
    {
        Task AddLivreCat(Livre livre, List<int> catSelected);
    }
}
