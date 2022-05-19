using UnityEngine;

public abstract class StaticInstance<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T _instance;
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if(!_instance)
        _instance=this as T;
    }
    
    private void OnApplicationQuit() {
        _instance=null;
        Destroy(gameObject);
    }
}
public abstract class Singleton<T> : StaticInstance<T> where T:MonoBehaviour
{
    protected override void Awake()
    {
        if(Instance)
            Destroy(Instance);
    }
    
}


public abstract class SingletonPersistent<T> : Singleton<T> where T:MonoBehaviour
{

    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        base.Awake();        
    }
    
}