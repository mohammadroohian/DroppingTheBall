using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // variable________________________________________________________________
    public string m_ballDetectionTag = "Ball";
    private bool m_ballIsOnThisPlatform = false;
    public Transform m_platforms = null;
    public Transform m_deathzpnes = null;
    public Transform m_trigger = null;


    // property________________________________________________________________
    public bool BallIsOnThisPlatform { get => m_ballIsOnThisPlatform; private set => m_ballIsOnThisPlatform = value; }


    // monoBehaviour___________________________________________________________
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == m_ballDetectionTag)
        {
            BallIsOnThisPlatform = true;
        }
    }
}
