using OrderCostCalculatorMauiAppMauiApp.Data;
using System.Collections.ObjectModel;

namespace OrderCostCalculatorMauiAppMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Shipping> ShippingOption { get; set; }
        private Shipping selectedShipping;
        public Shipping SelectedShipping
        {
            get { return selectedShipping; }
            set
            {
                selectedShipping = value;
                OnPropertyChanged();
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged();
            }
        }

        private double productPrice;
        public double ProductPrice
        {
            get { return productPrice; }
            set
            {
                productPrice = value; 
                OnPropertyChanged();
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value; 
                OnPropertyChanged();
            }
        }

        private string summaryCalculate;
        public string SummaryCalculate
        {
            get { return summaryCalculate; }
            set
            {
                summaryCalculate = value;
                OnPropertyChanged();
            }
        }

        public void CalculateCosts()
        {
            double productCost = Quantity * ProductPrice;
            double shippingCost = SelectedShipping.Price;
            double totalCost = productCost + shippingCost;

            if(!string.IsNullOrWhiteSpace(productName) &&
                SelectedShipping is not null)
            {
                SummaryCalculate =
                    $"Produkt: {ProductName}\n" +
                    $"Cena za sztukę: {ProductPrice}\n" +
                    $"Liczba sztuk: {Quantity}\n" +
                    $"Dostawa: {SelectedShipping.Name}\n" +
                    $"Wynik: {totalCost}";
            } else
            {
                SummaryCalculate = "Wprowadź poprawne dane.";
            }
        }

        private Command calculate;
        public Command Calculate
        {
            get
            {
                if(calculate == null)
                {
                    calculate = new Command(CalculateCosts);
                }

                return calculate;
            }
        }

        public MainPage()
        {
            ShippingOption = new ObservableCollection<Shipping>
            {
                new Shipping
                {
                    Name = "Odbiór osobisty - 0 zł",
                    Price = 0
                },

                new Shipping
                {
                    Name = "Kurier - 12 zł",
                    Price = 12
                },

                new Shipping
                {
                    Name = "Paczkomat - 10 zł",
                    Price = 10
                }
            };

            Quantity = 1;
            SelectedShipping = ShippingOption.First();
            InitializeComponent();
        }
    }
}
