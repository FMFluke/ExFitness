using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;      //Allows us to use SceneManager

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class PlayerScript : MoveController
{
	private Animator animator;                //Used to store a reference to the Player's animator component.
	private SpriteRenderer sprite;
	private int hp;								//Used to store player hp
	private bool jump;
	private float maxJump = 150.0f;
	//public int hspeed;                        //How many pixels it can move per second, horizontally

	//Start overrides the Start function
	protected override void Start ()
	{
		//Set movespeed for player
		moveTime = 0.007f;
		//Get a component reference to the Player's animator component
		animator = GetComponent<Animator>();
		//Get a component reference to the Player's SpriteRenderer
		sprite = GetComponent<SpriteRenderer>();
		//Call the Start function of the base class.
		base.Start ();
	}

	private void Update ()
	{
		int horizontal = 0;     //Used to store the horizontal move direction.
		int vertical = 0;       //Used to store the vertical move direction.


		//Get input from the input manager
		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
		vertical = (int) (Input.GetAxisRaw ("Vertical"));
		if (horizontal == 0 && vertical == 0) {
			animator.SetBool ("PlayerWalk", false);
            animator.SetBool("PlayerJump", false);
        }
		//prevent vertical from being lower than 0 (can't move down by yourself without gravity)
		if (vertical < 0) {
			vertical = 0;
		}
		Vector2 current = transform.position;
		Vector2 check = current + new Vector2 (0, -0.5f * boxCollider.size.y - 1);
		RaycastHit2D hit;
		//face direction.
		if (horizontal > 0) {
			sprite.flipX = false;
		} else if (horizontal < 0) {
			sprite.flipX = true;
		}
		if (!jump && !CheckCollide (current, check, out hit)) {
			//apply gravity
			base.Move (horizontal, -1);
		}
		else if (jump) {
			//jumping
			if (maxJump > float.Epsilon) {
				maxJump -= inverseMoveTime * Time.deltaTime;
				base.Move (horizontal, 1);
			} else if (!CheckCollide(current, check, out hit)){//collision check
				animator.SetBool("PlayerJump", false);
				base.Move (horizontal, -1);
			} else { //jump end, reset
				jump = false;
				maxJump = 150.0f;
				animator.SetTrigger("PlayerReachGround");
			}

		}
		//Walk horizontally?
		else if(horizontal != 0 && vertical == 0)
		{
			animator.SetBool("PlayerWalk",true);
			//move
			base.Move (horizontal, vertical);
		}
        //about to jump
        else if(vertical > 0)
        {
			jump = true;
			animator.SetBool("PlayerWalk", false);
            animator.SetBool("PlayerJump", true);
            //move
            base.Move(horizontal, vertical);
        }
	}
	
}