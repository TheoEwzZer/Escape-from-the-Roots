using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class PickUpFlashlight : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject torch;
    public Light2D flashlight;
    public Light2D vignette;

    public void Start()
    {
        torch.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.SetFlashlight(true);
        if (gameManager.isMobile) {
            flashlight.enabled = true;
            vignette.enabled = true;
            GetComponent<Light2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            StartCoroutine(UseTorch());
        }
    }

    public IEnumerator UseTorch()
    {
        GetComponent<Light2D>().enabled = false;
        torch.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5f);
        torch.SetActive(false);
        Destroy(gameObject);
    }
}
