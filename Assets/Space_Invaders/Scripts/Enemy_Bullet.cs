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
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += enemyBulletV * enemyBulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == buildingTag)
        {
            collision.GetComponent<Building_Script>().currentLife--;
            Destroy(gameObject);
        }
    }
}
