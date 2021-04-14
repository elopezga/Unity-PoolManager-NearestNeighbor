using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IronBelly.Test
{
    public class RandomizedMove : MonoBehaviour
    {
        private RandomizedSpawner Spawner;

        private Vector3 randomDirectionWithinSpawnZone;

        private void Awake()
        {
            Spawner = DemoManager.Instance().RandomZoneSpawner;
            randomDirectionWithinSpawnZone = Spawner.GetRandomPointInSphere() - transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, randomDirectionWithinSpawnZone, Time.deltaTime * 5f);

            if (Vector3.Distance(Vector3.zero, transform.position ) > Spawner.Radius)
            {
                randomDirectionWithinSpawnZone = Spawner.GetRandomPointInSphere() - transform.position;
            }
        }
    }
}