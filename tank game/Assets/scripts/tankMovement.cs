using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    public tankManager manager;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 700f;

    [Header("Audio")]
    public AudioSource movementAudio;
    public AudioSource fireAudio;

    [Header("Health")]
    public int health;

    [Header("Cannon")]
    public Rigidbody cannon;
    public float fireCooldown = 1f;

    public bool redTank;

    private Rigidbody rb;
    private Vector2 moveInput;
    private float rotateInput;
    private float aimInput;
    private float fireTimer;
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = manager.startHealth;
        fireAudio.clip = manager.cannonFireClip;
    }

    private void Update()
    {
        isMoving = moveInput != Vector2.zero || rotateInput != 0f; // als er input wordt gedetecteerd voor beweging staat isMoving aan

        if (aimInput == 0f)
            StopSound(manager.turretTurnClip); //als er geen aiminput is stopt het bijbehorende geluid

        if (!isMoving)
            StopSound(manager.tankMoveClip); // als er geen beweging is stopt het bijbehorende geluid
    }

    private void FixedUpdate()
    {
        MoveTank();
        RotateTank();

        if (!isMoving)
            AimCannon();

        fireTimer -= Time.fixedDeltaTime;
    }

    #region InputHandlers

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("moving");
        moveInput = context.ReadValue<Vector2>();
        PlaySound(manager.tankMoveClip);
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<float>();
        PlaySound(manager.tankMoveClip);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<float>();
        PlaySound(manager.turretTurnClip);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && fireTimer <= 0f)
        {
            Fire();
            fireAudio.Play();
            fireTimer = fireCooldown;
        }
    }

    #endregion

    #region Movement

    private void MoveTank()
    {
        Vector3 direction = transform.forward * moveInput.y;
        Vector3 velocity = direction.normalized * manager.moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private void RotateTank()
    {
        float rotation = rotateInput * manager.rotationSpeed * Time.fixedDeltaTime;
        Quaternion tankRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * tankRotation);

        // Cannon draait deels mee
        Quaternion cannonRotation = Quaternion.Euler(rotation * 0.5f, 0f, 0f);
        cannon.MoveRotation(cannon.rotation * cannonRotation);
    }

    private void AimCannon()
    {
        float rotation = aimInput * manager.rotationSpeed * Time.fixedDeltaTime;
        Quaternion aimRotation = Quaternion.Euler(rotation, 0f, 0f);
        cannon.MoveRotation(cannon.rotation * aimRotation);
    }

    #endregion

    #region Shooting

    private void Fire()
    {
        if (bulletPrefab == null || shootPoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * bulletSpeed);
    }

    #endregion

    #region Audio

    private void PlaySound(AudioClip clip)
    {
        if (movementAudio.isPlaying && movementAudio.clip == clip) return;

        movementAudio.volume = (clip == manager.tankMoveClip) ? 0.25f : 1f;
        movementAudio.clip = clip;
        movementAudio.Play();
    }

    private void StopSound(AudioClip clip)
    {
        if (movementAudio.isPlaying && movementAudio.clip == clip)
        {
            movementAudio.Stop();
        }
    }

    #endregion
}

//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Rigidbody))]
//public class TankMovement : MonoBehaviour
//{
//    [Header("Movement Settings")]
//    [SerializeField] private float moveSpeed = 5f;
//    [SerializeField] private float rotationSpeed = 150f;

//    [Header("Shooting Settings")]
//    [SerializeField] private GameObject bulletPrefab;
//    [SerializeField] private Transform shootPoint;
//    [SerializeField] private float bulletSpeed = 700f;

//    private Rigidbody rb;

//    private Vector2 moveInput = Vector2.zero;
//    private float rotateInput = 0f;
//    private float AimInput = 0f;

//    public Rigidbody cannon;
//    public int startHealth = 3;
//    public int health;

//    private bool moving = false;

//    public bool redTank;

//    public AudioSource audioS, audioB;
//    [SerializeField]private AudioClip tankMove_S, turretTurn_S, cannonFire_S;

//    public float cannonTime;
//    public float cannonTimer;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody>();
//        health = startHealth;
//        audioB.clip = cannonFire_S;
//    }

//    private void Update()
//    {
//        if (moveInput == Vector2.zero && rotateInput == 0f)
//        {
//            moving = false; 
//        }
//        else // checkt of de tank beweegt
//        {
//            moving = true;
//        }
//        if (AimInput == 0f)
//        {
//            stopSound(turretTurn_S);
//        }
//        if (!moving)
//        {
//            stopSound(tankMove_S);
//        }

//    }

//    private void FixedUpdate()
//    {
//        MoveTank();
//        RotateTank();
//        if (!moving)
//        {
//            AimCannon(); // kan alleen draaien als de tank niet beweegt
//        }
//        cannonTimer--;
//    }

//    // Wordt aangeroepen door PlayerInput component (Send Messages) bij Move actie
//    public void OnMove(InputAction.CallbackContext context)
//    {
//        moveInput = context.ReadValue<Vector2>(); 
//        playSound(tankMove_S);
//    }

//    // Wordt aangeroepen door PlayerInput component bij Rotate actie
//    public void OnRotate(InputAction.CallbackContext context)
//    {
//        rotateInput = context.ReadValue<float>();
//        playSound(tankMove_S);
//    }

//    // Wordt aangeroepen door PlayerInput component bij Fire actie
//    public void OnFire(InputAction.CallbackContext context)
//    {
//        if (context.performed && cannonTimer < 0f)
//        {
//            Shoot();
//            audioB.Play(); // schiet en moet dan even wachten voordat die weer kan schieten
//            cannonTimer = cannonTime;
//        }
//    }
//    public void OnAim(InputAction.CallbackContext context)
//    {
//        AimInput = context.ReadValue<float>();
//        playSound(turretTurn_S);
//    }
//    private void MoveTank()
//    {
//        Vector3 moveDirection = transform.forward * moveInput.y;
//        Vector3 velocity = moveDirection.normalized * moveSpeed;
//        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
//    }

//    private void RotateTank()
//    {
//        float rotation = rotateInput * rotationSpeed * Time.fixedDeltaTime;
//        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
//        rb.MoveRotation(rb.rotation * turnRotation);

//        Quaternion cannonRotation = Quaternion.Euler(rotation * 0.5f, 0f, 0f); // kanon roteert iets mee met de rest van de tank
//        cannon.MoveRotation(cannon.rotation * cannonRotation);
//    }

//    private void Shoot()
//    {
//        if (bulletPrefab == null || shootPoint == null)
//            return;

//        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
//        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
//        bulletRb.AddForce(shootPoint.forward * bulletSpeed);
//    }

//    private void AimCannon()
//    {
//        float rotation = AimInput * rotationSpeed * Time.fixedDeltaTime;
//        Quaternion turnRotation = Quaternion.Euler(rotation, 0f, 0f);
//        cannon.MoveRotation(cannon.rotation * turnRotation);
//    }
//    private void playSound(AudioClip s)
//    {
//        if (!audioS.isPlaying || audioS.clip != s) // kan maar een geluid tegelijk afspelen en restart niet hetzelfde geluid
//        {
//            if (s == tankMove_S)
//            {
//                audioS.volume = 0.25f;
//            }
//            else 
//            {
//                audioS.volume = 1;
//            }
//            audioS.clip = s;
//            audioS.Play();
//        }

//    }
//    private void stopSound(AudioClip s) // stopt een geluid
//    {
//        if (audioS.isPlaying && audioS.clip == s)
//        {
//            audioS.Stop();
//        }

//    }




//}
