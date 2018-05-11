using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    const string TEXT_SCORE_FORMAT = "Score : {0}";

    [SerializeField]
    Text txtScore;


    void OnEnable()
    {
        UpdateText(Global.GetScore());
    }

    void Awake()
    {
        Global.OnScoreChanged += _OnScoreChanged;
    }

    void OnDestroy()
    {
        Global.OnScoreChanged -= _OnScoreChanged;
    }

    void _OnScoreChanged(int value)
    {
        UpdateText(value);
    }

    void UpdateText(int value)
    {
        txtScore.text = string.Format(TEXT_SCORE_FORMAT, value);
    }
}
