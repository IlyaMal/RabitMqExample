using ProducerService.DAL;
using ProducerService.DAL.Models;
using ProducerService.Services;

namespace ProducerService.BLL;

public class UserBLL(IUserDAL userDal): IUserBLL
{
    public async Task AddUserAsync(UserModel model)
    {
        await userDal.AddUserAsync(model);
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        return await userDal.GetUserModelsAsync();
    }

    public void NotificateUsers(List<UserModel> users)
    {
        foreach (var user in users)
        {
            QueueProducer<UserModel>.SendMessage(user);
        }

        
    }
}