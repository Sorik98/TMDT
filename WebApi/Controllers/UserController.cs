using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Infrastructure.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Const;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        
        [HttpGet]
        [Authorize(Roles = RoleConst.Admin)]
        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }
        
        
        [HttpGet]
        [Authorize(Roles = RoleConst.Admin)]
        public async Task<ApplicationUser> GetById(string id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        [HttpGet]
        public async Task<ApplicationUser> GetByCurrent()
        {
            return await _userManager.GetUserAsync(User);
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> Create(LoginUser user)
        {
            var user1 = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if(user1 != null) {
                return BadRequest();
            }

            if(string.IsNullOrEmpty(user.Role)) {
                user.Role = "Member";
            }

            var a_user = new ApplicationUser 
                        { 
                          UserName = user.Email,
                          Name = user.Name,
                          PhoneNumber = user.PhoneNumber,
                          Email = user.Email,
                          Address = user.Address,
                          Role = user.Role,
                          Status = "Ok",
                        };
            await _userManager.CreateAsync(a_user, user.Password);

            await CreateClaim(a_user);

            return CreatedAtAction(nameof(GetById), new {id = a_user.Id}, a_user);
        }

        [HttpPut]
        [Authorize(Roles = RoleConst.Admin + "," + RoleConst.Customer)]
        public async Task<ActionResult<ApplicationUser>> Edit(string Id, LoginUser user_u)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if(user == null)
            {
                return NotFound();
            }

            if(string.IsNullOrEmpty(user_u.Role)) {
                user_u.Role = "Member";
            }

            if(string.IsNullOrEmpty(user_u.Status)) {
                user_u.Status = "Ok";
            }

            user.PhoneNumber = user_u.PhoneNumber;
            user.Address = user_u.Address;
            user.Role = user_u.Role;
            user.Name = user_u.Name;
            user.Status = user_u.Status;

            if(!string.IsNullOrEmpty(user_u.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, user_u.Password);
            }
            else {
                user.PasswordHash = user.PasswordHash;
            }

            var result = await _userManager.UpdateAsync(user);

            if(!result.Succeeded) 
            {
                return BadRequest();
            }

            await DeleteClaim(user);

            await CreateClaim(user);

            return Ok();
            
        }

        [HttpDelete]
        public async Task<ActionResult<ApplicationUser>> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if(user == null)
            {
                return NotFound();
            }

            await DeleteClaim(user);

            var result = await _userManager.DeleteAsync(user);

            if(!result.Succeeded) 
            {
                return BadRequest();
            }

            return Ok();
        }

        private async Task CreateClaim(ApplicationUser user)
        {
            await _userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(JwtClaimTypes.Name, user.Name),
                        new Claim(JwtClaimTypes.Email, user.Email),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.Role, user.Role),
                        new Claim(JwtClaimTypes.Address, user.Address),
                        new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber)});
        }

        private async Task DeleteClaim(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            await _userManager.RemoveClaimsAsync(user, claims);
        }

    }
}