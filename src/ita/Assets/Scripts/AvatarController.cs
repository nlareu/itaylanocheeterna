﻿using UnityEngine;

public class AvatarController : MonoBehaviour
{
    public float debugvar = 10f;

    public float AxisSensitive = 0.7f;
    //Un game object sin render que se coloca frente al personaje para interactuar con objetos o personajes
    //CUIDADO al cambiar las animaciones del personaje porque las modifique para que la posicion
    //de este objeto cambie segun la animacion.
    //Si se cambian las animaciones, hay que volver a modificar la posicion manualmente o no va a haber interaccion
    [SerializeField]
    GameObject interactionPos;
    [SerializeField]
    float interactionRange = 1f;
    public bool IsJumping = false;
    public float JumpHeight = 250.0f;
    public int PlayerNumber { get; protected set; }
    public float PushForce = 50.0f;
    public float Speed = 6.0F;
    private AvatarStates state = AvatarStates.Normal;
    public AvatarStates State
    {
        get
        {
            return this.state;
        }
        set
        {
            if (this.state != value)
            {
                this.state = value;

                //Set variables depending new state.
                switch (this.state)
                {
                    #region Normal
                    case AvatarStates.Normal:
                        {
                            this.spriteRendered.color = Color.white;

                            this.rigidBody.gravityScale = 1f;

                            ////Enable again collision with other avatars, except with those that are stunned.
                            //AppController
                            //    .GetPlayers()
                            //    .ForEach(item =>
                            //    {
                            //        if ((item.PlayerNumber != this.PlayerNumber) && (item.State != AvatarStates.Stunned))
                            //        {
                            //            Physics2D.IgnoreCollision(this.boxCollider, item.boxCollider, false);
                            //        }
                            //    });

                            break;
                        }
                    #endregion
                }
            }
        }
    }

    private Animator animator;
    internal BoxCollider2D boxCollider;
    private string playerName
    {
        //get { return "Player" + this.PlayerNumber + "-"; }
        get { return "Player-"; }
    }

    private AvatarStates previousState;
    private SpriteRenderer spriteRendered;
    internal Rigidbody2D rigidBody;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spriteRendered = GetComponent<SpriteRenderer>();
        this.tag = "Player";


        this.PlayerNumber = AppController.AddPlayer(this);
    }

    void FixedUpdate()
    {
        switch (this.State)
        {
            #region Normal
            case AvatarStates.Normal:
                {
                    this.CheckAvatarMove();

                    this.PlayerInteraction();

                    break;
                }
            #endregion
        }


        this.previousState = this.State;

        //Debug.Log(string.Format("Axis H: {0}, V: {1}.", (float)Input.GetAxis(this.playerName + "Horizontal"), (float)Input.GetAxis(this.playerName + "Vertical")));
    }

    private void CheckAvatarMove()
    {
        Vector2 moveVector = new Vector2();
        float axisHor = Input.GetAxis(this.playerName + "Horizontal");
        //float axisVer = Input.GetAxis(this.playerName + "Vertical");

        if ((Input.GetButton(this.playerName + "Left"))
            || (axisHor <= -this.AxisSensitive))
        {
            moveVector += Vector2.left * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", -1f);
        }
        else if ((Input.GetButton(this.playerName + "Right"))
            || (axisHor >= this.AxisSensitive))
        {
            moveVector += Vector2.right * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", 1f);
        }
        else
        {
            this.animator.SetBool("Moving", false);
            //this.animator.SetFloat("MoveX", 0.5f);
        }

        if (Input.GetButtonDown(this.playerName + "Jump") && this.IsJumping == false)
        {
            //this.rigidBody.AddForce(Vector2.up * this.JumpHeight);
            this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, this.JumpHeight);

            this.IsJumping = true;
        }

        //this.rigidBody.velocity = new Vector2(moveVector.x, this.rigidBody.velocity.y);
        this.transform.Translate(moveVector);
        //this.rigidBody.AddForce(moveVector);
    }
    //Acciona el script de interaccion de cualquier objeto con el que interactue
    void PlayerInteraction()
    {
        if (Input.GetButtonDown(this.playerName + "Interaction"))
        {
            Collider2D interact = Physics2D.OverlapCircle(interactionPos.transform.position, interactionRange);
            if (interact.GetComponent<BaseInteraction>() != null)
            {
                interact.GetComponent<BaseInteraction>().StartInteraction(this);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPos.transform.position, interactionRange);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
}
