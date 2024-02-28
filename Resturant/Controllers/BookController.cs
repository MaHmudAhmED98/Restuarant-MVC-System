using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using RestaruantMVC.Models;
using RestaruantMVC.Models.Reprositray;
using RestaruantMVC.Models.ViewModel;
using Resturant.Migrations;
using Resturant.Models;
using Table = Resturant.Models.Table;

namespace RestaruantMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {

        private readonly IBookRepositary bookRepositary;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductRepository productRepository;

        public BookController(IBookRepositary bookRepositary, UserManager<AppUser> userManager, IProductRepository productRepository)
        {
            this.bookRepositary = bookRepositary;
            _userManager = userManager;
            this.productRepository = productRepository;
        }
        public async Task <IActionResult> userBook()
        {
            var c = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var u = await _userManager.FindByIdAsync(c);
            ViewBag.tablelist = bookRepositary.getalltables().Select(t => t.Name);

            return View(bookRepositary.GetallBook(u.UserName).Select(InsertBookviewModel.FromDbModel));
        }
        public async Task< IActionResult> Getall()
        {
            ViewBag.tablelist = bookRepositary.getalltables().Select(t=>t.Name);
            ViewBag.Namelist = bookRepositary.GetAll().Select(InsertBookviewModel.FromDbModel);

            return View(bookRepositary.GetAll().Select(InsertBookviewModel.FromDbModel));
        }

        [HttpGet]
        public IActionResult Insert()
        {

            ViewBag.tablelist = bookRepositary.getalltables();  
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InitaitOrder(InsertBookviewModel viewModel)
        {
            var c = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var u = await _userManager.FindByIdAsync(c);

            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (!bookRepositary.IsTableEmpty(viewModel.Arrivedat, viewModel.Leavedat, viewModel.tableId))
            {
                ViewBag.tablelist = bookRepositary.getalltables();
                ModelState.AddModelError("", "The Table Isn't Empty At This Time Check Another One");
                return View("Insert",viewModel);
            }

            Table table = bookRepositary.GetTable(viewModel.tableId);
            Book book = new Book
            {
                userId = u.UserName,
                AppUser = u,
                arrivedAt = viewModel.Arrivedat,
                leaveAt = viewModel.Leavedat,
                numOfPersones = viewModel.Numberofperson,
                Table = table,
            };

            bookRepositary.Insert(book);
            bookRepositary.savechanges();

            return RedirectToAction("GetAllMeals", "Product");

        }
        public async Task<IActionResult> Creat(int id,int Count=1)
        {

            var book = bookRepositary.GetLastBookByUserId(await GetUserId());
            var product = productRepository.GetById(id);
          
            book.AddNewproduct(product, Count);
            bookRepositary.savechanges();
            return Json("");
        }
        [HttpGet]
        public async Task< IActionResult> Save()
        {
            
            var book = bookRepositary.GetLastBookByUserId(await GetUserId());
            foreach (var product in book.BookProduct)
            {
                ViewBag.tablelist = bookRepositary.getalltables().ToList();
                book.totalPrice += product.Products.price * product.Count;
            }
            bookRepositary.savechanges();
                List<InsertBookviewModel> list = new List<InsertBookviewModel>();
            list.Add(InsertBookviewModel.FromDbModel(book));
            return View(list);
        }     
        private async Task <string> GetUserId()
        {
            var claim = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(claim);
            return user.Id;
        }

        public IActionResult Details(int id)
        {
            ViewBag.tablelist = bookRepositary.getalltables().ToList();
            List<InsertBookviewModel> list = new List<InsertBookviewModel>();

            InsertBookviewModel vm = InsertBookviewModel.FromDbModel(bookRepositary.GetBook(id));
                list.Add(vm);
            return View("Save", list);
        }

    }

}