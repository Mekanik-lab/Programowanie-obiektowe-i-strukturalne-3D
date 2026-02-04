

//c++
//typ nazwa[rozmiar];
//nazwa[numerKomórki] = wartość;

//C#
//typ[] nazwa = new typ[rozmiar];

int[] tab = new int[10];
tab[3] = 45;

int[] tab2 = new int[20];
//przepisać z tab do tab2
tab = tab2;

string[] tab3 = { "Ala", "Ola", "Ula", "Ela", "Tola" };
//int length = 5;
string[] tab4 = ["Ala", "Ola", "Ula"]; //.net8 C#12

for (int i = 0; i < tab3.Length; i++)
    Console.WriteLine(tab3[i]);

//tab3[9] = "ABCD"; //BŁĄD

List<int> firstList = new List<int>();
firstList.Add(5);
firstList.Add(68);
firstList.Add(7);
firstList.Add(45);

firstList[1] = 78;
//firstList[8] = 99;

Console.WriteLine("Zawartość pierwszej kolekcji:");
for (int i = 0; i < firstList.Count; i++)
{
    Console.WriteLine(firstList[i]);
}

firstList.Clear();

int number;
do
{
    Console.WriteLine("Podaj liczbę:");
    number = int.Parse(Console.ReadLine());
    firstList.Add(number);
} while (number != 0);

Console.WriteLine("Zawartość kolekcji z liczbami użytkownika:");
for (int i = 0; i < firstList.Count; i++)
{
    Console.WriteLine(firstList[i]);
}

Console.WriteLine("Zawartość kolekcji z liczbami użytkownika:");
foreach (int num in firstList)
{
    Console.WriteLine(num);
}

firstList.Insert(1, 5);

Console.WriteLine("Zawartość kolekcji z liczbami użytkownika:");
foreach (int num in firstList)
{
    Console.WriteLine(num);
}

firstList.Remove(5);
Console.WriteLine("Zawartość kolekcji z liczbami użytkownika:");
foreach (int num in firstList)
{
    Console.WriteLine(num);
}

//wersja 1
List<string> words = new List<string>();
List<string> definictions = new List<string>();

words.Add("Kwadrat");
definictions.Add("czworokąt foremny, czyli z przystającymi bokami i kątami wewnętrznymi (a stąd prostymi)");

words.Add("Romb");
definictions.Add("rzadziej ukośnik – czworokąt o bokach równej długości");

Console.WriteLine("Słownik wersja 1");
for (int i = 0; i < words.Count; i++)
    Console.WriteLine($"{words[i]} - {definictions[i]}");


//wersja 2
List<WordDefinition> wordDefinitions = new List<WordDefinition>();

wordDefinitions.Add(new WordDefinition() { Word = "Kwadrat", Definition = "czworokąt foremny, czyli z przystającymi bokami i kątami wewnętrznymi (a stąd prostymi)" });
wordDefinitions.Add(new WordDefinition() { Word = "Romb", Definition = "rzadziej ukośnik – czworokąt o bokach równej długości" });

WordDefinition wordDefinition = new WordDefinition() { Word = "Kwadrat", Definition = "czworokąt foremny, czyli z przystającymi bokami i kątami wewnętrznymi (a stąd prostymi)" };
wordDefinitions.Add(wordDefinition);
wordDefinition.Word = "Inny";

Console.WriteLine("Słownik wersja 2");
foreach (WordDefinition item in wordDefinitions)
    Console.WriteLine($"{item.Word} - {item.Definition}");

//wersja 3
Dictionary<string, string> kolekcja = new Dictionary<string, string>();
kolekcja.Add("Prostokąt", "definicja prostokąta");
kolekcja.Add("Kwadrat", "definicja kwadratu");

Console.WriteLine("Słownik wersja 3");
foreach (var item in kolekcja)
    Console.WriteLine($"{item.Key} - {item.Value}");

if (kolekcja.ContainsKey("Romb"))
{
    kolekcja["Romb"] = "nowa definicja rombu";
}
else
    kolekcja.Add("Romb", "definicja rombu");

