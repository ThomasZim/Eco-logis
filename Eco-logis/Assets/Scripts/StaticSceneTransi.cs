using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticSceneTransi
{
    public static String PreviousSceneName { get; set; }
    public static Vector3 PreviousPosition { get; set; }
    public static Quaternion PreviousRotation { get; set; }
    
    public static bool inMainMenu { get; set; }
    static StaticSceneTransi()
    {
        PreviousSceneName = "null";
        inMainMenu = false;
    }
}
