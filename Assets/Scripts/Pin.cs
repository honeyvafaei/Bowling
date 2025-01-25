using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pin : MonoBehaviour
{
    public bool CountedPin;
    public int fallenPins ;
    private List<GameObject> _pins = new();
    public GameObject ball;
    public GameObject Menu;


    private readonly Dictionary<GameObject, Vector3> _pinsDefaultPositions = new();
    private readonly Dictionary<GameObject, Quaternion> _pinsDefaultRotations = new();




    private void Start()
    {
        _pins = GameObject.FindGameObjectsWithTag("Pin").ToList();
        
        foreach (var pin in _pins)
        {
            _pinsDefaultPositions[pin] = pin.transform.position;
            _pinsDefaultRotations[pin] = pin.transform.rotation;
        }
        


    }
    public void GameState()
    {

        if (fallenPins == 10)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else 
        {
        Menu.SetActive(true);
        ball.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("ball") || collision.collider.CompareTag("Pin")) )
        {
            //&& !CountedPin
  
                CountedPin = true;
                fallenPins += 1;
                Destroy(this.gameObject, 2f);
        }
        
    }

    

}
