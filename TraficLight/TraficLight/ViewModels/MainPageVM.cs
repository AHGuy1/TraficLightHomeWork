using System.Diagnostics;
using System.Windows.Input;
using TraficLight.Models;
using TraficLight.ViewModels;

namespace TraficLight.ViewModels
{
    class MainPageVM:ObservableObject
    {
        private ModelsLogic.TraficLight tl = new ();
        public ICommand ChangeLightCommand { get => new Command(ChangeLight); }
        public ICommand SwitchAutoChangeCommand { get => new Command(SwitchAutoChange); }
        public ICommand ChangeSwitchTime { get => new Command(SwitctChangeTime); }
        public double SwitchTimeSeconds { get => tl.ChangeTime; set => tl.ChangeTime = value; }
        public Color RedColor => tl.RedColor;
        public Color YellowColor => tl.YellowColor;
        public Color GreenColor => tl.GreenColor;
        public string LightImage => tl.LightImage;
        public string LightText => tl.LightText;
        public Color LightTextColor => tl.LightTextColor;
        public string SwitchAutoChangeLightText => tl.SwitchAutoChangeLightText;

        private void ChangeLight()
        {
            tl.ChangeLight();
        }

        private void SwitchAutoChange()
        {
            tl.SwitchAutoChange();
            OnPropertyChanged(nameof(SwitchAutoChangeLightText));
        }
        private void SwitctChangeTime()
        {
            tl.SwitctChangeTime();
        }

        public MainPageVM()
        {
            tl.LightChanged += OnLightChanged;
        }

        private void OnLightChanged(object? sender, LightChengedEventArgs e)
        {
            ColorChanged(e.Light);
        }

        private void ColorChanged(TraficLightModel.TraficLight light)
        {
            switch(light)
            {
                case TraficLightModel.TraficLight.Red:
                    OnPropertyChanged(nameof(RedColor));
                    break;
                case TraficLightModel.TraficLight.Yellow:
                    OnPropertyChanged(nameof(YellowColor));
                    break;
                case TraficLightModel.TraficLight.Green:
                    OnPropertyChanged(nameof(GreenColor));
                    break;
            }
            OnPropertyChanged(nameof(LightImage));
            OnPropertyChanged(nameof(LightText));
            OnPropertyChanged(nameof(LightTextColor));


        }
    }
}
