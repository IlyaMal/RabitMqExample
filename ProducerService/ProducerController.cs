using Microsoft.AspNetCore.Mvc;
using ProducerService.BLL;
using ProducerService.DAL.Models;

namespace ProducerService;
[ApiController]
public class ProducerController(IUserBLL userBll):ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] UserModel user)
    {
        await userBll.AddUserAsync(user); 
        return Ok();

    }
    [HttpGet("get")]
    public async Task<IActionResult> GetUsers()
    {
        var models = await userBll.GetUsersAsync(); 
        return Ok(models);

    }
    [HttpPost("send")]
    public async Task<IActionResult> NotificateUsers()
    {
        var models = await userBll.GetUsersAsync(); 
        userBll.NotificateUsers(models);
        return Ok();

    }
    
}