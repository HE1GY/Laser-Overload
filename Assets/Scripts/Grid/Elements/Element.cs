using UnityEngine;

public abstract class Element:MonoBehaviour
{
    public abstract ElementType ElementType { protected set; get; }
    

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}