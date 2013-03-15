using System.Linq;
using System.Web.Mvc;
using EventSourcingTest.Interfaces;
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
			var playerNames = _scoreQuery.GetAllPlayers().Select(x => x.Name.Name);
			foreach (var missingPlayer in new[] { redOffensive, redDefensive, blueOffensive, blueDefensive }.Except(playerNames))
			{
				_commandBus.Raise(new RegisterPlayarCommand(missingPlayer));
			}
			var players = _scoreQuery.GetAllPlayers().ToDictionary(x => x.Name.Name, x => x.Id);
			_commandBus.Raise(new PlayGameCommand(players[redOffensive], players[redDefensive], players[blueOffensive], players[blueDefensive], scoreRed, scoreBlue));

			return Json("Ok", JsonRequestBehavior.AllowGet);
		}
	}
}
