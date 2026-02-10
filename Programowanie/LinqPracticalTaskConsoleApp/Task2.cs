namespace LinqPracticalTasksConsoleApp;

/*
========================================
== ZESTAW ZADAŃ – LINQ – KLASA ORDER ==
==      (zadania całkowicie nowe)     ==
========================================

POZIOM 1 – PODSTAWOWY
1. Wypisz wszystkie zamówienia o statusie „New”.
2. Sprawdź, czy istnieje zamówienie na produkt “Laptop”.
3. Wypisz zamówienia z ostatnich 30 dni.

POZIOM 2 – ŚREDNI
4. Wygeneruj listę tekstów w formacie: "Klient ? wartość zamówienia".
5. Znajdź zamówienia, w których nazwa produktu zawiera literę „o”.
6. Znajdź zamówienia mające wartość większą niż 1000 i status inny niż „Cancelled”.
7. Sprawdź, czy wszystkie zamówienia pochodzą z bieżącego roku.

POZIOM 3 – ZAAWANSOWANY
8. Znajdź zamówienia, gdzie klient zamówił więcej niż jeden różny produkt (czyli klient pojawia się więcej niż raz z różnymi produktami).
9. Wypisz klientów wraz z liczbą dni, które minęły od ich najstarszego zamówienia.
10. Wypisz wszystkie unikalne pary (Klient, Produkt).
11. Znajdź klientów, którzy mają co najmniej jedno zamówienie w statusie „Cancelled” ORAZ co najmniej jedno w statusie „Delivered”.
12. Wypisz zamówienia, których wartość mieści się pomiędzy 1000 a 3000 zł i zostały złożone w ciągu ostatnich 14 dni.
13. Znajdź klientów, którzy zamawiali ten sam produkt w różnych terminach.
14. Znajdź zamówienia, w których cena jednostkowa produktu jest wyższa niż łączna wartość jakiegokolwiek innego zamówienia.
*/


internal class Task2
{
    void Print<T>(string title, IEnumerable<T> data)
    {
        Console.WriteLine($"\n=== {title} ===");
        foreach (var item in data)
            Console.WriteLine(item);
    }

