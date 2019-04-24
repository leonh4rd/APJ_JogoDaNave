using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeController : MonoBehaviour
{
    TextMeshProUGUI lifesText = null;
    int lifes = 3;

    public int Lifes
    {
        get
        {
            return lifes;
        }
        set
        {
            lifes = value;
            lifesText.text = lifes.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lifesText = GetComponent<TextMeshProUGUI>();
        Lifes = lifes;
    }

}
