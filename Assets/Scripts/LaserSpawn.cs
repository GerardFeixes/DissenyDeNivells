using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    public LineRenderer m_LineRenderer;
    public LayerMask m_CollisionLayerMask;
    public float m_MaxDistance;
    public float m_AngleLaserActive = 60f;

    bool IsLaserActive;

    // Use this for initialization
    void Start()
    {
        IsLaserActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 l_EndRaycastPosition = Vector3.forward * m_MaxDistance;
        RaycastHit l_RaycastHit;
        if (Physics.Raycast(new Ray(m_LineRenderer.transform.position, m_LineRenderer.transform.forward), out l_RaycastHit, m_MaxDistance, m_CollisionLayerMask.value))

            l_EndRaycastPosition = m_LineRenderer.gameObject.transform.InverseTransformPoint(l_RaycastHit.point);
        m_LineRenderer.SetPosition(1, l_EndRaycastPosition);

       // if (l_RaycastHit.collider.tag == "Player") l_RaycastHit.collider.GetComponentInParent<PlayerController>().PlayerDie();
        if (l_RaycastHit.collider.tag == "RefractionCube")
        {
            l_RaycastHit.collider.GetComponent<RefractionCube>().CreateRefraction();
        }

        if (IsLaserActive)
        {
            m_LineRenderer.gameObject.SetActive(true);
        }
        
        else
        {
            m_LineRenderer.gameObject.SetActive(false);
        }
        
    }
    /*
    bool IsLaserActive()
    {
        float l_DotAngleLaserActive = Mathf.Cos(m_AngleLaserActive * Mathf.Deg2Rad * 0.5f);
        bool l_RayActive = Vector3.Dot(transform.up, Vector3.up) > l_DotAngleLaserActive;

        return l_RayActive;
    }
    */
}
