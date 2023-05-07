using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoeScript : MonoBehaviour
{
    [SerializeField] public float velX = 5f;
    [SerializeField] public float velY = 0f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject cobweb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (cobweb == null)
        {
            cobweb = GameObject.FindGameObjectWithTag("cobweb");
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //shoe.GetComponent<Scorekeeper>().AddPoints();
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        Destroy(gameObject);
    }

}
