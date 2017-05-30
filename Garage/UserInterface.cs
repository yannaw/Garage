using Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage {//ska int känna till något om vhicl ska vara mrnyhantring
    class UserInterface {
        public Garage<Vehicle> garageOwner;

        public UserInterface() {
            init();
        }

        public void Run() {
            bool quit = false;

            while(!quit) {
                //            Console.Clear();
                Console.WriteLine("Huvudmeny\n1. Lägg till fordon\n2. Lista garagets fordon.\n3. Ta bort fordon\n4. Sök\nQ Avsluta.\n");
                char choise = Console.ReadKey(true).KeyChar;
                char c;
                switch(choise) {

                    case '1': //Lägg till
                        if(!garageOwner.isFull()) {
                            Console.WriteLine("Lägg till fordon\nVälj typ av fordon som ska läggas till\n1. Flygplan\n2. Motorcykel\n3. Bil\n4. Buss\n5. Båt\nQ. Återvänd till huvudmenyn");
                            int addingVehicle;

                            do {
                                addingVehicle = ReadInt();
                                if(addingVehicle == -1) {
                                    return;
                                }
                            } while(addingVehicle < 1 && addingVehicle > 5);

                            bool checkAdded = addingNewVehicle(addingVehicle);
                            if(!checkAdded) {
                                Console.WriteLine("Kunde inte lägga till fordonet!");
                            }
                        } else {
                            Console.WriteLine("Garaget är fullt, det går inte att lägga till fler fordon!\n");
                        }
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        c = Console.ReadKey(true).KeyChar;//c används aldrig!

                        break;

                    case '2': //Lista 
                        Console.WriteLine("Lista fordon i garaget, välj typ av lista:\n1. Alla fordon\n2. Flygplan\n3. Motorcyklar\n4. Bilar\n5. Bussar\n6. Båtar\nQ. Avsluta och återgå till huvudmenyn");
                        int listChoise = ReadInt();
                        if(listChoise == -1) {
                            return;
                        }

                        if(listChoise == 1) {
                            garageOwner.ListAll();
                        } else {
                            garageOwner.ListByType(listChoise - 1);
                        }

                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        c = Console.ReadKey(true).KeyChar;
                        break;

                    case '3': //Radera
                        Console.WriteLine("Radera fordon. Ange regnr eller 'Q' för att avbryta och återgå till huvudmenyn. ");
                        string deleteVehicle = Console.ReadLine();
                        if(deleteVehicle == "q") {
                            return;
                        }

                        bool deleted = garageOwner.RemoveVehicle(deleteVehicle);
                        string s = deleted ? "Raderade" : "Kunde inte radera";
                        Console.WriteLine($"{s} fordonet med Regnr: {deleteVehicle}");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        c = Console.ReadKey(true).KeyChar;

                        break;
                    case '4': //TD whitespace
                        Console.WriteLine("Ange sökord ");
                        string inputCreteria = Console.ReadLine();
                        string[] inputSplitCreteria = inputCreteria.Split();

                        garageOwner.search(inputSplitCreteria);
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        c = Console.ReadKey(true).KeyChar;

                        break;
                    case 'q': {//Avsluta
                            quit = true;
                            break;
                        }
                    default: {
                            Console.WriteLine("Du har angett ett icke giltigt menyval. Välj 1, 2, 3, 4 eller Q för att avsluta");
                            break;
                        }
                }
            }
        }



        private bool addingNewVehicle(int addingVehicle) {
            string inputRegnr = "";
            bool added = false;

            switch(addingVehicle) {
                case 1:
                    Console.WriteLine("Ange Regnr: "); //message if false
                    inputRegnr = Console.ReadLine();
                    Console.WriteLine("Ange namn på flygbolag: ");
                    string inputAirCompany = Console.ReadLine();
                    added = garageOwner.AddVehicle(new Airplane((inputAirCompany), inputRegnr));
                    break;
                case 2:
                    Console.WriteLine("Ange Regnr: ");
                    inputRegnr = Console.ReadLine();
                    double inputCylinderVolume;
                    Console.WriteLine("Ange cylindervolym:");
                    while(!double.TryParse(Console.ReadLine(), out inputCylinderVolume)) {
                        Console.WriteLine("Ange en giltig siffra!");
                        double.TryParse(Console.ReadLine(), out inputCylinderVolume);
                    }
                    added = garageOwner.AddVehicle(new Motorcycle(inputCylinderVolume, inputRegnr));

                    break;
                case 3: //Car string color
                    Console.WriteLine("Ange Regnr: ");
                    inputRegnr = Console.ReadLine();
                    Console.WriteLine("Ange färgen:");
                    string inputColor = "";

                    while(Console.ReadLine().Trim() == null) {
                        Console.WriteLine("Färgen kan inte lämnas tom");
                        inputColor = Console.ReadLine().Trim();
                    }
                    added = garageOwner.AddVehicle(new Car(inputColor, inputRegnr));
                    break;
                case 4: //Bus int NumberOfSeats
                    Console.WriteLine("Ange Regnr: ");
                    inputRegnr = Console.ReadLine();

                    Console.WriteLine("Ange antal sittplatser:");
                    int numberOfSeats = ReadInt();
                    added = garageOwner.AddVehicle(new Bus(numberOfSeats, inputRegnr));
                    break;
                case 5: //Boat double Length
                    Console.WriteLine("Ange Regnr: ");
                    inputRegnr = Console.ReadLine();

                    Console.WriteLine("Ange båtens längd:");
                    double inputLength;
                    while(!double.TryParse(Console.ReadLine(), out inputLength)) {
                        Console.WriteLine("Ange ett giltigt nummer");
                        double.TryParse(Console.ReadLine(), out inputLength);
                    }
                    added = garageOwner.AddVehicle(new Boat(inputLength, inputRegnr));
                    break;
                default:
                    break;
            }
            return added;
        }

        /// <summary>
        /// Tar en int från console och skapar nytt garage 
        /// </summary>
        public void init() {
            Console.WriteLine("Skapa nytt garage, ange storleken:");

            int inputint = ReadInt();
            garageOwner = new Garage<Vehicle>(inputint);// inputint);
            Console.WriteLine($"Ditt nya garage med {inputint} platser har skapats!\nTryck på valfri tangent för att fortsätta...");
            char c = Console.ReadKey(true).KeyChar;
        }

        private static int ReadInt() {
            int inputint = -1;
            string input = Console.ReadLine();
            if(input == "q") {
                return -1;
            }
            while(!int.TryParse(input, out inputint)) {

                Console.WriteLine("Ange ett giltigt nummer!");
                input = Console.ReadLine();
            }
            return inputint;
        }
    }
}
