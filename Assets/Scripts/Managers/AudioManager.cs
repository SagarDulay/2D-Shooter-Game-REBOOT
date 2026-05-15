using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource shootingSource;
    [SerializeField] private AudioSource powerUpSource;
    [SerializeField] private AudioSource musicSource;


    public void PlayShootingSound(AudioClip shootSound)
    {
        shootingSource.PlayOneShot(shootSound);
    }

    public void PlayPowerUpSound()
    {

    }

    public void PlayBackgroundMusic()
    {

    }

    public void StopBackgroundMusic()
    {

    }

}
