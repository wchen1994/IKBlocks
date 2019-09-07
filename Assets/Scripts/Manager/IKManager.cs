using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : Singleton<IKManager>
{
    private int m_Version = 0;
    public int Version{
        get{
            if (!Mathf.Approximately(m_UpdateTime, Time.time)){
                UpdateVersion();
            }
            return m_Version;
        }
    }
    
    private float m_UpdateTime = 0;

    private void UpdateVersion()
    {
        ++m_Version;
        m_UpdateTime = Time.time;
    }
}
