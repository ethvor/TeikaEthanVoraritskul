using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    public GameObject backPrefab;

    public float speed;

    private GameObject[] backgrounds;

    public float pivotPoint;
    public float scale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pivotPoint = scale * 16 * -0.32f;
        backPrefab.transform.localScale = new Vector3(scale,scale,scale);
        
        
        
        
        backgrounds = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            Vector2 position = new Vector2(xPos, yPos);
            backgrounds[i] = Instantiate(backPrefab, position, Quaternion.identity);
        }

    }
    
    void Update()
    {
        
        for (int i = 0; i < 3; i++)
        {
            float xPos = backgrounds[i].transform.position.x + speed * Time.deltaTime;
            float yPos = backgrounds[i].transform.position.y + speed * Time.deltaTime;
            Vector2 position = new Vector2(xPos, yPos);
          
            if (backgrounds[i].transform.position.x > -pivotPoint / 2)
            {
                position = new Vector2(pivotPoint,  pivotPoint);
            }
            backgrounds[i].transform.position = position;
        }
    }
}
