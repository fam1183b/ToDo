using UnityEngine;
using UnityEngine.UI;

public class NewChangeTask : MonoBehaviour
{
    GameObject parants;
    public GameObject panel;

    private void Start()
    {
        string _task = "";
        int g = 0;
        if (PlayerPrefs.HasKey("Task"))
        {
            _task = PlayerPrefs.GetString("Task");
            while ((g = _task.IndexOf(" -;- ", 0)) != 0)
            {
                panel.transform.GetChild(2).GetComponent<Text>().text = _task.Substring(0, g);
                _task = _task.Remove(0, g + 5);
                panel.transform.GetChild(3).GetComponent<Text>().text = _task.Substring(0, g = _task.IndexOf(" -;- ", 0));
                _task = _task.Remove(0, g + 5);
                panel.transform.GetChild(4).GetComponent<Text>().text = _task.Substring(0, g = _task.IndexOf(" -;- ", 0));
                _task = _task.Remove(0, g + 5);
                if (_task.Substring(0, g = _task.IndexOf(" -;- ", 0)) == "0")
                {
                    panel.transform.GetChild(1).GetComponent<Toggle>().isOn = true;
                }
                else
                {
                    panel.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
                }
                _task = _task.Remove(0, g + 5);

                Instantiate(panel, transform.GetChild(1).GetChild(0).GetChild(0).transform);
            }
            panel.transform.GetChild(2).GetComponent<Text>().text = "";
            panel.transform.GetChild(3).GetComponent<Text>().text = "";
            panel.transform.GetChild(4).GetComponent<Text>().text = "";
            panel.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        }
    }

    public void FixedUpdate()
    {
        string task = "";
        for (int f = 0; f < transform.GetChild(1).GetChild(0).GetChild(0).transform.childCount; f++)
        {
            int flag = 1;
            if (transform.GetChild(1).GetChild(0).GetChild(0).GetChild(f).GetComponent<Image>().color == new Color32(154, 74, 74, 100))
            {
                flag = 0;
            }
            task = task + transform.GetChild(1).GetChild(0).GetChild(0).GetChild(f).GetChild(2).GetComponent<Text>().text + " -;- " + transform.GetChild(1).GetChild(0).GetChild(0).GetChild(f).GetChild(3).GetComponent<Text>().text + " -;- " + transform.GetChild(1).GetChild(0).GetChild(0).GetChild(f).GetChild(4).GetComponent<Text>().text + " -;- " + flag + " -;- ";
        }
        PlayerPrefs.SetString("Task", task);
        PlayerPrefs.Save();
    }

    public void AddTask()
    {
        panel.transform.GetChild(2).GetComponent<Text>().text = "";
        panel.transform.GetChild(3).GetComponent<Text>().text = "";
        panel.transform.GetChild(4).GetComponent<Text>().text = "";
        panel.transform.GetChild(1).GetComponent<Toggle>().isOn = false;
        parants = Instantiate(panel, transform.GetChild(1).GetChild(0).GetChild(0).transform);
        transform.GetChild(5).gameObject.SetActive(true);
        transform.GetChild(6).gameObject.SetActive(true);

        transform.GetChild(6).GetChild(1).GetComponent<InputField>().text = "";
        transform.GetChild(6).GetChild(1).GetChild(1).GetComponent<Text>().text = "Enter text...";

        transform.GetChild(6).GetChild(0).GetComponent<InputField>().text = "";
        transform.GetChild(6).GetChild(0).GetChild(1).GetComponent<Text>().text = "Enter text...";

    }

    public void Activ(GameObject _parants)
    {
        parants = _parants;
        transform.GetChild(5).gameObject.SetActive(true);
        transform.GetChild(6).gameObject.SetActive(true);
        
        transform.GetChild(6).GetChild(1).GetComponent<InputField>().text = "";
        transform.GetChild(6).GetChild(1).GetChild(1).GetComponent<Text>().text = "Enter text...";
        
        transform.GetChild(6).GetChild(0).GetComponent<InputField>().text = "";
        transform.GetChild(6).GetChild(0).GetChild(1).GetComponent<Text>().text = "Enter text...";

        if (parants.transform.GetChild(3).GetComponent<Text>().text != "") transform.GetChild(6).GetChild(0).GetComponent<InputField>().text = parants.transform.GetChild(3).GetComponent<Text>().text;
        if (parants.transform.GetChild(2).GetComponent<Text>().text != "") transform.GetChild(6).GetChild(1).GetComponent<InputField>().text = parants.transform.GetChild(2).GetComponent<Text>().text;
    }

    public void ChangeTask(string s)
    {
        if (s == "1")
        {
            Destroy(parants);
            transform.GetChild(6).gameObject.SetActive(false);
            transform.GetChild(5).gameObject.SetActive(false);
        }
        
        if (s == "2")
        {
            parants.transform.GetChild(2).GetComponent<Text>().text = transform.GetChild(6).GetChild(1).GetComponent<InputField>().text;
            parants.transform.GetChild(3).GetComponent<Text>().text = transform.GetChild(6).GetChild(0).GetComponent<InputField>().text;
            parants.transform.GetChild(4).GetComponent<Text>().text = System.DateTime.Now.ToString().Substring(0, 11);

            transform.GetChild(5).gameObject.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
        }
    }
}
