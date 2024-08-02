using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUp : Collectible
{
    private SnakeController snakeController;
    private float originalMoveSpeed;

    new void Start(){
        base.Start();
        snakeController = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeController>();
    }

    protected override void StartEffect()
    {
        originalMoveSpeed = snakeController.GetSnakeSpeed();

        snakeController.SetSnakeSpeed(0f);
        gameManager.bombUpTime = duration;
    }

    protected override void EndEffect()
    {
        snakeController.SetSnakeSpeed(originalMoveSpeed);
    }
}
