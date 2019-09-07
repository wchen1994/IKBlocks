using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] protected Block m_Dependency;
    public Block Dependency { get { return m_Dependency; } }

    private int m_Version;
    public int Version { get { return m_Version; } }

    private void LateUpdate()
    {
        State();
    }

    private void State()
    {
        // Return if is Stated.
        if (m_Version == IKManager.Instance.Version)
        {
            return;
        }

        // State teh Dependency Block if it hasn't.
        if (m_Dependency != null && m_Dependency.Version != IKManager.Instance.Version)
        {
            m_Dependency.State();
        }

        // State the block
        OnState();

        m_Version = IKManager.Instance.Version;
    }

    public abstract void OnState();
}
