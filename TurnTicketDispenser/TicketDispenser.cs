namespace RefactorMircoExcercise.TurnTicketDispenser
{
    public class TicketDispenser
    {
        private readonly ITurnNumberGenerator _turnNumberGenerator;

        public TicketDispenser() :this(new TurnNumberGenerator())
        {
           
        }
        public TicketDispenser(ITurnNumberGenerator turnNumberGenerator)
        {
            _turnNumberGenerator = turnNumberGenerator;
        }

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberGenerator.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
