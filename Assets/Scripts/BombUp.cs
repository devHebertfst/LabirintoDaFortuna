using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUp : Collectible
{
    private SnakeController snakeController;
    private float originalMoveSpeed;
    private float originalSteerSpeed;

    new void Start(){
        base.Start();
        snakeController = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeController>();
    }

    protected override void StartEffect()
    {
        originalMoveSpeed = snakeController.MoveSpeed;

        snakeController.MoveSpeed = 0;
        gameManager.bombUpTime = duration;
    }

    protected override void EndEffect()
    {
        snakeController.MoveSpeed = originalMoveSpeed;
    }
}
