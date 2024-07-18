using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
	public class StaffController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Dashboard()
		{
			return View();
		}
		public IActionResult Product()
		{
			return View();
		}

		public IActionResult AddProduct()
		{
			return View();
		}

		public IActionResult ProductDetails()
		{
            return View();
        }

        #region Edit Product Options

        public IActionResult EditProduct()
		{
			return View();
		}

		public IActionResult EditBasicProductDetails()
		{
            return View();
        }

		public IActionResult EditProductDescription()
		{
			return View();
		}

        #endregion

		public IActionResult ProductFeedbacks()
		{
			return View();
		}

		public IActionResult Order()
		{
			return View();
		}

		public IActionResult OrderDetails()
		{
			return View();
		}

		public IActionResult PreOrder()
		{
			return View();
		}

		public IActionResult PreOrderDetails()
		{
			return View();
		}

		public IActionResult Message()
		{
			return View();
		}

		public IActionResult MessageDetails()
		{
			return View();
		}

		public IActionResult Blogs()
		{
			return View();
		}

		public IActionResult BlogDetails()
		{
			return View(); 
		}

		public IActionResult AddBlog()
		{
			return View();
		}

		public IActionResult EditBlog()
		{
			return View();
		}
    }
}
