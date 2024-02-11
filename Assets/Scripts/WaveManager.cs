using CowMilking.Enemy;
using CowMilking.SO;
using UnityEngine;

namespace CowMilking
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager Instance { private set; get; }

        [SerializeField]
        private WaveInfo[] _waves;

        [SerializeField]
        private Transform[] _lines;

        [SerializeField]
        private Transform _enemySpawnPos;

        private int _currWave;

        private void Awake()
        {
            Instance = this;
        }

        public void StartSpawn()
        {
            SpawnNext();
        }

        private void SpawnNext()
        {
            var wave = _waves[_currWave];

            var enemy = wave.Enemies[Random.Range(0, wave.Enemies.Length)];

            var line = _lines[Random.Range(0, _lines.Length)];
            var go = Instantiate(enemy.Prefab, new(_enemySpawnPos.position.x, line.position.y), Quaternion.identity);
            go.GetComponent<AlienController>().Info = enemy;
        }
    }
}
