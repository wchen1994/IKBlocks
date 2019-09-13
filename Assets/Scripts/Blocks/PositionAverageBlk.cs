using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAverageBlk : Block
{
    [SerializeField] Transform[] m_Targets;
    private Vector3 m_Center = new Vector3();

    public override void OnState()
    {
        // Find Center
        m_Center.Set(0, 0, 0);
        for (int i=0; i<m_Targets.Length; ++i)
        {
            m_Center += m_Targets[i].position;
        }
        m_Center /= m_Targets.Length;

        // Snap to Center
        transform.position = m_Center;
    }
}
