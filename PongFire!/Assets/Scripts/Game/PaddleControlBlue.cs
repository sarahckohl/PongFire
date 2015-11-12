using UnityEngine;
using System.Collections;

public class PaddleControlBlue : MonoBehaviour {
	
	// Speed that paddle moves
	public float speed;
	
	// Boundary variables
	public float yMin, yMax;
	
	// Firing variables
	public GameObject shot;		// Shots to be fired
	public Transform shotSpawn;	// Orientation of how the shot should be fired
	public float firerate;		// Limits the number of shots in a timeframe
	public float rapidfirerate;
	private float nextfire;		// Tracker for limit
	
	// Script to check if game should be paused
	public Freeze freezeScript;
	
	// Used for horizontal movement and arc
	public float maxX, arcValue;
	private float baseX;
    public float  baseXoffset=10f;
	
	// Reload variables
	public int ammoInMag;
	private float reloadTime, nextReload;
	public AmmoStash stash;
	private int maxAmmoPerMag;
	public AmmoTracker track;
	
	public float pushBack;
	
	public MagTracker magTrack;
	
	// Sound clips and variables
	public AudioClip clipFire;
	public AudioClip clipReload;
	
	private AudioSource audioFire;
	private AudioSource audioReload;
	
	void Awake() {
		audioFire = AddAudio(clipFire, false, false, .2f);
		audioReload = AddAudio(clipReload, false, false, 1);
	}
	
	AudioSource AddAudio(AudioClip clip, bool loop, bool playOnAwake, float vol) {
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playOnAwake;
		newAudio.volume = vol;
		return newAudio;
	} 
	
	void Start() {
		baseX = transform.position.x;
		reloadTime = ApplicationModel.reloadTime;
		
		if (ApplicationModel.reload) {
			maxAmmoPerMag = ApplicationModel.ammoPerClip;
			reload();
		}
		
		nextReload = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!freezeScript.frozen) {
			if (Time.time > nextReload) gun ();
			
			//straightMovement();
			
			// Sets the paddles position to its max when it passes the border
			if (transform.position.y > yMax) {
				transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
			} else if (transform.position.y < yMin) {
				transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
			}
			
			arcPosition();
		}
	}
	
	// For moving paddle up and down
	void straightMovement() {
		// Moves paddle when key is pressed or held down
		if (Input.GetKey ("w")) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, speed);
		} else if (Input.GetKey ("s")) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -speed);
		}
		
		// Stops the paddle when key isn't held down anymore
		if (Input.GetKeyUp ("w") || Input.GetKeyUp ("s")) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 0.0f);
		}
	}
	
	// Gives the paddle an arcing motion
	void arcPosition() {
		float arcPercent = Mathf.Abs(transform.position.y)/yMax;
		
		transform.rotation = Quaternion.Euler (0, 0, arcValue * Mathf.Sin(transform.position.y/yMax));
		
		// Uses cos to achieve the arc, -1 to get an accurate position
		transform.position = new Vector3(baseX + Mathf.Cos(maxX*arcPercent) - 1, transform.position.y, transform.position.z);
	}
	
	// All keys related to the gun
	void gun() {

		if ((Input.GetKey ("d")) && Time.time > nextfire) {
			if (ApplicationModel.reload && ammoInMag == 0) {
				if (stash.ammoInStash > 0) {
					reloadWAudio ();
				}
			} else {
				fire ();
			}
		}

		if ((Input.GetKeyUp ("d")) && (nextfire > (Time.time + rapidfirerate))) {
			nextfire = Time.time + rapidfirerate;
		}

		
		if (ApplicationModel.reload && Input.GetKeyDown ("a") &&
				stash.ammoInStash > 0 && ammoInMag < maxAmmoPerMag) {
			reloadWAudio ();
		}
	}
	
	void fire() {
		if (!ApplicationModel.infinite && !ApplicationModel.reload) stash.ammoInStash--;
		else if (ApplicationModel.reload) ammoInMag--;
			
		nextfire = Time.time + firerate;
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		track.updateAmmo();
		magTrack.updateAmmo(ammoInMag);
		audioFire.Play ();
	}



	
	// A way to bypass the reload sound playing when game starts
	void reloadWAudio() {
		audioReload.Play ();
		reload ();
	}
	
	// Fills magazine until full or no more ammo is in stash
	void reload() {
		nextReload = Time.time + reloadTime;
		while (ammoInMag < maxAmmoPerMag && stash.ammoInStash > 0) {
			if (!ApplicationModel.infinite) stash.ammoInStash--;
			ammoInMag++;
		}
		track.updateAmmo();
		magTrack.updateAmmo(ammoInMag);
	}
	
	void OnCollisionEnter2D(Collision2D collisionInfo) {
		if (collisionInfo.gameObject.tag != "Bullet")
			collisionInfo.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(pushBack, 0.0f));
	}
}