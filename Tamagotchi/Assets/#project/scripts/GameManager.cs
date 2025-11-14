using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private TextMeshProUGUI WinText;
    [SerializeField] private TextMeshProUGUI clockText; 
    [SerializeField] private TextMeshProUGUI perduText;
    [SerializeField] private RequestDb requestDb;
    private int idmemeber;


    int salary = 2000;
    public int Salary => salary;

    int heure = 7;
    int minutes = 0;

    float timer;
    public float timeSpeed;
    bool isPaused = false;
    int day;



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
    private void Start()
    {
        UpdateClockUI();

    }

    public void add(int amount)
    {
        salary += amount;
    }

    public void retire(int amount)
    {
        salary -= amount;
    }


    public void Lives()
    {
        lives--;
        
        
    }

    public void GameOver()
    {

        if (lives == 0)
        {
            perduText.gameObject.SetActive(true);
            perduText.text = "PERDU !";
            
        }
        //stopper le jeu
        //proposer de rejouer

    }

    void Update()
    {
        if (!requestDb.isReady) return;
        idmemeber = requestDb.personnageData.member[0].id;
        Debug.Log(idmemeber);
        
        UpdateClockUI();
        if (isPaused == true) { return; }

        if (day == 2)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "GAGNE !";

            
        }

        Temps();
        GameOver();
       

    }
    void Temps()
    {

        timer += Time.deltaTime;
        isPaused = false;


        

        if (lives <= 3)
        {
            gameOver.Over();
        }


            if (minutes >= 60)
            {
                minutes = 0;
                heure++;

                if (heure >= 24)
                    heure = 0;
                

            }

           
            if (heure == 8 && minutes == 0 || heure == 12 && minutes == 0 || heure == 19 && minutes == 0 || heure == 22 && minutes == 0)
            {
                isPaused = true;
                Debug.Log("pause temps");
            }

            if (heure == 22 && minutes == 0)
            {
              day++;
               
            }
        
        }


        if (heure == 8 && minutes == 0 || heure == 12 && minutes == 0 || heure == 19 && minutes == 0 || heure == 22 && minutes == 0)
        {
            isPaused = true;
            Debug.Log("pause temps");
        }

        if (heure == 22 && minutes == 0)
        {
            day++;

        }

    }

public void OnMangerButtonClicked()
{


    isPaused = false;

}

void UpdateClockUI()
    {
        clockText.text = $"{heure:D2}:{minutes:D2}";
    }

}


 
