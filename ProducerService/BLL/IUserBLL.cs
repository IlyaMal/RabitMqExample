using ProducerService.DAL.Models;

namespace ProducerService.BLL;

public interface IUserBLL
{
    Task AddUserAsync(UserModel model);
    Task<List<UserModel>> GetUsersAsync();
    void NotificateUsers(List<UserModel> users);
}