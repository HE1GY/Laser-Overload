using UnityEngine;

public abstract class Element:MonoBehaviour
{
    public abstract ElementType ElementType { set; get; }
    public  int StartRotation 
    { 
        get=>(int)transform.rotation.eulerAngles.z;
        set
        {
            Quaternion newRotation = Quaternion.Euler(0, 0, value);
            transform.rotation = newRotation;
        }
    }
    
    
    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}