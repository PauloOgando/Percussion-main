using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadX = 0;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadX = 5;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidadX, 0);
    }
}
