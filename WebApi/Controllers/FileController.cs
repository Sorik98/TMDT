using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebApi.Infrastructure.Interfaces;
using WebApi.Infrastructure.DTOs;
using WebApi.Infrastructure.Models;
using WebApi.Infrastructure.Mapping;
using System.Security.Claims;
using WebApi.Const;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin,Manager")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            this._env = env;
        }

        [HttpPost]
        public async Task<IDictionary<string,object>> OnUploadImage()
        {
            try {
            object result;
            var src = Request.Form.Files;
            var uploads = Path.Combine(_env.WebRootPath, "Image");
            foreach(var file in src){
                if(System.IO.File.Exists(Path.Combine(uploads, file.FileName))) {
                    
                    return Const.Response.ControlerResponse(Const.StatusCode.BadRequest,$"File {file.FileName} already existed");
                }
                var postedFileExtension = Path.GetExtension(file.FileName);
                if (!string.Equals(postedFileExtension , ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return Const.Response.ControlerResponse(Const.StatusCode.BadRequest,$"File {file.FileName} is not image");
                }

            }
            foreach(var file in src){
                    if (file.Length > 0)
                    { 
                        var extension = Path.GetExtension(file.FileName);
                        
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
            }
             result = new {type="Success",message ="Action complete successfully"};
             return Const.Response.ControlerResponse(Const.StatusCode.OK,$"Action complete successfully");
            }
            catch(Exception e) { 
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
            }
        }
    }
}