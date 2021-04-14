using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IronBelly.Test
{
    public class DemoManager : MonoBehaviour
    {
        [SerializeField] private InputField instancesToSpawn;
        [SerializeField] private PoolManager poolManager;
        [SerializeField] private int totalPoolPopulation;
        [SerializeField] private RandomizedSpawner randomZoneSpawner;
        [SerializeField] private Button spawnButton;

        private void Awake()
        {
            spawnButton.onClick.AddListener(Spawn);
        }

        private void Start()
        {
            poolManager.Preload(totalPoolPopulation);

            Vector3 randomPointInZone = randomZoneSpawner.GetRandomPointInSphere();
        }

        private void Spawn()
        {
            Text input = instancesToSpawn.GetComponentInChildren<Text>();

            int value = System.Convert.ToInt32(input.text);

            poolManager.Spawn(value);
        }
    }
}