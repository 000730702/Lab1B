// I, Nigel Reimer, student number 000730702, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using Lab1A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Data
{
    public class DealershipMgr
    {
        private static List<Dealership> Dealerships { get; set; }

        public DealershipMgr()
        {
            Dealerships = new List<Dealership> {
                new Dealership { Email = "dealer.one@website.com", Id = 1, Name = "Dealer One", PhoneNumber = "(111) 111-1111" },
                new Dealership { Email = "dealer.two@website.com", Id = 2, Name = "Dealer Two", PhoneNumber = "(222) 222-2222" }
            };
        }

        public DealershipMgr(List<Dealership> dealerships)
        {
            Dealerships = dealerships;
        }

        public List<Dealership> Get()
        {
            return Dealerships;
        }

        public Dealership Get(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return Dealerships.SingleOrDefault(d => d.Id == id);
        }

        public void Post(Dealership dealership)
        {
            if (dealership != null)
            {
                Dealerships.Add(dealership);
            }
        }

        public void Put(int id, Dealership updated)
        {
            if (id == updated.Id)
            {
                var dealership = Dealerships.SingleOrDefault(d => d.Id == updated.Id);

                if (dealership != null)
                {
                    dealership = updated;
                }
            }
        }

        public void Delete(int id)
        {
            Dealerships.RemoveAll(d => d.Id == id);
        }
    }
}
