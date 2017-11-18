using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject TextBoxScore;

    private int mScore = 100;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdateScore();
    }

    public void OnCutFruit()
    {
        mScore += 10;
        OnUpdateScore();
    }

    public void OnCutBomb()
    {
        mScore -= 50;
        OnUpdateScore();

        if (mScore < 0) {
            mScore = 0;
            SceneManager.LoadScene("over", LoadSceneMode.Single);
        }
    }

    private void OnUpdateScore()
    {
        TextBoxScore.GetComponent<Text>().text = "得分：" + mScore;
    }
}
