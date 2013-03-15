using EventSourcingTest.Interfaces;
using FoossballPlayars.Commands;

namespace FoossballPlayars.Services
{
    public interface IGameService:  Handles<RegisterPlayarCommand>, Handles<PlayGameCommand>
    {
    }
}