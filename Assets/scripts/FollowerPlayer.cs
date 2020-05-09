using UnityEngine;

public class FollowerPlayer : MonoBehaviour
{
    // this will contain a reference to the player object
    public Transform player;
    public Vector3 offset;

    // Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	private float shakeAmount = 0.1f;
    

    // Update is called once per frame
    void Update()
    {
       // lower case transform referes to current object the component
       // is attached to
       Vector3 appliedOffset = offset;
        
        if (FindObjectOfType<GameManager>().poweredUp) {
            appliedOffset.Set(appliedOffset.x, appliedOffset.y, appliedOffset.z);
            appliedOffset = appliedOffset + (Random.insideUnitSphere * shakeAmount);
        }

       transform.position = player.position + appliedOffset;
    }
}
