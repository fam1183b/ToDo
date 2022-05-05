using UnityEngine;
using UnityEngine.UI;

public class ChangeToDoList : MonoBehaviour
{
    public void ChangeFilter(GameObject txt)
    {
        if (txt.GetComponent<Text>().text == "Активные")
        {
            txt.GetComponent<Text>().text = "Выполненые";
        }
        else
        {
            txt.GetComponent<Text>().text = "Активные";
        }
        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf == true)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
