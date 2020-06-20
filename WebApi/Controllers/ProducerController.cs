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
    public class ProducerController : ControllerBase
    {
        private readonly IProducerRepository _producerRepo;
        public ProducerController(
                                IProducerRepository producerRepo
                                )
        {
            _producerRepo = producerRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ProducerDTO>> GetAll()
        {
            var producers = await _producerRepo.GetAll();
            if (producers == null)
            {
                return null;
            }
            producers = producers.Where(p => p.AuthStatus == AuthStatus.Approved);
            List<ProducerDTO> producers_result = new List<ProducerDTO>();
            foreach(Producer producer in producers)
            {
                var dto = producer.ToDTO();
                producers_result.Add(dto);
            }
            return producers_result;
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<IEnumerable<ProducerDTO>> GetAllAdmin()
        {
            var producers = await _producerRepo.GetAll();
            if (producers == null)
            {
                return null;
            }
            List<ProducerDTO> producers_result = new List<ProducerDTO>();
            foreach(Producer producer in producers)
            {
                var dto = producer.ToDTO();
                dto.SetAuditForDTO(producer);
                producers_result.Add(dto);
            }
            return producers_result;
        }

        [HttpGet]
        public async Task<ProducerDTO> GetBy(int id)
        {
            var producer = await _producerRepo.GetBy(id);
            if (producer == null || producer.AuthStatus != AuthStatus.Approved)
            {
                return null;
            }
            return producer.ToDTO();  
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<ProducerDTO> GetByAdmin(int id)
        {
            var producer = await _producerRepo.GetBy(id);
            if (producer == null)return null;
            var dto = producer.ToDTO();
            dto.SetAuditForDTO(producer);
            return dto;
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Create (ProducerDTO producerDTO)
        {
           // var user = User.;
           try{
            var producer = producerDTO.ToProducer();
            producer.SetAuditForCreate(producerDTO);
            await _producerRepo.Create(producer);
            return  Const.Response.ControlerResponse(Const.StatusCode.OK,"Action complete successfully");
           }
           catch(Exception e){
               Console.WriteLine(e.ToString());
               return Const.Response.ControlerResponse(Const.StatusCode.InternalServerError,e.ToString());
           }
        }
        
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IDictionary<string,object>> Update (ProducerDTO producerDTO)
        {
           if(producerDTO.ProducerId == null)return Const.Response.ControlerResponse(Const.StatusCode.BadRequest);
           try{
                var producer = producerDTO.ToProducer();
                producer.SetAuditForCreate(producerDTO);
                await _producerRepo.Update(producer);

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
        
            await _producerRepo.Approve(isApprove, id, user);

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
            // var producer = await _producerRepo.GetBy(id);

            // if (producer == null)
            // {
            //     return NotFound();
            // }

            await _producerRepo.Delete(id);

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
