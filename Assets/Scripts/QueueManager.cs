using UnityEngine;

public class QueueManager : MonoBehaviour
{


    public Sprite[] UISprites;
    public int[] queue;
    private SpriteRenderer[] childRenderers;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        queue = new int[7];
        for (int i = 0; i < 7; i++)
        {
            queue[i] = Random.Range(0, UISprites.Length); // make weighted



        }


        childRenderers = new SpriteRenderer[7];
        for (int i = 0; i < childRenderers.Length; i++)
        {
            childRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < queue.Length; i++)
        {
            childRenderers[i].sprite = UISprites[queue[i]];
        }




    }


    public int updateQueue()
    {
        int currentType = queue[0];

        for (int i = 1; i < 7; i++)
        {
            queue[i-1] = queue[i];
        }
        queue[6] = Random.Range(0, UISprites.Length);

return currentType;
    }
    
}
