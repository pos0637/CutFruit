using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool CanCut;

    public bool CanBomb;

    public GameObject[] CutFruits;

    public GameObject Splash;

    public GameObject SplashFlat;

    public GameObject Fireworks;

    public AudioClip CutSound;

    private bool mCut = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

    public virtual void OnCut()
    {
        if (mCut)
            return;

        if (CanCut) {
            if (CutFruits.Length == 1) {
                for (int i = 0; i < 2; ++i) {
                    GameObject go = Instantiate(CutFruits[0], transform.position, Random.rotation);
                    go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5.0f, ForceMode.Impulse);
                }
            }
            else {
                for (int i = 0; i < CutFruits.Length; ++i) {
                    GameObject go = Instantiate(CutFruits[i], transform.position, Random.rotation);
                    go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5.0f, ForceMode.Impulse);
                }
            }

            Instantiate(Splash, transform.position, Quaternion.identity);
            Instantiate(SplashFlat, transform.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(CutSound, transform.position);
            GameController.Instance.OnCutFruit();
        }

        if (CanBomb) {
            Instantiate(Fireworks, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(CutSound, transform.position);
            GameController.Instance.OnCutBomb();
        }

        mCut = true;

        Destroy(gameObject);
    }
}
