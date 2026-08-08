using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Manager")]
    [SerializeField] public static ScoreManager instance;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] public uint score;

    void Start()
    {
        instance = this;
        scoreText.text = score.ToString();
    }

    void Update()
    {
        
    }

    public void IncreaseScore(uint amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}
