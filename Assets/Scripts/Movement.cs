using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject MainCamera;
    private bool jumpAvailable;
    Vector3 offset;

    private Rigidbody myBody;
    // Start is called before the first frame update
    void Start()
    {
        jumpAvailable = true;
        offset = MainCamera.transform.position - this.transform.position;
        myBody = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame!!!! 30 - 60 fps.
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myBody.AddForce(new Vector2(-5f,0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            myBody.AddForce(new Vector2(5f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.W) && jumpAvailable)
        {
            myBody.AddForce(0f, 300f, 0f);
            jumpAvailable = false;
            StartCoroutine(JumpCooldown());
        }
        MainCamera.transform.position = this.transform.position + offset;//Whatever
    }

    public IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(1.2f);
        jumpAvailable = true;
    }
}
