using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerHPTest()
    {
        Player p = new Player("Hugo");
        Assert.AreEqual("Hugo", p.Name);
    }

}
