using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{


    Vector3 start;
    Vector3 end;

    Vector3 startr;
    float progress = 0.0f;
    bool isdown = true;
    bool isComnplete = false;
    public TextMeshProUGUI text;

    public int sceneTO;
    public string WinText;
    // Use this for initialization
    void Start()
    {
        if (sceneTO == 1)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            WinText = "This is a secret, you can go back to the painting level by pressing the COMMA key.";
        }
        start = new Vector3(this.transform.position.x, 2, this.transform.position.z);
        end = new Vector3(this.transform.position.x, 4, this.transform.position.z);
        startr = new Vector3(45, 0, 45);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            isComnplete = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Slerp(start, end, progress);
        this.transform.Rotate(startr, progress);
        if (progress >= 1)
        {
            isdown = false;
        }
        if (progress <= 0)
        {
            isdown = true;
        }
        if (isdown)
        {
            progress = progress + 0.05f;
        }
        if (!isdown)
        {
            progress = progress - 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.Comma) && isComnplete && sceneTO==1)
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Comma) && isComnplete)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        isComnplete = true;
        text.text = WinText;
    }
}
