﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlkIterator : MonoBehaviour
{
    [SerializeField] int m_Iteration = 1;
    [SerializeField] Block m_IterateBlock = null;

    private void Start()
    {
        if (m_IterateBlock == null)
        {
            enabled = false;
        }
    }

    private void LateUpdate()
    {
        for (int i = 1; i < m_Iteration; ++i)
        {
            RecurState(m_IterateBlock);
        }
    }

    private static void RecurState(Block blk)
    {
        if (blk.Dependency != null)
        {
            RecurState(blk.Dependency);
        }
        blk.OnState();
    }
}
