using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NukeAnimationScript : MonoBehaviour
{

    [SerializeField] private float flashDuration = 1f;
    private Image nukeAnimationPic;

    private void Start()
    {
        nukeAnimationPic = GetComponent<Image>();
    }

    public void TriggerFlash()
    {
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
