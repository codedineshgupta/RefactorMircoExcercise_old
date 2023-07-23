using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMircoExcercise.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Check_WhenPressure_is_Below_LowThreshold_Should_SetAlarmOn()
        {
            // Arrange
            var mockSensor = new Mock<Sensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(15); // Below LowPressureThreshold
            var alarm = new Alarm();

            // Use reflection to set the private field "_sensor" to the mocked sensor
            var sensorField = alarm.GetType().GetField("_sensor", BindingFlags.NonPublic | BindingFlags.Instance);
            sensorField.SetValue(alarm, mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }
        
    }
}
