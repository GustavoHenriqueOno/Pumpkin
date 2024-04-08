using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    Touch touch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            foreach (Touch tou in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    PlayerScript.contAboboras = 0;
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
