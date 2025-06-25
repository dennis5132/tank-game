using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankManager : MonoBehaviour
{

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 150f;

    public int startHealth = 3;

    [Header("Audio")]
    public AudioClip tankMoveClip;
    public AudioClip turretTurnClip;
    public AudioClip cannonFireClip;

    [Header("destruction")]
    public float radius = 5;
    public float force = 1500;
    public GameObject explosion;

    public float endTime;

    public bool fading;
    public AudioSource tankSource;
    public float timeLeft;
    //public float basetime;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
          
        if (fading)
        {
            tankSource.volume = tankSource.volume * timeLeft;
        }
    }
    private void FixedUpdate()
    {
        timeLeft -= timeLeft / endTime;
    }
    public void fadeOut()
    {
        fading = true;
        timeLeft = 1;
    }
}
