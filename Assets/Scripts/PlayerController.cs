using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
    private int count;
    public Text countText;
    public Text win;
	void  Start()
	{
		rb = GetComponent<Rigidbody> ();
        count = 0;
        setCountText();
        win.text = "";
    }
	void FixedUpdate()
	{
		float MoveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (MoveHorizontal, 0.0f, moveVertical);


		rb.AddForce (movement * speed);

	}
		void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count++ ;
            setCountText();
        }
    }
    void setCountText()
    {
        countText.text = "Tu puntuación :" + count.ToString();
        if(count >= 13)
        {
            win.text = "Ganache";
           
        }
    }
}
