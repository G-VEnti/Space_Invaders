using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    private Vector3 enemyBulletV = new Vector3(0, -1, 0);
    public float enemyBulletSpeed;
    private float despawnTime = 5;
    private string buildingTag = "Building";
    private string playerTag = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroys the gameObject 5 seconds later of his spawn
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += enemyBulletV * enemyBulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with building, destroys itself and reduces building life
        if (collision != null && collision.tag == buildingTag)
        {
            collision.GetComponent<Building_Script>().currentLife--;
            Destroy(gameObject);
        }

        if (collision != null && collision.tag == playerTag)
        {
            Destroy(gameObject);
        }
    }
}
