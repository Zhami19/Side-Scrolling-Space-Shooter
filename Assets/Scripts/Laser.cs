using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LaserPool laserPool;
    private PlayerControl player;

    [SerializeField] private float _speed = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        laserPool = LaserPool.FindAnyObjectByType<LaserPool>();
        player = PlayerControl.FindAnyObjectByType<PlayerControl>();

        transform.position = player.transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            laserPool.ReturnLaser(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        laserPool.ReturnLaser(this.gameObject);
    }
}
