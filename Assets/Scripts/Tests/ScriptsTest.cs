using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.IO;

public class ScriptsTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ScriptsTestSimplePasses()
    {
        string path1 = "Assets/Scripts/ChangeTable.cs";
        string path2 = "Assets/Scripts/Chessman.cs";
        string path3 = "Assets/Scripts/Game.cs";
        string path4 = "Assets/Scripts/MenuFunctionality.cs";
        string path5 = "Assets/Scripts/ModificatorDeScene.cs";
        string path6 = "Assets/Scripts/MovePlate.cs";
        string path7 = "Assets/Scripts/PiecesTaken.cs";
        string path8 = "Assets/Scripts/SaveOptions.cs";
        string path9 = "Assets/Scripts/Timer.cs";
        string path10 = "Assets/Scripts/Sounds.cs";
        bool contor1 = false;
        bool contor2 = false;
        bool contor3 = false;
        bool contor4 = false;
        bool contor5 = false;
        bool contor6 = false;
        bool contor7 = false;
        bool contor8 = false;
        bool contor9 = false;
        bool contor10 = false;
        if(File.Exists(path1))
        {
            contor1 = true;
        }
        if (File.Exists(path2))
        {
            contor2 = true;
        }
        if (File.Exists(path3))
        {
            contor3 = true;
        }
        if (File.Exists(path4))
        {
            contor4 = true;
        }
        if (File.Exists(path5))
        {
            contor5 = true;
        }
        if (File.Exists(path6))
        {
            contor6 = true;
        }
        if (File.Exists(path7))
        {
            contor7 = true;
        }
        if (File.Exists(path8))
        {
            contor8 = true;
        }
        if (File.Exists(path9))
        {
            contor9 = true;
        }
        if (File.Exists(path10))
        {
            contor10 = true;
        }
        Assert.AreEqual(contor1, true);
        Assert.AreEqual(contor2, true);
        Assert.AreEqual(contor3, true);
        Assert.AreEqual(contor4, true);
        Assert.AreEqual(contor5, true);
        Assert.AreEqual(contor6, true);
        Assert.AreEqual(contor7, true);
        Assert.AreEqual(contor8, true);
        Assert.AreEqual(contor9, true);
        Assert.AreNotEqual(contor10, true);
        // Use the Assert class to test conditions
    }

}
