using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    // variable________________________________________________________________
    private static LevelManager m_instance = null;
    public UnityEvent m_onGameOver = null;
    public UnityEvent m_onWin = null;
    private bool m_isGameOver = false;
    private bool m_isWin = false;


    // property________________________________________________________________
    public static LevelManager Instance { get { return m_instance; } }
    public bool GameIsWinOrGameOver { get { return IsGameOver || IsWin; } }

    public bool IsGameOver
    {
        get => m_isGameOver; set
        {
            m_isGameOver = value;
            if (m_isGameOver) m_isWin = false;
        }
    }
    public bool IsWin
    {
        get => m_isWin; set
        {
            m_isWin = value;
            if (m_isWin) m_isGameOver = false;
        }
    }


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        if (Instance == null)
            m_instance = this;
        else
            Destroy(this);
    }


    // function________________________________________________________________
    public void GameOver()
    {
        m_onGameOver.Invoke();
    }
    public void Win()
    {
        m_onWin.Invoke();
    }
}
