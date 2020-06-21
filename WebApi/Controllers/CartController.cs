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
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;
        public CartController(
                                ICartRepository cartRepo,
                                IProductRepository productRepo
                                )
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpGet]
        public async Task<IEnumerable<CartItemDTO>> GetUserCart(string id)
        {
            var cartItems = await _cartRepo.GetAll(id);
            if (cartItems == null)
            {
                return null;
            }
    
            List<CartItemDTO> cartItems_result = new List<CartItemDTO>();
            foreach(CartItem item in cartItems)
            {
                var dto = item.ToDTO();
                cartItems_result.Add(dto);
            }
            return cartItems_result;
        }

        // [Authorize(Roles = "Admin,Manager")]
        // [HttpGet]
        // public async Task<IEnumerable<CartItemDTO>> GetAllAdmin()
        // {
        //     var cartItems = await _cartRepo.GetAll();
        //     if (cartItems == null)
        //     {
        //         return null;
        //     }
        //     List<CartItemDTO> cartItems_result = new List<CartItemDTO>();
        //     foreach(Producer producer in cartItems)
        //     {
        //         var dto = producer.ToDTO();
        //         dto.SetAuditForDTO(producer);
        //         cartItems_result.Add(dto);
        //     }
        //     return cartItems_result;
        // }


        // [HttpGet]
        // public async Task<CartItemDTO> GetBy(int id)
        // {
        //     var item = await _cartRepo.GetBy(id);
        //     if (item == null)
        //     {
        //         return null;
        //     }
        //     return item.ToDTO();  
        // }

        // [Authorize(Roles = "Admin,Manager")]
        // [HttpGet]
        // public async Task<CartItemDTO> GetByAdmin(int id)
        // {
        //     var producer = await _cartRepo.GetBy(id);
        //     if (producer == null)return null;
        //     var dto = producer.ToDTO();
        //     dto.SetAuditForDTO(producer);
        //     return dto;
        // }

        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Create (CartItemDTO cartDTO)
        {
           // var user = User.;
           try{

            var stock = (await  _productRepo.GetBy(cartDTO.Product.Id.Value)).Stock;
            var stock_new = stock - cartDTO.Quantity.Value;
            if(stock_new < 0)return  Const.Response.ControlerResponse(Const.StatusCode.BadRequest,"Sản phẩm đã hết hàng tồn kho");
            await _productRepo.UpdateStock(stock_new,cartDTO.Product.Id.Value);
            
            var cart = cartDTO.ToCart(); 
            await _cartRepo.Create(cart);
            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
               Console.WriteLine(e.ToString());
               return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
        
        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Update (CartItemDTO cartDTO)
        {
           if(cartDTO.Id == null)return Const.Response.ControlerResponse(Const.StatusCode.BadRequest);
           try{
                var cart = cartDTO.ToCart();

                await _cartRepo.Update(cart);

                return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
        // [HttpPut]
        // public async Task<IDictionary<string,object>> Update(int id, CartItemDTO paymentDTO)
        // {
        //     if (id != paymentDTO.PaymentId)
        //     {
        //         return BadRequest();
        //     }

        //     var producer = await _cartRepo.GetBy(id);

        //     if (producer == null)
        //     {
        //         return NotFound();
        //     }

        //     paymentDTO.MapTo(producer);

        //     // try
        //     // {
        //     //     await _cartRepo.Add(producer);
        //     // }
        //     // catch (DbUpdateConcurrencyException) when (!_cartRepo.MovieExists(id))
        //     // {
        //     //     return NotFound();
        //     // }

        //     return NoContent();
        // }
        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpDelete]
        public async Task<IDictionary<string,object>> Delete(int id)
        {
            try{
            // var producer = await _cartRepo.GetBy(id);

            // if (producer == null)
            // {
            //     return NotFound();
            // }

            await _cartRepo.Delete(id);

            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
            }
        }

        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpDelete]
        public async Task<IDictionary<string,object>> DeleteRange(int[] ids)
        {
            try{
            // var producer = await _cartRepo.GetBy(id);

            // if (producer == null)
            // {
            //     return NotFound();
            // }

            await _cartRepo.Delete(ids);

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
