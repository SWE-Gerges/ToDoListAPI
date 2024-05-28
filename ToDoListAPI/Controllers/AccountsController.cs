using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoListAPI.Core.DTO;
using ToDoListAPI.Core.Interfaces;
using ToDoListAPI.Core.Models;
using ToDoListAPI.Infrastructure.JWT;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtOptions;

        public AccountsController(IUnitOfWork unitOfWork, IMapper mapper, JwtOptions jwtOptions)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtOptions = jwtOptions;
        }


        [HttpPost(Name = "Register")]
        public IActionResult Register(UserDTO userDTO)
        {
           var user = _mapper.Map<User>(userDTO);
            _unitOfWork.Users.Create(user);
            _unitOfWork.Save();

            return new ObjectResult(user) { StatusCode = 201 };

        }

        [HttpPost]
        [Route("auth")]
        public ActionResult<string> Login(AuthenticationRequest request)
        {
            var user = _unitOfWork.Users.Find(u => u.UserName == request.UserName &&
            u.Password == request.Password);

            if(user == null) 
                return Unauthorized();



            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Signingkey)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new (ClaimTypes.Name, user.Name)
                })

            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var accessToken = tokenHandler.WriteToken(securityToken);

            return Ok(accessToken);
        }
    }
}
