using Microsoft.AspNetCore.Mvc;
using productMVC.Models;
using productMVC.Services;

namespace productMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View(); // Return the create form
        }

        [HttpPost]
        public IActionResult Create(ProductDTO productDTO)
        {
            if (productDTO.ImageFileName == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }

            if (!ModelState.IsValid)
            {
                return View(productDTO);
            }
            //save the image file
            //string newFilename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //newFilename += Path.GetExtension(productDTO.ImageFileName.FileName);

            //string imageFullPath = Environment.webroot 

            //save the product
            Product product = new Product()
            {
                Name = productDTO.Name,
                Brand = productDTO.Brand,
                Category = productDTO.Category,
                Price = productDTO.Price,
                Description = productDTO.Description,
                ImageFileName = "null",
                CreatedAt = DateTime.Now,
            };

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Products");
            }

            // create productDTO from product
            var productDTO = new ProductDTO()
            {
                Name= product.Name,
                Brand= product.Brand,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
            };

            ViewData["id"] = product.Id;
            ViewData["createdAt"] = product.CreatedAt;

            return View(productDTO);
        }
    }
}
