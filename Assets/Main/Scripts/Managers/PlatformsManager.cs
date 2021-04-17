using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    // variable________________________________________________________________
    private static PlatformsManager m_instance = null;

    public Platform[] m_firstPlatforms = null;
    public Platform[] m_starterPlatforms = null;
    public Platform[] m_platforms = null;
    public Platform[] m_winPlatforms = null;


    // property________________________________________________________________
    public static PlatformsManager Instance { get { return m_instance; } }


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        if (Instance == null)
            m_instance = this;
        else
            Destroy(this);
    }
}