    public void DoTask()
    {
            var orders = new List<Order>
            {
                // Anna
                new() { Id = 1,  Customer="Anna", Product="Laptop",    Quantity=1, PricePerItem=4500m, OrderDate=DateTime.Today.AddDays(-20), Status=OrderStatus.New },
                new() { Id = 2,  Customer="Anna", Product="Myszka",    Quantity=2, PricePerItem=75m,   OrderDate=DateTime.Today.AddDays(-5),  Status=OrderStatus.Delivered },
                new() { Id = 3,  Customer="Anna", Product="Laptop",    Quantity=1, PricePerItem=4600m, OrderDate=DateTime.Today.AddDays(-2),  Status=OrderStatus.Shipped },

                // Piotr
                new() { Id = 4,  Customer="Piotr", Product="Monitor",   Quantity=1, PricePerItem=900m,  OrderDate=DateTime.Today.AddDays(-35), Status=OrderStatus.Delivered },
                new() { Id = 5,  Customer="Piotr", Product="Klawiatura",Quantity=1, PricePerItem=120m,  OrderDate=DateTime.Today.AddDays(-10), Status=OrderStatus.Cancelled },

                // Ewa
                new() { Id = 6,  Customer="Ewa", Product="Tablet",      Quantity=1, PricePerItem=1500m, OrderDate=DateTime.Today.AddDays(-8),  Status=OrderStatus.Processing },
                new() { Id = 7,  Customer="Ewa", Product="Słuchawki",   Quantity=2, PricePerItem=300m,  OrderDate=DateTime.Today.AddDays(-3),  Status=OrderStatus.New },

                // Ola
                new() { Id = 8,  Customer="Ola", Product="Laptop",      Quantity=1, PricePerItem=4200m, OrderDate=DateTime.Today.AddDays(-40), Status=OrderStatus.Delivered },
                new() { Id = 9,  Customer="Ola", Product="Monitor",     Quantity=3, PricePerItem=850m,  OrderDate=DateTime.Today.AddDays(-12), Status=OrderStatus.Processing },
                new() { Id = 10, Customer="Ola", Product="Laptop",      Quantity=2, PricePerItem=4100m, OrderDate=DateTime.Today.AddDays(-4),  Status=OrderStatus.New },

                // Jan
                new() { Id = 11, Customer="Jan", Product="Monitor",     Quantity=2, PricePerItem=780m,  OrderDate=DateTime.Today.AddDays(-18), Status=OrderStatus.Delivered },
                new() { Id = 12, Customer="Jan", Product="Monitor",     Quantity=1, PricePerItem=820m,  OrderDate=DateTime.Today.AddDays(-1),  Status=OrderStatus.Shipped },

                // Iga
                new() { Id = 13, Customer="Iga", Product="Tablet",      Quantity=1, PricePerItem=1600m, OrderDate=DateTime.Today.AddDays(-7),  Status=OrderStatus.Processing },
                new() { Id = 14, Customer="Iga", Product="Tablet",      Quantity=2, PricePerItem=1550m, OrderDate=DateTime.Today.AddDays(-2),  Status=OrderStatus.Delivered },

                // Kasia
                new() { Id = 15, Customer="Kasia", Product="Drukarka",  Quantity=1, PricePerItem=700m,  OrderDate=DateTime.Today.AddDays(-1),  Status=OrderStatus.New },
                new() { Id = 16, Customer="Kasia", Product="Laptop",    Quantity=1, PricePerItem=4300m, OrderDate=DateTime.Today.AddDays(-28), Status=OrderStatus.Delivered }
            };

        // === POZIOM 1 ===

        var q1 = orders.Where(o => o.Status == OrderStatus.New);
        Print("Zadanie 1", q1);

        var q2 = orders.Any(o => o.Product == "Laptop");
        Console.WriteLine($"\nZadanie 2\nCzy jest zamówienie ja jakikolwiek laptop: {q2}");

        var q3 = orders.Where(o => o.OrderDate >= DateTime.Today.AddDays(-30));
        Print("Zadanie 3", q3);

        // === POZIOM 2 ===

        var q4 = orders.Select(o => $"Klient:{o.Customer}\nWartość zamówienia:  {o.Total}").ToList();
        Print("Zadanie 4", q4);

        var q5 = orders.Where(o => o.Product.Contains('o'));
        Print("Zadanie 5", q5);

        var q6 = orders.Where(o => o.Total > 1000 && o.Status != OrderStatus.Cancelled);
        Print("Zadanie 6", q6);

        var q7 = orders.All(o => o.OrderDate.Year == DateTime.Today.Year);
        Console.WriteLine($"\nZadanie 7\nCzy wszystkie zamówienia pochodzą z bieżącego roku: {q7}");

        // === POZIOM 3 ===

        var q8 = orders.GroupBy(o => o.Customer)
            .Where(g => g.Select(o => o.Product).Distinct().Count() > 1)
            .SelectMany(g => g);
        Print("Zadanie 8", q8);

        var q9 = orders.GroupBy(o => o.Customer)
            .Select(g => new
            {
                Customer = g.Key,
                DaysSinceFirstOrder = (DateTime.Today - g.Min(o => o.OrderDate)).Days
            });
        Print("Zadanie 9", q9);

        var q10 = orders.Select(o => (o.Customer, o.Product)).Distinct();
        Print("Zadanie 10", q10);

        var q11 = orders.GroupBy(o => o.Customer)
            .Where(g => g.Any(o => o.Status == OrderStatus.Cancelled) && g.Any(o => o.Status == OrderStatus.Delivered))
            .Select(g => g.Key);
        Print("Zadanie 11", q11);

        var q12 = orders.Where(o => o.Total >= 1000 && o.Total <= 3000 && o.OrderDate >= DateTime.Now.AddDays(-14));
        Print("Zadanie 12", q12);

        var q13 = orders.GroupBy(o => new { o.Customer, o.Product })
            .Where(g => g.Select(o => o.OrderDate).Distinct().Count() > 1)
            .Select(g => g.Key.Customer);
        Print("Zadanie 13", q13);

        var q14 = orders.Where(o =>
            orders.Any(o2 => o2.Id != o.Id && o.PricePerItem > o2.Total)
        );
        Print("Zadanie 14", q14);
    }
}