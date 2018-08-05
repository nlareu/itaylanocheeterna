using UnityEngine;

public class AvatarBulletCollision : AvatarEnemyCollision
{
    public override string Collider2Tag { get { return "Bullet"; } }
}