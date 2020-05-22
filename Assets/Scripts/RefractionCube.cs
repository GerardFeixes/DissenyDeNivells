﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractionCube : MonoBehaviour
{

    public LineRenderer m_LineRenderer;
    private bool m_CreateRefraction;
    public float m_MaxDistance;
    public LayerMask m_CollisionLayerMask;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_LineRenderer.gameObject.SetActive(m_CreateRefraction);
        m_CreateRefraction = false;
    }
    public void CreateRefraction()
    {
        m_CreateRefraction = true;
        Vector3 l_EndRaycastPosition = Vector3.forward * m_MaxDistance;
        RaycastHit l_RaycastHit;
        if (Physics.Raycast(new Ray(m_LineRenderer.transform.position, m_LineRenderer.transform.forward), out l_RaycastHit, m_MaxDistance,
        m_CollisionLayerMask.value))
        {
            l_EndRaycastPosition = m_LineRenderer.gameObject.transform.InverseTransformPoint(l_RaycastHit.point);

            if (l_RaycastHit.collider.tag == "RefractionCube")
            {
                l_RaycastHit.collider.GetComponent<RefractionCube>().CreateRefraction();
            }


            /*
            if (l_RaycastHit.collider.tag == "Turret")
            {
                l_RaycastHit.collider.GetComponent<Turret>().DestroyTurret();
            }
            */

           // if (l_RaycastHit.collider.tag == "RefractionButton" /*&& !l_RaycastHit.collider.GetComponent<ButtonController>().stop*/) l_RaycastHit.collider.GetComponent<ButtonController>().TriggerLaser();
            //Other collisions
        }
        m_LineRenderer.SetPosition(1, l_EndRaycastPosition);
    }
}
