using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText; 

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText();
	}


	void Update() //called before rendering frame
	{


	}

	void FixedUpdate() //called before physics calculations; performs physics
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	// Destroy everything that enters the trigger
	void OnTriggerEnter (Collider other) 
	{

		if (other.gameObject.CompareTag ("Pick up")) 
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}

	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 8) 
		{
			winText.text = "You win!";

		}
	}
}
