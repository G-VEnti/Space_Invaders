using System.Collections;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemyManager;
    public GameObject playerController;
    private Enemy_Manager actualEnemyMovement;

    private Vector3 playerStartPos = new Vector3(0, -4.5f, 0);
    private float respawnTime = 5f;
    void Start()
    {
        InstantiateEnemyManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateEnemyManager() 
    {
        actualEnemyMovement = Instantiate(enemyManager).GetComponent<Enemy_Manager>();
    }

    IEnumerator EnemyRespawn()
    {
        yield return new WaitForSeconds(respawnTime);

        playerController.transform.position = playerStartPos;
        InstantiateEnemyManager();
    }
}
