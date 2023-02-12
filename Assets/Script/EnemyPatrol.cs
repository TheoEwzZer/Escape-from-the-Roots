using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public GameManager gameManager;
    public CharactereHealth health;
    private int direction;
    public Animator anim;
    public AudioSource screamerSound;
    public GameObject screamer;
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    public int destPoint = 0;

    void Start()
    {
        screamer.SetActive(false);
        target = waypoints[0];
    }

    void FixedUpdate()
    {
        if (gameManager.isPaused)
            return;
        Vector3 dir = target.position - transform.position;
        float rotationZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.Translate(dir.normalized * speed * Time.fixedDeltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) < 0.05f) {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
        if (rotationZ > -45 && rotationZ < 45)
            direction = 6;
        else if (rotationZ > 45 && rotationZ < 135)
            direction = 8;
        else if (rotationZ > 135 || rotationZ < -135)
            direction = 4;
        else if (rotationZ > -135 && rotationZ < -45)
            direction = 2;
        anim.SetInteger("Direction", direction);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (gameManager.isPaused)
            return;
        if (other.transform.CompareTag("Player")) {
            screamer.SetActive(true);
            screamerSound.Play();
            health.TakeDamage();
            transform.position = waypoints[0].position;
            destPoint = 0;
            if (health.heart <= 0)
                StartCoroutine(ScreamerEnd());
            else
                StartCoroutine(ScreamerContinue());
        }
    }

    public IEnumerator ScreamerEnd()
    {
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator ScreamerContinue()
    {
        yield return new WaitForSeconds(0.9f);
        screamer.SetActive(false);
    }
}
