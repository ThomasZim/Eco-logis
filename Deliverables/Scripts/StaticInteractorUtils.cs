using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticInteractorUtils
{
    public static int collisionCount = 0;

    static StaticInteractorUtils()
    {
      collisionCount = 0;
    }
    
    public static bool IsCharacterColliding()
    {
        Debug.Log("COLISION COUNT: " + collisionCount);
        return collisionCount > 0;
    }
    
    public static void ResetCollisionCount()
    {
        collisionCount = 0;
    }
}
