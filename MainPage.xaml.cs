using TimerPro.Custom;

namespace TimerPro;

public partial class MainPage : ContentPage
{
    
    TimerLogic oTimer = new TimerLogic();
    private bool isRunning = false;
    
    public MainPage()
    {
        InitializeComponent();
        Title = "Timer Pro";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        btnStart.IsEnabled = true;
        btnStop.IsEnabled = false;
    }

    private void BtnStart_OnClicked(object sender, EventArgs e)
    {
        btnStart.IsEnabled = false;
        btnStop.IsEnabled = true;
        isRunning = true;
        
        // recurring timer that is going to tick every second
        Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            // if isRunning is true continue to update timer and if isRunning is not true stop timer 
            if (isRunning)
            {
                // timer is going to count
                oTimer.SetTickCount();
                // to display the timer count
                lblDisplay.Text = oTimer.GetFormattedString();
            }
            
            return isRunning;
        });
    }

    private void BtnStop_OnClicked(object sender, EventArgs e)
    {
        btnStop.IsEnabled = false;
        btnStart.IsEnabled = true;
        isRunning = false;
    }

    private void BtnReset_OnClicked(object sender, EventArgs e)
    {
        // rest timer to all zeros
        oTimer.Reset();
        lblDisplay.Text = oTimer.GetFormattedString();
    }
}