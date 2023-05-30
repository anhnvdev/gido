
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public string objectName;
    // Start is called before the first frame update

    private void Awake()
    {
        objectName = name;
    }
}
