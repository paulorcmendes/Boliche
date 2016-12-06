using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControleBola : MonoBehaviour
{
	private Rigidbody rb;
	private bool play = false;
	public float power;
	private GameObject[] pinos;
	private int derrubNow;
	public int derrubados;
	public Text Placar;
	private float right  = 0.1f;
	private Vector3 originPos;
	// Use this for initialization
    void Start()
    {
		originPos = transform.position;
		pinos = GameObject.FindGameObjectsWithTag("pino");
        derrubados = 0;
        Placar.text ="";
        rb = GetComponent<Rigidbody>();

    }
// Update is called once per frame
void FixedUpdate()
    {
		
         if (Input.GetKey("w") && !play)
        {
            rb.AddForce(new Vector3(0.0f, 0.0f, -Mathf.Abs(power)));
            play = true;
           }
		if (play) {
			derrubNow = 0;
			for (int i = 0; i < pinos.Length; i++) {
				bool x = Mathf.Abs (pinos [i].transform.rotation.eulerAngles.x) > 45f && Mathf.Abs (pinos [i].transform.rotation.eulerAngles.x) < 315f;
				bool z = Mathf.Abs (pinos [i].transform.rotation.eulerAngles.z) > 45f && Mathf.Abs (pinos [i].transform.rotation.eulerAngles.z) < 315f;
				if (x || z) {
					print (i + "caiu");
					//pinos [i].GetComponent<Rigidbody> ().AddForce (0, 111, 0);
					derrubNow++;
				}
			}
			if (derrubNow > derrubados)
				derrubados = derrubNow;
			Placar.text = ""+derrubados;
		} else {
			if (Mathf.Abs(transform.position.x - originPos.x) > 2.0f)
			{
				right *= -1;
			}
			transform.Translate(right, 0.0f, 0.0f);
		}
		if (transform.position.z < -30 || Mathf.Abs (transform.position.x - originPos.x) > 2.5f) {
			rb.velocity = Vector3.zero;
		}

    }
}
