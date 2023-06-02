using UnityEngine;



public class Paralax : MonoBehaviour
{
    private Transform cam;
    private Vector2 camStartPos;
    private float distance;

    private GameObject[] backgrounds;
    private Material[] mat;
    private float[] backSpeed;

    private float farthestBack;
    
    [Range(0.5f, 2f)]
    public float parralaxSpeed;

    private void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int BackCount = transform.childCount;
        mat = new Material[BackCount];
        backSpeed = new float[BackCount];
        backgrounds = new GameObject[BackCount];

        for (int i = 0; i < BackCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
            
        }
        backSpeedCalculate(BackCount);
    }

    
    
    void backSpeedCalculate(int BackCount)
    {
        for (int i = 0; i < BackCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < BackCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void FixedUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parralaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
