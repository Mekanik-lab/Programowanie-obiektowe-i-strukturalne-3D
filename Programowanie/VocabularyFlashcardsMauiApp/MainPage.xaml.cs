using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VocabularyFlashcardsMauiApp.Data;

namespace VocabularyFlashcardsMauiApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Flashcard> Flashcards { get; set; }

        private string translation = string.Empty;
        public string Translation
        {
            get
            {
                return translation;
            }
            set
            {
                translation = value;
                OnPropertyChanged();
            }
        }

        private bool isTranslationVisible;
        public bool IsTranslationVisible
        {
            get
            {
                return isTranslationVisible;
            }
            set
            {
                isTranslationVisible = value;
                OnPropertyChanged();
            }
        }

        public Command ShowTranslation { get; }
        public Command Restart { get; }

        public MainPage()
        {
            Flashcards = new ObservableCollection<Flashcard>
            {
                new Flashcard { EnglishWord = "Apple", PolishWord = "Jabłko" },
                new Flashcard { EnglishWord = "House", PolishWord = "Dom" },
                new Flashcard { EnglishWord = "Dog", PolishWord = "Pies" },
                new Flashcard { EnglishWord = "Book", PolishWord = "Książka" },
                new Flashcard { EnglishWord = "Bike", PolishWord = "Rower" }
            };

            ShowTranslation = new Command(() =>
            {
                if (FlashcardsCarousel.CurrentItem is Flashcard flashcard)
                {
                    Translation = flashcard.PolishWord;
                    IsTranslationVisible = true;
                }
            });

            Restart = new Command(() =>
            {
                FlashcardsCarousel.Position = 0;
                Translation = string.Empty;
                IsTranslationVisible = false;
            });

            InitializeComponent();
            BindingContext = this;

            FlashcardsCarousel.IndicatorView = FlashCardIndicators;
        }

        private void FlashcardsCarousel_PositionChanged(
            object sender, PositionChangedEventArgs e)
        {
            Translation = string.Empty;
            IsTranslationVisible = false;
        }
    }
}