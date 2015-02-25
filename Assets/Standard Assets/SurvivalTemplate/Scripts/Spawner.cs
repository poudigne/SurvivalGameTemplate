using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour {

    public GameObject ennemy;
    public GameObject player;

    public float spawnOffset = 3;
    public float spawnDelay = 5;
    public int ennemyPerWave = 5;

    int currentEnnemyCount;
    int currentWave = 1;
    Vector3 randomSpawnPoint
    {
        get
        {
            int randIndex = Random.Range(0, transform.childCount - 1);
            var position = transform.GetChild(randIndex).position + Random.insideUnitSphere * spawnOffset;
            position.y = 0;
            return position;
        }
    }

    void Update()
    {
        CheckIfReadySpawn();
    }

    private void CheckIfReadySpawn()
    {
        if (currentEnnemyCount <= 0)
        {
            currentWave++;
            currentEnnemyCount = currentWave * ennemyPerWave;
            Invoke("Spawn", spawnDelay);
        }
            
    }

    void Start()
    {
        currentEnnemyCount = currentWave * ennemyPerWave;

        Spawn();
    }

    private void Spawn()
    {
        Debug.Log("wave starting : " + currentWave);

        for (int i = 0; i <= currentEnnemyCount; i++)
        {
            var ennemyGameObject = (GameObject)Instantiate(ennemy, randomSpawnPoint, Quaternion.identity);

            var hitDamage = ennemyGameObject.GetComponent<HitDamage>();

            hitDamage.hasDied = EnemyHasDied;

            SetAITarget(ennemyGameObject);
        }
    }

    private void SetAITarget(GameObject enemyGameObject)
    {
        var ai = enemyGameObject.GetComponent<AIPath>();
        if (ai == null)
            throw new MissingComponentException("ennemy GameObject needs to have an AIPath components. AIPath Component missing");
        ai.target = player.transform;
    }

    void EnemyHasDied()
    {
        Debug.Log("Died ! " + currentEnnemyCount);

        currentEnnemyCount--;
    }
}
