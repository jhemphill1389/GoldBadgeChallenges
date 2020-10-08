using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> BadgeDoors { get; set; }
        public Badges() { }
        public Badges(int id, List<string> doors)
        {
            BadgeDoors = doors;
            BadgeID = id;
        }
    }
}