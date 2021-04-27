using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(BoxCollider2D))]


public class Player : MonoBehaviour
{
    public float Health = 100;
    public float CrystalOne = 0;
    public float CrystalTwo = 0;
    public float CrystalThree = 0;
    public float Speed;
    public float JumpForce;
    public List<TreasureData> Inventory = new List<TreasureData>();
    public TMP_Text HealthText;
    public TMP_Text CrystalOneText;
    public TMP_Text CrystalTwoText;
    public TMP_Text CrystalThreeText;

    private Rigidbody2D _rigidbody;
    private GroundChecker _groundChecker;
    private Animator _animator;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _animator = GetComponent<Animator>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.CheckGround())
        {
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        HealthText.text = Health.ToString();
    }

    public void TakeCrystalOne(float amount)
    {
        CrystalOne += amount;
        CrystalOneText.text = CrystalOne.ToString();
    }

  
    public void TakeCrystalTwo(float amount)
    {
        CrystalTwo += amount;
        CrystalTwoText.text = CrystalTwo.ToString();
    }

    public void TakeCrystalThree(float amount)
    {
        CrystalThree += amount;
        CrystalThreeText.text = CrystalThree.ToString();
    }

   

    private void FixedUpdate()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        if (direction < 0)
        {
            _animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (direction > 0)
        {
            _animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        else
        {
            _animator.SetBool("IsWalk", false);
        }

        _rigidbody.velocity = new Vector2(direction * Speed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.CheckGround())
        {
            _animator.SetBool("IsJump", true);
            _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _animator.SetBool("IsJump", false);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Chest chest = collision.gameObject.GetComponent<Chest>();
                chest.Open();
            }
        }

        else if (collision.gameObject.CompareTag("Treasure"))
        {
            
                Treasure treasure = collision.gameObject.GetComponent<Treasure>();
                Inventory.Add(treasure.Take());
           
        }
    }
}