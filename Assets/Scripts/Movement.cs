using UnityEngine.AI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public new Camera camera;
    public NavMeshAgent player;
    public bool ballActive = true;
    public int color = 0; //white = 0, Blue = 1, Yellow = 2, green = 3, purple = 4, red = 5, black = 6


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Input.touchCount > 0)
            {
                ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
            }
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                try
                {
                    player.SetDestination(hit.point);
                }
                catch (Exception e)
                {
                    Debug.Log(e + "LOLOL");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ballActive)
            {
                player.ResetPath();
                this.GetComponentInParent<NavMeshAgent>().enabled = false;
                ballActive = false;
            }
            else
            {
                this.GetComponentInParent<NavMeshAgent>().enabled = true;
                ballActive = true;

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            color = 0;
            GetComponent<Renderer>().material.SetColor("_Color", Color.white);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            color = 1;
            GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            color = 2;
            GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            color = 3;
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            color = 4;
            GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            color = 5;
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            color = 6;
            GetComponent<Renderer>().material.SetColor("_Color", Color.black);

        }
    }
}
