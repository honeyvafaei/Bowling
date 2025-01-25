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
    public static int FallenPins; // متغیر static برای شمارش پین‌ها
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

        FallenPins = 0; // مقداردهی اولیه به شمارش پین‌ها
    }

    public void GameState()
    {
        if (FallenPins >= 10) // بررسی اگر تعداد پین‌های افتاده بیشتر یا مساوی 10 باشد
        {
            Menu.SetActive(false);
            StartCoroutine(LoadNextScene()); // انتقال به صحنه بعدی با Coroutine
        }
        else
        {
            Menu.SetActive(true);
            ball.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ball") || collision.collider.CompareTag("Pin"))
        {
            if (!CountedPin)
            {
                CountedPin = true;
                FallenPins += 1;
                Destroy(this.gameObject, 2f);
                StartCoroutine(WaitAndCheckGameState());
            }
        }
    }

    private IEnumerator WaitAndCheckGameState()
    {
        yield return new WaitForSeconds(1.6f); // یک و نیم ثانیه صبر

        if (FallenPins >= 10) // اگر همه پین‌ها افتاده باشند
        {
            GameState();
        }
        else // اگر حتی یک پین باقی مانده باشد
        {
            Menu.SetActive(true);
            ball.SetActive(false);
        }
    }

    private IEnumerator LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = (currentIndex == 1) ? currentIndex + 1 : 0;
        yield return null; // صبر برای پایان فریم جاری
        SceneManager.LoadScene(nextIndex);
    }
}
