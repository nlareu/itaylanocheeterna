﻿using UnityEngine;

public class AvatarYasiCollision : AvatarEnemyCollision
{
    public override string Collider2Tag { get { return "Yasi"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collider2D collider, params object[] parameters)
    {
        AppController.ResetGame();
    }
    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision, params object[] parameters)
    {
        AppController.ResetGame();
    }
}