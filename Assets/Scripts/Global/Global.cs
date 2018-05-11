
public class Global
{
    public delegate void Func(int value);
    public static event Func OnScoreChanged;

    static int _score;


    static void _FireEvent_OnScoreChanged()
    {
        if (OnScoreChanged != null)
        {
            OnScoreChanged(_score);
        }
    }

    public static void AddScore(int value)
    {
        _score += value;
        _FireEvent_OnScoreChanged();
    }

    public static void Reset()
    {
        _score = 0;
    }

    public static int GetScore()
    {
        return _score;
    }

}
