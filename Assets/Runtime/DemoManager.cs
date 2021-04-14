using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IronBelly.Test
{
    public class DemoManager : MonoBehaviour
    {
        [SerializeField] public RandomizedSpawner RandomZoneSpawner;

        [SerializeField] private InputField instancesToSpawn;
        [SerializeField] private PoolManager poolManager;
        [SerializeField] private int totalPoolPopulation;
        [SerializeField] private Button spawnButton;

        public event Action<int> OnSpawnCubes;

        public static DemoManager Instance()
        {
            return instance;
        }

        private static DemoManager instance;

        private void Awake()
        {
            instance = this;
            spawnButton.onClick.AddListener(Spawn);
        }

        private void Start()
        {
            poolManager.Preload(totalPoolPopulation);

            Vector3 randomPointInZone = RandomZoneSpawner.GetRandomPointInSphere();
        }

        private void Spawn()
        {
            Text input = instancesToSpawn.GetComponentInChildren<Text>();

            int cubesToSpawn;
            if (!Int32.TryParse(input.text, out cubesToSpawn)) return;

            poolManager.DespawnActiveInstances();
            poolManager.Spawn(cubesToSpawn);

            if (OnSpawnCubes != null) OnSpawnCubes.Invoke(cubesToSpawn);
        }
    }
}