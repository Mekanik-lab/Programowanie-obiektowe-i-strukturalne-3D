/*
Zadanie – Wypożyczalnia sprzętu sportowego

Napisz aplikację w .NET MAUI, która oblicza koszt wypożyczenia
wybranego sprzętu. Całość umieść na jednej stronie MainPage,
bez nawigacji.

Przygotuj w programie kolekcję sprzętu:
- Rower – 40 zł za dzień,
- Hulajnoga – 30 zł za dzień,
- Rolki – 20 zł za dzień,
- Kajak – 50 zł za dzień.

Aplikacja powinna zawierać:
- listę sprzętu – CollectionView z możliwością wyboru jednej pozycji;
 każdy element wyświetla nazwę sprzętu i cenę za dzień,
- imię i nazwisko klienta – Entry,
- liczbę dni wypożyczenia – Stepper od 1 do 7,
- Label pokazujący aktualną liczbę dni,
- ubezpieczenie – CheckBox,
- przycisk „Oblicz koszt”,
- Label wyświetlający podsumowanie.

Aktualna liczba dni powinna być wyświetlana za pomocą bindingu,
tak aby zmieniała się automatycznie wraz z wartością Steppera.

Ubezpieczenie kosztuje dodatkowo 5 zł za każdy dzień wypożyczenia.

Po naciśnięciu przycisku oblicz koszt i wyświetl:
- imię i nazwisko klienta,
- nazwę wybranego sprzętu,
- liczbę dni,
- informację o ubezpieczeniu,
- łączny koszt wypożyczenia.

Przed obliczeniem sprawdź, czy podano imię i nazwisko oraz wybrano
sprzęt. W razie brakujących danych wyświetl odpowiedni komunikat.

Przykład:
Klient: Jan Kowalski
Sprzęt: Rower
Liczba dni: 3
Ubezpieczenie: TAK
Koszt sprzętu: 3 × 40 zł = 120 zł
Ubezpieczenie: 3 × 5 zł = 15 zł
Łącznie: 135 zł
*/

using SportsEquipmentRentalMauiApp.Data;
using System.Collections.ObjectModel;

namespace SportsEquipmentRentalMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Equipment> Equipment { get; set; }

        private Equipment selectedEquipment;

        public Equipment SelectedEquipment
        {
            get
            {
                return selectedEquipment;
            }

            set
            {
                selectedEquipment = value;
                OnPropertyChanged();
            }
        }

        private string fullName;

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
                OnPropertyChanged();
            }
        }

        private short dayCount;

        public short DayCount
        {
            get
            {
                return dayCount;
            }

            set
            {
                dayCount = value;
                OnPropertyChanged();
            }
        }

        private bool isInsured;
        
        public bool IsInsured
        {
            get
            {
                return isInsured;
            }

            set
            {
                isInsured = value;
                OnPropertyChanged();
            }
        }

        private string summaryText;

        public string SummaryText
        {
            get
            {
                return summaryText;
            }
            set
            {
                summaryText = value;
                OnPropertyChanged();
            }
        }

        public void CreateSummary()
        {
            if(!string.IsNullOrWhiteSpace(FullName) &&
               SelectedEquipment is not null)
            {
                double equipmentCost = DayCount * SelectedEquipment.Price;

                double insuranceCost = 0;

                if(IsInsured)
                {
                    insuranceCost = DayCount * 5;
                }

                string insurance = IsInsured ? "Tak" : "Nie";

                double totalCost = equipmentCost + insuranceCost;

                SummaryText = 
                    $"Klient: {FullName}\n" +
                    $"Sprzęt: {SelectedEquipment.Name}\n" +
                    $"Liczba dni: {DayCount}\n" +
                    $"Ubezpieczenie: {insurance}\n" +
                    $"Koszt sprzętu: {DayCount} x {SelectedEquipment.Price}zł = {equipmentCost}zł\n" +
                    $"Ubezpieczenie: {DayCount} x 5zł = {insuranceCost}zł\n" +
                    $"Łącznie: {totalCost}zł";
            } else
            {
                SummaryText = "Wprowadź poprawne dane";
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
            Equipment = new ObservableCollection<Equipment>
            {
                new Equipment
                {
                    Name = "Rower - 40zł/dzień",
                    Price = 40
                },

                new Equipment
                {
                    Name = "Hulajnoga - 30zł/dzień",
                    Price = 30
                },

                new Equipment
                {
                    Name = "Rolki - 20zł/dzień",
                    Price = 20
                },

                new Equipment
                {
                    Name = "Kajak - 50zł/dzień",
                    Price = 50
                }
            };

            InitializeComponent();
            SelectedEquipment = Equipment.First();
            DayCount = 1;
        }
    }
}
