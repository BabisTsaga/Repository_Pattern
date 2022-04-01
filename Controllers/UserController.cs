using Microsoft.AspNetCore.Mvc;
using PRWeb.Core.IConfiguration;
using PRWeb.Models;

namespace PRWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public UserController(ILogger<UserController> logger, IUnitOfWork unitofwork)
        {

            _logger = logger;
            _unitOfWork = unitofwork;

        }

        [HttpPost]

        public async Task<IActionResult> CreateUser(User user)
        {

            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();

                await _unitOfWork.Users.Add(user);
                await _unitOfWork.ComleteAsync();

                return CreatedAtAction("GetItem", new { user.Id }, user);

            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> GetItem(Guid id)
        {

            var user = await _unitOfWork.Users.GetById(id);


            if (user == null)
                return NotFound();

            return Ok(user);

        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Users.All();
            return Ok(users);
        }

        [HttpPatch("{id}")]

        public async Task<IActionResult> UpdateItem(Guid id, User user) { 
        
        if(id != user.Id)
                return BadRequest();

        await _unitOfWork.Users.Update(user);
            await _unitOfWork.ComleteAsync();

            return NoContent();
        
        }
        [HttpDelete("{id}")]


        public async Task <ActionResult> DeleteItem(Guid id) { 
        var item = await _unitOfWork.Users.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.ComleteAsync();


            return Ok(item);

        
        }

    }
}
