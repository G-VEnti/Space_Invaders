using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public static Enemy_Movement instance;
    public Vector3 enemyV = new Vector3(1, 0, 0);
    public float enemySpeed;
    public bool directionChanged = false;
    public List<Enemy_Script> enemyScripts;
    private int randomNum;
    private float spawnEnemyBullet;
    public GameObject enemyBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        // Set timer to spawn the first bullet
        spawnEnemyBullet = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += enemyV * enemySpeed * Time.deltaTime;

        // Choose a random enemy from the list, uses its transform to instantiate a bullet and adds 1s to the timer
        if (Time.time >= spawnEnemyBullet)
        {
            randomNum = Random.Range(0, enemyScripts.Count);
            Instantiate(enemyBullet, enemyScripts[randomNum].gameObject.transform.position, enemyScripts[randomNum].gameObject.transform.rotation);
            spawnEnemyBullet = Time.time + 1;
        }
    }

    
}
