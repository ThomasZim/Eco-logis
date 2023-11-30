using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticSceneTransi
{
    public static String PreviousSceneName { get; set; }
    static StaticSceneTransi()
    {
        PreviousSceneName = "null";
    }
}
