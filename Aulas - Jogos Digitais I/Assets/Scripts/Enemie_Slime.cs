using UnityEngine;

public class Enemie_Slime : MonoBehaviour
{
    public GameManager gameManager;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.AlterLife(1);
        }
    }
}
