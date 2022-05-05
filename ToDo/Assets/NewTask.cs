using UnityEngine;
using UnityEngine.UI;

public class NewTask : MonoBehaviour
{
    public void KASTIL()
    {
        transform.parent.parent.parent.parent.gameObject.GetComponent<NewChangeTask>().Activ(gameObject);
    }
}
