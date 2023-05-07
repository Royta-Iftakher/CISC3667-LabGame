using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isSpriteRight = true;
    [SerializeField] float Pos;
    [SerializeField] float startX, endX, currentX;
    [SerializeField] AudioSource spiderDie;
    [SerializeField] GameObject shoe;
    [SerializeField] float growthRate = 0.01f;
    [SerializeField] float shrinkRate = 0.01f;
    [SerializeField] float maxScale = 2.0f;
    [SerializeField] float minScale = 0.5f;
    [SerializeField] private float currScale = 1.0f;
    [SerializeField] int sizeMod = 0;
    [SerializeField] int isHard = 0;
    [SerializeField] GameObject controller;

    private SettingsMenu SettingsMenu;


    // Start is called before the first frame update

    //position syntax: 
    void Start()
    {
        isHard = PlayerPrefs.GetInt("isHard");
        speed = 15;
        startX = transform.position.x;
        endX = -(transform.position.x);

        SettingsMenu = FindObjectOfType<SettingsMenu>();


        if (shoe == null)
        {
            shoe = GameObject.FindGameObjectWithTag("sneaker");
        }
        if (spiderDie == null)
        {
            spiderDie = GetComponent<AudioSource>();
        }

        //InvokeRepeating("Grow", 2.0f, 0.3f);

        if (isHard == 1)
        {
            InvokeRepeating("Shrink", 2.0f, 0.3f);

        }
        else
        {
            InvokeRepeating("Grow", 2.0f, 0.3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentX = transform.position.x;
        
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector2.right * Time.deltaTime * speed);
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, startX - endX) + endX, transform.position.y, 0);
        if (currentX == startX && isSpriteRight || currentX == endX && !isSpriteRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isSpriteRight = !isSpriteRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(spiderDie.clip, transform.position);
        //GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        controller.GetComponent<GameManager>().AddPoints(10-(sizeMod/3));
        controller.GetComponent<GameManager>().AdvanceScene();

        Destroy(gameObject);
    }

    void Grow()
    {
        currScale += growthRate * 0.1f;

        currScale = Mathf.Min(currScale, maxScale);

        transform.localScale = new Vector3(currScale, currScale, 1.0f);

        if(currScale < maxScale)
        {
            sizeMod += 1;
        }

        if(currScale >= maxScale)
        {
            GameObject controller = GameObject.FindGameObjectWithTag("GameController");
            Destroy(gameObject, 8f);
            sizeMod = 30;
            controller.GetComponent<GameManager>().AdvanceScene();
        }
    }

    void Shrink()
    {
        currScale -= shrinkRate * 0.1f;

        currScale = Mathf.Min(currScale, minScale);

        transform.localScale = new Vector3(currScale, currScale, 1.0f);

        if (currScale > minScale)
        {
            sizeMod += 1;
        }

        if (currScale <= minScale)
        {
            GameObject controller = GameObject.FindGameObjectWithTag("GameController");
            Destroy(gameObject, 8f);
            sizeMod = 30;
            controller.GetComponent<GameManager>().AdvanceScene();
        }
    }

}
