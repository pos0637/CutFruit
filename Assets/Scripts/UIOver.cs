using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOver : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickPlayButton()
    {
        SceneManager.LoadScene("start", LoadSceneMode.Single);
    }
}
