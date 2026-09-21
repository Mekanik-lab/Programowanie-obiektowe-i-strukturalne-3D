namespace EventVsBindingMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            /*if (rotationSlider is not null)
                rotationLabel.Rotation = rotationSlider.Value;*/

            /*
            Slider slider = sender as Slider;
            if (slider is not null
                && rotationLabel is not null)
                rotationLabel.Rotation = slider.Value;

            */

            if (sender is Slider slider
                && rotationLabel is not null)
                rotationLabel.Rotation = slider.Value;
        }

    }
}