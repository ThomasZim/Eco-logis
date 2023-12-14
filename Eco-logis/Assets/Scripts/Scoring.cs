using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scoring
{
	public static float faim;
	public static float soif;
	public static float vessie;
	public static float confort;
	public static float hygiène;
	public static float plaisir;
	public static float energie;
	public static float eau;
	public static float capitale;
	public static float time;
	
	private static bool isRunning = false;
	
	public static void Init()
    {
		faim = 90;
		soif = 90;
		vessie = 90;
		confort = 50;
		hygiène = 60;
		plaisir = 50;
		energie = 0;
		eau = 0;
		capitale = 25000;
    }
	
	public static void stop()
    {
		isRunning = false;
    }
	
	private static void start()
	{
		float faim_rate = 10;
		float soif_rate = 10;
		float vessie_rate = 7;
		float confort_rate = 0;
		float hygiene_rate = -5;
		float plaisir_rate = -6;
		
		isRunning = true;
		
		while(isRunning)
		{
			System.Threading.Thread.Sleep(1000);
			
			faim += faim_rate;
			soif += soif_rate;
			vessie += vessie_rate;
			confort += confort_rate;
			hygiène += hygiene_rate;
			plaisir += plaisir_rate;
			
			//Garage
			if(CoreMechanics.lightGarageState){
				energie += CoreMechanics.lightGarageValue;
			}
			//1Floor
			if(CoreMechanics.lightFloor1State){
				energie += CoreMechanics.lightFloor1Value;
			}
			if(CoreMechanics.tvFloor1State){
				energie += CoreMechanics.tvFloor1Value;
			}
			if(CoreMechanics.fridgeFloor1State){
				energie += CoreMechanics.fridgeFloor1Value;
			}
			if(CoreMechanics.ovenFloor1State){
				energie += CoreMechanics.ovenFloor1Value;
			}
			if(CoreMechanics.lavaboFloor1State){
				energie += CoreMechanics.lavaboFloor1Value;
			}
			//Bathroom 1Floor
			if(CoreMechanics.lightBathFloor1State){
				energie += CoreMechanics.lightBathFloor1Value;
			}
			if(CoreMechanics.wcBathFloor1State){
				energie += CoreMechanics.wcBathFloor1Value;
			}
			if(CoreMechanics.lavaboBathFloor1State){
				energie += CoreMechanics.lavaboBathFloor1Value;
			}
			//Office
			if(CoreMechanics.lightOfficeState){
				energie += CoreMechanics.lightOfficeValue;
			}
			if(CoreMechanics.computerOfficeState){
				energie += CoreMechanics.computerOfficeValue;
			}
			//Bathroom 2Floor
			if(CoreMechanics.lightBathFloor2State){
				energie += CoreMechanics.lightBathFloor2Value;
			}
			if(CoreMechanics.bathBathFloor2State){
				energie += CoreMechanics.bathBathFloor2Value;
			}
			if(CoreMechanics.wcBathFloor2State){
				energie += CoreMechanics.wcBathFloor2Value;
			}
			if(CoreMechanics.lavaboBathFloor2State){
				energie += CoreMechanics.lavaboBathFloor2Value;
			}
			//Child room
			if(CoreMechanics.lightChildRoomState){
				energie += CoreMechanics.lightChildRoomValue;
			}
			//Adult room
			if(CoreMechanics.lightAdultRoomState){
				energie += CoreMechanics.lightAdultRoomValue;
			}
			//Laundry Room
			if(CoreMechanics.lightLaundryRoomState){
				energie += CoreMechanics.lightLaundryRoomValue;
			}
			if(CoreMechanics.washMachineLaundryRoomState){
				energie += CoreMechanics.washMachineLaundryRoomValue;
			}
			if(CoreMechanics.heaterLaundryRoomState){
				energie += CoreMechanics.heaterLaundryRoomValue;
			}
		}
	}
}