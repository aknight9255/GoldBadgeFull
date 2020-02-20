using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    public class OutingRepo
    {
        private List<Outing> _listOfOutings = new List<Outing>();

        public List<Outing> ShowAllOutings()
        {
            return _listOfOutings;
        }
        public List<Outing> ShowAllByYear(int year)
        {
            var listByYear = new List<Outing>();
            foreach(Outing outing in _listOfOutings)
            {
                if (year == outing.DateOfEvent.Year)
                {
                    listByYear.Add(outing);
                }
            }
            return listByYear;
        }

        public void AddNewOuting(Outing model)
        {
            _listOfOutings.Add(model);
        }

        public decimal ReturnCostForTheYear(int year)
        {
            var specifiedYearOutingList = new List<decimal>();
            foreach (Outing outing in _listOfOutings)
            {
                if (year == outing.DateOfEvent.Year)
                {
                    specifiedYearOutingList.Add(outing.TotalCostOfEvent);
                }
            }
            return specifiedYearOutingList.Sum();
        }

        public decimal ReturnCostForTheYearByType(EventType typeOfEvent, int year)
        {
            var listOfOutings = new List<decimal>();
            foreach (Outing outing in _listOfOutings)
            {
                if (year == outing.DateOfEvent.Year)
                {
                    if (outing.TypeOfEvent == typeOfEvent)
                    {
                        listOfOutings.Add(outing.TotalCostOfEvent);
                    }

                }
            }
            return listOfOutings.Sum();
        }
    }
}
