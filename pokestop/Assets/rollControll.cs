using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollControll : MonoBehaviour
{
	public GameObject Rolling_Panel;
	GameObject main_camera;

	Rigidbody rb;
	cameraScript cameraScript;
	public Material maincolor;

	Vector3 startPos;
	Vector3 endPos;
	float dir = 0;
	float time = 0;
	float speed = 0;

	bool approach = false;
	//bool rolling = false;

	public string hit_tag = "pokestop";

    // Start is called before the first frame update
    void Start()
    {

        rb = Rolling_Panel.GetComponent<Rigidbody>();
		rb.maxAngularVelocity = 100f;

		main_camera = GameObject.Find("Main Camera");
		cameraScript = main_camera.GetComponent < cameraScript >();
     }

    // Update is called once per frame
    void Update()
    {

    //rayあたり判定
		Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
			if (hit.collider.gameObject.CompareTag(hit_tag))
			{
				if(Input.GetMouseButtonDown(0) && approach == false){
					approach = true;
					cameraScript.enabled = !cameraScript.enabled;
				}

			}

		}
		//rayあたり判定終了






		//ドラッグ処理
		if (main_camera.transform.position.x == 0)
		{
			//タップした場所と時間
			if (Input.GetMouseButtonDown(0))
			{
				this.startPos = Input.mousePosition;
				this.time = 0;

			}

			//スワイプ中の時間
			if (Input.GetMouseButton(0))
			{
				this.time += Time.deltaTime;
			}

			//話した場所
			if (Input.GetMouseButtonUp(0))
			{
				this.endPos = Input.mousePosition;

				//距離
				this.dir = Mathf.Abs(Vector3.Distance(this.startPos, this.endPos));
				//速度
				this.speed = this.dir / this.time;

				//回転させる
				rb.AddTorque(Vector3.up * Mathf.PI * speed / -10);
				maincolor.color = Color.magenta;

			}



            
                
            
		}

     //ドラッグ処理終了


    }
}
