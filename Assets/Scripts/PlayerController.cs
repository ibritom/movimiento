using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-45f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(45f * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("up") && canJump == true)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8000f));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "floor")
        {
            canJump = true;   
        }
    }
}
