using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
public static class CoreMechanics
{
    private static Thread t;

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
    public static double eatingEffectHunger = -100;
    public static double drinkingEffectThirst = -100;
    public static double wcEffectBladder = -100;
    public static double wcEffectWater = 40;
    public static double workshopEffectFun = 10;
    public static double tvEffectFun = 10;
    public static double lavaboEffectHygiene = 20;
    public static double lavaboEffectWater = 10;
    public static double bathEffectHygiene = 60;
    public static double bathEffectFun = 30;
    public static double bathEffectWater = 200;
    public static double showerEffectHygiene = 50;
    public static double showerEffectFun = 20;
    public static double showerEffectWater = 50;
    public static double washMachineEffectHygiene = 60;
    public static double washMachineEffectWater = 60;
    public static double dishwasherEffectHygiene = 20;
    public static double dishwasherEffectWater = 12;
    public static double heaterHighEffectComfort = 100;
    public static double heaterMediumEffectComfort = 50;
    public static double heaterOffEffectComfort = 0;
    public static double conditionerHighEffectComfort = 100;
    public static double conditionerMediumEffectComfort = 50;
    public static double conditionerOffEffectComfort = -100;

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
    public static bool lightChildRoomState = false;
    public static bool lightAdultRoomState = false;
    public static bool lightLaundryRoomState = false;
    public static bool washMachineLaundryRoomState = false;
    public static bool heaterLaundryRoomState = false;
    public static bool conditionerLaundryRoomState = false;

    //Consommation values
    public static double[] lightConso = { 0.056, 0.04, 0.032 };
    public static double tvConso = 0.1;
    public static double[] fridgeConso = { 1, 0.56, 0.4 };
    public static double[] ovenConso = { 1.23, 1, 0.52 };
    public static double lavaboConso = 1;
    public static double wcConso = 1;
    public static double computerConso = 1;
    public static double bathConso = 1;
    public static double showerConso = 1;
    public static double[] washMachineConso = { 0.5, 0.4, 0.2 };
    public static double[] dishwasherConso = { 0.84, 0.74, 0.54 };
    public static double[] heaterConso = { 0, 0, 3.5 };
    public static double[] conditionerConso = { 20, 13, 8 };

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
    public static double time = 0;

    public static double scoreJoy = 0;

    //Rate
    public static double hunger_rate = 10;
    public static double thirst_rate = 10;
    public static double bladder_rate = 7;
    public static double comfort_rate = 0;
    public static double hygiene_rate = -5;
    public static double fun_rate = -6;

    private static bool isRunning = false;

    public static void Init()
    {
        hunger = 50;
        thirst = 50;
        bladder = 50;
        comfort = 50;
        hygiene = 60;
        fun = 60;
        energy = 0;
        water = 0;
        money = 25000;
        time = 0;
    }

    public static void stop()
    {
        isRunning = false;
    }

    public static double keepBetween0and100(double variable)
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

    public static void lightIsOff()
    {
        fun_rate = -8;
    }

    public static void lightIsOn()
    {
        fun_rate = -6;
    }

    public static int coreMecanicsEvent(string mecanic)
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
        if (mecanic == "Wc")
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
        if (mecanic == "HeaterMax")
        {
            comfort = heaterHighEffectComfort;
            return 1;
        }
        if (mecanic == "HeaterMin")
        {
            comfort = heaterMediumEffectComfort;
            return 1;
        }
        if (mecanic == "HeaterOff")
        {
            comfort = heaterOffEffectComfort;
            return 1;
        }
        if (mecanic == "ConditionerMax")
        {
            comfort = conditionerHighEffectComfort;
            return 1;
        }
        if (mecanic == "ConditionerMin")
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
        if (mecanic == "Workshop")
        {
            fun += workshopEffectFun;
            return 1;
        }
        return 0;
    }

    public static void start()
    {
        t = new Thread(thread_func);
        t.Start();
    }

    public static void thread_func()
    {
        isRunning = true;

        while (isRunning)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            hunger += hunger_rate/60;
            thirst += thirst_rate / 60;
            bladder += bladder_rate / 60;
            comfort += comfort_rate / 60;
            hygiene += hygiene_rate / 60;
            fun += fun_rate / 60;
            time += 1;

            //Debug.Log("Time since start: " + time + "[s]");

            keepBetween0and100(hunger);
            keepBetween0and100(thirst);
            keepBetween0and100(bladder);
            keepBetween0and100(comfort);
            keepBetween0and100(hygiene);
            keepBetween0and100(fun);

            //Garage
            if (lightGarageState)
            {
                energy += lightConso[lightLevel];
            }

            //1Floor
            if (lightFloor1State)
            {
                energy += lightConso[lightLevel];
            }

            if (tvFloor1State)
            {
                energy += tvConso;
            }

            if (fridgeFloor1State)
            {
                energy += fridgeConso[fridgeLevel];
            }

            if (ovenFloor1State)
            {
                energy += ovenConso[ovenLevel];
            }

            if (dishwasherFloor1State)
            {
                energy += dishwasherConso[dishwasherLevel];
            }

            if (lavaboFloor1State)
            {
                water += lavaboConso;
            }

            //Bathroom 1Floor
            if (lightBathFloor1State)
            {
                energy += lightConso[lightLevel];
            }

            if (wcBathFloor1State)
            {
                energy += wcConso;
            }

            if (lavaboBathFloor1State)
            {
                energy += lavaboConso;
            }

            //Office
            if (lightOfficeState)
            {
                energy += lightConso[lightLevel];
            }

            if (computerOfficeState)
            {
                energy += computerConso;
            }

            //Bathroom 2Floor
            if (lightBathFloor2State)
            {
                energy += lightConso[lightLevel];
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

            //Child room
            if (lightChildRoomState)
            {
                energy += lightConso[lightLevel];
            }

            //Adult room
            if (lightAdultRoomState)
            {
                energy += lightConso[lightLevel];
            }

            //Laundry Room
            if (lightLaundryRoomState)
            {
                energy += lightConso[lightLevel];
            }

            if (washMachineLaundryRoomState)
            {
                energy += washMachineConso[washMachineLevel];
            }

            if (heaterLaundryRoomState)
            {
                energy += heaterConso[heaterLevel];
            }

            if (conditionerLaundryRoomState)
            {
                energy += conditionerConso[conditionerLevel];
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
            //UnityEngine.Debug.Log("fun since start: " + fun + "[s]");
            //UnityEngine.Debug.Log("Score since start: " + scoreJoy + "[s]");

            stopwatch.Stop();
            System.Threading.Thread.Sleep(1000- (int)stopwatch.ElapsedMilliseconds);
        }
    }

    public static double getJoyScore()
    {
        return scoreJoy;
    }

    public static double getMoneyScore()
    {
        return money;
    }

    public static double getEcologyScore()
    {
        double refEnergie = 12;
        double refWater = 150;
        double scoreEnergie = 100 / (energy / refEnergie);
        double scoreWater = 100 / (water / refWater);
        double scoreEquipments = 100 * (lightLevel + fridgeLevel + ovenLevel + washMachineLevel + dishwasherLevel + heaterLevel + conditionerLevel) / 21;

        scoreEnergie = keepBetween0and100(scoreEnergie);
        scoreWater = keepBetween0and100(scoreWater);
        scoreEquipments = keepBetween0and100(scoreEquipments);

        double score = scoreEnergie * 0.6 + scoreWater * 0.2 + scoreEquipments * 0.2;

        return score;
    }
}