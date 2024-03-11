using AutoMapper;
using Azure;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using User_App.Token;
using User_App.UserService.UserService;
using User_Domain;
using User_Infrastructure.User_Map;
using User_Infrastructure.User_Validation;

namespace WebApplication1.Controllers
{
    [ApiController]
   // [Route("")]
    public class UserControler : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Validation_User _Validation_User;
        private readonly IMapper _mapper;
        private readonly ITokenServie _tokenServie;

        public UserControler(IUserService userService, Validation_User validation_User, IMapper mapper, ITokenServie tokenServie)
        {
            _userService = userService;
            _Validation_User = validation_User;
            _mapper = mapper;
           _tokenServie = tokenServie;
        }
        [HttpGet]
        [Route("GetTokenByName")]
        public async Task<string> GetTokenByName(string name)
        {
            var users = await _tokenServie.GetTokenByname(name);

            return users;
        }
        [HttpGet, Authorize]
        [Route("AllUser-Token")]
        public async Task<IActionResult> GetAllUsers()
        {
           

            var users = await _userService.GetAllUsersasync();
           // var data = _mapper.Map<IEnumerable<User>>(users);
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUSerById")]
        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
        //----------------------------------------------
        [HttpGet]
        [Route("GetUserName")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await _userService.GetUserByName(name);
            return Ok(user);
        }

     

        //----------------------------------------------------
        [HttpDelete("deleteUser/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> AddUser(UserDto modelModel)
        {
           

            var message = _Validation_User.Validate(modelModel);
            var response = new ResponseModel();
            if (!message.IsValid)
            {
                  response.IsValid = false;
                foreach (var Errorsmessage in message.Errors)
                {
                    response.ValidationMessage.Add(Errorsmessage.ErrorMessage);
                }

                return BadRequest(response);
            }
            else
            {
                    var data = _mapper.Map<User>(modelModel);
                    await _userService.AddUser(data);
                    return Ok(data);
                              
            }

        }

        [HttpPut]
        [Route("Edit User/{id:int}")]
        public async Task<ActionResult> UpdateUser(User model, int id)
        {
            await _userService.UpdateUser(model, id);
            return Ok();
        }

     
    }

}