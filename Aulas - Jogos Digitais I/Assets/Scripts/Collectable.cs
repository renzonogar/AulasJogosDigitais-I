using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.AddPoints(10);
            Destroy(gameObject);
        }
    }

 
}
