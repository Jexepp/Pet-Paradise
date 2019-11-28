using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    public class Treatment
    {
        public int TreatId { get; set; }
        public string Service { get; set; }
        public DateTime Date { get; set; }
        public double Charge { get; set; }

        //public Treatment(int id)
        //{
        //    TreatId = id; 
        //}

        public override string ToString()
        {
            //"3: Parasites on 13-10-2014 00:00:00 costs 42"
            return TreatId + ": " + Service + " on " + Date + " costs " + Charge;
        }
    }
}
