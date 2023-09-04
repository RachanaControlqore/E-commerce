﻿using E_Commerce.Repository.Context;
using E_Commerce_API.Request.Command;
using E_Commerce_API.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private E_Commerce_DbContext _context;
        public ProductController(E_Commerce_DbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProduct([FromBody] AddProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<AddProductCommand>> GetProduct(int productId)
        {
            var query = new GetProductQuery { ProductID = productId };
            var product = await _mediator.Send(query);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        { 
            return Ok(_context.Product); 
        }


        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}