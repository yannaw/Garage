using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Garage {
    class Program {

/*
            ○ Möjlighet att söka efter ett flertal fordon på ett flertal valfria variabler.
        
            1.  Skapa garage. Ange namn, ange antal platser.
                spara/läsa in 
            
            2. Lägga till/ta bort fordon 
                A. Ange typ och specifika parametrar
                B. ta bort enl index, regnr.
            
            3. Söka
            item.GetType==Airplane
                A. Listning
                B. Söktermer
                C. Frisökning?

       initSearch
            fordonstyp = 5st
            regnr
            aircompany
            cylinder
            fuel
            seats
            length
            
            case-sensitive?
            search 
            subclasses
            UI


//            https://msdn.microsoft.com/en-us/library/system.io.streamreader(vs.71).aspx

*/

            /// <summary>
            /// equaltest
            /// </summary>
            /// <param name="args"></param>
        static void Main(string[] args) {

            UserInterface ui = new UserInterface();
            ui.Run();
        }
    }
}
