﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlkBackward : Block
{
    private Vector3 m_OriginPosition;

    private void Awake()
    {
        m_OriginPosition = transform.localPosition;
    }

    public override void OnState()
    {
        transform.localPosition = m_OriginPosition;
    }
}
