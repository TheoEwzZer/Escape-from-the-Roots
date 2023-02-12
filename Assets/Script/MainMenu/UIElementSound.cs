using UnityEngine;
using UnityEngine.EventSystems;

namespace TheoEwzZer.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class UIElementSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {
        [Header("RESOURCES")]
        public AudioSource audioSource;
        public AudioClip hoverSound;
        public AudioClip clickSound;

        [Header("SETTINGS")]
        public bool enableHoverSound = true;
        public bool enableClickSound = true;

        void Start()
        {
            if (!audioSource) {
                try {
                    audioSource = gameObject.GetComponent<AudioSource>();
                    audioSource.playOnAwake = false;
                } catch {
                    Debug.LogError("UI Element Sound - Cannot initalize AudioSource due to missing resources.", this);
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (enableHoverSound && audioSource != null)
                audioSource.PlayOneShot(hoverSound);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (enableClickSound && audioSource != null) {
                audioSource.PlayOneShot(clickSound);
            }
        }
    }
}