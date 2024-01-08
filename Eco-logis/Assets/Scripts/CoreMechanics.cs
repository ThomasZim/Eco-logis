using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography;
using Debug = System.Diagnostics.Debug;
using UnityEngine.SceneManagement;

public static class CoreMechanics
{
    private static Thread t;

    public static string playerScene = "";

    public static bool isFinised = false;
    public static bool isVictory = false;

    //Upgrade cost
    public static double[] lightCosts = { 7, 13, 20 };
    public static double[] fridgeCosts = { 360, 630, 840 };
    public static double[] ovenCosts = { 2350, 4790, 6895 };
    public static double[] washMachineCosts = { 700, 1600, 2900 }; 
    public static double[] dishwasherCosts = { 1070, 1650, 2250 };
    public static double[] Costs = { 1070, 1650, 2250 };
    public static double[] heaterCosts = { 3100, 4800, 21500 };
    public static double[] conditionerCosts = { 1100, 1550, 2300 };

    //Level of objects
    public static int lightLevel = 0; // 0 = Low, 1 = Medium, 2 = Good
    public static int fridgeLevel = 0; // 0 = Low, 1 = Medium, 2 = Good
    public static int ovenLevel = 0; // 0 = Low, 1 = Medium, 2 = Good
    public static int washMachineLevel = 0; // 0 = Low, 1 = Medium, 2 = Good
    public static int dishwasherLevel = 0; // 0 = Low, 1 = Medium, 2 = Good
    public static int heaterLevel = 0; // 0 = Low, 1 = Medium, 2 = Good
    public static int conditionerLevel = 0; // 0 = Low, 1 = Medium, 2 = Good

    //Score effect
    private static readonly double eatingEffectHunger = -100;
    private static readonly double drinkingEffectThirst = -100;
    private static readonly double wcEffectBladder = -100;
    private static readonly double wcEffectWater = 40;
    private static readonly double workshopEffectFun = 10;
    private static readonly double tvEffectFun = 10;
    private static readonly double lavaboEffectHygiene = 20;
    private static readonly double lavaboEffectWater = 10;
    private static readonly double bathEffectHygiene = 60;
    private static readonly double bathEffectFun = 30;
    private static readonly double bathEffectWater = 200;
    private static readonly double showerEffectHygiene = 50;
    private static readonly double showerEffectFun = 20;
    private static readonly double showerEffectWater = 50;
    private static readonly double washMachineEffectHygiene = 60;
    private static readonly double washMachineEffectWater = 60;
    private static readonly double dishwasherEffectHygiene = 20;
    private static readonly double dishwasherEffectWater = 12;
    private static readonly double heaterHighEffectComfort = 100;
    private static readonly double heaterMediumEffectComfort = 50;
    private static readonly double heaterOffEffectComfort = 0;
    private static readonly double conditionerHighEffectComfort = 100;
    private static readonly double conditionerMediumEffectComfort = 50;
    private static readonly double conditionerOffEffectComfort = -100;

    //States
    public static bool lightGarageState = false;
    public static bool lightFloor1State = false;
    public static bool tvFloor1State = false;
    public static bool fridgeFloor1State = false;
    public static bool ovenFloor1State = false;
    public static bool dishwasherFloor1State = false;
    public static bool lavaboFloor1State = false;
    public static bool lightBathFloor1State = false;
    public static bool wcBathFloor1State = false;
    public static bool lavaboBathFloor1State = false;
    public static bool lightOfficeState = false;
    public static bool computerOfficeState = false;
    public static bool lightBathFloor2State = false;
    public static bool bathBathFloor2State = false;
    public static bool wcBathFloor2State = false;
    public static bool lavaboBathFloor2State = false;
    public static bool lightFloor2State = false;
    public static bool lightChildRoomState = false;
    public static bool lightAdultRoomState = false;
    public static bool lightLaundryRoomState = false;
    public static bool washMachineLaundryRoomState = false;
    public static bool heaterLaundryRoomState = false;
    public static bool conditionerLaundryRoomState = false;

