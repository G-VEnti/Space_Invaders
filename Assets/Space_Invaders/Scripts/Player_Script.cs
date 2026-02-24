using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Script : MonoBehaviour
{
    private Vector3 movementV;
    public float movementSpeed;
    public float horizontalLimit = 8f;
    public GameObject playerBullet;
    public GameObject shootingPos;
    private Vector3 startPos = new Vector3 (0, -4.5f, 0);
    private string enemyBulletTag = "EnemyBullet";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        movementV = new Vector3(0, 0, 0);

        // Inputs for horizontal movement
        if (Keyboard.current.aKey.isPressed)
        {
            movementV.x = -1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            movementV.x = 1;
        }

        // Player attack
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }

        transform.position += movementV * movementSpeed * Time.deltaTime;

        // Horizontal limits
        if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3 (-horizontalLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3 (horizontalLimit, transform.position.y, transform.position.z);
        }

        if (UI_Manager.instance.playerLives <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Instantiates player bullet using the shootingPos gameObject transform
    /// </summary>
    private void Shoot()
    {
        Instantiate(playerBullet, shootingPos.transform.position, shootingPos.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == enemyBulletTag)
        {
            Instantiate(gameObject, startPos, transform.rotation);
            UI_Manager.instance.playerLives--;
            Destroy(gameObject);
        }
    }
}
