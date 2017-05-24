using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;      //Allows us to use SceneManager

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class PlayerScript : MoveController
{
	private Animator animator;                //Used to store a reference to the Player's animator component.
	private int hp;                           //Used to store player hp
	//public int hspeed;                        //How many pixels it can move per second, horizontally

	//Start overrides the Start function
	protected override void Start ()
	{
		//Get a component reference to the Player's animator component
		animator = GetComponent<Animator>();
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
		}
		//Check if walking horizontally
		if(horizontal != 0 && vertical == 0)
		{
			//set animation.
			animator.SetBool("PlayerWalk",true);
			//move
			base.Move (horizontal, vertical);
		}
	}
	
}