using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    
    private bool _delayRespaunBomb;
    private Rigidbody2D _rigidbody2DL;
    
    void Start()
    {
        _rigidbody2DL = GetComponent<Rigidbody2D>();
        _delayRespaunBomb = true;
    }
    
    public void InstBomb()
    {
        if (_delayRespaunBomb)
        {
            _delayRespaunBomb = false;
            StartCoroutine(StartBomb());
        }
    }

    private  IEnumerator StartBomb()
    {
        GameObject projectileObject = Instantiate(_bomb, _rigidbody2DL.position
            , Quaternion.identity);
        yield return new WaitForSeconds(3f);
        _delayRespaunBomb = true;
    }

    
    // обработка столкновения с бомбой
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "BombActiv")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
    // обработка столкновения с врагом
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        
        if (other.gameObject.tag == "Enamy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
