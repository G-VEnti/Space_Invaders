using UnityEngine;
using UnityEngine.UIElements;

public class Building_Script : MonoBehaviour
{
    public float currentLife;
    private Vector3 originalScale;
    private float horizontalScaler;
    private float maxLife = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = transform.localScale;
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalScaler = (originalScale.x / maxLife) * currentLife;        

        if (currentLife == 15)
        {
            transform.localScale = originalScale;
        }

        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }

        transform.localScale = new Vector3 (horizontalScaler, transform.localScale.y, transform.localScale.z);
    }
}
