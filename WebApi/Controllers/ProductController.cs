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
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(
                                IProductRepository productRepo
                                )
        {
            _productRepo = productRepo;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetLatestProducts(int num)
        {
            var products = await _productRepo.GetLatestProducts(num);
            if (products == null)
            {
                return null;
            }
            products = products.Where(p => p.AuthStatus == AuthStatus.Approved);
            List<ProductDTO> products_result = new List<ProductDTO>();
            foreach(Product product in products)
            {
                var dto = product.ToDTO();
                products_result.Add(dto);
            }
            return products_result;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll(string type)
        {
            var products = await _productRepo.GetAll(type);
            if (products == null)
            {
                return null;
            }
            products = products.Where(p => p.AuthStatus == AuthStatus.Approved);
            List<ProductDTO> products_result = new List<ProductDTO>();
            foreach(Product product in products)
            {
                var dto = product.ToDTO();
                products_result.Add(dto);
            }
            return products_result;
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAllAdmin()
        {
            var products = await _productRepo.GetAll();
            if (products == null)
            {
                return null;
            }
            List<ProductDTO> products_result = new List<ProductDTO>();
            foreach(Product product in products)
            {
                var dto = product.ToDTO();
                dto.SetAuditForDTO(product);
                products_result.Add(dto);
            }
            return products_result;
        }

        

        [HttpGet]
        public async Task<ProductDTO> GetBy(int id)
        {
            var product = await _productRepo.GetBy(id);
            if (product == null || product.AuthStatus != AuthStatus.Approved)
            {
                return null;
            }
            return product.ToDTO();  
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<ProductDTO> GetByAdmin(int id)
        {
            var product = await _productRepo.GetBy(id);
            if (product == null)return null;
            var dto = product.ToDTO();
            dto.SetAuditForDTO(product);
            return dto;
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Create ([FromBody] ProductDTO productDTO)
        {
           // var user = User.;
           try{
            var product = productDTO.ToProduct();
            product.SetAuditForCreate(productDTO);
            await _productRepo.Create(product);
            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
               Console.WriteLine(e.ToString());
               return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
        
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Update (ProductDTO productDTO)
        {
           if(productDTO.Id == null)return Const.Response.ControlerResponse(Const.StatusCode.BadRequest);
           try{
                var product = productDTO.ToProduct();
                product.SetAuditForUpdate(productDTO);
                await _productRepo.Update(product);
                return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
       
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IDictionary<string,object>> Approve(bool isApprove, int id, string user)
        {
            try{
        
            await _productRepo.Approve(isApprove, id, user);

            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IDictionary<string,object>> Delete(int id)
        {
            try{
            

            await _productRepo.Delete(id);

            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
            }
        }

        
    }
}
