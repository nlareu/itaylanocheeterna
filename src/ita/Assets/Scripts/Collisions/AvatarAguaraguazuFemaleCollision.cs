using UnityEngine;

public class AvatarAguaraguazuFemaleCollision : AvatarEnemyCollision
{
    public override string Collider2Tag { get { return "AguaraguazuFemale"; } }

    public override void Resolve(GameObject collider1, GameObject collider2, Collider2D collider, params object[] parameters)
    {
        Enemy_AguaraguazuFemale enemy = collider2.GetComponent<Enemy_AguaraguazuFemale>();

        if (enemy.State == Enemy_AguaraguazuFemale.States.Attacking)
            AppController.ResetGame();
    }
    public override void Resolve(GameObject collider1, GameObject collider2, Collision2D collision, params object[] parameters)
    {
        Enemy_AguaraguazuFemale enemy = collider2.GetComponent<Enemy_AguaraguazuFemale>();

        if (enemy.State == Enemy_AguaraguazuFemale.States.Attacking)
            AppController.ResetGame();
    }
}