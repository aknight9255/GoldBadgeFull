using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    public enum EventType
    {
        Golf =1,
        Bowling,
        AmusementParke,
        Concert
    } 
    public class Outing
    {
        public EventType TypeOfEvent { get; set; }
        public int TotalNumberOfPeopleAttending { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCostOfEvent {get {return CostPerPerson * TotalNumberOfPeopleAttending;}}


        public Outing() { }
        public Outing(EventType typeOfEvent, int numberOfPeople,DateTime dateOfEvent,decimal costPerPerson )
        {
            TypeOfEvent = typeOfEvent;
            TotalNumberOfPeopleAttending = numberOfPeople;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
        }

    }
}
