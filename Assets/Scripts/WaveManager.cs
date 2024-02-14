using CowMilking.Character.Enemy;
using CowMilking.SO;
using System.Collections;
using System.Linq;
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

        private void Awake()
        {
            Instance = this;
        }

        public void StartSpawn()
        {
            StartCoroutine(SpawnWaves());
        }

        private IEnumerator SpawnWaves()
        {
            foreach (var w in  _waves)
            {
                for (int i = 0; i < w.EnemyCount; i++)
                {
                    SpawnNext(w);

                    yield return new WaitForSeconds(3f);
                }

                yield return new WaitForSeconds(6f);
            }
        }

        private void SpawnNext(WaveInfo wave)
        {
            var enemies = wave.Enemies.Where(x => CowManager.Instance.AllCows.Sum(c => c.DangerValue) >= x.MinDangerReq).ToArray();
            var enemy = enemies[Random.Range(0, enemies.Length)];

            var line = _lines[Random.Range(0, _lines.Length)];
            var go = Instantiate(enemy.Prefab, new(_enemySpawnPos.position.x, line.position.y), Quaternion.identity);
            go.GetComponent<AlienController>().Info = enemy;
        }
    }
}
