using System.Diagnostics;
using TraficLight.ModelsLogic;

namespace TraficLight.Models
{
    public abstract class TraficLightModel
    {
        public enum TraficLightState
        {
            Red,
            RedYellow,
            Yellow,
            Green
        }
        public enum TraficLight
        {
            Red,
            Yellow,
            Green
        }
        protected System.Timers.Timer timer  = new(1000);
        protected TraficLightState currentState = TraficLightState.Red;
        protected Light[] lights = [new Light(Colors.Red,true), new Light(Colors.Yellow, false), new Light(Colors.Green, false)];
        protected bool isAutoChange = false;
        protected LightImage lightImage = new();
        protected LightText lightText = new();  
        public EventHandler<LightChengedEventArgs>? LightChanged;
        public Color RedColor => lights[(int)TraficLight.Red].Color;
        public Color YellowColor => lights[(int)TraficLight.Yellow].Color;
        public Color GreenColor => lights[(int)TraficLight.Green].Color;
        public abstract string LightImage {  get; }
        public abstract string LightText { get; }
        public abstract Color LightTextColor { get; }
        public abstract string SwitchAutoChangeLightText { get; }
        public double ChangeTime { get; set; } = 1;
        public abstract void ChangeLight();
        public abstract void SwitchAutoChange();
        public abstract void SwitctChangeTime();
    }
}
