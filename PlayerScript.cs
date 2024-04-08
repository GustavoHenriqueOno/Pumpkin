using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject mesh;
    [SerializeField] Camera PlayerCamera;

    public static int contAboboras;
    [SerializeField] Text placarAboboras;

    Vector3 target_position = Vector3.zero;

    Touch touch;

    Ray ray;
    RaycastHit hit;

    Rigidbody rb;
    Animation an;
    AudioSource au;

    bool is_running;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animation>();
        au = GetComponent<AudioSource>();

        an.CrossFade("Idle");
    }

    void Update()
    {
        Touch();
        Move();
        placarAboboras.text = contAboboras.ToString();
    }

    void Touch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                ray = PlayerCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ground")
                    {
                        target_position = hit.point;
                        is_running = true;
                    }
                    else if (hit.collider.tag == "Pumpkin")
                    {
                        target_position = hit.point;
                        is_running = true;
                    }
                }
            }
        }
    }

    void Move()
    {
        if (is_running)
        {
            float distance = Vector3.Distance(transform.position, target_position);
            if (distance <= 0.0f)
            {
                an.CrossFade("Idle");
                is_running = false;
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, target_position, speed * Time.deltaTime);
            transform.LookAt(target_position);
            an.CrossFade("Run");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pumpkin")
        {
            Destroy(collision.gameObject);
            contAboboras++;
            au.Play();
            
            if (contAboboras >= 10)
            {
                SceneManager.LoadScene(4);
            }
        }        
    }
}
