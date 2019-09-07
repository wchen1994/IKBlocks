using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : Singleton<IKManager>
{
    private int m_Version = 0;
    public int Version{
        get{
            if (m_UpdateLead != m_UpdateFollow){
                UpdateVersion();
            }
            return m_Version;
        }
    }

    private bool m_UpdateLead = false;
    private bool m_UpdateFollow = true;
    
    private float m_UpdateTime = 0;

    private void Update(){
        m_UpdateLead = !m_UpdateLead;
    }

    private void UpdateVersion()
    {
        ++m_Version;
        m_UpdateFollow = m_UpdateLead;
    }
}
