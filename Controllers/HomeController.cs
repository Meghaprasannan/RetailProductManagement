using iStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using iStore.ViewModel;

namespace iStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;
        string apiUrl;
        private readonly ProductDbContext _db;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ProductDbContext db)
        {
            _logger = logger;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("VendorAPI");
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> VendorList()
        {
            var result = new List<Vendor>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://istore015.azurewebsites.net/api/vendor/getvendorslist"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Vendor>>(apiResponse);
                }
            }
            return View(result);
        }
        [Authorize]
        public IActionResult VendorStock()
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };
            return View(tables);
        }

        [Authorize]
        public async Task<IActionResult> VendorListById(int id)
        {
            var results = new Vendor();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"https://istore015.azurewebsites.net/api/vendor/getvendorbyid/{ id }"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<Vendor>(apiResponse);

                    }
                    else
                    {
                        var noResponse = response.StatusCode.ToString();
                        return View(noResponse);
                    }
                }
            }
            return View(results);
        }
        /*public IActionResult VendorList()
        {
            return View();
        }*/

        /*public ViewResult AddedToCart() => View();*/



        /*THIS IS CART FUNCTIONALITY*/
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProductToCart(Cart cart)
        {
            var resService = new Cart();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                }
            }
            return RedirectToAction("Cart");
        }
        /*[HttpGet]*/

        [Authorize]
        public IActionResult Cart()
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };
            return View(tables);
            /*var result = new List<Cart>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://istore015.azurewebsites.net/api/proceedtobuy/getproductsfromcart"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                }
            }*/


        }

        [Authorize]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var results = new Cart();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"https://istore015.azurewebsites.net/api/proceedtobuy/deleteproductfromcart/{id}"))
                {

                    var apiResponse = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<Cart>(apiResponse);
                }
            }
            return RedirectToAction("Cart");
        }





        /*THIS IS Wishlist FUNCTIONALITY*/
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProductToWishlist(Wishlist cart)
        {
            var resService = new Wishlist();
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                }
            }
            return RedirectToAction("Wishlist");
        }
        /*[HttpGet]*/

        [Authorize]
        public IActionResult Wishlist()
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };
            /*var result = new List<Cart>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://istore015.azurewebsites.net/api/proceedtobuy/getproductsfromwishlist"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<Cart>>(apiResponse);
                }
            }*/

            return View(tables);
        }

        [Authorize]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var results = new Wishlist();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"https://istore015.azurewebsites.net/api/proceedtobuy/deleteproductfromwishlist/{id}"))
                {

                    var apiResponse = await response.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                }
            }
            return RedirectToAction("Wishlist");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Search(string option, string search)
        {
            if (option == "Name")
            {
                return RedirectToAction("ProductByName",new { name=search});
            }else if(option == "Id")
            {
                
                return RedirectToAction("ProductById",new { id=search});
            }
            else
            {
                var result = new List<Product>();
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync("https://istore015.azurewebsites.net/api/product/getproductslist"))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                    }
                }
                return View(result);
            }
            
        }

        [Authorize]
        public async Task<IActionResult> ProductById(string id)
        {
            
            var results = new List<Product>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"https://istore015.azurewebsites.net/api/product/getproductbyid/{id}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<List<Product>>(apiResponse);

                    }
                    else
                    {
                        var noResponse = response.StatusCode.ToString();
                        return View(noResponse);
                    }
                }
            }
            return View(results);
        }

        [Authorize]
        public async Task<IActionResult> ProductByName(string name)
        {

            var results = new List<Product>();
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"https://istore015.azurewebsites.net/api/product/getproductbyname/{name}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        results = JsonConvert.DeserializeObject<List<Product>>(apiResponse);

                    }
                    else
                    {
                        var noResponse = response.StatusCode.ToString();
                        return View(noResponse);
                    }
                }
            }
            return View(results);
        }
        /*public IActionResult Search()
        {
            
                return View();
        }*/

        [Authorize]
        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        public IActionResult CustomerSupport()
        {
            return View();
        }

        [Authorize]
        public IActionResult Orders()
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };
            return View(tables);
        }
        [Authorize]
        public IActionResult CheckoutPage()
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };
            return View(tables);
        }
        [Authorize]
        public IActionResult ReferralAdvantages()
        {
            return View();
        }
        /*public IActionResult Wishlist()
        {
            return View();
        }*/


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
