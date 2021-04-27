using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalThree : MonoBehaviour
{
    [SerializeField] private float _totalCrystalThree;

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
            collision.gameObject.GetComponent<Player>().TakeCrystalThree(_totalCrystalThree);
        }
    }
}