    //Consommation values
    public static double[] lightConso = { 0.05, 0.04, 0.03 };
    public static double tvConso = 0.1;
    public static double[] fridgeConso = { 1, 0.56, 0.4 };
    public static double[] ovenConso = { 1.23, 1, 0.52 };
    public static double lavaboConso = 1;
    public static double wcConso = 1;
    public static double computerConso = 1;
    public static double bathConso = 1;
    public static double showerConso = 1;
    public static double[] washMachineConso = { 0.5, 0.4, 0.2 };
    public static double[] dishwasherConso = { 0.4, 0.2, 0.1 };
    public static double[] heaterConso = { 0, 0, 0.35 };
    public static double[] conditionerConso = { 2, 1.3, 0.8 };

    //Scoring
    public static double hunger = 0;
    public static double thirst = 0;
    public static double bladder = 0;
    public static double comfort = 0;
    public static double hygiene = 0;
    public static double fun = 0;
    public static double energy = 0;
    public static double water = 0;
    public static double money = 0;
    public static double kid = 0;

    public static double time = 0;

    public static double scoreJoy = 0;

    //Rate
    public static double hunger_rate = 10;
    public static double thirst_rate = 10;
    public static double bladder_rate = 7;
    public static double comfort_rate = 0;
    public static double hygiene_rate = -5;
    public static double fun_rate = -6;
    public static double kid_rate = 1;
    public static double moneyRate = 1000;

    public static double fun_rate_factor = 1;
    public static int gameLevel = 0;  // 0 = Easy, 1 = Normal, 2 = Hard

    private static bool isRunning = false;

    public static void InitEasy()
    {
        //Scoring
        hunger = 50;
        thirst = 50;
        bladder = 50;
        comfort = 50;
        hygiene = 60;
        fun = 60;
        energy = 0;
        water = 0;
        money = 10000;
        kid = 0;
        time = 0;

        // Rates
        hunger_rate = 6;
        thirst_rate = 6;
        bladder_rate = 3;
        comfort_rate = 0;
        hygiene_rate = -2;
        fun_rate = -4;
        kid_rate = 0.5;
        moneyRate = 1500;

        //Ending
        isFinised = false;
        isVictory = false;
    }
    public static void InitNormal()
    {
        //Scoring
        hunger = 50;
        thirst = 50;
        bladder = 50;
        comfort = 50;
        hygiene = 60;
        fun = 60;
        energy = 0;
        water = 0;
        money = 6000;
        kid = 0;
        time = 0;

        // Rates
        hunger_rate = 10;
        thirst_rate = 10;
        bladder_rate = 7;
        comfort_rate = 0;
        hygiene_rate = -5;
        fun_rate = -8;
        kid_rate = 1;
        moneyRate = 1000;

        //Ending
        isFinised = false;
        isVictory = false;
    }
    public static void InitHard()
    {
        //Scoring
        hunger = 50;
        thirst = 50;
        bladder = 50;
        comfort = 50;
        hygiene = 60;
        fun = 60;
        energy = 0;
        water = 0;
        money = 3000;
        kid = 0;
        time = 0;

        // Rates
        hunger_rate = 12;
        thirst_rate = 12;
        bladder_rate = 9;
        comfort_rate = 0;
        hygiene_rate = -7;
        fun_rate = -10;
        kid_rate = 2;
        moneyRate = 700;

        //Ending
        isFinised = false;
        isVictory = false;
    }

    public static void Stop()
    {
        isRunning = false;
    }

    public static double KeepBetween0and100(double variable)
    {
        if (variable < 0)
        {
            variable = 0;
        }
        else if (variable > 100)
        {
            variable = 100;
        }
        return variable;
    }

    public static void LightIsOff()
    {
        fun_rate_factor = 1.3;
    }

    public static void LightIsOn()
    {
        fun_rate_factor = 1;
    }

