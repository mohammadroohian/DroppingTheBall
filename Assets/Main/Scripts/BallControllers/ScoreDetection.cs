using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetection : MonoBehaviour
{
    // variable________________________________________________________________
    [Tag]
    public string m_scoreDetectionTag = "ScoreTrigger";
    public int m_scorePerDectection = 8;


    // monoBehaviour___________________________________________________________
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != m_scoreDetectionTag) return;

        // add score
        ScoreManager.Instance.NewScore += m_scorePerDectection;

        // deactive trigger
        other.gameObject.SetActive(false);

        // camera
        CameraManager.Instance.GoToNextPosition();
    }
}
