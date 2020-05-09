using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameManager gameManager;

    public float forwardForce = 1000f;
    public float sidewaysForce = 100f;

    private bool leftKeyDown = false;
    private bool rightKeyDown = false;
    private bool squashed = false;

    void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {
        // best to check for input in update vs fixed update due to logic
        rightKeyDown = Input.GetKey(KeyCode.D);
        leftKeyDown = Input.GetKey(KeyCode.A);

        if ((rightKeyDown || leftKeyDown)) {
            if (!squashed) {
                transform.localScale += new Vector3(0.5f, 0.0f, 0.0f);
                squashed = true;
            }
        } else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) {
            transform.localScale -= new Vector3(0.5f, 0.0f, 0.0f);
            squashed = false;
        } else {
            // transform.localScale -= new Vector3(0.2f, 0.0f, 0.0f);
            squashed = false;
        }
    }

    // Update is called once per frame
    // Use FixedUpdate instead of Update for physics calculations
    // Update runs once per frame. 
    // FixedUpdate can run once, zero, or several times per frame, 
    // depending on how many physics frames per second are set in the time settings, 
    // and how fast/slow the framerate is
    void FixedUpdate()
    {
        float multiplier = gameManager.poweredUp ? 1.2f : 1.0f;
        // need to handle CPU speed to keep the speed different by 
        // time . deltaTime
        // Time.deltaTime is the number of seconds since computer draw last frame
        rb.AddForce(0, 0, forwardForce * multiplier * Time.deltaTime);

        if (rightKeyDown) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (leftKeyDown) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -5) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
