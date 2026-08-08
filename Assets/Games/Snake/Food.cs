using UnityEngine;

public class Food : MonoBehaviour
{
    private Vector2 pos;
    private int xMin = -8;
    private int xMax = 8;
    private int yMin = -4;
    private int yMax = 3;

    void Start()
    {
        MoveFood();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            {
                ScoreManager.instance.IncreaseScore(1);
            //Debug.Log("Food eaten!");

            MoveFood();
        }
    }

    void MoveFood()
    {
        pos = new Vector2((int)Random.Range(xMin, xMax), (int)Random.Range(yMin, yMax));
        transform.position = pos;
    }
}
