using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public Vector3 randomPos;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float döngüBekleme;

    void Start()
    {
        StartCoroutine(Olustur());
    }


    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Enemy, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);

            }
            yield return new WaitForSeconds(döngüBekleme);

        }





    }








}
