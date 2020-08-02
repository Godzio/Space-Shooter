using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;

    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (stopSpawning == false)
        {
            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-9.5f, 9.5f), 7f, 0), Quaternion.identity, enemyContainer.transform);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
        StopCoroutine(SpawnRoutine());
    }
}
