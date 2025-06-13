using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class tankMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotSpeed = 5f;

    public InputAction moveAction;
    //private Action inputActions;
    public Rigidbody body;
    public GameObject bulletPrefab;
    public GameObject shootPoint;
    public float bSpeed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveInput = moveAction.
        //float rotationInput = moveAction.Player.Rotate.ReadValue<float>();
    }
    void OnMove(InputValue direction)
    {
        
        var v = direction.Get<Vector2>();
        Vector3 moveDir = (transform.forward * v.y) + (transform.right * v.x);
        Debug.Log(v);
        body.velocity = moveDir * speed * Time.deltaTime;
    }

    void OnRotate(InputValue direction)
    {
        var v = direction.Get<float>();
        transform.Rotate(Vector3.up * v * rotSpeed * Time.deltaTime);
    }
    void OnFire()
    {
        var newBullet = Instantiate(bulletPrefab, shootPoint.transform.position, GetComponentInChildren<Transform>().rotation);
        Rigidbody rbnewBullet = newBullet.GetComponent<Rigidbody>();
        rbnewBullet.AddForce(rbnewBullet.transform.forward * bSpeed);
    }
    //private void Awake()
    //{
    //    inputActions = new Action();
    //}

    //private void OnEnable()
    //{
    //    inputActions.Enable();
    //}

    //private void OnDisable()
    //{
    //    inputActions.Disable();
    //}
}
