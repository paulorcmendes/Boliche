using UnityEngine;
 using System.Collections;
 public class ControleCamera : MonoBehaviour
{
 public GameObject bola;
 private Vector3 offset;
 // Use this for initialization
 void Start()
 {
 offset = transform.position - bola.transform.position;
 }
 // Update is called once per frame
void LateUpdate() {
		transform.position = new Vector3 (bola.transform.position.x + offset.x, offset.y, bola.transform.position.z + offset.z);
}
}