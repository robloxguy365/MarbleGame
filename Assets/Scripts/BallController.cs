using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour
{
	public float speed;
	public float jumpHeight;
	public Text countText;
	public Text winText;
	public int numPickups;
	public AudioSource musicSource;
	public AudioSource sfxSource;
	private float horizAxis;
	private float vertAxis;
	private bool space;
	private Rigidbody rb;
	public int count;
	private bool isgrounded;
	public Camera mainCamera;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
		isgrounded = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
		if(GameObject.FindGameObjectWithTag("Music") != null) { 
			GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
		}
	}
    private void Update()
    {
		horizAxis = Input.GetAxis("Horizontal");
		vertAxis = Input.GetAxis("Vertical");
		space = Input.GetKey("space");
    }
    private void OnCollisionStay(Collision collision)
    {
		isgrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
		isgrounded = false;
    }
    void FixedUpdate()
	{
		float moveHorizontal = horizAxis;
		float moveVertical = vertAxis;
		float cameraFacingX = mainCamera.transform.eulerAngles.x;
		float cameraFacingY = mainCamera.transform.eulerAngles.y;
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 turnedMovement = Quaternion.Euler(0, cameraFacingY, 0) * movement;

		rb.AddForce(turnedMovement * speed);

		if (space && isgrounded)
		{
			Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
			rb.AddForce(jump);
			sfxSource.PlayOneShot(Resources.Load<AudioClip>("Zero Rare/Retro Sound Effects/Audio/Jump/jump_04"), PlayerPrefs.GetFloat("GameVolume"));
		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
			sfxSource.PlayOneShot(Resources.Load<AudioClip>("Zero Rare/Retro Sound Effects/Audio/Coin/coin_15"), PlayerPrefs.GetFloat("GameVolume"));
		}
		else if (other.gameObject.CompareTag("Respawn"))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

	void SetCountText()
	{
		countText.text =  count.ToString() + "/" + numPickups;
	}
}
