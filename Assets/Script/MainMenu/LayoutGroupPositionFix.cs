using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheoEwzZer.UI
{
    public class LayoutGroupPositionFix : MonoBehaviour
    {
        LayoutGroup lg;

        void Start()
        {
            // BECAUSE UNITY UI IS BUGGY AND NEEDS REFRESHING :P
            try {
                lg = gameObject.GetComponent<LayoutGroup>();
            } catch {
                Debug.LogError("LayoutGroupPositionFix: No LayoutGroup found on this GameObject!");
            }
            StartCoroutine(ExecuteAfterTime(0.01f));
        }

        public void Fix()
        {
            StartCoroutine(ExecuteAfterTime(0.01f));
        }

        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            lg.enabled = false;
            lg.enabled = true;
            StopCoroutine(ExecuteAfterTime(0.01f));
            //Destroy(this);
        }
    }
}