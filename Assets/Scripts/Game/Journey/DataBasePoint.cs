using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace JourneySpace
{
    public class DataBasePoint
    {
        private List<JourneyPoint> list = new List<JourneyPoint>();

        public void Add(JourneyPoint point) {
            list.Add(point);
        }

        public void Remove(JourneyPoint point)
        {
            list.Remove(point);
        }

        public List<JourneyPoint> NearestList(int count = 5) {
            List<JourneyPoint> result = new List<JourneyPoint>();

            list = list.OrderBy(x => x.Distance).ToList();

            for (int i = 0; result.Count < count; i++)
            {
                if (list[i].Distance > 3)
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }
    }
}
