using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private Effect effect;

    // Start is called before the first frame update
    void Start()
    {
        if (name != "")
        {
            transform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;
        }
        transform.Find("Effect").GetComponent<TextMeshProUGUI>().text = effect.GetEffectText();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
