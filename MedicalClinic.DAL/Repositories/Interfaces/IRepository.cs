namespace EfWebTutorial.Interfaces
{

    public interface IRepository<T>
    {
        Task<List<T>> GetAllItemsAsync();
        Task<T> GetItemAsync(int id); 
        Task<T> CreateAsync(T item);
        Task DeleteAsync(int id); 
        Task <T> EditAsync(T item);
    }
}
