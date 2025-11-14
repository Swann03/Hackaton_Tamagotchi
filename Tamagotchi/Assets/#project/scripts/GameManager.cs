using UnityEngine;
using TMPro;    

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimeText;

    int salary = 2000;
    public int Salary => salary;

    int heure = 7;
    int minutes = 0;

    float timer;
   public float timeSpeed;



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
        salary += amount;
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

                if (heure >= 24)
                    heure = 0;
            }

            Debug.Log($"{heure:D2}:{minutes:D2}");


            if (lives <= 3)
            {
                GameOver();
            }

            //si le temps > 7  = gameover()

        }

        //3fonctions avec matin, midi soir et un timeSpeed different pour differentes phases).
    }
}

 
