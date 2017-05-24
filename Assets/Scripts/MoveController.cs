using UnityEngine;
using System.Collections;

/*Notice: Part of this code is from 2DRoguelike tutorial available at unity3d.com and is used for educational purpose only*/

public abstract class MoveController : MonoBehaviour
{
	public float moveTime = 0.01f;           //Time it will take object to move, in seconds.
	public LayerMask blockingLayer;         //Layer on which collision will be checked.


	private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
	private Rigidbody2D rb2D;               //The Rigidbody2D component attached to this object.
	private float inverseMoveTime;          //Used to make movement more efficient.


	//Protected, virtual functions can be overridden by inheriting classes.
	protected virtual void Start ()
	{
		boxCollider = GetComponent <BoxCollider2D> ();

		rb2D = GetComponent <Rigidbody2D> ();

		inverseMoveTime = 1f / moveTime;
	}

	protected bool CheckCollide(Vector2 start, Vector2 end, out RaycastHit2D hit)
	{
		//Disable the boxCollider so that linecast doesn't hit this object's own collider.
		boxCollider.enabled = false;

		//Cast a line from start point to end point checking collision on blockingLayer.
		hit = Physics2D.Linecast (start, end, blockingLayer);

		//Re-enable boxCollider after linecast
		boxCollider.enabled = true;

		if (hit.transform == null) {
			return false; //No Collision
		}
		return true; //Collision, object stored in hit.
	}

	//Move returns true if it is able to move and false if not. 
	//Move takes parameters for x direction, y direction
	protected bool Move (int xDir, int yDir)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);
		RaycastHit2D hit;
		//Check if anything was hit
		if(!CheckCollide(start, end, out hit)) //If no collision occurs
		{
			//If nothing was hit, start moving
			//StartCoroutine (SmoothMovement (end));
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition (newPostion);
			return true;
		}

		//If something was hit, return false, Move was unsuccesful.
		return false;
	}

}