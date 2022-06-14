using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.IO;

public class ScenesTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ScenesTestSimplePasses()
    {
        string pathgame = "Assets/Scenes/Game.unity";
        string pathmenu = "Assets/Scenes/Menu.unity";
        string pathoptions = "Assets/Scenes/Options.unity";
        string pathgameover = "Assets/Scenes/GameOver.unity";
        string pathsound = "Assets/Scenes/Sound.unity";
        bool contorgame = false;
        bool contormenu = false;
        bool contoroptions = false;
        bool contorfals1 = false;
        bool contorfals2 = false;
        if(File.Exists(pathgame))
        {
            contorgame = true;
        }
        if (File.Exists(pathmenu))
        {
            contormenu = true;
        }
        if (File.Exists(pathoptions))
        {
            contoroptions = true;
        }
        if (File.Exists(pathgameover))
        {
            contorfals1 = true;
        }
        if (File.Exists(pathsound))
        {
            contorfals2 = true;
        }
        Assert.AreEqual(contorgame, true);
        Assert.AreEqual(contormenu, true);
        Assert.AreEqual(contoroptions, true);
        Assert.AreNotEqual(contorfals1, true);
        Assert.AreNotEqual(contorfals2, true);
        // Use the Assert class to test conditions
    }

}
