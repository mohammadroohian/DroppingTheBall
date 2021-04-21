using Pashmak.Core.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    // variable________________________________________________________________
    private static ScoreManager m_instance = null;
    private int m_newScore = 0;
    private int m_bestScore = 0;
    [SerializeField] private TextMeshProUGUI m_newScoreUI = null;
    [SerializeField] private TextMeshProUGUI m_bestScoreUI = null;
    [SerializeField] private string m_bestScoreKey = "bestScore";
    [SerializeField] private UnityEvent m_onScoreChanged = null;


    // property________________________________________________________________
    public static ScoreManager Instance { get { return m_instance; } }
    public int NewScore
    {
        get => m_newScore;
        set
        {
            m_newScore = value;

            // UI
            NewScoreUI.text = m_newScore.ToString();

            // event
            m_onScoreChanged.Invoke();
        }
    }
    public int BestScore
    {
        get => m_bestScore;
        private set
        {
            m_bestScore = value;
            BestScoreUI.text = "Best Score: " + m_bestScore.ToString();
        }
    }

    public TextMeshProUGUI NewScoreUI { get => m_newScoreUI; set => m_newScoreUI = value; }
    public TextMeshProUGUI BestScoreUI { get => m_bestScoreUI; set => m_bestScoreUI = value; }
    public string BestScoreKey { get => m_bestScoreKey; set => m_bestScoreKey = value; }


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        if (Instance == null)
            m_instance = this;
        else
            Destroy(this);

        BestScore = GetBestScore();
    }


    // function________________________________________________________________
    public void SaveNewScore()
    {
        if (NewScore > GetBestScore())
            SetBestScore(NewScore);
    }
    private int GetBestScore()
    {
        return SaveLoad.LoadInt(BestScoreKey, VariableSaveType.Binary);
    }
    private void SetBestScore(int newScore)
    {
        SaveLoad.SaveInt(BestScoreKey, newScore, VariableSaveType.Binary);
    }
}
