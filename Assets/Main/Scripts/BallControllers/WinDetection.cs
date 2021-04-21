using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDetection : MonoBehaviour
{
    // variable________________________________________________________________
    public string m_winDetectionTag = "Win";
    private Movement m_movement = null;


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        m_movement = GetComponent<Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (LevelManager.Instance.GameIsWinOrGameOver) return;
        if (other.gameObject.tag != m_winDetectionTag) return;

        // freez ball
        m_movement.enabled = false;

        // freez input
        InputManager.Instance.IsFreezed = true;

        // win 
        LevelManager.Instance.Win();

        // score
        ScoreManager.Instance.SaveNewScore();
        LevelManager.Instance.IsWin = true;
    }
}
