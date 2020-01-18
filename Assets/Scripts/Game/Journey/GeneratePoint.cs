using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JourneySpace
{
    public class GeneratePoint
    {
        private Vector3 startPosition = new Vector3(0, 0, 0);
        private Vector3 maxPosition = new Vector3(30, 30, 30);
        private Vector3 stepPosition = new Vector3(10, 10, 10);

        private Vector3 currentPosition = new Vector3(0, 0, 0);

        public void Create(Transform mainTransform) {
            float _z = startPosition.y;
            for (; _z < maxPosition.z; _z += stepPosition.z) {
                Create_Z(_z);
            }
        }

        public void Create_Z(float _z) {

            GameObject pointObj = Load.Prefab.Get("JourneyPoint");
            

            float _x = startPosition.x;
            float _y = startPosition.y;

            for (; _x < maxPosition.x; _x += stepPosition.x)
            {
                for (; _y < maxPosition.y; _y += stepPosition.y)
                {
                    Vector3 createPosition = new Vector3(_x, _y, _z);
                    GameObject tempObject = MonoBehaviour.Instantiate(pointObj);
                    JourneyPoint journeyPoint = tempObject.GetComponent<JourneyPoint>();
                    JourneyManager.DB.Add(journeyPoint);
                    tempObject.transform.position = createPosition;
                    
                }
                _y = startPosition.y;
            }
        }
    }
}
