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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        public OrderController(
                                IOrderRepository orderRepo
                                )
        {
            _orderRepo = orderRepo;
        }

        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string id)
        {
            var orders = await _orderRepo.GetAll(id);
            if (orders == null)
            {
                return null;
            }
    
            List<OrderDTO> orders_result = new List<OrderDTO>();
            foreach(Order item in orders)
            {
                var dto = item.ToDTO();
                orders_result.Add(dto);
            }
            return orders_result;
        }

        // [Authorize(Roles = "Admin,Manager")]
        // [HttpGet]
        // public async Task<IEnumerable<CartItemDTO>> GetAllAdmin()
        // {
        //     var cartItems = await _orderRepo.GetAll();
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
        //     var item = await _orderRepo.GetBy(id);
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
        //     var producer = await _orderRepo.GetBy(id);
        //     if (producer == null)return null;
        //     var dto = producer.ToDTO();
        //     dto.SetAuditForDTO(producer);
        //     return dto;
        // }

        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Create (OrderDTO orderDTO)
        {
           // var user = User.;
           try{
            var order = orderDTO.ToOrder();  
            order.Status = OrderStatus.Sent;
            order.CreateDate = DateTime.Now;
            await _orderRepo.Create(order);
            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
               Console.WriteLine(e.ToString());
               return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IDictionary<string,object>> UpdateStatus (int id, string status = null)
        {
            try{
                await _orderRepo.UpdateStatus(id,status);
                return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
        
        [Authorize(Roles = "Admin,Manager,Customer")]
        [HttpPost]
        public async Task<IDictionary<string,object>> CancelOrder (int id,string userId)
        {
            try{
                var order = await _orderRepo.GetBy(id);
                if(!order.UserId.Equals(userId))
                    return  Const.Response.ControlerResponse(Const.StatusCode.Forbidden,"This action is Forbidden");
                if(order.Status.Equals(OrderStatus.onShipping))
                    return  Const.Response.ControlerResponse(Const.StatusCode.Forbidden,"You can't cancel on shipping package");

                await _orderRepo.UpdateStatus(id,OrderStatus.Cancel);
                return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
                Console.WriteLine(e.ToString());
                return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
        // [Authorize(Roles = "Admin,Manager,Customer")]
        // [HttpPost]
        // public async Task<IDictionary<string,object>> Update (CartItemDTO cartDTO)
        // {
        //    if(cartDTO.Id == null)return Const.Response.ControlerResponse(Const.StatusCode.BadRequest);
        //    try{
        //         var cart = cartDTO.ToCart();

        //         await _orderRepo.Update(cart);

        //         return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
        //    }
        //    catch(Exception e){
        //         Console.WriteLine(e.ToString());
        //         return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
        //    }
        // }
        
        
        
    }
}
