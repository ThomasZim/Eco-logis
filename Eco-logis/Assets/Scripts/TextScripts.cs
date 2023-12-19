using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScripts : MonoBehaviour
{
    [SerializeField] private GameObject _textBad;
    [SerializeField] private GameObject _textMedium;
    [SerializeField] private GameObject _textGood;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (this.name)
        {
            case "MoneyBalance":
            {
                this.GetComponent<TMP_Text>().text = "Money: " + CoreMechanics.money + "€";
            }
                break;
            case "FridgeUpgradeMenu":
            {
                switch (CoreMechanics.fridgeLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.fridgeCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.fridgeCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.fridgeCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.fridgeCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.fridgeCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.fridgeCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
            case "HeatingUpgradeMenu":
            {
                switch (CoreMechanics.heaterLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.heaterCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.heaterCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.heaterCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.heaterCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.heaterCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.heaterCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
            case "AirCondUpgradeMenu":
            {
                switch (CoreMechanics.conditionerLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.conditionerCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.conditionerCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.conditionerCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.conditionerCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.conditionerCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.conditionerCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
            case "WashingMachineUpgradeMenu":
            {
                switch (CoreMechanics.washMachineLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.washMachineCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.washMachineCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.washMachineCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.washMachineCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.washMachineCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.washMachineCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
            case "DishwasherUpgradeMenu":
            {
                switch (CoreMechanics.dishwasherLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.dishwasherCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.dishwasherCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.dishwasherCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.dishwasherCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.dishwasherCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.dishwasherCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
            case "LightningUpgradeMenu":
            {
                switch (CoreMechanics.lightLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.lightCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.lightCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.lightCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.lightCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.lightCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.lightCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
            case "OvenUpgradeMenu":
            {
                switch (CoreMechanics.ovenLevel)
                {
                    case 0:
                    {
                        _textBad.GetComponent<TMP_Text>().text = "BAD\n (Current)";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Upgrade: " + CoreMechanics.ovenCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.ovenCosts[2] + "€";
                    }
                        break;
                    case 1:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.ovenCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text = "MEDIUM\n (Current)";
                        _textGood.GetComponent<TMP_Text>().text =
                            "GOOD\n Upgrade: " + CoreMechanics.ovenCosts[2] + "€";
                    }
                        break;
                    case 2:
                    {
                        _textBad.GetComponent<TMP_Text>().text =
                            "BAD\n Downgrade: " + CoreMechanics.ovenCosts[0] + "€";
                        _textMedium.GetComponent<TMP_Text>().text =
                            "MEDIUM\n Downgrade: " + CoreMechanics.ovenCosts[1] + "€";
                        _textGood.GetComponent<TMP_Text>().text = "GOOD\n (Current)";
                    }
                        break;
                }
            }
                break;
        }
    }

    public void pressButton(string buttonName)
    {
        switch (this.name)
        {
            case "FridgeUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if (CoreMechanics.fridgeLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.fridgeCosts[0]))
                            {
                                CoreMechanics.fridgeLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.fridgeLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.fridgeCosts[1]))
                            {
                                CoreMechanics.fridgeLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.fridgeLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.fridgeCosts[2]))
                            {
                                CoreMechanics.fridgeLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
            case "HeatingUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if(CoreMechanics.heaterLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.heaterCosts[0]))
                            {
                                CoreMechanics.heaterLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.heaterLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.heaterCosts[1]))
                            {
                                CoreMechanics.heaterLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.heaterLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.heaterCosts[2]))
                            {
                                CoreMechanics.heaterLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
            case "AirCondUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if (CoreMechanics.conditionerLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.conditionerCosts[0]))
                            {
                                CoreMechanics.conditionerLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.conditionerLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.conditionerCosts[1]))
                            {
                                CoreMechanics.conditionerLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.conditionerLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.conditionerCosts[2]))
                            {
                                CoreMechanics.conditionerLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
            case "WashingMachineUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if(CoreMechanics.washMachineLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.washMachineCosts[0]))
                            {
                                CoreMechanics.washMachineLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.washMachineLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.washMachineCosts[1]))
                            {
                                CoreMechanics.washMachineLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.washMachineLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.washMachineCosts[2]))
                            {
                                CoreMechanics.washMachineLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
            case "DishwasherUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if (CoreMechanics.dishwasherLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.dishwasherCosts[0]))
                            {
                                CoreMechanics.dishwasherLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.dishwasherLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.dishwasherCosts[1]))
                            {
                                CoreMechanics.dishwasherLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.dishwasherLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.dishwasherCosts[2]))
                            {
                                CoreMechanics.dishwasherLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
            case "LightningUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if (CoreMechanics.lightLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.lightCosts[0]))
                            {
                                CoreMechanics.lightLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.lightLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.lightCosts[1]))
                            {
                                CoreMechanics.lightLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.lightLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.lightCosts[2]))
                            {
                                CoreMechanics.lightLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
            case "OvenUpgradeMenu":
            {
                switch (buttonName)
                {
                    case "bad":
                    {
                        if (CoreMechanics.ovenLevel != 0)
                        {
                            if (tryUpgrade(CoreMechanics.ovenCosts[0]))
                            {
                                CoreMechanics.ovenLevel = 0;
                            }
                        }
                    }
                        break;
                    case "medium":
                    {
                        if (CoreMechanics.ovenLevel != 1)
                        {
                            if (tryUpgrade(CoreMechanics.ovenCosts[1]))
                            {
                                CoreMechanics.ovenLevel = 1;
                            }
                        }
                    }
                        break;
                    case "good":
                    {
                        if (CoreMechanics.ovenLevel != 2)
                        {
                            if (tryUpgrade(CoreMechanics.ovenCosts[2]))
                            {
                                CoreMechanics.ovenLevel = 2;
                            }
                        }
                    }
                        break;
                }
            }
                break;
        }
    }

    private bool tryUpgrade(double cost)
    {
        if (CoreMechanics.money >= cost)
        {
            CoreMechanics.money -= cost;
            return true;
        }

        return false;
    }
}
