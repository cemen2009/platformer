using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monstersReference;
    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monstersReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monstersReference[randomIndex], this.transform.GetChild(randomSide));
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(-spawnedMonster.transform.position.x * 2,
                -spawnedMonster.transform.position.x * 4);

            if (spawnedMonster.transform.position.x > 0)
            {
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
