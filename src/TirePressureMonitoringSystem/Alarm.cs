namespace RefactorMircoExcercise.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly ISensor _sensor;

        bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor ?? throw new ArgumentNullException(nameof(sensor));
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
