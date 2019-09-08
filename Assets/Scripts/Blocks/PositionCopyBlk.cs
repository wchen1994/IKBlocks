using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCopyBlk : Block
{
    [SerializeField] Transform m_Target = null;

    public override void OnState()
    {
        if (m_Target != null)
        {
            transform.position = m_Target.position;
        }
    }
}
