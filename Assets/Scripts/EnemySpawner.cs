using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] spawnPoints;
    public GameObject[] enemies;


    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float döngüBekleme;

    private void spawnEnemy()
    {

        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];


    }
    void Start()
    {
        StartCoroutine(Olustur());
    }


    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
                Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPoint.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);

            }
            yield return new WaitForSeconds(döngüBekleme);

        }
    }

    public static void dropVirus(GameObject virus,Vector3 position)
    {


    }

}
