using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesDisplay;
    [SerializeField]
    private Sprite[] _livesSprites;
    void Start()
    {
        _scoreText.text = $"Score: 0";
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }

    public void UpdateLivesDisplay(int currentLives)
    {
        _livesDisplay.sprite = _livesSprites[currentLives];
    }
}
