using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;      //Allows us to use SceneManager

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class PlayerScript : MoveController
{
	private Animator animator;                //Used to store a reference to the Player's animator component.
	private SpriteRenderer sprite;
	private int hp;                           //Used to store player hp
	//public int hspeed;                        //How many pixels it can move per second, horizontally

	//Start overrides the Start function
	protected override void Start ()
	{
		//Get a component reference to the Player's animator component
		animator = GetComponent<Animator>();

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
		//Check if walking horizontally
		if(horizontal != 0 && vertical == 0)
		{
			//set animation.
			if (horizontal >= 0) {
				sprite.flipX = false;
			} else {
				sprite.flipX = true;
			}
			animator.SetBool("PlayerWalk",true);
			//move
			base.Move (horizontal, vertical);
		}
        //jump
        if(vertical > 0)
        {
            animator.SetBool("PlayerJump", true);
            //move
            base.Move(horizontal, vertical);
        }
	}
	
}