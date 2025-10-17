using UnityEngine;

public class volumeControl : MonoBehaviour
{
    public GameObject volumeOff;

    public GameObject volumeOn;

    public AudioSource music;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeOff.SetActive(false);
        volumeOn.SetActive(true);
    }

    // Update is called once per frame
    void Update() { }

    public void VolumeOn()
    {
        volumeOff.SetActive(false);
        volumeOn.SetActive(true);
        music.volume = 0.2f;
    }

    public void VolumeOff()
    {
        volumeOff.SetActive(true);
        volumeOn.SetActive(false);
        music.volume = 0f;
    }
}