    public static int CoreMecanicsEvent(string mecanic)
    {
        if (mecanic == "Drinking")
        {
            thirst += drinkingEffectThirst;
            return 1;
        }
        if (mecanic == "Eating")
        {
            hunger += eatingEffectHunger;
            return 1;
        }
        if (mecanic == "WC")
        {
            water += wcEffectWater;
            bladder += wcEffectBladder;
            return 1;
        }
        if (mecanic == "Shower")
        {
            water += showerEffectWater;
            hygiene += showerEffectHygiene;
            fun += showerEffectFun;
            return 1;
        }
        if (mecanic == "Bath")
        {
            fun += bathEffectFun;
            hygiene += bathEffectHygiene;
            water += bathEffectWater;
            return 1;
        }
        if (mecanic == "HeaterON")
        {
            comfort = heaterMediumEffectComfort;
            return 1;
        }
        if (mecanic == "HeaterOff")
        {
            comfort = heaterOffEffectComfort;
            return 1;
        }
        if (mecanic == "ConditionerON")
        {
            comfort = conditionerMediumEffectComfort;
            return 1;
        }
        if (mecanic == "ConditionerOff")
        {
            comfort = conditionerOffEffectComfort;
            return 1;
        }
        if (mecanic == "WashMachine")
        {
            hygiene += washMachineEffectHygiene;
            water += washMachineEffectWater;
            return 1;
        }

        if (mecanic == "Dishwasher")
        {
            hygiene += dishwasherEffectHygiene;
            water += dishwasherEffectWater;
            return 1;
        }
        if (mecanic == "TV")
        {
            fun += tvEffectFun;
            return 1;
        }
        if (mecanic == "Lavabo")
        {
            hygiene += lavaboEffectHygiene;
            water += lavaboEffectWater;
            return 1;
        }
        return 0;
    }

    public static void Start()
    {
        t = new Thread(Thread_func);
        t.Start();
    }

    public static void Thread_func()
    {
        isRunning = true;

        while (isRunning)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            switch(playerScene)
            {
                case "Office":
                    if (lightOfficeState)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "Garage":
                    if (lightGarageState)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "Bathroom_1st":
                    if (lightBathFloor1State)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }

                    break;
                case "1st_floor":
                    if (lightFloor1State)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "buanderie_chauffage":
                    if (lightLaundryRoomState)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "2nd_floor":
                    if (lightFloor2State)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "Child_room":
                    if (lightChildRoomState)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "Adult_bedroom":
                    if (lightAdultRoomState)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
                case "Bathroom_2nd":
                    if (lightBathFloor2State)
                    {
                        LightIsOn();
                    }
                    else
                    {
                        LightIsOff();
                    }
                    break;
            }
            hunger += hunger_rate / 60;
            thirst += thirst_rate / 60;
            bladder += bladder_rate / 60;
            comfort += comfort_rate / 60;
            hygiene += hygiene_rate / 60;
            fun += fun_rate * fun_rate_factor / 60;
            kid += kid_rate;
            time += 1;

            if (time % 60 == 0)
            {
                money += moneyRate;
            }

            hunger = KeepBetween0and100(hunger);
            thirst = KeepBetween0and100(thirst);
            bladder = KeepBetween0and100(bladder);
            comfort = KeepBetween0and100(comfort);
            hygiene = KeepBetween0and100(hygiene);
            kid = KeepBetween0and100(kid);
            fun = KeepBetween0and100(fun);

            //Garage
            if (lightGarageState)
            {
                energy += lightConso[lightLevel] / 60;
            }

            //1Floor
            if (lightFloor1State)
            {
                energy += lightConso[lightLevel] / 60;
            }

            if (tvFloor1State)
            {
                energy += tvConso / 60;
            }

            if (fridgeFloor1State)
            {
                energy += fridgeConso[fridgeLevel] / 60;
            }

            if (ovenFloor1State)
            {
                energy += ovenConso[ovenLevel] / 60;
            }

            if (dishwasherFloor1State)
            {
                energy += dishwasherConso[dishwasherLevel] / 60;
            }

            if (lavaboFloor1State)
            {
                water += lavaboConso;
            }

            //Bathroom 1Floor
            if (lightBathFloor1State)
            {
                energy += lightConso[lightLevel] / 60;
            }

            if (wcBathFloor1State)
            {
                energy += wcConso / 60;
            }

            if (lavaboBathFloor1State)
            {
                energy += lavaboConso / 60;
            }

