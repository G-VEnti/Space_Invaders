using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public string leftLimitTag = "LeftLimit";
    public string rightLimitTag = "RightLimit";
    public string playerBulletTag = "PlayerBullet";
    public string playerTag = "Player";
    public string buildingTag = "Building";
    public string deadAnim = "isDead";
    public float downDistance = 0.5f;
    private float timeLimit;
    public float waitingTime;
    public float enemySpeedIncreasement = 0.1f;
    public int scoreToGive;
    public float despawnTime = 0.3f;
    

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeLimit)
        {
            Enemy_Manager.instance.directionChanged = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with any of the limits activates function
        if (collision != null && (collision.tag == leftLimitTag || collision.tag == rightLimitTag))
        {
            ChangeDirection();
        }

        // If player bullet collides destroys gameObject, script, player bullet, adds score, increases enemy movement speed and changes sprite
        if (collision != null && collision.tag == playerBulletTag)
        {
            UI_Manager.instance.score += scoreToGive;
            Enemy_Manager.instance.enemySpeed += enemySpeedIncreasement;
            Enemy_Manager.instance.enemyScripts.Remove(this);
            Destroy(collision.gameObject);
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<Animator>().SetBool(deadAnim, true);
            Destroy(gameObject, despawnTime);
            Destroy(this);
        }

        // If enemy collides with building or player, game finishes
        if (collision != null && (collision.tag == buildingTag || collision.tag == playerTag))
        {
            UI_Manager.instance.playerLives = 0;
        }
    }

    /// <summary>
    /// Multiplies enemyV by -1 to change the direction, subtracts downDistance to "y" coordinate to move the block of enemies down
    /// adds time to a counter to reset directionChaneged to false
    /// </summary>
    private void ChangeDirection()
    {
        if (Enemy_Manager.instance.directionChanged == false)
        {
            Enemy_Manager.instance.directionChanged = true;
            Enemy_Manager.instance.enemyV *= -1;
            Enemy_Manager.instance.transform.position = new Vector3(Enemy_Manager.instance.transform.position.x, Enemy_Manager.instance.transform.position.y - downDistance, transform.position.z);
            timeLimit = Time.time + waitingTime;
        }
    }

}
