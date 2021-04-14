using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IronBelly.Test
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private RandomizedSpawner zoneSpawner;

        private List<GameObject> population = new List<GameObject>();

        private void Awake()
        {

        }

        public void Preload(int totalToPreload)
        {
            for(int i = 0; i < totalToPreload; i += 1)
            {
                GameObject instance = GameObject.Instantiate(prefab, transform);
                instance.SetActive(false);
                population.Add(instance);
            }
        }

        public void SpawnOne(Vector3 position)
        {
            GameObject instance = population.Where(gameObject => gameObject.active.Equals(false)).FirstOrDefault();

            // If instance is null (no available in pool) add to the pool


            instance.transform.position = position;
            instance.SetActive(true);
        }

        public void Spawn(int spawnAmount)
        {   
            for (int i = 0; i < spawnAmount; i += 1)
            {
                SpawnOne(zoneSpawner.GetRandomPointInSphere());
            }
        }

        public void Despawn()
        {

        }
    }
}