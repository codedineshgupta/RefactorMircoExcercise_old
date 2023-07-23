using Moq;

namespace RefactorMircoExcercise.TelemetrySystem
{ 

    public class TelemetryDiagnosticControlsTest
    {       

        [Fact]
        public void CheckTransmission_WhenTelemetryClientConnectSucceeds_ShouldSetDiagnosticInfo()
        {
            // Arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(x => x.OnlineStatus)                               
                               .Returns(true);
            mockTelemetryClient.Setup(x => x.Receive()).Returns("Mocked diagnostic message");
            var controls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            // Act
            controls.CheckTransmission();

            // Assert
            Assert.Equal("Mocked diagnostic message", controls.DiagnosticInfo);           
            mockTelemetryClient.Verify(x => x.Disconnect(), Times.Once);
            mockTelemetryClient.Verify(x => x.Send(TelemetryClient.DiagnosticMessage), Times.Once);
            mockTelemetryClient.Verify(x => x.Receive(), Times.Once);
        }

        [Fact]
        public void CheckTransmission_WhenTelemetryClientConnectFails_ShouldThrowException()
        {
            // Arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(x => x.OnlineStatus).Returns(false);
            var controls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => controls.CheckTransmission());
            Assert.Equal("Unable to connect.", exception.Message);

            mockTelemetryClient.Verify(x => x.Connect(It.IsAny<string>()), Times.Exactly(3));
            mockTelemetryClient.Verify(x => x.Disconnect(), Times.Once);
            mockTelemetryClient.Verify(x => x.Send(TelemetryClient.DiagnosticMessage), Times.Never);
        }

        [Fact]
        public void CheckTransmission_WhenTelemetryClientReceiveFails_ShouldSetDiagnosticInfoToEmpty()
        {
            // Arrange
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(x => x.OnlineStatus)
                               .Returns(true);
                               
            mockTelemetryClient.Setup(x => x.Receive()).Throws(new Exception("Receive error"));
            var controls = new TelemetryDiagnosticControls(mockTelemetryClient.Object);

            // Act
            var exception = Assert.Throws<Exception>(() => controls.CheckTransmission());

            // Assert
            Assert.Equal("Receive error", exception.Message);
            Assert.Equal(string.Empty, controls.DiagnosticInfo);            
            mockTelemetryClient.Verify(x => x.Disconnect(), Times.Once);
            mockTelemetryClient.Verify(x => x.Send(TelemetryClient.DiagnosticMessage), Times.Once);
        }

        [Fact]
        public void TelemetryDiagnosticControls_Should_Throw_ArgumentNull_Exception_if_dependency_not_resolved()
        {
            // Arrange   
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new TelemetryDiagnosticControls(null));

            // Assert
            Assert.IsType<ArgumentNullException>(exception);

        }

    }

}
