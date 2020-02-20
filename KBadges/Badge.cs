using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBadges
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public ICollection<string> Doors { get; set; }
    public Badge() { }

    public Badge(int badgeId, ICollection<string> doors)
        {
            BadgeId = badgeId;
            Doors = doors;
        }
    }


}
