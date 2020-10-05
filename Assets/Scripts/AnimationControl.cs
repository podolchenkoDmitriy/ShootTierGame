using System.Collections;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
	private string currentAnimation = "";
	// Use this for initialization
	public Animator anim;
	public Vector3 startPos;
	public Vector3 target;
	public Rigidbody rb;
	public Vector3 moveVector;
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();

		startPos = transform.position;
		target = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
		anim = GetComponent<Animator>();

	}

	private bool walk = false;
	public void Walk(float speed, Vector3 move)
	{
		walk = true;
		moveVector = move;
		StartCoroutine(Walking(speed));

	}

	private IEnumerator Walking(float speed)
	{

		while (walk)
		{
			rb.MovePosition(rb.position + moveVector.normalized * speed * Time.fixedDeltaTime);
			transform.LookAt(moveVector);
			yield return new WaitForFixedUpdate();
			if (Vector3.Distance(rb.position, moveVector) < 0.1f)
			{
				SetAnimationIdle();

			}
		}
	}
	public void SetAnimation(string animationName, bool walkState)
	{
		walk = walkState;
		if (currentAnimation != "")
		{
			anim.SetBool(currentAnimation, false);
		}
		anim.SetBool(animationName, true);
		currentAnimation = animationName;
	}

	public void SetAnimationIdle()
	{

		if (currentAnimation != "")
		{
			anim.SetBool(currentAnimation, false);
			walk = false;
		}


	}
	public void SetDeathAnimation(int numOfClips)
	{

		int clipIndex = Random.Range(0, numOfClips);
		string animationName = "Death";
		Debug.Log(clipIndex);

		anim.SetInteger(animationName, clipIndex);
	}















}
