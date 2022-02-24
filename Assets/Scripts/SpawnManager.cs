using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Componentes e objetos
    public GameObject enemyPrefabs;
    public GameObject powerupPrefabs;

    //Variaveis
    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        GeneratorPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            GeneratorPowerUp();
            GeneratorEnemy(waveNumber);
        }
    }

    //gera posições aleatorias em x e y
    public Vector3 spawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);
        return spawnPos;
    }

    //gerador de enemygos 
   void GeneratorEnemy(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn ; i++)
        {
            Instantiate(enemyPrefabs, spawnPosition(), enemyPrefabs.transform.rotation);
        }
    }

    //gerador de powerups
    void GeneratorPowerUp()
    {
        Instantiate(powerupPrefabs, spawnPosition(), powerupPrefabs.transform.rotation);
    }

}
