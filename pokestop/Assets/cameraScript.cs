using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
	private int i = 0;

	public GameObject target;
	//public Camera mainCamera;

	float speed = 45;
	public GameObject purpose;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		
		


		float step = speed * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(this.transform.position, purpose.transform.position, 20);
		
		transform.position = Vector3.MoveTowards(this.transform.position, purpose.transform.position, step);

		transform.LookAt(target.transform);
		i += 1;
    }
}
