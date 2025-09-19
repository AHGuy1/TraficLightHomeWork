using TraficLight.Models;

namespace TraficLight.ModelsLogic
{
    public class LightText : LightTextModel
    {
        public override Color GetLightColor(TraficLightModel.TraficLightState tls)
        {
            return lightTextColors[(int)tls];
        }
        public override string GetLighText(TraficLightModel.TraficLightState tls)
        {
            return lightTexts[(int)tls];
        }
    }
}
