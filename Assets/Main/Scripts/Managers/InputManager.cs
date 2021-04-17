using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // variable________________________________________________________________
    private static InputManager m_instance = null;
    private bool m_isFreezed = false;
    private InputController[] m_inputSystems;

    // property________________________________________________________________
    public static InputManager Instance { get { return m_instance; } }
    public bool IsFreezed
    {
        get => m_isFreezed; set
        {
            m_isFreezed = value;
            if (m_isFreezed)
                DeactiveInput();
        }
    }
    public InputController[] InputSystems { get => m_inputSystems; set => m_inputSystems = value; }


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        if (Instance == null)
            m_instance = this;
        else
            Destroy(this);

        InputSystems = GetComponentsInChildren<InputController>();
    }

    public void DeactiveInput()
    {
        for (int i = 0; i < InputSystems.Length; i++)
        {
            InputSystems[i].DeactiveInput();
        }
    }
    public void ActiveInput()
    {
        for (int i = 0; i < InputSystems.Length; i++)
        {
            InputSystems[i].ActiveInput();
        }
    }

}
