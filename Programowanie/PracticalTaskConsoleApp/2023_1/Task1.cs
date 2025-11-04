namespace PracticalTaskConsoleApp.Styczeń2023_1
{
    internal class Task1
    {
        /**********************************************
        nazwa funkcji: AlgorytmEuklidesa
        opis funkcji: Oblicza największy wspólny dzielnik (NWD) dwóch liczb całkowitych dodatnich metodą Euklidesa.
        parametry: a - pierwsza liczba całkowita dodatnia (int), b - druga liczba całkowita dodatnia (int)
        zwracany typ i opis: int - największy wspólny dzielnik (NWD) dwóch liczb całkowitych dodatnich
        autor: Dawid Strzelecki
        ***********************************************/

        public int AlgorytmEuklidesa(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        public void Task()
        {
            Console.Write("Podaj pierwszą liczbę a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Podaj drugą liczbę b: ");
            int b = int.Parse(Console.ReadLine());

            int nwd = AlgorytmEuklidesa(a, b);

            Console.WriteLine($"Największy wspólny dzielnik liczb {a} i {b} wynosi: {nwd}");
        }
    }
}