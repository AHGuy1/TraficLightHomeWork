using System.Diagnostics;
using System.Timers;
using TraficLight.Models;
using TraficLight.ViewModels;

namespace TraficLight.ModelsLogic
{
    public class TraficLight : TraficLightModel
    {
        public override string LightImage => lightImage.GetLightImage(currentState);
        public override string LightText => lightText.GetLighText(currentState);
        public override string SwitchAutoChangeLightText => isAutoChange ? Strings.StopAutoChangeLightText : Strings.StartAutoChangeLightText;
        public override Color LightTextColor => lightText.GetLightColor(currentState);

        public TraficLight()
        {
            timer.Elapsed += OnTimerElapsed;
        }
        public override void ChangeLight()
        {
            if (currentState == TraficLightState.Red)
                {
                currentState = TraficLightState.RedYellow;
                lights[(int)TraficLight.Yellow].IsOn = true;
                LightChanged?.Invoke(this, new LightChengedEventArgs(TraficLight.Yellow));
            }
            else if (currentState == TraficLightState.RedYellow)
            {
                currentState = TraficLightState.Green;
                lights[(int)TraficLight.Green].IsOn = true;
                lights[(int)TraficLight.Red].IsOn = false;
                lights[(int)TraficLight.Yellow].IsOn = false;

                foreach (TraficLight tl in Enum.GetValues<TraficLight>())
                    LightChanged?.Invoke(this, new LightChengedEventArgs(tl));
            }
            else if (currentState == TraficLightState.Green)
            {
                currentState = TraficLightState.Yellow;
                lights[(int)TraficLight.Yellow].IsOn = true;
                lights[(int)TraficLight.Green].IsOn = false;
                foreach (TraficLight tl in Enum.GetValues<TraficLight>())
                    if (tl != TraficLight.Red)
                        LightChanged?.Invoke(this, new LightChengedEventArgs(tl));
            }
            else if (currentState == TraficLightState.Yellow)
            {
                currentState = TraficLightState.Red;
                lights[(int)TraficLight.Yellow].IsOn = false;
                lights[(int)TraficLight.Red].IsOn = true;
                foreach (TraficLight tl in Enum.GetValues<TraficLight>())
                    if (tl != TraficLight.Green)
                        LightChanged?.Invoke(this, new LightChengedEventArgs(tl));
            }
            
        }
        public override void SwitchAutoChange()
        {
            isAutoChange = !isAutoChange;
            if (isAutoChange)
                timer.Start();
            else
                timer.Stop();
           
            
        }
        private void OnTimerElapsed(object? sender,ElapsedEventArgs e)
        {
            ChangeLight();
        }
        public override void SwitctChangeTime()
        {
            timer.Interval = ChangeTime * 1000;
        }
    }
}
