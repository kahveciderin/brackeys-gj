using UnityEngine;

public class Camera : MonoBehaviour {

	public Transform target;

	//public float smoothSpeed = 0.125f;
	public Vector3 smoothSpeed;
	public Vector3 offset;

	public bool shake = false;

	public float shakeSpeed = 1f;

	//public bool stop = false;

	void FixedUpdate ()
	{

	if (!GetComponent<Animation>().IsPlaying("leveltransition"))
     {
		Vector3 desiredPosition = target.position + offset;

		if(shake)	desiredPosition += new Vector3(Random.Range(-shakeSpeed,shakeSpeed),Random.Range(-shakeSpeed,shakeSpeed),Random.Range(-shakeSpeed,shakeSpeed));
		Vector3 smoothedPositionX = Vector3.Lerp(new Vector3(transform.position.x, 0), new Vector3(desiredPosition.x, 0), smoothSpeed.x);
		Vector3 smoothedPositionY = Vector3.Lerp(new Vector3(transform.position.y, 0), new Vector3(desiredPosition.y, 0), smoothSpeed.y);
		Vector3 smoothedPositionZ = Vector3.Lerp(new Vector3(transform.position.z, 0), new Vector3(desiredPosition.z, 0), smoothSpeed.z);
		transform.position = new Vector3(smoothedPositionX.x, smoothedPositionY.x, smoothedPositionZ.x);
	 }

	}

	public void LevelUp(){
		//stop = true;
		GetComponent<Animation>().Play("leveltransition");
		//stop = false;

	}

	

}