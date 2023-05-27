using DojoDaGalera.Classes;

namespace DojoDaGalera.Repositories
{
    public interface IDojoRepository
    {
        Task<Dojo> Add(Dojo dojo);

        Task<Dojo> Update(string id, Dojo dojo);

        Task<bool> Delete(string id);

        Task<Dojo> Get(string id);

        Task<IEnumerable<Dojo>> Get();
    }
}