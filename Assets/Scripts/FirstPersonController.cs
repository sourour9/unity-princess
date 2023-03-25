using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{
	// public vars
	public float mouseSensitivityX = 1;

	public float mouseSensitivityY = 1;
	public float walkSpeed = 6;
	public float jumpForce = 220;
	public LayerMask groundedMask;

	// System vars
	private bool grounded;

	private Vector3 moveAmount;
	private Vector3 smoothMoveVelocity;
	private float verticalLookRotation;
	private Transform cameraTransform;
	private Rigidbody rigidbody;

	private Animator animator;

	private float jumpOffsetTime = 1.2f;
	private float lastJumpTime = 0;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		cameraTransform = Camera.main.transform;
		rigidbody = GetComponent<Rigidbody>();

		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		// Look rotation:
		handleLookRotation();

		// Calculate movement:
		handleMovementCalculation();

		// Jump
		handleMovement();

		// Grounded check
		handleGroundCheck();
	}

	private void handleMovementCalculation()
	{
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputY = Input.GetAxisRaw("Vertical");

		Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
		Vector3 targetMoveAmount = moveDir * walkSpeed;
		moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
	}

	private void handleLookRotation()
	{
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
		cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;
	}

	private void handleGroundCheck()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, .1f, groundedMask))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}
	}

	private void handleMovement()
	{
		if (grounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				rigidbody.AddForce(transform.up * jumpForce);
				lastJumpTime = Time.time;
				playAnimation("jump");
			}
			else
			{
				if (Time.time > lastJumpTime + jumpOffsetTime)
				{
					if (moveAmount != Vector3.zero)
					{
						playAnimation("walk");
					}
					else
					{
						playAnimation("Idle");
					}
				}
			}
		}
	}

	private void playAnimation(string trigger)
	{
		if (animator! != null)
		{
			animator.SetTrigger(trigger);
			Debug.Log("la princesse " + trigger);
		}
	}

	private void FixedUpdate()
	{
		// Apply movement to rigidbody
		Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
		rigidbody.MovePosition(rigidbody.position + localMove);
	}
}