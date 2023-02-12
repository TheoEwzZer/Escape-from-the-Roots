using UnityEngine;
using UnityEngine.UI;

namespace TheoEwzZer.UI
{
    public class ScrollForMore : MonoBehaviour
    {
        [Header("RESOURCES")]
        public Scrollbar listScrollbar;
        private Animator SFMAnimator;

        [Header("SETTINGS")]
        public float fadeOutValue;
        public bool invertValue = false;

        void Start()
        {
            SFMAnimator = gameObject.GetComponent<Animator>();
            CheckValue();
        }

        public void CheckValue()
        {
            if (!invertValue) {
                if (SFMAnimator != null && listScrollbar.value >= fadeOutValue)
                    SFMAnimator.Play("SFM In");
                else if (SFMAnimator != null && listScrollbar.value <= fadeOutValue)
                    SFMAnimator.Play("SFM Out");
            } else {
                if (SFMAnimator != null && listScrollbar.value <= fadeOutValue)
                    SFMAnimator.Play("SFM In");
                else if (SFMAnimator != null && listScrollbar.value >= fadeOutValue)
                    SFMAnimator.Play("SFM Out");
            }
        }
    }
}
