using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.IO;

public class BoardFilesTesting
{
    // A Test behaves as an ordinary method
    [Test]
    public void BoardFilesTestingSimplePasses()
    {
        string pathboard1 = "Assets/Assets/Sprites/board1.png";
        string pathboard2 = "Assets/Assets/Sprites/board2.png";
        string pathboard3 = "Assets/Assets/Sprites/board3.png";
        bool contor1 = false;
        bool contor2 = false;
        bool contor3 = false;
        if (File.Exists(pathboard1))
        {
            contor1 = true;
        }
        if (File.Exists(pathboard2))
        {
            contor2 = true;
        }
        if (File.Exists(pathboard3))
        {
            contor3 = true;
        }
        Assert.AreEqual(contor1, true);
        Assert.AreEqual(contor2, true);
        Assert.AreEqual(contor3, true);
    }
}
