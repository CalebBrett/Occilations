
using UnityEngine;
using UnityEngine.AI;



public class Collisions : MonoBehaviour
{
    public bool ballActive = true;

    Vector3 start;
    Vector3 end;
    public float progress = 0.0f;
    bool isCol = false;
    bool isDown = false;
    int State = 0; // 0 = normal, 1=inactive, 2 = sea, 3 = Paint

    // Use this for initialization
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        start = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        end = new Vector3(this.transform.position.x, -2, this.transform.position.z);
        this.transform.position = start;
        if (this.transform.parent.GetComponent("NavMeshModifier") != null)
        {
            rend.material.SetColor("_Color", Color.black);
            State = 1;
        }
        if (this.transform.parent.tag == "Water")
        {
            rend.material.SetColor("_Color", Color.blue);
            State = 2;
            //progress = Random.Range(0f,1f);
            progress = Mathf.Sin((this.transform.position.z)/5)/2;
            //progress = ((Mathf.Sin((this.transform.position.x) / 5) * Mathf.Sin((this.transform.position.z) / 5))/2);
        }
        if (this.transform.parent.tag == "Paintable")
        {
            State = 3;
            this.transform.localScale = new Vector3(1,2,1);

        }

        if (this.transform.parent.tag == "GO1")
        {
            int third = Random.Range(0, 10);
            if (third  == 2 && this.transform.parent.GetComponent("NavMeshModifier") != null)
            {
                rend.material.SetColor("_Color", Color.white);
            } else if (third == 2)
            {
                rend.material.SetColor("_Color", Color.black);
            }
        }
        if (this.transform.parent.tag == "GO2")
        {
            int third = Random.Range(0, 6);
            if (third == 4)
            {
                rend.material.SetColor("_Color", Color.red);
            }
            if (third == 2 && this.transform.parent.GetComponent("NavMeshModifier") != null)
            {
                rend.material.SetColor("_Color", Color.white);
            }
            else if (third == 2)
            {
                rend.material.SetColor("_Color", Color.black);
            }
        }

        if (this.transform.parent.tag == "GO")
        {
            int rand = Random.Range(0, 9);
            if (rand == 0)
            {
                rend.material.SetColor("_Color", Color.white);
            }
            else if (rand == 1)
            {
                rend.material.SetColor("_Color", Color.blue);
            }
            else if (rand == 2)
            {
                rend.material.SetColor("_Color", Color.yellow);
            }
            else if (rand == 3)
            {
                rend.material.SetColor("_Color", Color.green);
            }
            else if (rand == 4)
            {
                rend.material.SetColor("_Color", Color.magenta);
            }
            else if (rand == 5)
            {
                rend.material.SetColor("_Color", Color.red);
            }
            else if (rand == 6)
            {
                rend.material.SetColor("_Color", Color.black);
            }
            else if (rand == 7)
            {
                rend.material.SetColor("_Color", Color.cyan);
            }
            else if (rand == 8)
            {
                rend.material.SetColor("_Color", Color.grey);
            }
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (ballActive == true)
        {
            if (State == 0)
            {
                isCol = true;
                if (progress < 1)
                {
                    progress = progress + 0.02f;
                }
            }
            if (State == 2)
            {
                progress = 1;

            }
            if (State == 3)
            {
                Renderer rend = GetComponent<Renderer>();
                Movement movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
                if (movement.color == 0)
                {
                    rend.material.SetColor("_Color", Color.white);
                } else if (movement.color == 1)
                {
                    rend.material.SetColor("_Color", Color.blue);
                }
                else if (movement.color == 2)
                {
                    rend.material.SetColor("_Color", Color.yellow);
                }
                else if (movement.color == 3)
                {
                    rend.material.SetColor("_Color", Color.green);
                }
                else if (movement.color == 4)
                {
                    rend.material.SetColor("_Color", Color.magenta);
                }
                else if (movement.color == 5)
                {
                    rend.material.SetColor("_Color", Color.red);
                }
                else if (movement.color == 6)
                {
                    rend.material.SetColor("_Color", Color.black);
                }

                isCol = true;
                if (progress < 1)
                {
                    progress = progress + 0.02f;
                }
            }
        }
    }
    void OnTriggerExit(Collider collision)
    {
        isCol = false;
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Slerp(start, end, progress);
        if (State == 0 || State == 3)
        {

            if (isCol == false && progress > 0)
            {
                progress = progress - 0.02f;
            }
        }
        if (State == 2)
        {

            if (progress < 0)
            {
                isDown = true;
            }
            if (progress > 1)
            {
                isDown = false;
            }
            ocillate();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ballActive)
            {
                ballActive = false;
            }
            else
            {
                ballActive = true;
            }
        }
    }

    void ocillate()
    {
        if (isDown)
        {
            progress = progress + 0.04f;
        }
        if (isDown == false)
        {
            progress = progress - 0.04f;
        }
    }
}
    