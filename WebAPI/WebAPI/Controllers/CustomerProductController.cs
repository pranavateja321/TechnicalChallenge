using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerProductController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public CustomerProductController(ICustomerService customerService, IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }

        [HttpGet("customers")]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("customers/{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost("customers")]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpPut("customers/{id}")]
        public IActionResult UpdateCustomer(int id, Customer customer)
        {
            _customerService.UpdateCustomer(id, customer);
            return NoContent();
        }

        [HttpDelete("customers/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }

        [HttpGet("customers/{customerId}/products")]
        public IActionResult GetProductsByCustomerId(int customerId)
        {
            var customerProducts = _productService.GetProductsByCustomerId(customerId);
            return Ok(customerProducts);
        }

        // CRUD operations for products

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost("products")]
        public IActionResult AddProduct(Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("products/{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            _productService.UpdateProduct(id, product);
            return NoContent();
        }

        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }

}
