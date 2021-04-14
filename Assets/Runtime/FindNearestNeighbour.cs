using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IronBelly.Test
{
    public class FindNearestNeighbour : MonoBehaviour
    {
        private FindNearestNeighbour[] allNeighbours;
        private FindNearestNeighbour nearestNeighbour = null;
        private float minDistance = 0f;
        private int totalNeighbours = 0;

        void OnEnable()
        {
            DemoManager.Instance().OnSpawnCubes += UpdateAllNeighbours;
        }

        void OnDisable()
        {
            DemoManager.Instance().OnSpawnCubes -= UpdateAllNeighbours;
        }

        void Update()
        {
            PointToNearestNeighbour();
        }

        private void UpdateAllNeighbours(int neighbours)
        {
            totalNeighbours = neighbours;
            allNeighbours = transform.parent.GetComponentsInChildren<FindNearestNeighbour>();
        }

        private void PointToNearestNeighbour()
        {
            Collider[] colliders = null;
            do
            {
                colliders = Physics.OverlapSphere(transform.position, minDistance);
                minDistance += 0.1f;
            } while (colliders.Length < 2);

            {
                foreach (Collider otherCollider in colliders)
                {
                    if (otherCollider != null)
                    Debug.DrawRay(transform.position, otherCollider.gameObject.transform.position - transform.position, Color.green);
                }

                minDistance = 0f;
            }
        }

        private void PointToNearestNeighbourUnoptimized()
        {
            float minDistanceFound = Mathf.Infinity;

            foreach (FindNearestNeighbour neighbour in allNeighbours)
            {
                if (neighbour.Equals(this)) continue;

                if (minDistanceFound > Vector3.Distance(transform.position, neighbour.gameObject.transform.position))
                {
                    minDistanceFound = Vector3.Distance(transform.position, neighbour.gameObject.transform.position);
                    nearestNeighbour = neighbour;
                }
            }

            Debug.DrawRay(transform.position, nearestNeighbour.transform.position - transform.position, Color.green);
        }
    }
}