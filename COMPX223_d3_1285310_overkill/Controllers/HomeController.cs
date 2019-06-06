using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COMPX223_d3_1285310_overkill.Models;

namespace COMPX223_d3_1285310_overkill.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyTrapAppContext _context;

        public HomeController(MyTrapAppContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Validate(Manager thung)
        {
            IQueryable<Manager> query = _context.Manager.Where(b => b.Name == thung.Name && b.Password == thung.Password);
            if (query.Count() == 0)
            {
                return BadRequest("Bad Username Password Combo");

            }
            _context.CurrentUser = query.First().Id;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
