using ProducerService.DAL.Models;

namespace ProducerService.DAL;

public interface IUserDAL
{
    Task AddUserAsync(UserModel user);
    Task<List<UserModel>> GetUserModelsAsync();
}