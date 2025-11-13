using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameOver gameOver;
    int salary;
    int money;

    int lives = 3;

    //recuperer le temps

    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    

    public void add(int amount)
    {
        amount += salary;
    }

    public void retire(int amount)
    {
        salary -= amount;
    }
    public void Lives(int amount)
    {
        lives -= amount;
    }


    void Update()
    {
  

        if (lives <= 3)
        {
            gameOver.Over();
        }


        //si le temps > 7  = gameover()

    }

}
