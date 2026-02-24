using UnityEngine;

public class Change_Enemy_Direction : MonoBehaviour
{
    public string leftLimit = "LeftLimit";
    public string rightLimit = "RightLimit";
    private Enemy_Movement enemyMovement;
    public GameObject enemyManager;
    public float downDistance = 0.5f;
    private float timeLimit;
    public float waitingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyMovement = enemyManager.GetComponent<Enemy_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeLimit)
        {
            enemyMovement.directionChanged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && (collision.tag == leftLimit || collision.tag == rightLimit))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (enemyMovement.directionChanged == false)
        {
            enemyMovement.directionChanged = true;
            enemyMovement.enemyV *= -1;
            enemyMovement.transform.position = new Vector3(enemyMovement.transform.position.x, enemyMovement.transform.position.y - downDistance, transform.position.z);
            timeLimit = Time.time + waitingTime;
        }
    }
}
