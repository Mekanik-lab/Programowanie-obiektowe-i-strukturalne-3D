namespace LinqPracticalTasksConsoleApp;

/*
========================================
== POZIOM 1 – PODSTAWOWY ==
========================================

1. Znajdź wszystkie osoby z Krakowa.
2. Znajdź osoby pełnoletnie.
3. Posortuj osoby po wieku rosnąco.
4. Posortuj osoby po nazwisku malejąco.
5. Wypisz tylko imię i nazwisko każdej osoby.
6. Wypisz tylko miasta bez duplikatów.
7. Oblicz liczbę osób z Warszawy.
8. Oblicz średnią pensję wszystkich osób.
9. Znajdź najmłodszą osobę.
10. Sprawdź, czy jest ktoś z Gdańska.


========================================
== POZIOM 2 – ŚREDNI ==
========================================

11. Posortuj osoby po mieście, a w ramach miasta po pensji malejąco.
12. Znajdź osoby w wieku od 25 do 35 lat (włącznie).
13. Oblicz sumę pensji osób z Kielc.
14. Znajdź pierwszą osobę, której pensja jest większa niż 10 000.
15. Znajdź ostatnią osobę w kolejności alfabetycznej po nazwisku.
16. Wygeneruj dane osób w formacie: "Imię Nazwisko (Miasto)".
17. Sprawdź, czy wszyscy mają co najmniej 18 lat.
18. Policz, ile jest kobiet.
19. Znajdź osoby, które zarabiają więcej niż średnia pensja.
20. Znajdź najstarszą osobę z Krakowa.


========================================
== POZIOM 3 – ZAAWANSOWANY ==
========================================

21. Znajdź osoby, które mają skill "C#".
22. Znajdź osoby, które mają co najmniej trzy skille.
23. Znajdź osoby z Warszawy, posortuj je po wieku malejąco i wypisz tylko ich imię, nazwisko, wiek i pensję.
24. Sprawdź, czy ktoś ma skill "Azure".
25. Sprawdź, czy wszyscy zarabiają co najmniej 4000.
26. Znajdź osobę o największej pensji.
27. Znajdź osobę o najmniejszej pensji.
28. Wypisz osoby, które mają taki sam wiek jak najstarsza osoba.


========================================
== POZIOM 4 – EKSTRA / DLA CHĘTNYCH ==
========================================

29. Posortuj osoby według liczby posiadanych skilli.
30. Podziel osoby na dwie listy: zarabiających przynajmniej 8000 oraz zarabiających mniej niż 8000.
31. Przyporządkuj każdą osobę do przedziału wiekowego (np. 20–29, 30–39, 40–49) i wypisz osoby z każdego przedziału.

*/

internal class Task1
{
    void Print<T>(string title, IEnumerable<T> data)
    {
        Console.WriteLine($"\n=== {title} ===");
        foreach (var item in data)
            Console.WriteLine(item);
    }

    public void DoTasks()
    {
        var people = new List<Person>
        {
            new Person() { Id=1, FirstName="Anna",  LastName="Nowak",    Age=29, Gender=Gender.Female, City="Kielce", Salary=8200m,  Skills=["C#", "LINQ", "SQL"] },
            new() { Id=2, FirstName="Marek", LastName="Kowalski", Age=43, Gender=Gender.Male,   City="Warszawa", Salary=15000m, Skills=["Azure", "C#", "DevOps"] },
            new() { Id=3, FirstName="Ewa",   LastName="Wiśniewska",Age=35, Gender=Gender.Female, City="Kraków", Salary=9800m,  Skills=["JavaScript", "React"] },
            new() { Id=4, FirstName="Jan",   LastName="Zieliński", Age=43, Gender=Gender.Male,   City="Gdańsk", Salary=12000m, Skills=["C#", "SQL"] },
            new() { Id=5, FirstName="Ola",   LastName="Maj",       Age=26, Gender=Gender.Female, City="Kielce", Salary=7200m,  Skills=["Python", "ML"] },
            new() { Id=6, FirstName="Piotr", LastName="Lewandowski",Age=37,Gender=Gender.Male,   City="Warszawa", Salary=13400m, Skills=["C#", "LINQ", "Azure"] },
            new() { Id=7, FirstName="Iga",   LastName="Kowal",     Age=31, Gender=Gender.Female, City="Kraków", Salary=9900m,  Skills=["Go", "Kubernetes"] },
            new() { Id=8, FirstName="Tomek", LastName="Sikora",    Age=29, Gender=Gender.Male,   City="Kielce", Salary=8800m,  Skills=["C#", "MAUI", "Bluetooth"] },
        };

        // === POZIOM 1 ===

        // Zadanie 1
        var q1 = people.Where(p => p.City == "Kraków");
        Print("Zadanie 1", q1);

    }
}