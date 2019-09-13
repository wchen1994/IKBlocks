using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardBlk : Block, IDesirePosition, IDesireRotation
{
    private float m_JointLength;
    private Vector3 m_JointDirection;
    private Quaternion m_CompenstateRotation;

    Vector3 m_DesirePosition;
    Quaternion m_DesireRotation;

    [SerializeField] Transform m_Target = null;
    [SerializeField] bool m_IsSolver = false;
    private IDesirePosition m_TargetDesirePosition;

    private void Start()
    {
        if (m_Target == null && transform.childCount == 1)
        {
            m_Target = transform.GetChild(0);
        } else if (m_Target != null)
        {
            Vector3 offset = m_Target.position - transform.position;
            m_JointLength = offset.magnitude;
            if (m_JointLength > Mathf.Epsilon)
            {
                m_JointDirection = offset.normalized;
                m_CompenstateRotation = Quaternion.FromToRotation(m_JointDirection, transform.forward);
            }
        } else
        {
            Debug.LogError("Can't determine which target is.");
        }
        m_TargetDesirePosition = m_Target.GetComponent<IDesirePosition>();
    }

    public override void OnState()
    {
        if (m_Target == null)
        {
            return;
        }

        // Setup target position
        Vector3 m_TargetPosition;
        if (m_TargetDesirePosition != null)
        {
            m_TargetPosition = m_TargetDesirePosition.GetDesirPosition();
        }
        else
        {
            m_TargetPosition = m_Target.position;
        }

        // Setup desire position and rotation
        Vector3 offset = m_TargetPosition - transform.position;
        if (offset.sqrMagnitude > Mathf.Epsilon) {
            // Move
            Vector3 direction = (offset).normalized;
            m_DesirePosition = m_TargetPosition - direction * m_JointLength;

            // Rotate
            //m_DesireRotation = Quaternion.LookRotation(direction);
            m_DesireRotation = Quaternion.LookRotation(direction) * m_CompenstateRotation;
        }

        // ResolveDesire position and rotation chant
        if (m_IsSolver)
        {
            ResolveDesire();
        }
    }

    protected void ResolveDesire()
    {
        transform.position = m_DesirePosition;
        transform.rotation = m_DesireRotation;
        if (Dependency != null && Dependency.GetType() == typeof(ForwardBlk))
        {
            ((ForwardBlk)Dependency).ResolveDesire();
        }
    }

    public Vector3 GetDesirPosition()
    {
        return m_DesirePosition;
    }

    public Quaternion GetDesirRotation()
    {
        return m_DesireRotation;
    }
}
