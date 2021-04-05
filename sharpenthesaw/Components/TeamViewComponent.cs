using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using sharpenthesaw.Models;

namespace sharpenthesaw.Components
{
    //view each team
    public class TeamViewComponent : ViewComponent 
    {
        private BowlingLeagueContext context;

        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            //this helps us view each team and filter bowlers by their team
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            return View(context.Teams.Distinct().OrderBy(x => x));
        }
    }
}
