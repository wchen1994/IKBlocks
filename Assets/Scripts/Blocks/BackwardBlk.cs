using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardBlk : Block
{
    private Vector3 m_OriginPosition;

    private void Start()
    {
        m_OriginPosition = transform.localPosition;
    }

    public override void OnState()
    {
        transform.localPosition = m_OriginPosition;
    }
}
