﻿using APICatalog.Context;
using APICatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products.ToList();
            if (products is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return products;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product is null)
            {
                return NotFound("Produto não encontrado");
            }
            return product;
        }
    }
}