﻿using UnityEngine;

public class FrogGroundCollision : GameCollision
{
    public override string Collider1Tag { get { return "Frog"; } }
    public override string Collider2Tag { get { return "Ground"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collider2D collider, params object[] parameters)
    {
    }
    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision, params object[] parameters)
    {
        Enemy_Frog ac = collider1.GetComponent<Enemy_Frog>();

        ac.IsJumping = false;
    }
}