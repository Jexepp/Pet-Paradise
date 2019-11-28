using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        

        public override string ToString()
        {
            //"3: Liz Frier - T: 555 537 6543 - M: Liz.Frier@somewhere.com"
            return OwnerId + ": " + FirstName + " " + LastName + " - T: " + Phone + " - M: " + Email;
        } 
    }
}
