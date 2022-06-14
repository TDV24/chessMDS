using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.IO;

public class ObjectsFilesTesting
{
    // A Test behaves as an ordinary method
    [Test]
    public void ObjectsFilesTestingSimplePasses()
    {
        string objpath1 = "Assets/Objects/Chesspiece.prefab";
        string objpath2 = "Assets/Objects/movePlates.prefab";
        string objpath3 = "Assets/Objects/movePlate.prefab";
        bool contor1 = false;
        bool contor2 = false;
        bool contor3 = false;
        if(File.Exists(objpath1))
        {
            contor1 = true;
        }
        if (File.Exists(objpath2))
        {
            contor2 = true;
        }
        if (File.Exists(objpath3))
        {
            contor3 = true;
        }
        Assert.AreEqual(contor1, true);
        Assert.AreNotEqual(contor2, true);
        Assert.AreEqual(contor3, true);
        // Use the Assert class to test conditions
    }

}
