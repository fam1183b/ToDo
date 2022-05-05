using UnityEngine;
using UnityEngine.UI;

public class TaskControl : MonoBehaviour
{
    public void Update()
    {
        if (transform.GetChild(1).GetComponent<Toggle>().isOn == true && gameObject.GetComponent<Image>().color == new Color32(255, 0, 0, 100))
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color32(154, 74, 74, 100);
        }
        else if (transform.GetChild(1).GetComponent<Toggle>().isOn == false && gameObject.GetComponent<Image>().color == new Color32(154, 74, 74, 100))
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color32(255, 0, 0, 100);
        }
    }
}
