﻿using UnityEngine;

namespace TheoEwzZer.UI
{
    public class SplashScreenManager : MonoBehaviour
    {
        [Header("RESOURCES")]
        public GameObject splashScreen;
        public GameObject mainPanels;
        public GameObject homePanel;
        private Animator splashScreenAnimator;
        private Animator mainPanelsAnimator;
        private Animator homePanelAnimator;

        [Header("SETTINGS")]
        public bool disableSplashScreen;

        void Start()
        {
            if (disableSplashScreen) {
                splashScreen.SetActive(true);
                splashScreenAnimator = splashScreen.GetComponent<Animator>();
                splashScreenAnimator.Play("Splash Out");
                mainPanels.SetActive(true);
                mainPanelsAnimator = mainPanels.GetComponent<Animator>();
                mainPanelsAnimator.Play("Splash Disabled");
                homePanelAnimator = homePanel.GetComponent<Animator>();
                homePanelAnimator.Play("Panel In");
            } else {
                splashScreen.SetActive(true);
            }
        }
    }
}