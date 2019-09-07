using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlkForward : Block
{
    private float m_JointLength;
    private Vector3 m_JointDirection;
    private Quaternion m_InverseRotation;

    [SerializeField] TargetGetter m_TargetGetter;

    private void Awake()
    {
        if (m_TargetGetter == null && transform.childCount == 1)
        {
            m_TargetGetter = gameObject.AddComponent<ConstTargetGetter>();
            ((ConstTargetGetter)m_TargetGetter).m_Target = transform.GetChild(0);
        } else if (m_TargetGetter != null)
        {
            Vector3 offset = m_TargetGetter.Get().position - transform.position;
            m_JointLength = offset.magnitude;
            m_JointDirection = offset.normalized;
            m_InverseRotation = Quaternion.LookRotation(transform.forward, m_JointDirection);
            m_InverseRotation = Quaternion.Inverse(m_InverseRotation);
        }

    }

    public override void OnState()
    {
        if (!m_TargetGetter.enabled || m_TargetGetter == null)
        {
            return;
        }

        Transform targetTrans = m_TargetGetter.Get();
        Vector3 direction = (targetTrans.position - transform.position).normalized;
        transform.position = targetTrans.position - direction * m_JointLength;

        //transform.rotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.LookRotation(direction) * m_InverseRotation;
    }
}
