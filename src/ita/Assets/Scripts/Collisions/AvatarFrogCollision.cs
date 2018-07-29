using UnityEngine;

public class AvatarFrogCollision : AvatarEnemyCollision
{
    public override string Collider2Tag { get { return "Frog"; } }
}