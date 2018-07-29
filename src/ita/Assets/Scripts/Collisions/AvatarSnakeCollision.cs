using UnityEngine;

public class AvatarSnakeCollision : AvatarEnemyCollision
{
    public override string Collider2Tag { get { return "Snake"; } }
}