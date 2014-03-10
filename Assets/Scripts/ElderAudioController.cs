using UnityEngine;
using System.Collections;

public class ElderAudioController : MonoBehaviour 
{

	public AudioClip[] tauntSounds;
	public AudioClip[] liftSounds;
	public AudioClip[] setDownSounds;
	public AudioClip[] fallSounds;
	public AudioClip[] winSounds;
	public AudioClip[] loseSounds;
	public AudioClip throwSound;

	public AudioClip[] generalSounds;

	public float pitch = 1f;
	
	void Start () 
	{
		audio.pitch = pitch;
		ElderlyController.Taunt += new ElderlyController.SoundEventHandler(PlayTaunt);
		ElderlyController.Fall += new ElderlyController.SoundEventHandler(PlayFall);
		WalkerController.Lift += new WalkerController.SoundEventHandler(PlayLift);
	}

	void OnDisable()
	{
		ElderlyController.Taunt -= new ElderlyController.SoundEventHandler(PlayTaunt);
		ElderlyController.Fall -= new ElderlyController.SoundEventHandler(PlayFall);
		WalkerController.Lift -= new WalkerController.SoundEventHandler(PlayLift);
	}

	void PlayTaunt()
	{
		if(!audio.isPlaying)
		{
			audio.clip = tauntSounds[Random.Range(0,tauntSounds.Length - 1)];
			audio.Play();               
		}
	}

	void PlayFall()
	{
		audio.clip = fallSounds[Random.Range(0,fallSounds.Length - 1)];
		audio.Play(); 
	}

	void PlayLift()
	{
		audio.clip = liftSounds[Random.Range(0,liftSounds.Length - 1)];
		audio.Play();
	}
}
