using UnityEngine;

public class Bullet_Script : MonoBehaviour
{

    private Vector3 bulletV = new Vector3 (0, 1, 0);
    public float bulletSpeed;
    private string enemyTag = "Enemy";
    private string buildingTag = "Building";
    private float despawnTime = 5;
    public float enemySpeedIncreasement = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletV * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == enemyTag)
        {
            Enemy_Movement.instance.enemySpeed += enemySpeedIncreasement;
            Destroy(collision.gameObject);
            Destroy(collision.GetComponent<Change_Enemy_Direction>());
            Destroy(gameObject);
        }

        if (collision != null && collision.tag == buildingTag)
        {
            collision.GetComponent<Building_Script>().currentLife--;            
            Destroy(gameObject);
        }
    }
}
