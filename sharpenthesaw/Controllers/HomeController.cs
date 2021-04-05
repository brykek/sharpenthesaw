using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using sharpenthesaw.Models;
using sharpenthesaw.Models.ViewModels;

namespace sharpenthesaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;

            context = ctx;
        }

        public IActionResult Index(long? teamid, string teamname, int pagenum = 0)
        {
            int pagesize = 5;
            return View(new IndexViewModel
            {
                bowlers = context.Bowlers.Where(m => m.TeamId == teamid || teamid == null).OrderBy(m => m.BowlerFirstName).Skip((pagenum - 1) * pagesize).Take(pagesize).ToList(),

                pageNumberingInfo = new PageNumberingInfo
                {


                    NumItemsPerPage = pagesize,
                    CurrentPage = pagenum,
                    //if no teamid selected then display all. otherwise, only count the number where team has been selected.
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() : context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },

                TeamName = teamname
            }) ;
            //return View(context.Bowlers.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId = {teamid} OR {teamid} IS NULL").ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
