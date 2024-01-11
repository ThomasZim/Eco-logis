using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _audioIntro;
    public AudioSource _audioMain;
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioIntro = _audioIntro.GetComponent<AudioSource>();
        _audioMain = _audioMain.GetComponent<AudioSource>();
    }

    public void PlayIntro()
    {
        if (_audioIntro.isPlaying) return;
        _audioIntro.Play();
    }

    public void StopIntro()
    {
        _audioIntro.Stop();
    }
    
    public void PlayMain()
    {
        if (_audioMain.isPlaying) return;
        _audioMain.Play();
    }
    
    public void StopMain()
    {
        _audioMain.Stop();
    }
}