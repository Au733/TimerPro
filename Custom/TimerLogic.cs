namespace TimerPro.Custom;

public class TimerLogic
{
    // creating variables
    private int _intSec;
    private int _intMin;
    private int _intHours;
    
    // TimerLogic method calling Rest method
    public TimerLogic()
    {
        Reset();
    }

    // Reset method
    public void Reset()
    {
        _intSec = 0;
        _intMin = 0;
        _intHours = 0;
    }

    // counter method
    public void SetTickCount()
    {
        _intSec++;
        if (_intSec == 60)
        {
            _intMin++;
            _intSec = 0;
            if (_intMin == 60)
            {
                _intHours++;
                _intMin = 0;
            }
        }
    }

    public string GetFormattedString()
    {
        return _intHours.ToString().PadLeft(2,'0') + ":" + _intMin.ToString().PadLeft(2,'0') + ":" + _intSec.ToString().PadLeft(2,'0');
    }
    
}