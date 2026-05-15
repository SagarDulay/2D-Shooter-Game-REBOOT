using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NukeAnimationScript : MonoBehaviour
{

    [SerializeField] private float flashDuration = 1f;
    [SerializeField] AudioClip nukeSound;
    [SerializeField] private Image nukeAnimationPic;

    
    private AudioSource nukeSource;

    private void Start()
    {
        
        nukeSource = GetComponent<AudioSource>();
    }

    public void TriggerFlash()
    {
        nukeSource.PlayOneShot(nukeSound);
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < flashDuration / 2)
        {
            elapsed += Time.deltaTime;
            nukeAnimationPic.color = new Color(nukeAnimationPic.color.r, nukeAnimationPic.color.g, nukeAnimationPic.color.b, elapsed / (flashDuration / 2));
            yield return null;
        }

        elapsed = 0f;

        while (elapsed < flashDuration / 2)
        {
            elapsed += Time.deltaTime;
            nukeAnimationPic.color = new Color(nukeAnimationPic.color.r, nukeAnimationPic.color.g, nukeAnimationPic.color.b, 1 - (elapsed / (flashDuration / 2)));
            yield return null;

        }

        nukeAnimationPic.color = new Color(nukeAnimationPic.color.r, nukeAnimationPic.color.g, nukeAnimationPic.color.b, 0f);
    }

}  
