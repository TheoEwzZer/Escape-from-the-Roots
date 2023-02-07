using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class PickUpFlashlight : MonoBehaviour
{
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
        flashlight.enabled = true;
        vignette.enabled = false;
        StartCoroutine(UseTorch());
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
