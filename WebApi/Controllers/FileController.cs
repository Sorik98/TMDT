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
        private readonly string imageFolderDir;
        public FileController(IWebHostEnvironment env)
        {
            this._env = env;
            imageFolderDir = Path.Combine(_env.WebRootPath, "Image");
        }

        [HttpPost]
        public async Task<IDictionary<string,object>> OnUploadImage()
        {
            try {

            var src = Request.Form.Files;
            foreach(var file in src){
                if(System.IO.File.Exists(Path.Combine(imageFolderDir, file.FileName))) {
                    
                    return Const.Response.ControlerResponse(Const.StatusCode.BadRequest,$"File {file.FileName} already exists");
                }
                var postedFileExtension = Path.GetExtension(file.FileName);
                if (!string.Equals(postedFileExtension , ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return Const.Response.ControlerResponse(Const.StatusCode.BadRequest,$"File {file.FileName} is not an image");
                }

            }
            foreach(var file in src){
                    if (file.Length > 0)
                    { 
                        var extension = Path.GetExtension(file.FileName);
                        
                        using (var fileStream = new FileStream(Path.Combine(imageFolderDir, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
            }

             return Const.Response.ControlerResponse(Const.StatusCode.OK,$"Action complete successfully");
            }
            catch(Exception e) { 
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
            }
        }

        [HttpDelete]
        [Authorize(Roles="Admin")]
        public  IDictionary<string,object> DeleteImages(string[] images){
        try{
            foreach(var image in images){ 
                if(!System.IO.File.Exists(Path.Combine(imageFolderDir, image))) {
                    
                    return Const.Response.ControlerResponse(Const.StatusCode.BadRequest,$"File {image} doesn't exist");
                }
                var postedFileExtension = Path.GetExtension(image);
                if (!string.Equals(postedFileExtension , ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension , ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return Const.Response.ControlerResponse(Const.StatusCode.BadRequest,$"File {image} is not an image");
                }

            }
            foreach(var image in images) System.IO.File.Delete(Path.Combine(imageFolderDir, image));

             return Const.Response.ControlerResponse(Const.StatusCode.OK,$"Action complete successfully");
            }
            catch(Exception e) { 
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
            }
        }
    }
}