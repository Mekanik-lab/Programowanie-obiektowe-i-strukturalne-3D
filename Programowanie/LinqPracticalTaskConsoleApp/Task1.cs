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

        var q1 = people.Where(p => p.City == "Kraków");
        Print("Zadanie 1", q1);

        var q2 = people.Where(p => p.Age > 18);
        Print("Zadanie 2", q2);

        var q3 = people.OrderBy(p => p.Age);
        Print("Zadanie 3", q3);

        var q4 = people.OrderByDescending(p => p.LastName);
        Print("Zadanie 4", q4);

        var q5 = people.Select(p => new { FirstName = p.FirstName, LastName = p.LastName });
        Print("Zadanie 5", q5);

        var q6 = people.Select(p => p.City).Distinct();
        Print("Zadanie 6", q6);

        var q7 = people.Count(p => p.City == "Warszawa");
        Console.WriteLine($"\nZadanie 7\nLiczba osób: {q7}");

        var q8 = people.Average(p => p.Salary);
        Console.WriteLine($"\nZadanie 8\nŚrednia pensja: {q8}");

        var minAge = people.Min(p => p.Age);
        var q9 = people.Where(p => p.Age == minAge);
        Print("Zadanie 9", q9);

        var q10 = people.Any(p => p.City == "Gdańsk");
        Console.WriteLine($"\nZadanie 10\nCzy jest ktoś z Gdańska: {q10}");

        // === POZIOM 2 ===

        var q11 = people.OrderBy(p => p.City).ThenByDescending(p => p.Salary);
        Print("Zadanie 11", q11);

        var q12 = people.Where(p => p.Age >= 25 && p.Age <= 35);
        Print("Zadanie 12", q12);

        var q13 = people.Where(p => p.City == "Kielce").Sum(p => p.Salary);
        Console.WriteLine($"\nZadanie 13\nSuma pensji osób z kielc: {q13}");

        var q14 = people.FirstOrDefault(p => p.Salary > 10000);
        Print("Zadanie 14", new[] { q14 });

        var q15 = people.OrderBy(p => p.LastName).Last();
        Print("Zadanie 15", new[] { q15 });

        var q16 = people.Select(p => $"{p.FirstName} {p.LastName} ({p.City})");
        Print("Zadanie 16", q16);

        var q17 = people.All(p => p.Age > 18);
        Console.WriteLine($"\nZadanie17\nCzy każdy ma 18 lat: {q17}");

        var q18 = people.Count(p => p.Gender == Gender.Female);
        Console.WriteLine($"Liczba kobiet: {q18}");

        var averageSalary = people.Average(p => p.Salary);
        var q19 = people.Where(p => p.Salary > averageSalary);
        Print("Zadanie 19", q19);

        var maxAge = people.Max(p => p.Age);
        var q20 = people.Where(p => p.Age == maxAge && p.City == "Kraków");
        Print("Zadanie 20", q20);

        // === POZIOM 3 ===

        var q21 = people.Where(p => p.Skills.Contains("C#"));
        Print("Zadanie 21", q21);

        var q22 = people.Where(p => p.Skills.Count() > 3);
        Print("Zadanie 22", q22);

        var q23 = people.Where(p => p.City == "Warszawa")
            .Select(p => new
            {
                p.FirstName,
                p.LastName,
                p.Age,
                p.Salary
            })
            .OrderByDescending(p => p.Age);
        Print("Zadanie 23", q23);

        var q24 = people.Where(p => p.Skills.Contains("Azure"));
        Print("Zadanie 24", q24);

        var q25 = people.All(p => p.Salary > 4000);
        Console.WriteLine($"\nZadanie 25\nCzy wszyscy zarabiają conajmniej 4000: {q25}");

        var maxSalary = people.Max(p => p.Salary);
        var q26 = people.Where(p => p.Salary == maxSalary);
        Print("Zadanie 26", q26);

        var minSalary = people.Min(p => p.Salary);
        var q27 = people.Where(p => p.Salary == minSalary);
        Print("Zadanie 27", q27);

        var q28 = people.Where(p => p.Age == maxAge);
        Print("Zadanie 28", q28);

        // === POZIOM 4 ===

        var q29 = people.OrderBy(p => p.Skills.Count());
        Print("Zadanie 29", q29);

        var q30 = people.Where(p => p.Salary < 8000).ToList();
        var q30_2 = people.Where(p => p.Salary > 8000).ToList();
        Print("Zadanie 30", q30);
        Print("", q30_2);
    }
}