//kolekcja["Prostokąt"] = "definicja prostokąta";
//kolekcja["Kwadrat"] = "definicja kwadratu";


class WordDefinition
{
    public string Word { get; set; }
    public string Definition { get; set; }
}

/*
1) Podstawy
T[] (tablica)

Jak przechowuje: ciągły blok pamięci o stałym rozmiarze.
Operacje: indeksowanie O(1), zmiana rozmiaru – brak (tworzenie nowej tablicy).
Uporządkowanie: zachowuje kolejność.
Duplikaty: dozwolone.
Kiedy używać: stała liczba elementów, maksymalna wydajność i minimalny narzut; dostęp przez indeks.

List<T>

Jak przechowuje: dynamiczna tablica (automatyczne powiększanie).
Operacje: indeksowanie O(1), dodanie na końcu amortyzacyjnie O(1), wstawki/usuń w środku O(n), wyszukiwanie liniowe O(n) (chyba że wcześniej posortujesz i użyjesz BinarySearch).
Uporządkowanie: zachowuje kolejność dodawania.
Duplikaty: dozwolone.
Kiedy używać: najczęstsza domyślna kolekcja; gdy potrzebujesz listy o zmiennym rozmiarze.

LinkedList<T>

Jak przechowuje: dwukierunkowa lista wiązana.
Operacje: dodawanie/usuwanie mając węzeł O(1), wyszukiwanie O(n), brak indeksowania O(1).
Uporządkowanie: zachowuje kolejność.
Duplikaty: dozwolone.
Kiedy używać: dużo wstawek/usunięć w środku bez przesuwania pamięci; rzadko w praktyce, bo List<T> bywa szybsza dzięki spójności pamięci.

2) Słowniki i mapy (klucz ? wartość)
Dictionary<TKey,TValue>

Jak przechowuje: tablica z haszowaniem (hash table).
Operacje: dodaj/odczytaj/usuń O(1) średnio.
Uporządkowanie: brak gwarancji kolejności.
Duplikaty: klucze unikalne, wartości mogą się powtarzać.
Kiedy używać: szybki dostęp po kluczu (lookup cache, indeksy).

SortedDictionary<TKey,TValue>

Jak przechowuje: drzewo BST (zbalansowane).
Operacje: O(log n) dla wstaw/odczyt/usuń; łatwy dostęp do zakresów.
Uporządkowanie: posortowane po kluczu (komparer).
Kiedy używać: potrzebujesz danych w kolejności lub operacji „range”.

SortedList<TKey,TValue>

Jak przechowuje: dwie posortowane tablice (klucze i wartości).
Operacje: odczyt po indeksie O(1), wyszukiwanie O(log n), wstawka O(n) (przesunięcia).
Kiedy używać: małe/średnie zbiory, częsty odczyt, rzadsze wstawki, i dostęp po indeksie.

3) Zbiory (bez duplikatów)
HashSet<T>

Jak przechowuje: hash set.
Operacje: dodaj/sprawdź O(1) średnio; przecięcia/łącznie – efektywne.
Uporządkowanie: brak.
Duplikaty: niedozwolone.
Kiedy używać: obecność elementu, operacje na zbiorach.

SortedSet<T>

Jak przechowuje: drzewo BST.
Operacje: O(log n); wspiera zakresy i kolejność.
Uporządkowanie: posortowane.
Duplikaty: niedozwolone.
Kiedy używać: potrzebujesz zbioru z kolejnością lub operacji zakresowych.

4) Kolejki i stosy (struktury FIFO / LIFO)
Queue<T>

Jak przechowuje: kołowa kolejka (array-backed).
Operacje: Enqueue/Dequeue O(1) amortyzacyjnie.
Uporządkowanie: FIFO.
Kiedy używać: buforowanie, przetwarzanie w kolejności przyjścia.

Stack<T>

Jak przechowuje: stos (array-backed).
Operacje: Push/Pop/Peek O(1).
Uporządkowanie: LIFO.
Kiedy używać: nawigacja, rekurencja, „cofanie”.


 */
