using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T m_Instance;
    public static T Instance{
        get{
            if (m_Instance == null){
                m_Instance = FindObjectOfType<T>();
            }
            if (m_Instance == null){
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                m_Instance = obj.AddComponent<T>();
            }
            return m_Instance;
        }
    }

    private void Awake(){
        if (m_Instance != null && m_Instance != this){
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }
}