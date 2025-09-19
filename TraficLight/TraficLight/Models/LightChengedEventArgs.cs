namespace TraficLight.Models
{
    public class LightChengedEventArgs(TraficLightModel.TraficLight light) : EventArgs
    {
        public TraficLightModel.TraficLight Light { get; } = light;
    }
}
