using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypesConsoleApp;

class Container<T>
{
    private T item;

    public T Item
    {
        get { return item; }
        set { item = value; }
    }

    public Container(T item)
    {
        Item = item;
    }

    public void Show()
    {
        Console.WriteLine($"Wartość przechowywana: {Item}");
    }
}

class ContainerInt
{
    private int item;

	public int Item
	{
		get { return item; }
		set { item = value; }
	}

    public ContainerInt(int item)
    {
        Item = item;
    }

    public void Show()
    {
        Console.WriteLine($"Wartość przechowywana: {Item}");
    }
}

class ContainerString
{
    private string item;

    public string Item
    {
        get { return item; }
        set { item = value; }
    }

    public ContainerString(string item)
    {
        Item = item;
    }

    public void Show()
    {
        Console.WriteLine($"Wartość przechowywana: {Item}");
    }
}

/*
class Container_dfgdnhfghjdghjcfgh
{
    private int item;

    public int Item
    {
        get { return item; }
        set { item = value; }
    }

    public Container_dfgdnhfghjdghjcfgh(int item)
    {
        Item = item;
    }

    public void Show()
    {
        Console.WriteLine($"Wartość przechowywana: {Item}");
    }
}

class Container_sdfhsdfghdf
{
    private string item;

    public string Item
    {
        get { return item; }
        set { item = value; }
    }

    public Container_sdfhsdfghdf(string item)
    {
        Item = item;
    }

    public void Show()
    {
        Console.WriteLine($"Wartość przechowywana: {Item}");
    }
}
*/

/*
Typów generycznych używamy, gdy chcemy stworzyć klasę, strukturę, 
interfejs lub metodę, która może działać z dowolnym typem danych,
bez konieczności definiowania osobnej wersji dla każdego typu.
Aby nie łamać zasady DRY.

Funkcji anonimowych używamy, gdy chcemy stworzyć krótką funkcję,
która nie wymaga osobnej deklaracji i może być użyta w miejscu,
gdzie jest potrzebna, na przykład jako argument do innej funkcji.

*/