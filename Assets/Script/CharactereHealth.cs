using UnityEngine;

public class CharactereHealth : MonoBehaviour
{
    public Heart heart2;
    public GameObject spawn;
    public int heart = 3;
    void Start()
    {
        transform.position = spawn.transform.position;
    }

    void Update()
    {
        
    }

    public void TakeDamage()
    {
        heart -= 1;
        transform.position = spawn.transform.position;
        heart2.TakeDamage();
    }
}
