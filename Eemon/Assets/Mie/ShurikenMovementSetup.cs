using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenMovementSetup : MonoBehaviour
{
    public Rigidbody rigidbody;
    static public bool isThrowing;
    public float moveVelocity = 30.0f;
    public float rotateVelocity = 70.0f;
    private ScoreManager scoreManager;
    static public int throwCount = 0;
    private bool collisionTarget;
    public Transform controllerTransform;
    private bool isGrabbing;
    public AudioClip throwSound;
    public AudioClip hitSound;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        isThrowing = false;
        collisionTarget = false;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        isGrabbing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing)
        {
            transform.position = controllerTransform.position;
        }
        if (!collisionTarget)
        {
            if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                isThrowing = true;
                isGrabbing = false;
                rigidbody.isKinematic = false;
                AudioSource.PlayClipAtPoint(throwSound, transform.position);
                throwCount++;
            }

            if (isThrowing)
            {
                transform.Rotate(Vector3.forward, rotateVelocity * Time.deltaTime);
                Vector3 newPosition = transform.position + Vector3.forward * moveVelocity * Time.deltaTime;
                transform.position = newPosition;
            }

            // if (Input.GetKeyDown(KeyCode.L))
            // {
            //     transform.position += new Vector3(1, 0, 0);
            // }
            // if (Input.GetKeyDown(KeyCode.J))
            // {
            //     transform.position += new Vector3(-1, 0, 0);
            // }
            // if (Input.GetKeyDown(KeyCode.I))
            // {
            //     transform.position += new Vector3(0, 1, 0);
            // }
            // if (Input.GetKeyDown(KeyCode.K))
            // {
            //     transform.position += new Vector3(0, -1, 0);
            // }
        }
        if ((Input.GetKeyDown(KeyCode.A) || OVRInput.GetDown(OVRInput.Button.Three)) && !isThrowing  && throwCount < 3)
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(90, 0, 0);
            collisionTarget = false;
            isGrabbing = true;
            //transform.position = controllerTransform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isThrowing = false;
        rigidbody.isKinematic = true;
        collisionTarget = true;
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        if (collisionTarget)
        {
            if (collision.gameObject.CompareTag("center50"))
            {
                scoreManager.gamePoint -= 50;
            }
            if (collision.gameObject.CompareTag("out40"))
            {
                scoreManager.gamePoint -= 40;
            }
            if (collision.gameObject.CompareTag("out30"))
            {
                scoreManager.gamePoint -= 30;
            }
            if (collision.gameObject.CompareTag("out20"))
            {
                scoreManager.gamePoint -= 20;
            }
            if (collision.gameObject.CompareTag("out10"))
            {
                scoreManager.gamePoint -= 10;
            }
        }

    }
}
