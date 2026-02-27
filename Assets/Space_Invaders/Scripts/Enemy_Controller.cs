using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemyManager;
    private Enemy_Manager actualEnemyMovement;
    private float respawnTime = 5f;
    private bool respawning = false;
    void Start()
    {
        InstantiateEnemyManager();
    }

    // Update is called once per frame
    void Update()
    {
        if (actualEnemyMovement == null && respawning == false)
        {
            respawning = true;
            StartCoroutine(EnemyRespawn());
        }
    }
    public void InstantiateEnemyManager() 
    {
        actualEnemyMovement = Instantiate(enemyManager).GetComponent<Enemy_Manager>();
    }

    IEnumerator EnemyRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        InstantiateEnemyManager();
        respawning = false;
    }
}
