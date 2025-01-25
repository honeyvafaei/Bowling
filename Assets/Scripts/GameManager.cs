using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;

    Rigidbody rb;
    public AudioSource ballAudio;
    /*------*/
    [SerializeField] TextMeshProUGUI scoreUI;
    int turnCounter = 0;
    GameObject[] pins;
    int score = 0;
    Vector3[] initialPositions; // ذخیره مکان اولیه پین‌ها
    //--------------------------

    [SerializeField] float force;

    bool isShooting = false;
    bool isGoingRight = true;

    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 50;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * force);
            ballAudio.Play();
            isShooting = true;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!isShooting)
        {
            MoveBall();
        }
    }

    void MoveBall()
    {
        if (isGoingRight)
        {
            ball.transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            ball.transform.Translate(Vector3.left * Time.deltaTime);
        }

        if (ball.transform.position.x > 1.5f)
        {
            isGoingRight = false;
        }

        if (ball.transform.position.x < -1.5f)
        {
            isGoingRight = true;
        }
    }


}
