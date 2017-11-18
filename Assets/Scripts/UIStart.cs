using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStart : MonoBehaviour
{
    public Button SoundButton;
    public AudioSource AudioBackground;
    public Sprite[] SoundButtonSprites;

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
        SceneManager.LoadScene("play", LoadSceneMode.Single);
    }

    void onClickSoundButton()
    {
        Image image = SoundButton.GetComponent<Image>();
        if (image == null)
            return;

        if (SoundButtonSprites.Length < 2)
            return;

        if (AudioBackground.isPlaying) {
            AudioBackground.Stop();
            image.sprite = SoundButtonSprites[1];
        }
        else {
            AudioBackground.Play();
            image.sprite = SoundButtonSprites[0];
        }
    }
}
