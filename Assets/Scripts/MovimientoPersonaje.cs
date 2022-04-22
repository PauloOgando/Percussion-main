using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public static MovimientoPersonaje instance;

    public float velocidadX = 0;

    public bool canMove;

    public GameObject box;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        velocidadX = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(velocidadX, 0);
        } else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Taiko"))
        {
            canMove = false;
            box.SetActive(true);
        }
    }
}
