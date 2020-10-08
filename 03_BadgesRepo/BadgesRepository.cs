using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class BadgesRepository
    {
        private readonly Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
        public Dictionary<int, List<string>> ShowAllBadges()
        {
            return _badges;
        }

        public bool AddBadge(Badges badge)
        {
            int id = badge.BadgeID;
            List<string> doors = badge.BadgeDoors;
            _badges.Add(id, doors);
            bool added = _badges.ContainsKey(id);
            return added;
        }

        public bool AddBadgeDoors(int id, string newDoor)
        {
            foreach (KeyValuePair<int, List<string>> valuePair in _badges)
            {
                if (id == valuePair.Key)
                {
                    valuePair.Value.Add(newDoor);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveBadgeDoors(int id, string door)
        {
            foreach (KeyValuePair<int, List<string>> valuePair in _badges)
            {
                if (id == valuePair.Key)
                {
                    valuePair.Value.Remove(door);
                    if (valuePair.Value.Contains(door))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
