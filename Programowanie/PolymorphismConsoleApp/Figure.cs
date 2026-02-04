namespace PolymorphismConsoleApp
{
    internal abstract class Figure: IWorkOnFiles
    {
        protected string name;

        public Figure()
        {
            //name = "???";
        }

        public abstract void ShowInfo();

        public abstract /*virtual*/ int GetPerimeter();
        /*{
            return 0;
        }*/

        public abstract int GetArea();

        public abstract void SaveToFile();
    }
}

/*
Aby stworzyć klasę abstrakcyjną w C#, używamy słowa kluczowego 
"abstract" przed
deklaracją klasy. Klasa abstrakcyjna może zawierać zarówno metody 
abstrakcyjne 
(bez implementacji), jak i metody z implementacją. Metody abstrakcyjne 
muszą być oznaczone jako "abstract" i nie mogą mieć ciała. Klasy 
dziedziczące po klasie abstrakcyjnej muszą implementować wszystkie 
metody abstrakcyjne.
Klasa Figure implementuje interfejs IWorkOnFiles, co oznacza, że musi 
zawierać implementację metody SaveToFile(), jednak jako klasa abstrakcyjna
nie dostarcza jej implementacji, pozostawiając to zadanie klasom pochodnym.

Wiązanie krótkie (ang. early binding) odnosi się do procesu, w którym
kompilator ustala, która metoda lub właściwość ma być wywołana podczas
kompilacji programu. Oznacza to, że decyzja o tym, która metoda zostanie
wywołana, jest podejmowana na etapie kompilacji, a nie podczas wykonywania
programu.

Wiązanie długie (ang. late binding) odnosi się do procesu, w którym decyzja
o tym, która metoda lub właściwość ma być wywołana, jest podejmowana
podczas wykonywania programu, a nie na etapie kompilacji. Oznacza to, że
decyzja ta jest podejmowana dynamicznie, w zależności od typu obiektu
w czasie wykonywania programu. 

W jakim przypadku występuje wiązanie długie?
Wiązanie długie występuje w przypadku metod wirtualnych (oznaczonych słowem
"virtual") oraz metod abstrakcyjnych (oznaczonych słowem "abstract") w klasach
abstrakcyjnych. Kiedy wywołujemy taką metodę na obiekcie, decyzja o tym,
która implementacja metody zostanie użyta, jest podejmowana podczas
wykonywania programu, w zależności od rzeczywistego typu obiektu.
/*

Natomiast wiązanie krótkie występuje w przypadku metod statycznych,
metod niestatycznych (nie oznaczonych jako "virtual" lub "abstract")
oraz metod przesłoniętych (oznaczonych jako "new"). W tych przypadkach
decyzja o tym, która metoda zostanie wywołana, jest podejmowana na etapie
kompilacji, w zależności od typu zmiennej, a nie rzeczywistego typu obiektu.

Polimorfizm - zdolność do przyjmowania wielu form przez kod.
*/
