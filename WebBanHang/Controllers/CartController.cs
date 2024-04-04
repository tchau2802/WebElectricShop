using Microsoft.AspNetCore.Mvc;
using WebBanHang.Data;
using WebBanHang.ViewModels;
using WebBanHang.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace WebBanHang.Controllers
{
    public class CartController : Controller
    {
        private readonly Hshop2023Context db;

        public CartController(Hshop2023Context context)
        {
            db = context;
        }

        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }

        #region Add To Cart
        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHang == id);
            if (item == null)
            {
                var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Khong Tim Thay Hang Co Ma {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaHang = hangHoa.MaHh,
                    TenHang = hangHoa.TenHh,
                    DonGiaHang = hangHoa.DonGia ?? 0,
                    HinhHang = hangHoa.Hinh ?? "",
                    SoLuongHang = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuongHang += quantity;
            }
            HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHang == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Checkout

        //[Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            var gioHang = Cart;
            if (Cart.Count == 0)
            {
                return Redirect("/");
            }
            return View(Cart);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Checkout(CheckoutVM model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(Cart);
        }

        #endregion
    }
}
