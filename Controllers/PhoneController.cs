using iStore.Models;
using iStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iStore.Controllers
{
    public class PhoneController : Controller
    {

        

        private readonly IConfiguration _configuration;
        string apiUrl;
        private readonly ProductDbContext _db;
        public PhoneController( IConfiguration configuration, ProductDbContext db)
        {
            
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
        public IActionResult WishlistConfirmation(int id)
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
        public async Task<IActionResult> iPad(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach(var item in a)
            {
                if (item.ProductID == 23)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 23,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }
                    
                }
            }
            if (search == null)
            {
                return View();
            }
            else {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 23,
                        VendorId=1,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
                 } 

            

        }


        [Authorize]
        public async Task<IActionResult> iPadAir(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 22)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 22,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 22,
                        VendorId = 2,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPadMini(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 24)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 24,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 24,
                        VendorId = 3,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPadPro(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 21)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 21,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 21,
                        VendorId = 4,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone13(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 3)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 3,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 3,
                        VendorId = 5,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone13Pro(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 2)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 2,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 2,
                        VendorId = 6,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone13ProMax(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 1)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 1,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 1,
                        VendorId = 7,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone13Mini(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 4)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 4,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 4,
                        VendorId = 8,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone12(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 7)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 7,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 7,
                        VendorId = 1,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone12Pro(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 6)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 6,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 6,
                        VendorId = 2,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone12ProMax(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 5)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 5,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 5,
                        VendorId = 3,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone12Mini(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 8)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 8,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 8,
                        VendorId = 4,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone11(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 12)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 12,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 12,
                        VendorId = 5,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone11Pro(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 11)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 11,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 11,
                        VendorId = 6,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone11ProMax(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 10)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 10,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 10,
                        VendorId = 7,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhoneX(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 13)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 13,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 13,
                        VendorId = 8,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhoneXR(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 16)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 16,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 16,
                        VendorId = 1,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhoneXS(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 15)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 15,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 15,
                        VendorId = 2,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhoneXSMax(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 14)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 14,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 14,
                        VendorId = 3,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone8(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 18)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 18,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 18,
                        VendorId = 4,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone8Plus(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 17)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 17,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 17,
                        VendorId = 5,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone7(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 20)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 20,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 20,
                        VendorId = 6,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhone7Plus(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 19)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 19,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 19,
                        VendorId = 7,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }

        [Authorize]
        public async Task<IActionResult> iPhoneSE(string search)
        {
            var tables = new OverallViewModel
            {
                products = _db.products.ToList(),
                wishlists = _db.wishlists.ToList(),
                vendors = _db.vendors.ToList(),
                vendorstocks = _db.vendorStocks.ToList(),
                carts = _db.carts.ToList()
            };

            var a = tables.vendorstocks;
            foreach (var item in a)
            {
                if (item.ProductID == 9)
                {
                    if (item.StockInHand > 0)
                    {
                        if (search == null)
                        {
                            return View();
                        }
                        else if (search.Length == 6)
                        {
                            Cart c = new Cart
                            {

                                ProductId = 9,
                                CustomerId = User.Identity.Name,
                                DeliveryDate = DateTime.UtcNow.AddDays(7),
                                Zipcode = Convert.ToInt32(search)
                            };
                            var resService = new Cart();
                            using (var client = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                                using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addproducttocart", content))
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    resService = JsonConvert.DeserializeObject<Cart>(apiResponse);
                                }
                            }
                            return RedirectToAction("Cart", "Home");
                            /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                        }
                        else { return View(); }
                    }

                }
            }
            if (search == null)
            {
                return View();
            }
            else
            {
                if (search == null)
                {
                    return View();
                }
                else if (search.Length == 6)
                {
                    Wishlist c = new Wishlist
                    {

                        ProductId = 9,
                        VendorId = 8,
                        CustomerId = User.Identity.Name,
                        DateAddedToWishlist = DateTime.UtcNow.AddDays(7),
                        Quantity = 1
                    };
                    var resService = new Wishlist();
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("https://istore015.azurewebsites.net/api/proceedtobuy/addtowishlist", content))
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            resService = JsonConvert.DeserializeObject<Wishlist>(apiResponse);
                        }
                    }
                    return RedirectToAction("Wishlist", "Home");
                    /*return RedirectToAction("AddProductToCart", "Home", new { cart = c });*/
                }
                else { return View(); }
            }



        }
    }
}
