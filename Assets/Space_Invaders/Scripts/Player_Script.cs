using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    private Vector3 movementV;
    public float movementSpeed;
    public float horizontalLimit = 7.2f;
    public GameObject playerBullet;
    public GameObject shootingPos;
    private Vector3 startPos = new Vector3(0, -4.5f, 0);
    private string enemyBulletTag = "EnemyBullet";

    private InputSystem_Actions actions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPos;
        actions = new InputSystem_Actions();
        actions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        movementV = new Vector3(0, 0, 0);
        Vector2 movementVInput = actions.Player.Move.ReadValue<Vector2>();

        // Inputs for horizontal movement
        if (movementVInput.x < 0)
        {
            movementV.x = -1;
        }
        if (movementVInput.x > 0)
        {
            movementV.x = 1;
        }

        // Attack input
        if (actions.Player.Attack.WasPressedThisFrame() && UI_Manager.instance.panelActive == false)
        {
            Shoot();
        }


        transform.position += movementV * movementSpeed * Time.deltaTime;

        // Horizontal limits
        if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
        }
        if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z);
        }

        if (UI_Manager.instance.playerLives <= 0)
        {
            Destroy(gameObject);
        }

        if (Enemy_Manager.instance.enemyScripts.Count == 0)
        {
            transform.position = startPos;
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
            actions.Player.Disable();
            Destroy(gameObject);
        }
    }
}
