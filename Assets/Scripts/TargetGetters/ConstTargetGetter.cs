using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstTargetGetter : TargetGetter
{
    public Transform m_Target;

    private void Awake()
    {
        if (m_Target == null)
        {
            Debug.LogWarning("Target can not be null.");
            enabled = false;
        }
    }

    public override Transform Get()
    {
        return m_Target;
    }
}
