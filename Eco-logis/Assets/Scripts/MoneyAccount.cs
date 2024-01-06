using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyAccount : MonoBehaviour
{
    string textVariable = "600$";
    public TextMeshProUGUI moneyText;
    string int_to_string;
    string dollard = " $";
    int money = 799;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = textVariable;
    }

    // Update is called once per frame
    void Update()
    {
        money = (int)(CoreMechanics.kid);
        int_to_string = money.ToString();
        textVariable = string.Concat(int_to_string, dollard);
        moneyText.text = textVariable;
    }
}
