using Pashmak.Core.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // variable________________________________________________________________
    private static ScoreManager m_instance = null;
    private int m_newScore = 0;
    private int m_bestScore = 0;
    public TextMeshProUGUI m_newScoreUI = null;
    public TextMeshProUGUI m_bestScoreUI = null;
    public string m_bestScoreKey = "bestScore";


    // property________________________________________________________________
    public static ScoreManager Instance { get { return m_instance; } }
    public int NewScore
    {
        get => m_newScore;
        set
        {
            m_newScore = value;
            m_newScoreUI.text = m_newScore.ToString();
        }
    }
    public int BestScore
    {
        get => m_bestScore;
        private set
        {
            m_bestScore = value;
            m_bestScoreUI.text = "Best Score: " + m_bestScore.ToString();
        }
    }


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
        return SaveLoad.LoadInt(m_bestScoreKey, VariableSaveType.Binary);
    }
    private void SetBestScore(int newScore)
    {
        SaveLoad.SaveInt(m_bestScoreKey, newScore, VariableSaveType.Binary);
    }
}
