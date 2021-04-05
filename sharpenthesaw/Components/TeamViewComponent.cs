using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sharpenthesaw.Models;

namespace sharpenthesaw.Components
{
    public class TeamViewComponent : ViewComponent 
    {
        private BowlingLeagueContext context;

        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            return View(context.Teams.Distinct().OrderBy(x => x));
        }
    }
}
