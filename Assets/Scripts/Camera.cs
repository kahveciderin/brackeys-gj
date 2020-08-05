using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public bool shake = false;

	//public bool stop = false;

	void FixedUpdate ()
	{

	if (!GetComponent<Animation>().IsPlaying("leveltransition"))
     {
		Vector3 desiredPosition = target.position + offset;

		if(shake)	desiredPosition += new Vector3(Random.Range(-2,2), Random.Range(-2,2), Random.Range(-2,2));
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;
	 }

	}

	public void LevelUp(){
		//stop = true;
		GetComponent<Animation>().Play("leveltransition");
		//stop = false;

	}

	

}