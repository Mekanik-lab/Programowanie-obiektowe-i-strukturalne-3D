using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphismConsoleApp
{
    internal interface IWorkOnFiles
    {
        void SaveToFile();
        //void LoadFromFile();
    }
    /*
    abstract class WorkOnFiles
    {
        virtual void SaveToFile() = 0;
        virtual void LoadFromFile() = 0;
    }
    */
}

/*
Interfejs w C# to kontrakt, który definiuje zestaw metod, właściwości, 
zdarzeń lub indeksatorów, które klasa musi zaimplementować, jeśli
zdecyduje się na implementację tego interfejsu. Interfejsy są definiowane
za pomocą słowa kluczowego "interface". Klasy mogą implementować wiele 
interfejsów, co pozwala na tworzenie bardziej elastycznych i modularnych
struktur kodu.

Interfejsu używamy gdy chcemy skorzystać z z jakiejś funkcjonalności,
ale nie chcemy narzucać dziedziczenia po konkretnej klasie bazowej.

Natomiast gdy mamy jakąś funkcję i chcemy wykonać prace na obiekcie,
to przekazujemy do tej funkcji klase bazową. np.Figure
*/
