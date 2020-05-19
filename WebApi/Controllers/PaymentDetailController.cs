using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using WebApi.Infrastructure.Interfaces;
using WebApi.Infrastructure.DTOs;
using WebApi.Infrastructure.Models;
using WebApi.Infrastructure.Mapping;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentDetailRepository _paymentRepo;

        public PaymentDetailController(IPaymentDetailRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        // // GET /catalog
        // [HttpGet("catalog")]
        // public async Task<IndexDTO> GetCatalog(string genre = "", string searchString = "")
        // {
        //     var indexDTO = new IndexDTO()
        //     {
        //         MovieGenre = genre,
        //         SearchString = searchString,
        //         Genres = await _paymentRepo.GetGenres(),
        //         Movies = await _paymentRepo.GetMovies(genre, searchString)
        //     };

        //     return indexDTO;
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<PaymentDetailDTO>> GetMovie(int id)
        // {
        //     var payment = await _paymentRepo.GetBy(id);

        //     if (payment == null)
        //     {
        //         return NotFound();
        //     }

        //     return payment.ToDTO();
        // }

        // [HttpPost]
        // public async Task<ActionResult<PaymentDetail>> Create(PaymentDetailDTO paymentDTO)
        // {
        //     var payment = paymentDTO.ToPaymentDetail();

        //     await _paymentRepo.Add(payment);

        //     return CreatedAtAction(nameof(GetMovie), new { id = payment.Id }, payment);
        // }

        [HttpGet]
        public async Task<ActionResult<List<PaymentDetailDTO>>> GetAll()
        {
            var payments = await _paymentRepo.GetAll();

            if (payments == null)
            {
                return NotFound();
            }
            List<PaymentDetailDTO> payments_result = new List<PaymentDetailDTO>();
            foreach(PaymentDetail payment in payments)
            {
                payments_result.Add(payment.ToDTO());
            }
            return payments_result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentDetailDTO paymentDTO)
        {
            var payment = paymentDTO.ToPaymentDetail();

            await _paymentRepo.Add(payment);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, PaymentDetailDTO paymentDTO)
        {
            if (id != paymentDTO.PaymentId)
            {
                return BadRequest();
            }

            var payment = await _paymentRepo.GetBy(id);

            if (payment == null)
            {
                return NotFound();
            }

            paymentDTO.MapTo(payment);

            // try
            // {
            //     await _paymentRepo.Add(payment);
            // }
            // catch (DbUpdateConcurrencyException) when (!_paymentRepo.MovieExists(id))
            // {
            //     return NotFound();
            // }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentRepo.GetBy(id);

            if (payment == null)
            {
                return NotFound();
            }

            await _paymentRepo.Delete(payment);

            return NoContent();
        }
    }
}
