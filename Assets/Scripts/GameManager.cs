using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // move the ball 
    // manage the score 
    // manage the turns 

    public GameObject ball;
    public TextMeshProUGUI scoreUI;
    int turncounter = 0 ; 
    GameObject[] pins;
    int score = 0; 

    Vector3[] positions;


    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
    }

    void Update()
    {
        MoveBall();

        if(Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < 20 )
        {
            CountPinsDown();
            turncounter++;
        }
    }

    void MoveBall()
    {
        Vector3 position = ball.transform.position;
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 100 ;
        position.x=Mathf.Clamp(position.x , 750 , 1100 );
        ball.transform.position = position; 
        //ball.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
    }

    void CountPinsDown()
    {
        for(int i=0; i < pins.Length; i++ )
        {
            if ( pins[i].transform.eulerAngles.z > 5 && 
            pins[i].transform.eulerAngles.z < 355 &&
            pins[i].activeSelf )
            {
                score++;
                pins[i].SetActive(false);
            }
        }
        scoreUI.text = score.ToString();
    }
}
