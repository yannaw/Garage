using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage {
    public class Garage<T> : IEnumerable<T> where T : Vehicle {
        public Vehicle[] GarageVehicles;
        public string[] VehicleTypes = new string[] { "Quit", "Airplane", "Motorcycle", "Car", "Bus", "Boat" };

        public Garage(int capacity) {
            GarageVehicles = new Vehicle[capacity];
        }

        public Garage(string name, int capacity) {
            GarageVehicles = new Vehicle[capacity];
        }

        

        public bool isFull() {
            foreach(var item in GarageVehicles) {
                if(item == null) {
                    return false;
                }
            }
            return true;
        }

        public bool isExistByRegnr(string searchCriteria) { //kollar unikt regnr returnerar fordonets index

            if(GarageVehicles
                .Where(item => item != null)
                .Where(item => item.Match(searchCriteria)).Count() > 0) {
                return true;
            }
            return false; ;
        }

        public bool AddVehicle(T ap) {
            if(!isExistByRegnr(ap.RegNr)) {
                for(int i = 0; i < GarageVehicles.Length; i++) {
                    if(GarageVehicles.ElementAt(i) == null) {
                        GarageVehicles.SetValue(ap, i);
                        return true;
                    }
                }
            }
            return false;
        }

        internal bool RemoveVehicle(string regTest) {
            if(isExistByRegnr(regTest)) {
                for(int i = 0; i < GarageVehicles.Length; i++) {
                    if(GarageVehicles.ElementAt(i).RegNr == regTest) {
                        GarageVehicles.SetValue(null, i);
                        return true;
                        
                    }
                }
            }
            return false;
        }

        public int ListByType(int index) {
            int i = 0;
            foreach(var item in GarageVehicles) {
                if(item != null && (item.GetName() == VehicleTypes[index])) {
                    i++;
                    Console.WriteLine(item);
                }
            }

            if(i != 0) {
                Console.WriteLine($"{i}st {VehicleTypes[index]}");
            }
            return i; //returnerar antal av varje typ
        }

        public void ListAll() {
            for(int i = 1; i < VehicleTypes.Length; i++) {
                ListByType(i);
            }
        }

        public void search(string[] searchTerms) {

            List<Vehicle> searches = new List<Vehicle>();

            for(int i = 0; i < GarageVehicles.Length; i++) {
                for(int j = 0; j < searchTerms.Length; j++) {//typer    
                    if(GarageVehicles.ElementAt(i).RegNr == (searchTerms[j])) {
                        searches.Add(GarageVehicles.ElementAt(i));
                    }
                }
            }

            //Skriver ut 
            for(int k = 0; k < searches.Count; k++) {
                Console.WriteLine(searches.ElementAt(k));
            }
        }

        

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {

            for(int i = 0; i < GarageVehicles.Count(); i++) {
                if(GarageVehicles[i] != null)
                    yield return GarageVehicles[i] as T;
            
            }
        }

        public IEnumerator GetEnumerator() {
            return GetEnumerator();
        }
    }
}