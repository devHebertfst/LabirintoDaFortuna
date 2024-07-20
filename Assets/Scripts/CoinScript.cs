using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : Collectible
{
    protected override void StartEffect()
    {
        gameManager.AddCoin();
    }

    protected override void EndEffect()
    {
        
    }
}
