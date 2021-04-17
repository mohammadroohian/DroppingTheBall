using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : InputController
{
    // monoBehaviour___________________________________________________________
    void Update()
    {
        if (!m_isActive) return;

        // Smoothly tilts a transform towards a target rotation.
        m_currentAngle += Input.GetAxis("Horizontal") * m_speed;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, m_currentAngle, 0);

        // Dampen towards the target rotation
        m_baseGameObject.transform.rotation = Quaternion.Slerp(m_baseGameObject.transform.rotation,
            target,
            Time.deltaTime * m_smooth);
    }
}
