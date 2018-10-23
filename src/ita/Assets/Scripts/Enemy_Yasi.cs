using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_Yasi : ScriptStarterBehaviour
{
    public float Speed = 8.0F;
    public BoxCollider2D StopLimit;

    private new Rigidbody2D rigidbody;

    // Use this for initialization
    void Start () {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.tag = "Yasi";

        this.rigidbody.velocity = Vector2.right * this.Speed;
    }

    void FixedUpdate() {
        
	}

    protected override void Stop()
    {
        this.rigidbody.velocity = Vector2.zero;
    }
}
