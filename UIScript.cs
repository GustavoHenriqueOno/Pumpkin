using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] Text score_text;
    [SerializeField] Text timer_text;

    public float score_number;
    public float timer_number;

    void Start()
    {
        score_number = 00;
        StartCoroutine(Timer());
    }

    void Update()
    {
        score_text.text = score_number.ToString();
        timer_text.text = timer_number.ToString();
        if (timer_number <= 0)
        {
            Time.timeScale = 0;
        }

        if (timer_number == 0)
        {
            SceneManager.LoadScene(3);
        }        
    }

    void ScorePoits ()
    {
        score_number++;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        timer_number--;
        StartCoroutine(Timer()); 
    }
}
