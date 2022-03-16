using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ActivBomb());
    }
    // меняем таг бомбы через 1 сек, что бы сразу не подорвалась свинка.
    IEnumerator ActivBomb()
    {
        yield return new WaitForSeconds(1f);
        gameObject.tag = "BombActiv";
    }
}
