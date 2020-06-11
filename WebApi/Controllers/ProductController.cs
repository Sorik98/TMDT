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
                foreach(ImageUrl url in product.ImageUrls)
                {
                    dto.ImageUrls.Add(url.ToDto());
                }
                products_result.Add(dto);
            }
            return products_result;
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAllAdmin(string type)
        {
            var products = await _productRepo.GetAll(type);
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

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> Create (ProductDTO productDTO)
        {
           // var user = User.;
           try{
            var product = productDTO.ToProduct();
            product.SetAuditForCreate(productDTO);
            await _productRepo.Create(product);
            return Ok();
           }
           catch(Exception e){
               Console.WriteLine(e.ToString());
               return BadRequest();
           }
        }
        
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> Update (ProductDTO productDTO)
        {
           if(productDTO.Id == null)return BadRequest();
           try{
                var product = productDTO.ToProduct();
                await _productRepo.Update(product);

                return Ok();
           }
           catch(Exception e){
                Console.WriteLine(e.ToString());
                return BadRequest();
           }
        }
        // [HttpPut]
        // public async Task<IActionResult> Update(int id, ProductDTO paymentDTO)
        // {
        //     if (id != paymentDTO.PaymentId)
        //     {
        //         return BadRequest();
        //     }

        //     var product = await _productRepo.GetBy(id);

        //     if (product == null)
        //     {
        //         return NotFound();
        //     }

        //     paymentDTO.MapTo(product);

        //     // try
        //     // {
        //     //     await _productRepo.Add(product);
        //     // }
        //     // catch (DbUpdateConcurrencyException) when (!_productRepo.MovieExists(id))
        //     // {
        //     //     return NotFound();
        //     // }

        //     return NoContent();
        // }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            // var product = await _productRepo.GetBy(id);

            // if (product == null)
            // {
            //     return NotFound();
            // }

            await _productRepo.Delete(id);

            return NoContent();
        }
    }
}
