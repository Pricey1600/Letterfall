using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private GameManager GM;
    private AudioSource AS;
    public AudioClip audioClip;
    private float ASPitchDefault;

    private bool isPlaying = false, isPlayingReverse = false;

    private void Start()
    {
        if (GameObject.Find("Game Manager"))
        {
            GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
            AS = GM.gameObject.GetComponent<AudioSource>();
            ASPitchDefault = AS.pitch;
        }
        else if (GameObject.Find("MainMenuManager"))
        {
            AS = GameObject.Find("MainMenuManager").GetComponent<AudioSource>();
            ASPitchDefault = AS.pitch;
        }
    }

    public void playAudio()
    {
        AS.pitch = Random.Range(1f, 3f);
        AS.PlayOneShot(audioClip);
    }
    public void playAnimAudio()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            AS.PlayOneShot(audioClip);
        }
        else
        {
            isPlaying = false;
        }

    }
    public void playAnimAudioReverse()
    {
        if (!isPlayingReverse)
        {
            isPlayingReverse = true;
            AS.PlayOneShot(audioClip);
        }
        else
        {
            isPlayingReverse = false;
        }
        
    }
}
