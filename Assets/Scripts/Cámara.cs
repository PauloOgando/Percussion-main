using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cámara : MonoBehaviour
{
    public static Cámara instance;

    private Rigidbody2D rb;
    private float velocidadX = 0;

    // Start is called before the first frame update
    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocidadX, 0);
        if (gameObject.transform.position.x >= 19 || gameObject.transform.position.x <= -19 || gameObject.transform.position.x == 0)
        {
            velocidadX = 0;
        }
    }

    // Update is called once per frame
    public void moverDerecha()
    {
        velocidadX = 17;
    }

    public void moverIzquierda()
    {
        velocidadX = -17;
    }
}

