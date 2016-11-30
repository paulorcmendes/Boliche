using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControleBola : MonoBehaviour
{
	private Rigidbody rb;
	private bool play = false;
	public float power;
	private GameObject[] pinos;
	private float[] xzes;
	private int derrubNow;
	public int derrubados;
	public Text Placar;
    // Use this for initialization
    void Start()
    {
		pinos = GameObject.FindGameObjectsWithTag("pino");
		xzes = new float[10];
		for(int i = 0;i<xzes.Length;i++){
			xzes[i]=pinos[i].transform.position.x;
		}
        derrubados = 0;
        Placar.text ="";
        rb = GetComponent<Rigidbody>();
         }
// Update is called once per frame
void FixedUpdate()
    {
         if (Input.GetKey("a") && transform.position.x < 2.0f && !play)
        {
            transform.Translate(0.1f, 0.0f, 0.0f);
             }
         if (Input.GetKey("d") && transform.position.x > -2.0f && !play)
        {
            transform.Translate(-0.1f, 0.0f, 0.0f);
             }
         if (Input.GetKey("w") && !play)
        {
            rb.AddForce(new Vector3(0.0f, 0.0f, -Mathf.Abs(power)));
            play = true;
           }
        if (play)
        {
			derrubNow = 0;
			for (int i = 0; i < pinos.Length; i++) {
				if (Mathf.Abs(pinos[i].transform.rotation.eulerAngles.z) > 45 || Mathf.Abs(pinos[i].transform.rotation.eulerAngles.x) > 45)
					derrubNow++;
			}
			if (derrubNow > derrubados)
				derrubados = derrubNow;
            Placar.text = "Derrubou: " + derrubados.ToString() + " pinos.";
        }
    }
}
