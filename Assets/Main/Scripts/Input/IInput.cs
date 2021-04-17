using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    // variable________________________________________________________________
    public bool m_isActive = false;
    public float m_speed = 1f;
    public float m_smooth = 5;
    protected float m_currentAngle = 0;
    public Transform m_baseGameObject = null;


    // function________________________________________________________________
    public void ActiveInput()
    {
        this.enabled = true;
    }
    public void DeactiveInput()
    {
        this.enabled = false;
    }
}
