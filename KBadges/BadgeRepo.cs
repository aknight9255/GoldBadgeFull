using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBadges
{
    public class BadgeRepo
    {
        private Dictionary<int, List<string>> _badgeList = new Dictionary<int, List<string>>();
        public void AddNewBadge(int key, List<string> value)
        {
            try
            {
            _badgeList.Add(key, value);
            }
            catch
            {
                Console.WriteLine("This badge is already in the system");
            }
        }
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _badgeList;
        }
        public Badge PullOneBadge(int badgeId)
        {
            Badge badge = new Badge(badgeId, _badgeList[badgeId]);
            return badge;

        }
        public void WipeAllDoorsFromBadge(int badgeId)
        {
            _badgeList[badgeId].Clear();
        }
        public void RemoveDoorFromBadge(int badgeId, string roomNumber)
        {
            _badgeList[badgeId].Remove(roomNumber);
        }
    }
}
