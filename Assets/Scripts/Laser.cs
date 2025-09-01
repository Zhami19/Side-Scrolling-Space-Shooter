using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    private UI ui;
    private LaserPool laserPool;
    private PlayerControl player;
    private AudioManager audioManager;

    [SerializeField] private float _speed = 3f;

    public UnityEvent OnKill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ui = UI.FindFirstObjectByType<UI>();
        laserPool = LaserPool.FindAnyObjectByType<LaserPool>();
        player = PlayerControl.FindAnyObjectByType<PlayerControl>();
        audioManager = AudioManager.FindAnyObjectByType<AudioManager>();

        OnKill.AddListener(ui.UpdateKillCount);
        OnKill.AddListener(audioManager.DestroyingSound);
    }

    public void InitializeLaser()
    {
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
            OnKill.Invoke();
        }
    }

    private void OnBecameInvisible()
    {
        laserPool.ReturnLaser(this.gameObject);
    }
}
