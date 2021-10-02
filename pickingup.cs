using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pickingup : MonoBehaviour {
	public int Bulbsc = 0;
	public float SainityB = 1;
	public GameObject bp;
	public GameObject saint;
	public GameObject Light;
	public GameObject armss;
	public GameObject DS;
	public GameObject GDS;
	bool triger=true;
	public Text Textt;
	public AudioSource m_AudioSource;
	public AudioClip scream;


	// Use this for initialization
	void Start () {
		if (triger==true) {
			PlayScream ();
		}
	}
	
	void Update () {
		float x = SainityB;
		float y = SainityB;
		saint.transform.localScale = new Vector3 (x, y, 0.0f);
		;
		if (Bulbsc > 0) {
			bp.SetActive (true);
		} else {
			bp.SetActive (false);
		}
		if (SainityB<=0) {
			DS.SetActive (true);
			StartCoroutine (BtoM ());
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu"); 
		}
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.distance < 40) {
				if (hit.rigidbody) {
					
					//Debug.Log (hit.rigidbody.tag);
					if (Input.GetKeyDown (KeyCode.E)) {
						//Debug.Log ("E");			
						Transform tc = hit.rigidbody.transform;
						if (tc.gameObject.name == "LightBulb") {
							Bulbsc++;
							Textt.text = "It's time to change the light bulb in the lamp";
							Destroy (tc.gameObject);
						}
						if (tc.gameObject.name == "Lamp") {
							Bulbsc--;
							m_AudioSource.enabled =false;
							Light.SetActive (true);
							armss.SetActive (false);
							saint.SetActive (false);
							triger = false;
							Textt.text = "Now I can sleep";
						}
						if (tc.gameObject.name == "Bed"&&triger == false) {
							Debug.Log ("Bed");
							GDS.SetActive (true);
							StartCoroutine (GDM());

						}
					}
				}
			}
		}
		if (triger == true) 
		{
		StartCoroutine (sainityremove ());
	    }
	}
	private void PlayScream()
	{
	m_AudioSource.clip = scream;
	m_AudioSource.Play();
	}
	IEnumerator sainityremove()
	{
		SainityB = SainityB - 0.001f;
		yield return new WaitForSeconds(4f);
	}
	IEnumerator BtoM()
	{
		if (triger == true) {
			yield return new WaitForSeconds (10f);
			SceneManager.LoadScene ("menu");
		}
	}
	IEnumerator GDM()
	{
		
			yield return new WaitForSeconds (10f);
			SceneManager.LoadScene ("menu");

	}

}
