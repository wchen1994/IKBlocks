using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlkInterator : Block
{
    [SerializeField] int iteration;

    public override void OnState()
    {
        for (int i=1; i<iteration; ++i)
        {
            RecurState(m_Dependency);
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
