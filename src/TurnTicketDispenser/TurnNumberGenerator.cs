
namespace RefactorMircoExcercise.TurnTicketDispenser
{
    internal class TurnNumberGenerator : ITurnNumberGenerator
    {
        public int GetNextTurnNumber()
        {
            return TurnNumberSequence.GetNextTurnNumber();
        }
    }
}
