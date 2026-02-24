using UnityEngine;

public class Bullet_Script : MonoBehaviour
{

    private Vector3 bulletV = new Vector3 (0, 1, 0);
    public float bulletSpeed;
    private float despawnTime = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroys the gameObject 5 seconds later of his spawn
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletV * bulletSpeed * Time.deltaTime;
    }
}
