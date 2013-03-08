using System.Linq;
using System.Web.Mvc;
using Ankiro.Framework.Tools.Bus;
using FoossballPlayars.Commands;
using FoossballPlayars.QueryContext;

namespace FoossballWeb.Controllers
{
	public class MatchController : Controller
	{
		private readonly IBus _commandBus;
		private readonly IScoreQuery _scoreQuery;

		public MatchController(IBus commandBus, IScoreQuery scoreQuery)
		{
			_commandBus = commandBus;
			_scoreQuery = scoreQuery;
		}

		public JsonResult Create(string redOffensive, string redDefensive, string blueOffensive, string blueDefensive, int scoreRed, int scoreBlue)
		{
			var players = _scoreQuery.GetAllPlayers().ToDictionary(x=>x.Name.ToString(), x=>x.Id);

			_commandBus.Raise(new PlayGameCommand(players[redOffensive], players[redDefensive], players[blueOffensive], players[blueDefensive], scoreRed, scoreBlue));

			return Json("Ok");
		}
	}
}
