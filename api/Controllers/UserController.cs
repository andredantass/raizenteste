using Microsoft.AspNetCore.Mvc;
using RaizenUserRegister.Domain.Interface;
using RaizenUserRegister.Domain.Request;

namespace RaizenUserRegister.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IUserRegisterService service)
        {
            try
            {
                var user = await service.GetAll();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] IUserRegisterService service, string id)
        {
            try
            {
                var user = await service.GetUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IUserRegisterService service,
                                              [FromBody] UserRequest request)
        {
            try
            {
                return Ok(await service.AddUser(request));
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IUserRegisterService service,
                                              [FromBody] UserRequest request)
        {
            try
            {
                return Ok(await service.UpdateUser(request));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] IUserRegisterService service, string id)
        {
            try
            {
                var user = await service.RemoveUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
