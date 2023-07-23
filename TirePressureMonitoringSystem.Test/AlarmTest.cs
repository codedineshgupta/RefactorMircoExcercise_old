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
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(15); // Below LowPressureThreshold
            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_WhenPressure_is_Above_HighThreshold_Should_SetAlarmOn()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(22); // Above HighPressureThreshold
            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_WhenPressure_is_WithinThreshold_Should_Not_Set_AlarmOn()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(18); // Within threshold
            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Check_WhenPressure_is_ExactlyAtLowThreshold_ShouldNot_Set_AlarmOn()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(17); // At LowPressureThreshold
            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Check_WhenPressure_is_ExactlyAtHighThreshold_Should_Not_SetAlarmOn()
        {
            // Arrange
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(21); // At HighPressureThreshold
            var alarm = new Alarm(mockSensor.Object);

            // Act
            alarm.Check();

            // Assert
            Assert.False(alarm.AlarmOn);
        }


    }
}
