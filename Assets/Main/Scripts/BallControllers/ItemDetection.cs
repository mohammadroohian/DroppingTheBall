using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour
{
    // variable________________________________________________________________
    public string m_itemTag = "Star";


    // monoBehaviour___________________________________________________________
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != m_itemTag) return;

        print("+" + m_itemTag);
    }
}