            //Office
            if (lightOfficeState)
            {
                energy += lightConso[lightLevel] / 60;
            }

            if (computerOfficeState)
            {
                energy += computerConso / 60;
            }

            //Bathroom 2Floor
            if (lightBathFloor2State)
            {
                energy += lightConso[lightLevel] / 60;
            }

            if (bathBathFloor2State)
            {
                water += bathConso;
            }

            if (wcBathFloor2State)
            {
                water += wcConso;
            }

            if (lavaboBathFloor2State)
            {
                water += lavaboConso;
            }
            //1Floor
            if (lightFloor2State)
            {
                energy += lightConso[lightLevel] / 60;
            }

            //Child room
            if (lightChildRoomState)
            {
                energy += lightConso[lightLevel] / 60;
            }

            //Adult room
            if (lightAdultRoomState)
            {
                energy += lightConso[lightLevel] / 60;
            }

            //Laundry Room
            if (lightLaundryRoomState)
            {
                energy += lightConso[lightLevel] / 60;
            }

            if (washMachineLaundryRoomState)
            {
                energy += washMachineConso[washMachineLevel] / 60;
            }

            if (heaterLaundryRoomState)
            {
                energy += heaterConso[heaterLevel] / 60;
            }

            if (conditionerLaundryRoomState)
            {
                energy += conditionerConso[conditionerLevel] / 60;
            }
            double hungerWeight = 0.15;
            double thirstWeight = 0.20;
            double bladderWeight = 0.15;
            double comfortWeight = 0.05;
            double hygieneWeight = 0.20;
            double funWeight = 0.25;
            scoreJoy = 0;
            scoreJoy += (100 - hunger) * hungerWeight;
            scoreJoy += (100 - thirst) * thirstWeight;
            scoreJoy += (100 - bladder) * bladderWeight;
            scoreJoy += (comfort * comfortWeight);
            scoreJoy += (hygiene * hygieneWeight);
            scoreJoy += (fun * funWeight);
            //UnityEngine.Debug.Log("hunger since start: " + hunger + "[s]");
            //UnityEngine.Debug.Log("thirst since start: " + thirst + "[s]");
            //UnityEngine.Debug.Log("bladder since start: " + bladder + "[s]");
            //UnityEngine.Debug.Log("comfort since start: " + comfort + "[s]");
            //UnityEngine.Debug.Log("hygiene since start: " + hygiene + "[s]");
            //UnityEngine.Debug.Log("fun factor: " + fun_rate_factor + "");
            //UnityEngine.Debug.Log("Score since start: " + scoreJoy + "[s]");

            //UnityEngine.Debug.Log("Scene: " + playerScene + "");

            

            if (time > (22 - 8) * 60)
            {
                isFinised = true;
                if (GetEcologyScore() < 50)
                {
                    isVictory = true;
                }
                else
                {
                    isVictory = false;
                }
                Stop();
            }
            
            if (scoreJoy < 33)
            {
                isFinised = true;
                isVictory = false;
                UnityEngine.Debug.Log("END");
                Stop();
            }

            stopwatch.Stop();
            System.Threading.Thread.Sleep(1000- (int)stopwatch.ElapsedMilliseconds);
        }
    }

    public static double GetJoyScore()
    {
        return scoreJoy;
    }

    public static double GetMoneyScore()
    {
        return money;
    }

    public static double GetEcologyScore()
    {
        double refEnergie = 12;
        double refWater = 150;
        double scoreEnergie = 100 / (energy / refEnergie);
        double scoreWater = 100 / (water / refWater);
        double scoreEquipments = 100 * (lightLevel + fridgeLevel + ovenLevel + washMachineLevel + dishwasherLevel + heaterLevel + conditionerLevel) / 21;

        scoreEnergie = KeepBetween0and100(scoreEnergie);
        scoreWater = KeepBetween0and100(scoreWater);
        scoreEquipments = KeepBetween0and100(scoreEquipments);

        double score = scoreEnergie * 0.5 + scoreWater * 0.2 + scoreEquipments * 0.3;

        return score;
    }
}