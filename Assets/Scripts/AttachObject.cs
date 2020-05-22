using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObject : MonoBehaviour
{
    public Transform m_AttachingPosition;
    public Quaternion m_AttachingObjectStartRotation;
    public float m_AttachingObjectSpeed;
    public bool m_AttachedObject;
    public bool m_AttachingObject;

    bool canShoot;

    public Rigidbody m_ObjectAttached;


    // Use this for initialization
    void Start()
    {
        m_AttachingObjectStartRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray l_CameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit l_RayCastHit;
            if (Physics.Raycast(l_CameraRay, out l_RayCastHit, 200f/*, m_ShootLayerMask.value*/))
            {
                /*
                if (l_RayCastHit.collider.tag != "CompanionCube" && !attachObj.m_AttachedObject && !attachObj.m_AttachingObject)
                {
                   // bluePlaceholder.gameObject.SetActive(true);
                   // m_BluePortal.gameObject.SetActive(false);
                }
                else
                {
                   // bluePlaceholder.gameObject.SetActive(false);
                }
                */
            }
        }
    }

    void LateUpdate()
    {
        canShoot = false;

        if (Input.GetMouseButtonDown(1) && m_AttachingObject) DetachObject(0f);
        if (Input.GetMouseButtonDown(0) && m_AttachingObject && !canShoot) DetachObject(1000f);


        if (Input.GetMouseButtonDown(0) && !m_AttachingObject && !canShoot)
        {
            ShootToAttachObject();
        }

        if (m_AttachingObject) UpdateAttachedObject();


    }


    void ShootToAttachObject()
    {
        Ray l_CameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit l_RayCastHit;

        if (Physics.Raycast(l_CameraRay, out l_RayCastHit, 6f))
        {
            if (l_RayCastHit.collider.tag == "CompanionCube" || l_RayCastHit.collider.tag == "Turret" || l_RayCastHit.collider.tag == "RefractionCube")
            {
                m_ObjectAttached = l_RayCastHit.rigidbody;
                m_AttachingObject = true;
                m_ObjectAttached.isKinematic = true;
            }
        }
    }

    void UpdateAttachedObject()
    {
        Vector3 l_EulerAngles = m_AttachingPosition.rotation.eulerAngles;
        if (!m_AttachedObject)
        {
            Vector3 l_Direction = m_AttachingPosition.transform.position - m_ObjectAttached.transform.position;
            float l_Distance = l_Direction.magnitude;
            float l_Movement = m_AttachingObjectSpeed * Time.deltaTime;

            Debug.Log("l_Distance : " + l_Distance);
            Debug.Log("l_movement : " + l_Movement);
            if (l_Movement >= l_Distance)
            {
                m_AttachedObject = true;
                m_ObjectAttached.MovePosition(m_AttachingPosition.position);
                m_ObjectAttached.MoveRotation(Quaternion.Euler(0.0f, l_EulerAngles.y, l_EulerAngles.z));
            }
            else
            {
                l_Direction /= l_Distance;
                m_ObjectAttached.MovePosition(m_ObjectAttached.transform.position + l_Direction * l_Movement);
                m_ObjectAttached.MoveRotation(Quaternion.Lerp(m_AttachingObjectStartRotation, Quaternion.Euler(0.0f, l_EulerAngles.y, l_EulerAngles.z), 1.0f - Mathf.Min(l_Distance / 1.5f, 1.0f)));
            }
        }
        else
        {
            m_ObjectAttached.MoveRotation(Quaternion.Euler(0.0f, l_EulerAngles.y, l_EulerAngles.z));
            m_ObjectAttached.MovePosition(m_AttachingPosition.position);
        }
    }

    void DetachObject(float Force)
    {
        m_AttachedObject = false;
        m_AttachingObject = false;
        m_ObjectAttached.isKinematic = false;
        // m_ObjectAttached.GetComponent<Companion>().SetTeleport(true);
        m_ObjectAttached.AddForce(m_AttachingPosition.forward * Force);
        canShoot = true;
    }
}
