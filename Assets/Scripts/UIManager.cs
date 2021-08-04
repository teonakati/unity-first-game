using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    void Start()
    {
        _scoreText.text = $"Score: 0";
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}
