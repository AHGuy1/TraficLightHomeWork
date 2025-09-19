using static TraficLight.Models.TraficLightModel;

namespace TraficLight.Models
{
    public abstract class LightImageModel
    {
        protected string[] lightImages = ["crysmiley.jpg", "thinksmile.jpg", "thinksmile2.jpg", "happeysmile.jpg"];
        public abstract string GetLightImage(TraficLightState tls);
    }
}
