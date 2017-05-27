using System;
using System.Collections.Generic;

namespace BrickBrackBruck
{
    class Program
    {
        static void Main(string[] args)
        {
            // einmal gesetzt, bleibt die Einstellung bis die Console neu gestartet wird.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Mutter: Hallo! Ich bin Mutter. Meine Kinder sind: ");
            Console.WriteLine("Mutter: Walter der Halter");
            Console.WriteLine("Mutter: Evolot Freund des Lanzelot");
                        
            WalterDerHalter walter = new WalterDerHalter();
            
            if (args.Length > 0)
                walter.VerzeichnisHinzufügen( args[0] );

            Console.WriteLine("Mutter: Walter sag mal was!");
            walter.hoseRunter();            

        }

    }

}

