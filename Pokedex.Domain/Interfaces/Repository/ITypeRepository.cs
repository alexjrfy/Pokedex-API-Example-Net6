namespace Pokedex.Domain.Interfaces.Repository
{
    public interface ITypeRepository : IRepository<Model.Type>
    {
        Task<Model.Type?> GetTypeByNameAsync(string typeName);
    }
}
