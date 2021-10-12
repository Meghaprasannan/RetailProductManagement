using iStore.CartData;
using iStore.Models;
using iStore.WishlistData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iStore.API_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceedToBuyController : ControllerBase
    {
        ICartData cartData;
        IWishlistData wishData;
        public ProceedToBuyController(ICartData data,IWishlistData wislistData)
        {
            cartData = data;
            wishData = wislistData;
        }
        [HttpPost]
        [Route("AddProductToCart")]
        public IActionResult AddProductToCart(Cart c)
        {
            var createduser = cartData.AddProductToCart(c);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" 
                + HttpContext.Request.Path + "/" + createduser.Id, createduser);
        }
        [HttpGet]
        [Route("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            var user = cartData.GetProductById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with id {id} is not found");

        }
        [HttpDelete]
        [Route("DeleteProductFromCart/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var prod = cartData.GetProductById(id);
            if (prod != null)
            {
                cartData.DeleteProductFromCart(prod);
                return Ok();
            }
            return NotFound($"User with id {id} is not found");
        }

        [HttpGet]
        [Route("GetProductsFromCart")]
        public IActionResult GetProductsFromCart()
        {
            return Ok(cartData.GetProductsFromCart());
        }













        [HttpPost]
        [Route("AddToWishlist")]
        public IActionResult AddProductToWishlist(Wishlist c)
        {
            var createduser = wishData.AddProductToWishlist(c);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/" + createduser.Id, createduser);
        }
        [HttpGet]
        [Route("GetProductByIdFromWishlist/{id}")]
        public IActionResult GetProductByIdFromWishlist(int id)
        {
            var user = wishData.GetProductByIdFromWishlist(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound($"User with id {id} is not found");

        }
        [HttpDelete]
        [Route("DeleteProductFromWishlist/{id}")]
        public IActionResult DeleteUserFromWishlist(int id)
        {
            var prod = wishData.GetProductByIdFromWishlist(id);
            if (prod != null)
            {
                wishData.DeleteProductFromWishlist(prod);
                return Ok();
            }
            return NotFound($"User with id {id} is not found");
        }

        [HttpGet]
        [Route("GetProductsFromWishlist")]
        public IActionResult GetProductsFromWishlist()
        {
            return Ok(wishData.GetProductsFromWishlist());
        }


        /*// GET: api/<ProceedToBuyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProceedToBuyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProceedToBuyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProceedToBuyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProceedToBuyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
