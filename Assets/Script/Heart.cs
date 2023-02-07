using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject[] hearts;
    void Start()
    {
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].SetActive(true);
        }
    }

    public void TakeDamage()
    {
        for (int i = 0; i < hearts.Length; i++) {
            if (hearts[i].activeSelf) {
                hearts[i].SetActive(false);
                break;
            }
        }
    }
}
