using UnityEngine;

public class Splash : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Invoke("DestroySplash", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DestroySplash()
    {
        Destroy(gameObject);
    }
}
