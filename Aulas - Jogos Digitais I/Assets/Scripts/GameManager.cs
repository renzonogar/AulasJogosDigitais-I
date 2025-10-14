using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int points = 0;
    public int lifes = 3;

    public TextMeshProUGUI txtPoints;
    public TextMeshProUGUI txtLifes;
    
    public void AddPoints(int qtd)
    {
        points += qtd;

        if (points < 0) {
            points = 0;
        }
        txtPoints.text = points + " P";
        Debug.Log("Pontos: " + points);
    }

    public void AlterLife(int life)
    {
        lifes -= life;
        txtLifes.text = lifes + " x";
        Debug.Log("Vidas: " + lifes);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().RestartPosition();

        if (lifes <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("PERDEU VACILÃO PIPOCOU");
        }
    }

}
