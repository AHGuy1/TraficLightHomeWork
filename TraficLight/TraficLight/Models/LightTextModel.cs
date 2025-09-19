using static TraficLight.Models.TraficLightModel;

namespace TraficLight.Models
{
    public abstract class LightTextModel
    {
        protected string[] lightTexts = ["STOP", "GET READY", "SLOW DOWN", "GO"];
        protected Color[] lightTextColors = [Colors.Red, Colors.Orange, Colors.Yellow, Colors.Green];
        public abstract string GetLighText(TraficLightState tls);
        public abstract Color GetLightColor(TraficLightState tls);
    }
}
