using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // variable________________________________________________________________
    private static CameraManager m_instance = null;
    public Transform m_mainCamHolder = null;
    public float m_translateSpeed = 1;
    private Vector3 m_currentTarget;


    // property________________________________________________________________
    public static CameraManager Instance { get { return m_instance; } }


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        if (Instance == null)
            m_instance = this;
        else
            Destroy(this);

        m_currentTarget = new Vector3(0,
            m_mainCamHolder.transform.position.y,
            0);
    }

    private void Update()
    {
        if (m_mainCamHolder.transform.position.y > m_currentTarget.y)
        {
            m_mainCamHolder.transform.Translate(0, -m_translateSpeed * Time.deltaTime, 0);
        }
    }


    // function________________________________________________________________
    public void GoToNextPosition()
    {
        m_currentTarget = new Vector3(0,
            m_mainCamHolder.transform.position.y - 1.5f,
            0);
    }
}
