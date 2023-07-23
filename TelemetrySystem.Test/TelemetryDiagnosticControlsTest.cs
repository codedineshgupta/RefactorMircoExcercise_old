using Moq;

namespace RefactorMircoExcercise.TelemetrySystem
{ 

    public class TelemetryDiagnosticControlsTest
    {
        [Fact]
        public void CheckTransmission_OnSuccess_DiagnosticInfoContainsData()
        {
            // Arrange
            //var telemetryClientMock = new Mock<TelemetryClient>();
            //telemetryClientMock.SetupSequence(tc => tc.OnlineStatus).Returns(true);
            //telemetryClientMock.Setup(tc => tc.Receive()).Returns("Test diagnostic data");

            var diagnosticControls = new TelemetryDiagnosticControls();

            // Act
            diagnosticControls.CheckTransmission();

            // Assert
            Assert.True(!string.IsNullOrEmpty(diagnosticControls.DiagnosticInfo));
        }

        [Fact]
        public void CheckTransmission_On_FailedConnection_Should_ThrowsException()
        {
            //// Arrange
            //var telemetryClientMock = new Mock<TelemetryClient>();
            //telemetryClientMock.SetupSequence(tc => tc.OnlineStatus).Returns(false);
              

            var diagnosticControls = new TelemetryDiagnosticControls();

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => diagnosticControls.CheckTransmission());
            Assert.Equal("Unable to connect.", exception.Message);
        }
    }

}
