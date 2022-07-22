using UnityEngine;

public class CharController : MonoBehaviour
{

    public float moveSpeed;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Animator animator;
    private bool walking = true;

    private Vector3 moveDirection;
    public float gravity;

    private WeaponSwitcher switcher;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInChildren<Animator>();
        switcher = GetComponent<WeaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {

        float yCurrentDirection = moveDirection.y;
        moveDirection = (Camera.main.transform.forward * Input.GetAxis("Vertical")) + (Camera.main.transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yCurrentDirection;


        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }

        }

        if (controller.isGrounded && Input.GetKey("left shift"))
        {
            if (walking)
            {
                moveSpeed = runningSpeed;
                walking = false;
            }
        }
        else
        {
            moveSpeed = walkingSpeed;
            walking = true;
        }

        //apply gravity to our character controller
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravity * Time.deltaTime);

        //move the char controller towards our movedirection
        controller.Move(moveDirection * Time.deltaTime);

        //set the animators speed similar to that of our magnitude 
        animator.SetFloat("Speed", moveDirection.magnitude - 1f);

        //get the vector of our forward vector from the camera and move towards 
        Vector3 newDirection = Vector3.RotateTowards(Camera.main.transform.forward, moveDirection, 1f, 0.0f);

        //lock the y rotation as we don't want to listen to this
        newDirection.y = 0;

        //lerp our rotation towards the target to create a smooth effect
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection), .05f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        print("hitanobject");
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Pistol")
		{
            switcher.canUsePistol = true;
            Destroy(other.gameObject);
		}

        if(other.gameObject.tag == "Rifle")
		{
            switcher.canUseRifle = true;
            Destroy(other.gameObject);
		}
	}
}
