using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTwo : MonoBehaviour
{
    [SerializeField] private float _totalCrystalTwo;

    public string _treasureLabel;
    public int _treasurePrice;

    public void Open()
    {
        Destroy(gameObject);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeCrystalTwo(_totalCrystalTwo);
        }
    }
}
