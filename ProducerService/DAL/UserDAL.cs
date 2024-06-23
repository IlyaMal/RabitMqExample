using Microsoft.EntityFrameworkCore;
using ProducerService.DAL.Models;

namespace ProducerService.DAL;

public class UserDAL: IUserDAL
{
    public async Task AddUserAsync(UserModel user)
    {
        using (var connection = new DbHelper())
        {
            await connection.Users.AddAsync(user);
            await connection.SaveChangesAsync();
        }
    }

    public async Task<List<UserModel>> GetUserModelsAsync()
    {
        using (var connection = new DbHelper())
        {
            return await connection.Users.ToListAsync();
        }
    }
}