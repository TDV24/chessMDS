using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class NewTestScript
{
    int XK, YK, xk, yk;
    private GameObject controller;
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        string white = "White";
        string black = "Player2";
        // Verific daca stringurile date aici sunt doar black si white, ca sa fie mai explicit cine castiga
        Assert.AreEqual(white, "White");
        Assert.AreNotEqual(black, "Black");
        // Use the Assert class to test conditions
    }
}
