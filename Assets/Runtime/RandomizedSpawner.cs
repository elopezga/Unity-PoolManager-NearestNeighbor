using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IronBelly.Test
{
    public class RandomizedSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3 spawnZoneSize;

        public Vector3 GetRandomPointInSphere()
        {
            return Vector3.Scale(Random.insideUnitSphere, spawnZoneSize);
        }
    }
}