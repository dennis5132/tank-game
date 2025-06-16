using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 150f;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 700f;

    private Rigidbody rb;

    private Vector2 moveInput = Vector2.zero;
    private float rotateInput = 0f;
    private float AimInput = 0f;

    public Rigidbody cannon;
    public int health = 3;

    private bool moving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (moveInput == Vector2.zero)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
        //Debug.Log(moving);
    }

    private void FixedUpdate()
    {
        MoveTank();
        RotateTank();
        if (!moving)
        {
            AimCannon();
        }
    }

    // Wordt aangeroepen door PlayerInput component (Send Messages) bij Move actie
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
    }

    // Wordt aangeroepen door PlayerInput component bij Rotate actie
    public void OnRotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<float>();
    }

    // Wordt aangeroepen door PlayerInput component bij Fire actie
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }
    public void OnAim(InputAction.CallbackContext context)
    {
        AimInput = context.ReadValue<float>();
    }
    private void MoveTank()
    {
        Vector3 moveDirection = transform.forward * moveInput.y 
            //+ transform.right * moveInput.x
            ;
        Vector3 velocity = moveDirection.normalized * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private void RotateTank()
    {
        float rotation = rotateInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    private void Shoot()
    {
        if (bulletPrefab == null || shootPoint == null)
            return;

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * bulletSpeed);
    }

    private void AimCannon()
    {
        float rotation = AimInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(rotation, 0f, 0f);
        cannon.MoveRotation(cannon.rotation * turnRotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            health--;
            Debug.Log(health);
        }
    }

}
