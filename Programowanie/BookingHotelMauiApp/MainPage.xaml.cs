using System.Collections.ObjectModel;
using BookingHotelMauiApp.Data;

namespace BookingHotelMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Room> RoomType { get; set; }

        private Room selectedRoom;

        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set
            {
                selectedRoom = value;

                if (selectedRoom.Name.Contains("jednoosobowy"))
                {
                    MaxGuests = 1;
                }
                else if (selectedRoom.Name.Contains("dwuosobowy"))
                {
                    MaxGuests = 2;
                }
                else if (selectedRoom.Name.Contains("Apartament"))
                {
                    MaxGuests = 4;
                }

                if (GuestsCount > MaxGuests)
                {
                    GuestsCount = MaxGuests;
                }


                OnPropertyChanged();
            }
        }

        private int maxGuests;

        public int MaxGuests
        {
            get { return maxGuests; }
            set
            {
                maxGuests = value;
                OnPropertyChanged();
            }
        }


        private DateTime minimumDate;

        public DateTime MinimumDate
        {
            get { return minimumDate; }
            set
            {
                minimumDate = value;
                OnPropertyChanged();
            }
        }

        private int nightCount;

        public int NightCount
        {
            get { return nightCount; }
            set
            {
                nightCount = value;
                OnPropertyChanged();
            }
        }

        private int guestsCount;

        public int GuestsCount
        {
            get { return guestsCount; }
            set
            {
                guestsCount = value;
                OnPropertyChanged();
            }
        }

        private bool isBreakfast;

        public bool IsBreakfast
        {
            get { return isBreakfast; }
            set
            {
                isBreakfast = value;
                OnPropertyChanged();
            }
        }

        private bool isParking;

        public bool IsParking
        {
            get { return isParking; }
            set
            {
                isParking = value;
                OnPropertyChanged();
            }
        }

        public string FullName { get; set; }
        public string EmailAdress { get; set; }

        private DateTime arrivalDate;

        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set
            {
                arrivalDate = value;
                OnPropertyChanged();
            }
        }

        private string summaryText;

        public string SummaryText
        {
            get { return summaryText; }
            set
            {
                summaryText = value;
                OnPropertyChanged();
            }
        }

        public void CreateSummary()
        {
            if (!string.IsNullOrWhiteSpace(FullName) &&
                !string.IsNullOrWhiteSpace(EmailAdress) &&
                SelectedRoom is not null)
            {
                double roomCost = NightCount * SelectedRoom.Price;

                double breakfastCost = 0;

                if (IsBreakfast)
                {
                    breakfastCost = NightCount * GuestsCount * 40;
                }

                double parkingCost = 0;

                if (IsParking)
                {
                    parkingCost = NightCount * 30;
                }

                double totalCost = roomCost + breakfastCost + parkingCost;

                string breakfast = IsBreakfast ? "Tak" : "Nie";
                string parking = IsParking ? "Tak" : "Nie";

                SummaryText =
                    $"Imię i nazwisko: {FullName}\n" +
                    $"Data przyjazdu: {ArrivalDate:dd.MM.yyyy}\n" +
                    $"Liczba nocy: {NightCount}\n" +
                    $"Liczba osób: {GuestsCount}\n" +
                    $"Pokój: {SelectedRoom.Name}\n" +
                    $"Śniadanie: {breakfast}\n" +
                    $"Parking: {parking}\n" +
                    $"Koszt pokoju: {NightCount} x {SelectedRoom.Price} zł = {roomCost} zł\n" +
                    $"Koszt śniadania: {NightCount} x {GuestsCount} x 40 zł = {breakfastCost} zł\n" +
                    $"Koszt parkingu: {NightCount} x 30 zł = {parkingCost} zł\n" +
                    $"Łączny koszt: {totalCost} zł";
            }
            else
            {
                SummaryText = "Wprowadź poprawne dane.";
            }
        }

        private Command summary;

        public Command Summary
        {
            get
            {
                if (summary == null)
                {
                    summary = new Command(CreateSummary);
                }

                return summary;
            }
        }

        public MainPage()
        {
            RoomType = new ObservableCollection<Room>
            {
                new Room
                {
                    Name = "Pokój jednoosobowy - 200zł / noc",
                    Price = 200
                },

                new Room
                {
                    Name = "Pokój dwuosobowy - 300zł / noc",
                    Price = 300
                },

                new Room
                {
                    Name = "Apartament - 500zł / noc",
                    Price = 500
                }
            };

            SelectedRoom = RoomType.First();
            MinimumDate = DateTime.Today;
            ArrivalDate = DateTime.Today;
            NightCount = 1;
            GuestsCount = 1;
            MaxGuests = 1;

            InitializeComponent();
        }
    }
}
