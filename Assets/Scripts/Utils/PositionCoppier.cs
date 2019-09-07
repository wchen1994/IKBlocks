using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCoppier : MonoBehaviour
{
    [SerializeField] Transform m_Target;

    private void LateUpdate()
    {
        transform.position = m_Target.position;
    }
}
