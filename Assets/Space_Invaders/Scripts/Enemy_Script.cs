using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public string leftLimitTag = "LeftLimit";
    public string rightLimitTag = "RightLimit";
    public string playerBulletTag = "PlayerBullet";
    public string playerTag = "Player";
    public string buildingTag = "Building";
    public float downDistance = 0.5f;
    private float timeLimit;
    public float waitingTime;
    public float enemySpeedIncreasement = 0.1f;
    public int scoreToGive;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeLimit)
        {
            Enemy_Movement.instance.directionChanged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with any of the limits activates function
        if (collision != null && (collision.tag == leftLimitTag || collision.tag == rightLimitTag))
        {
            ChangeDirection();
        }

        // If bullet collides destroys gameObject, script, player bullet, adds score and increases enemy movement speed
        if (collision != null && collision.tag == playerBulletTag)
        {
            UI_Manager.instance.score += scoreToGive;
            Enemy_Movement.instance.enemySpeed += enemySpeedIncreasement;
            Enemy_Movement.instance.enemyScripts.Remove(this);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(this);
        }
        
        // If enemy collides with building or player game finishes
        if (collision != null && (collision.tag == buildingTag || collision.tag == playerTag))
        {
            UI_Manager.instance.gameOver = true;
        }
    }

    /// <summary>
    /// Multiplies enemyV by -1 to change the direction, subtracts downDistance to "y" coordinate to move the block of enemies down
    /// adds time to a counter to reset directionChaneged to false
    /// </summary>
    private void ChangeDirection()
    {
        if (Enemy_Movement.instance.directionChanged == false)
        {
            Enemy_Movement.instance.directionChanged = true;
            Enemy_Movement.instance.enemyV *= -1;
            Enemy_Movement.instance.transform.position = new Vector3(Enemy_Movement.instance.transform.position.x, Enemy_Movement.instance.transform.position.y - downDistance, transform.position.z);
            timeLimit = Time.time + waitingTime;
        }
    }

}
