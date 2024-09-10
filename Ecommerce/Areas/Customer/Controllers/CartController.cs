using Ecommerce.DataAccess.Respository.IRepository;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM = new ShoppingCartVM()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Product")
            };
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }
        public IActionResult Summary()
        {
            return View();
        }
        public IActionResult Plus(int cartId)
        {

            var cartObj = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, includeProperties: "Product");
            cartObj.Count += 1;

            cartObj.Price = GetPriceBasedOnQuantity(cartObj);
            _unitOfWork.ShoppingCart.Update(cartObj);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {

            var cartObj = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId, includeProperties: "Product");
            if (cartObj.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cartObj);
            }
            else
            {
                cartObj.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartObj);

            }
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {

            var cartObj = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);

            _unitOfWork.ShoppingCart.Remove(cartObj);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count >= 100)
            {
                return shoppingCart.Product.Price100;
            }
            else if (shoppingCart.Count >= 50)
            {
                return shoppingCart.Product.Price50;
            }

            else
            {
                return shoppingCart.Product.Price;
            }
        }
    }
}
