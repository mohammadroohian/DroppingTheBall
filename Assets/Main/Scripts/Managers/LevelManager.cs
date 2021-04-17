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


    // property________________________________________________________________
    public static LevelManager Instance { get { return m_instance; } }


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
