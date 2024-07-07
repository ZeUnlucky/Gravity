using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class MovementScript : MonoBehaviour
{
    const float left = -1 * multiplier;
    const float mid = 0 * multiplier;
    const float right = 1 * multiplier;
    const float multiplier = 2;

    [Header("Game Manager")]
    public GameManager gm;

    [Header("Animation and Camera")]
    private Animator animator;
    private Rigidbody rb;
    public Camera mainCam;

    [Header("Tiles and Movement")]
    private bool canMove = true;
    private bool grounded = true;
    private GameObject tileToGoTo = null;
    [SerializeField] public TileClass currentTile;

    [SerializeField] private float smoothRotationSpeed;

    public LayerMask whatIsGround;

    [Header("Movement Input Preferences")]
    public Button[] MovementButtons;

    [Header("Debug")]
    public TMP_Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
        CheckFaultyMovement();
        DebugVelocity();
    }

    void DebugVelocity()
    {
        //debugText.text = $"Dist:{Vector2.Distance(transform.position, tileToGoTo.transform.position)}\nTTGT:{tileToGoTo.transform.position}";
    }

    void CheckFaultyMovement()
    {
        if (transform.position.x > right)
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
        if (transform.position.x < left)
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        if (transform.position.z != gm.DefaultPlayerZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, gm.DefaultPlayerZ);
    }
    void DoMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = SwipeInput.moveDirection;
        if (tileToGoTo != null)
            Move();
        foreach (Button btn in MovementButtons)
        {
            btn.gameObject.SetActive(PlayerPrefs.GetInt("UseButtons") == 1);
        }
        if (PlayerPrefs.GetInt("UseButtons") != 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || moveDirection == Vector3.left)
                MoveLeft();
            else if (Input.GetKeyDown(KeyCode.D) || moveDirection == Vector3.right)
                MoveRight();
            else if (Input.GetKeyDown(KeyCode.Space) || moveDirection == Vector3.up)
                Jump();
        }       
    }

    public void MoveLeft()
    {
        Debug.Log("Left");
        if (canMove)
        {
            tileToGoTo = currentTile.LeftTile;
            animator.SetBool("MoveLeft", true);
        }
        canMove = false;
    }
    public void MoveRight()
    {
        Debug.Log("Right");
        if (canMove)
        {
            tileToGoTo = currentTile.RightTile;
            animator.SetBool("MoveRight", true);
        }
        canMove = false;
    }

   
    void Move()
    {
        if (Vector2.Distance(transform.position, tileToGoTo.transform.position) <= 0.3f)
        {
            transform.position = new Vector3(tileToGoTo.transform.position.x, tileToGoTo.transform.position.y, transform.position.z);
            transform.rotation = tileToGoTo.transform.rotation;
            currentTile = tileToGoTo.GetComponent<TileClass>();
            tileToGoTo = null;
            animator.SetBool("MoveLeft", false); 
            animator.SetBool("MoveRight", false);
            canMove = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, tileToGoTo.transform.position, gm.PlayerSpeed * Time.deltaTime);
            RotatePlayer();
        } 
    }

    void RotatePlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, tileToGoTo.transform.rotation, Time.deltaTime * smoothRotationSpeed);
    }
    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(Vector3.up * 10f * gm.JumpForce, ForceMode.Force);
            animator.SetBool("Jumping", true);
            StartCoroutine(StopJumpAndAddGravity());
        }
    }
    
    IEnumerator StopJumpAndAddGravity()
    {
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector3.down * 10f * gm.JumpForce, ForceMode.Force);
        animator.SetBool("Jumping", false);
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector3.down * 10f * gm.JumpForce, ForceMode.Force);
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(Vector3.up * 10f * gm.JumpForce, ForceMode.Force);
        yield return null;
    }
    


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            grounded = false;
    }
}
