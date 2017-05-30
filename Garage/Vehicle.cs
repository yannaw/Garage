using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage {

    public abstract class Vehicle {
        public string RegNr { get; set; }

        public Vehicle(string regnr) {
            RegNr = regnr;
        }

        public override string ToString() {
            return $"Typ: {GetName()}  Regnr: {RegNr}";
        }

        //TD Extremt dålig lösning 
        internal string GetName() {
            return GetType().ToString().Substring(7);
        }

        public virtual bool Match(string search) {
            if(RegNr.Contains(search)) {
                return true;
            }
            return false;
        }
    }

    public class Airplane : Vehicle {
        public string AirCompany { get; set; }
        public Airplane(string airCompany, string regnr) : base(regnr) {
            AirCompany = airCompany;
        }
        public override string ToString() {
            return $"{base.ToString()} Flygbolag: {AirCompany}";
        }
        public override bool Match(string search) {
            if(AirCompany.Contains(search) || base.Match(search)) {
                return true;
            }
            return false;
        }
    }

    class Motorcycle : Vehicle {
        public double CylinderVolume { get; set; }
        public Motorcycle(double cylinderVolume, string regNr) : base(regNr) {
            CylinderVolume = cylinderVolume;
        }
        public override string ToString() {
            return $"{base.ToString()} Cylindervolym: {CylinderVolume}";
        }
        public override bool Match(string search) {
            double test;
            return CylinderVolume.Equals(double.TryParse(search, out test));
        }
    }


    class Car : Vehicle {
        public string Color { get; set; }
        public Car(string color, string regNr) : base(regNr) {
            Color = color;
        }
        public override string ToString() {
            return $"{base.ToString()} Färg: {Color}";
        }
        public override bool Match(string search) {
            if(Color.Contains(search) || base.Match(search)) {
                return true;
            }
            return false;
        }
    }
    class Bus : Vehicle {
        public int NumberOfSeats { get; set; }
        public Bus(int seats, string regNr) : base(regNr) {
            NumberOfSeats = seats;
        }
        public override string ToString() {
            return $"{base.ToString()} Säten: {NumberOfSeats}";
        }
        public override bool Match(string search) {
            int test;
            return NumberOfSeats.Equals(int.TryParse(search, out test));
        }
    }
    class Boat : Vehicle {
        public double Length { get; set; }
        public Boat(double length, string regNr) : base(regNr) {
            Length = length;
        }
        public override string ToString() {
            return $"{base.ToString()} Längd: {Length}";
        }
        public override bool Match(string search) {
            double test;
            return Length.Equals(double.TryParse(search, out test));
        }
    }
}