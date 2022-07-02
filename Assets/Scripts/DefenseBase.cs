using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBase : MonoBehaviour
{
    [SerializeField]
    private int defenseBaseHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyController enemyController))
        {
            defenseBaseHp -= enemyController.attackDamage;
        }
        if (defenseBaseHp < 1)
        {
            Debug.Log("Game Over");
        }

        Destroy(collision.gameObject);

    }
}
