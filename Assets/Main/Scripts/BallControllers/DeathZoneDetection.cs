using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneDetection : MonoBehaviour
{
    // variable________________________________________________________________
    [Tag]
    public string m_deathZoneTag = "DeathZone";
    private Movement m_movement = null;


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        m_movement = GetComponent<Movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (LevelManager.Instance.GameIsWinOrGameOver) return;
        if (other.gameObject.tag != m_deathZoneTag) return;

        // freez ball
        m_movement.enabled = false;

        // freez input
        InputManager.Instance.IsFreezed = true;

        // save new best score
        ScoreManager.Instance.SaveNewScore();

        // game over 
        LevelManager.Instance.GameOver();
        LevelManager.Instance.IsGameOver = true;
    }
}
