namespace SimpleBindingCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        private int result;

        public int Result
        {
            get
            {
                return result;

            }

            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Result = FirstNumber + SecondNumber;
        }
    }
}
