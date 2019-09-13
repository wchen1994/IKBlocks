using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    [SerializeField] private Block m_Dependency = null;
    public Block Dependency { get { return m_Dependency; } }
    public int Version { get; private set; }
    //public int DepentCount { get; private set; } = 0;
    //private bool m_Linked = false;

    private void LateUpdate()
    {
        State();
    }

    private void State()
    {
        // Return if is Stated.
        if (Version == IKManager.Instance.Version)
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

        Version = IKManager.Instance.Version;
    }

    public abstract void OnState();

    //private void Link()
    //{
    //    if (!m_Linked)
    //    {
    //        if (m_Dependency != null)
    //        {
    //            m_Dependency.DepentCount++;
    //        }
    //        m_Linked = true;
    //    }
    //}

    //private void Unlink()
    //{
    //    if (m_Linked)
    //    {
    //        if (m_Dependency != null)
    //        {
    //            m_Dependency.DepentCount--;
    //        }
    //        m_Linked = false;
    //    }
    //}

    //protected void Awake()
    //{
    //    Link();
    //}

    //private void OnEnable()
    //{
    //    Link();   
    //}

    //private void OnDestroy()
    //{
    //    Unlink();
    //}

    //private void OnDisable()
    //{
    //    Unlink();
    //}

}
