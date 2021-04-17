using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // variable________________________________________________________________
    public Transform m_platformHolder = null;
    public float m_platformsDistance = 1.5f;
    public int m_starterPlatformsCount = 2;
    public int m_platformsCount = 20;


    // function________________________________________________________________
    public void GeneratePlatforms()
    {
        Vector3 tmpPos = new Vector3();

        // first platform
        GameObject tmpObjF = Instantiate(PlatformsManager.Instance.m_firstPlatforms[
            Random.Range(0, PlatformsManager.Instance.m_firstPlatforms.Length)],
            tmpPos,
            Quaternion.Euler(0, 0, 0)).gameObject;
        tmpObjF.transform.SetParent(m_platformHolder);
        tmpPos -= new Vector3(0, m_platformsDistance, 0);

        // starter platforms
        for (int i = 0; i < m_starterPlatformsCount; i++)
        {
            GameObject tmpObjS = Instantiate(PlatformsManager.Instance.m_starterPlatforms[
                Random.Range(0, PlatformsManager.Instance.m_starterPlatforms.Length)],
                tmpPos,
                Quaternion.Euler(0, Random.Range(0, 360), 0)).gameObject;
            tmpPos -= new Vector3(0, m_platformsDistance, 0);
            tmpObjS.transform.SetParent(m_platformHolder);
        }

        // platforms
        for (int i = 1; i < m_platformsCount; i++)
        {
            GameObject tmpObj = Instantiate(PlatformsManager.Instance.m_platforms[
                Random.Range(0, PlatformsManager.Instance.m_platforms.Length)],
                tmpPos,
                Quaternion.Euler(0, Random.Range(0, 360), 0)).gameObject;
            tmpPos -= new Vector3(0, m_platformsDistance, 0);
            tmpObj.transform.SetParent(m_platformHolder);
        }

        // win platform
        GameObject tmpObjW = Instantiate(PlatformsManager.Instance.m_winPlatforms[
            Random.Range(0, PlatformsManager.Instance.m_winPlatforms.Length)],
            tmpPos,
            Quaternion.identity).gameObject;
        tmpObjW.transform.SetParent(m_platformHolder);
    }
}
