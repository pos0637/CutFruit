using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Fruits;

    public GameObject Bomb;

    public AudioSource FruitLaunch;

    bool isPlaying = true;

    private float mCurrentFruitZ = 0.0f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("onSpawn", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void onSpawn()
    {
        if (!isPlaying)
            return;

        int bomb = Random.Range(0, 100);
        int fruits = Random.Range(1, 3);

        if (bomb > 80) {
            onSpawn(false);
        }
        else {
            while (fruits-- > 0)
                onSpawn(true);
        }
    }

    private void onSpawn(bool isFruits)
    {
        float x = Random.Range(-4.0f, 4.0f);
        float y = transform.position.y;
        float z = -mCurrentFruitZ;
        mCurrentFruitZ = (mCurrentFruitZ + 1) % 6;

        int fruitId = Random.Range(0, Fruits.Length);
        GameObject go;

        if (isFruits)
            go = Instantiate(Fruits[fruitId], new Vector3(x, y, z), Random.rotation);
        else
            go = Instantiate(Bomb, new Vector3(x, y, z), Random.rotation);

        Vector3 velocity = new Vector3(-x * Random.Range(0.2f, 0.8f), -Physics.gravity.y * Random.Range(1.2f, 1.6f), 0);

        Rigidbody rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.velocity = velocity;

        FruitLaunch.Play();
    }
}
