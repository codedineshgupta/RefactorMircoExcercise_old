using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMircoExcercise.TurnTicketDispenser
{

    public class TicketDispenserTest
    {
        [Fact]
        public void GetTurnTicket_ShouldReturnNewTurnTicket()
        {
            // Arrange
            int nextTurnNumber = 1;
            var mockTurnNumberGenerator = new Mock<ITurnNumberGenerator>();
            mockTurnNumberGenerator.Setup(generator => generator.GetNextTurnNumber()).Returns(nextTurnNumber);

            var ticketDispenser = new TicketDispenser(mockTurnNumberGenerator.Object);

            // Act
            TurnTicket turnTicket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.Equal(nextTurnNumber, turnTicket.TurnNumber);
        }

        [Fact]
        public void GetTurnTicket_ShouldReturnDifferentTurnTicketsOnMultipleCalls()
        {
            // Arrange
            int firstTurnNumber = 1;
            int secondTurnNumber = 2;
            var mockTurnNumberGenerator = new Mock<ITurnNumberGenerator>();
            mockTurnNumberGenerator.SetupSequence(generator => generator.GetNextTurnNumber())
                .Returns(firstTurnNumber)
                .Returns(secondTurnNumber);

            var ticketDispenser = new TicketDispenser(mockTurnNumberGenerator.Object);

            // Act
            TurnTicket firstTurnTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTurnTicket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.Equal(firstTurnNumber, firstTurnTicket.TurnNumber);
            Assert.Equal(secondTurnNumber, secondTurnTicket.TurnNumber);
        }

        [Fact]
        public void GetTurnTicket_ShouldIncrementTurnNumberOnEachCall()
        {
            // Arrange
            int initialTurnNumber = 1;
            var mockTurnNumberGenerator = new Mock<ITurnNumberGenerator>();
            mockTurnNumberGenerator.SetupSequence(generator => generator.GetNextTurnNumber())
                .Returns(initialTurnNumber)
                .Returns(initialTurnNumber + 1)
                .Returns(initialTurnNumber + 2);

            var ticketDispenser = new TicketDispenser(mockTurnNumberGenerator.Object);

            // Act
            TurnTicket firstTurnTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTurnTicket = ticketDispenser.GetTurnTicket();
            TurnTicket thirdTurnTicket = ticketDispenser.GetTurnTicket();

            // Assert
            Assert.Equal(initialTurnNumber, firstTurnTicket.TurnNumber);
            Assert.Equal(initialTurnNumber + 1, secondTurnTicket.TurnNumber);
            Assert.Equal(initialTurnNumber + 2, thirdTurnTicket.TurnNumber);
        }

        [Fact]
        public void dispense_a_ticket_WHEN_dispense_a_new_ticket_at_another_machine_THEN_turn_number_of_the_new_ticket_is_greater()
        {
            // Arrange
            int firstDespensenumber = 1;
            var mockTurnNumberGenerator1 = new Mock<ITurnNumberGenerator>();
            mockTurnNumberGenerator1.Setup(generator => generator.GetNextTurnNumber()).Returns(firstDespensenumber);
              

            var ticketDispenser1 = new TicketDispenser(mockTurnNumberGenerator1.Object);

            int secondDespensenumber = 2;
            var mockTurnNumberGenerator2 = new Mock<ITurnNumberGenerator>();
            mockTurnNumberGenerator2.Setup(generator => generator.GetNextTurnNumber()).Returns(secondDespensenumber);


            var ticketDispenser2 = new TicketDispenser(mockTurnNumberGenerator2.Object);

            // Act
            TurnTicket firstTurnTicket = ticketDispenser1.GetTurnTicket();
            TurnTicket secondTurnTicket = ticketDispenser2.GetTurnTicket();
          

            // Assert
            Assert.True(firstTurnTicket.TurnNumber < secondTurnTicket.TurnNumber);
          
        }

     
    }
}
