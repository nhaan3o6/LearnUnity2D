using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject spawnObject;
    [SerializeField]
    private float timeToDestroy = 2f;
    private GameObject runtimeSpawnGO;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            runtimeSpawnGO =Instantiate(spawnObject, spawnPoint);
            if(runtimeSpawnGO !=null)
            {
                DestroyGO();
            }
        }
    }
    private void DestroyGO()
    {
        Destroy(runtimeSpawnGO, timeToDestroy);
    }
}
