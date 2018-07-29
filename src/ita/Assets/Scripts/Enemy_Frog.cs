using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy_Frog : ScriptStarterBehaviour {

    public bool IsJumping = false;
    public float JumpForce = 125.0f;
    public TimeInterval JumpInterval = new TimeInterval(0.5f);

    internal Rigidbody2D rigidBody;

    // Use this for initialization
    void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.tag = "Frog";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.IsJumping == false)
        {
            this.JumpInterval.Accumulate();

            if (this.JumpInterval.IntervalExceeded == true)
            {
                this.rigidBody.AddForce((Vector2.up + Vector2.left) * this.JumpForce);

                this.IsJumping = true;

                this.JumpInterval.Reset();
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
}
