#region

using UnityEngine;

#endregion

public abstract class Element : MonoBehaviour
{
    public abstract ElementType ElementType { set; get; }

    public abstract IElementLogic ElementLogic { set; get; }

    public int StartRotation
    {
        get => (int) transform.rotation.eulerAngles.z;
        set
        {
            var newRotation = Quaternion.Euler(0, 0, value);
            transform.rotation = newRotation;
        }
    }

    public void Awake()
    {
        ElementLogic = GetComponent<IElementLogic>();
    }
}