using AppData.Interface;
using AppData.Models;
using AppData.Serviece;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IUser _user;
        public UserController()
        {
            _user= new UserServices();
        }
        // GET: UserController
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Userr>> Index()
        {
          return await _user.GetAll();
        }

        // GET: UserController/Details/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
           Userr user = await _user.GetById(id);
            return Ok(user);
        }

        // GET: UserController/Create
        [HttpPost("Post")]
        public async Task<IActionResult> Create(Userr user)
        {
            if (user!=null)
            {
                await _user.Add(user);
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(Userr user)
        {
                
          

            if (!await _user.Update(user))
            {
                return BadRequest();
            }
            return Ok();

            //return await _chucVuService.Update(chucVu);

        }

        // GET: UserController/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
         
           await _user.Delete(id);
            return Ok();
        }
       
    }
}
