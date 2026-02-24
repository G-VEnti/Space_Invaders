using UnityEngine;
using UnityEngine.UIElements;

public class Building_Script : MonoBehaviour
{
    public float currentLife;
    private Vector3 originalScale;
    private float horizontalScaler;
    private float maxLife = 15;
    public string playerBulletTag = "PlayerBullet";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Store original scale and set current life to the max
        originalScale = transform.localScale;
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        // Divide the original scale by the maxLife to make equal reductions of the scale every time the building is hit
        horizontalScaler = (originalScale.x / maxLife) * currentLife;        

        if (currentLife == maxLife)
        {
            transform.localScale = originalScale;
        }


        // Destroy building when life <= 0
        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }

        transform.localScale = new Vector3 (horizontalScaler, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player bullet collides, subtracts life and destroys bullet
        if (collision != null && collision.tag == playerBulletTag)
        {
            currentLife--;
            Destroy(collision.gameObject);
        }
    }
}
