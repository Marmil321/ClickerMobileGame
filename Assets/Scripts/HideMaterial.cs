using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideMaterial : MonoBehaviour
{
    [SerializeField] string str;
 
    private void Update()
    {
        GameObject hide = this.transform.Find("?").gameObject;

        if (PlayerPrefs.GetInt(str) > 0)
        {
            hide.SetActive(false);
            this.GetComponent<Image>().enabled = true;
            Destroy(this);
        } else
        {
            hide.SetActive(true);
            this.GetComponent<Image>().enabled = false;
        }
    }
}
