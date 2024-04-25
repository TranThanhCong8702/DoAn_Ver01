using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatSpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 1.5f;

    private void Start()
    {
        StartCoroutine(SpawnPlat());
    }
    IEnumerator SpawnPlat()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate/2);
            var t = ObjectPool.instance.Get(ObjectPool.instance.mapPlat[0]);
            t.transform.position = transform.position;
            t.SetActive(true);
            int temp = Random.Range(-1, 1);
            yield return new WaitForSeconds(spawnRate / 2 + temp);
        }
    }
}
