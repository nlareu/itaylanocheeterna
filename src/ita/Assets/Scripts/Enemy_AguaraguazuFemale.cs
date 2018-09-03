using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy_AguaraguazuFemale : ScriptStarterBehaviour
{
    public float FlipColliderInterval = 1f;
    public float Speed = 6.0F;
    public LayerMask PlayerLayerMask;
    //public int PlayerLayerMask;
    public GameObject VisionZonePointA;
    public GameObject VisionZonePointB;

    private Animator animator;
    private new BoxCollider2D collider;
    private TimeInterval flipColliderTimerInterval;
    private GameObject player;
    private new Rigidbody2D rigidbody;

    private States state = States.LookingBack;
    public States State
    {
        get
        {
            return this.state;
        }
        protected set
        {
            if (this.state != value)
            {
                this.state = value;

                //Set variables depending new state.
                switch (this.state)
                {
                    #region Attacking
                    case States.Attacking:
                        {
                            //Physics2D.IgnoreLayerCollision(this.gameObject.layer, this.PlayerLayerMask, false);

                            //Set direction of velocity depending the position of the player.
                            var dir = (this.transform.position.x < this.player.transform.position.x)
                                            ? Vector2.right
                                            : Vector2.left;

                            this.collider.enabled = true;
                            this.rigidbody.isKinematic = true;

                            this.rigidbody.velocity = dir * this.Speed;

                            this.animator.SetBool("Attacking", true);

                            break;
                        }
                    #endregion
                    #region Attacking
                    case States.LookingBack:
                        {
                            this.animator.SetBool("Looking", false);

                            break;
                        }
                    #endregion
                    #region LookingFront
                    case States.LookingFront:
                        {
                            this.animator.SetBool("Looking", true);

                            break;
                        }
                    #endregion
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        this.collider = GetComponent<BoxCollider2D>();
        this.flipColliderTimerInterval = new TimeInterval(this.FlipColliderInterval);
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.tag = "AguaraguazuFemale";


        this.collider.enabled = false;
        this.rigidbody.isKinematic = true;
        //Physics2D.IgnoreLayerCollision(this.gameObject.layer, this.PlayerLayerMask, true);
    }

    void FixedUpdate() {
        switch (this.State)
        {
            #region Attacking
            case States.Attacking:
                {
                    break;
                }
            #endregion
            #region LookingBack
            case States.LookingBack:
                {
                    this.flipColliderTimerInterval.Accumulate();

                    //Check if must active/deactive vision zone.
                    if (this.flipColliderTimerInterval.IntervalExceeded == true)
                    {
                        this.State = States.LookingFront;

                        this.flipColliderTimerInterval.Reset();
                    }

                    break;
                }
            #endregion
            #region LookingFront
            case States.LookingFront:
                {
                    //Check if player is in the vision zone.
                    Collider2D playerCollider = Physics2D.OverlapArea(this.VisionZonePointA.transform.position, this.VisionZonePointB.transform.position, this.PlayerLayerMask);

                    if (playerCollider)
                    {
                        Debug.Log("Player in vision zone!");

                        this.player = playerCollider.gameObject;

                        this.State = States.Attacking;

                        break;
                    }



                    this.flipColliderTimerInterval.Accumulate();

                    //Check if must active/deactive vision zone.
                    if (this.flipColliderTimerInterval.IntervalExceeded == true)
                    {
                        this.State = States.LookingBack;

                        this.flipColliderTimerInterval.Reset();
                    }

                    break;
                }
            #endregion
        }
	}

    public enum States
    {
        LookingBack,
        LookingFront,
        Attacking,
    }

}
