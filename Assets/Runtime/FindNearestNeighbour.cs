using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestNeighbour : MonoBehaviour
{
    private FindNearestNeighbour[] allNeighbours;
    private FindNearestNeighbour nearestNeighbour = null;
    private float minDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /* void Update()
    {
        
    } */

    void Update()
    {
        PointToNearestNeighbour();
    }

    private void UpdateAllNeighbours()
    {
        allNeighbours = transform.parent.GetComponentsInChildren<FindNearestNeighbour>();
    }

    private void PointToNearestNeighbour()
    {
        UpdateAllNeighbours();

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
