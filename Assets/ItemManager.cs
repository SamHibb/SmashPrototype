using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    float delta_time = 0;

    private void Update()
    {
        delta_time += Time.deltaTime;

        if (delta_time > 30.0f)
        {
            SpawnRandomItem();
            delta_time = 0;
        }
    }

    void SpawnRandomItem()
    {
        Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
    }


}
