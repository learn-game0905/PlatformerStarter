using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player1Controller : MonoBehaviour
{
	[SerializeField] private float speed = 5f;
	[SerializeField] private float jumpHeight = 5f;
	[SerializeField] private Slider healthBar;
	private int bar = 80000;
	private Rigidbody2D _rigidbody2D;
	
	public Animator anim;

	// Controls facing direction
	public bool facingRight;

	// Use this for initialization
	void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		healthBar.DOValue(bar,1f);
	}
	 
	public void Jump()
    {
		anim.SetBool("Jump", true) ;
	}

	public void JumpOff()
    {
		anim.SetBool("Jump", false);
	}

	public void Dead()
	{
		anim.SetBool("Dead" , true);
	}

	public void DeadOff()
	{
		anim.SetBool("Dead", false);
	}
	public void Walk()
	{
		anim.SetBool("Walk" , true);
	}

	public void WalkOff()
	{
		anim.SetBool("Walk", false);
	}
	public void Run()
	{
		anim.SetBool("Run" , true);
	}
	public void RunOff()
	{
		anim.SetBool("Run", false);
	}
	public void Attack()
	{
		anim.SetBool("Attack" , true);
	}
	public void AttackOff()
	{
		anim.SetBool("Attack", false);
	}

	void Update()
	{
		if (speed <= 1.5f)
		{
			Walk();
		}
		if (speed >= 1.5f && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			Run();
			transform.Translate(Vector3.left * speed * Time.deltaTime);
			if (gameObject.transform.localScale.x > 0)
			{
				gameObject.transform.localScale = new Vector3(
						gameObject.transform.localScale.x * -1,
						gameObject.transform.localScale.y,
						gameObject.transform.localScale.z
					);
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			Run();
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			if (gameObject.transform.localScale.x < 0)
			{
				gameObject.transform.localScale = new Vector3(
					gameObject.transform.localScale.x * -1,
					gameObject.transform.localScale.y,
					gameObject.transform.localScale.z
				);
			}
		}
		else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			Jump();
			if (gameObject.transform.position.x < 5)
			{
				_rigidbody2D.velocity = new Vector2(
					_rigidbody2D.velocity.x,
					jumpHeight
				);
			}
		}
		else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			Dead();
			bar -= 10000;
			healthBar.DOValue(bar, 1f);
		}
		else if (Input.GetKey(KeyCode.Space))
		{
			Attack();
		}
		else
		{
			JumpOff();
			DeadOff();
			WalkOff();
			RunOff();
			AttackOff();
		}
	} 


}



