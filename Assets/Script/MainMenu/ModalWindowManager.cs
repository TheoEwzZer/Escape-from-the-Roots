using UnityEngine;

namespace TheoEwzZer.UI
{
    public class ModalWindowManager : MonoBehaviour
    {
        [Header("BRUSH ANIMATION")]
        public Animator brushAnimator;
        public bool enableSplash = true;

        private Animator mWindowAnimator;

        void Start()
        {
            mWindowAnimator = gameObject.GetComponent<Animator>();
        }

        public void ModalWindowIn()
        {
            mWindowAnimator.Play("Modal Window In");
            if (enableSplash) {
                brushAnimator.Play("Transition Out");
            }
        }

        public void ModalWindowOut()
        {
            mWindowAnimator.Play("Modal Window Out");
            if (enableSplash) {
                brushAnimator.Play("Transition In");
            }
        }
    }
}