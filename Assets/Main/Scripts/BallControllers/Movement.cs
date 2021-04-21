using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // variable________________________________________________________________
    public string m_groundDetectionTag = "Platform";
    [SerializeField] private float m_speed = 2f;
    public float m_maxHight = 1f;
    public float m_impactOffset = 0.1f;
    public GameObject m_impactPrefab;
    private Vector3 m_speedVec;
    private Vector3 m_currentTopPoint;
    private Transform m_basePlatform = null;
    Rigidbody m_Rigidbody;


    // property________________________________________________________________
    public bool IsGoingUp
    {
        get
        {
            if (Speed > 0) return true;
            else return false;
        }
    }
    public float Speed
    {
        get => m_speed;
        set
        {
            m_speed = value;
            UpdateSpeedVec();
        }
    }
    public Transform BasePlatform
    {
        get => m_basePlatform;
        set
        {
            m_basePlatform = value;
            UpdateCurrentTopPoint();
        }
    }


    // monoBehaviour___________________________________________________________
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        UpdateSpeedVec();
    }
    private void FixedUpdate()
    {
        if (IsGoingUp && transform.position.y > m_currentTopPoint.y)
        {
            Speed = -Speed;
        }

        m_Rigidbody.MovePosition(transform.position +
                m_speedVec *
                Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (LevelManager.Instance.GameIsWinOrGameOver) return;
        if (other.gameObject.tag != m_groundDetectionTag) return;

        if (BasePlatform != other.transform)
            BasePlatform = other.transform;
        ForceGoUp();

        Vector3 imPos = new Vector3(transform.position.x, other.transform.position.y + m_impactOffset, transform.position.z);
        GameObject tmpG = Instantiate(m_impactPrefab, imPos, Quaternion.identity) as GameObject;
        tmpG.transform.SetParent(other.transform);
    }


    // function________________________________________________________________
    public void ForceGoUp() => Speed = Mathf.Abs(Speed);
    public void SetSpeed(float newSpeed) => Speed = newSpeed;
    private void UpdateSpeedVec() => m_speedVec = new Vector3(0, Speed, 0);
    private void UpdateCurrentTopPoint() => m_currentTopPoint = new Vector3(transform.position.x,
                BasePlatform.position.y + m_maxHight,
                transform.position.z);
}
