using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RequestDb requestDb;
    private int idmember;
    private string messageAlert;
    private int montantAlert;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI WinText;
    [SerializeField] private TextMeshProUGUI clockText; 
    [SerializeField] private TextMeshProUGUI perduText;
    [SerializeField] private GameObject alertImage;
    [SerializeField] private GameObject alertImageAssurance;
    [SerializeField] private TextMeshProUGUI salaryText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private GameObject alertImageFood;
    public TextMeshProUGUI AssuranceText;
    public TextMeshProUGUI MamieText;

    [SerializeField] private TextMeshProUGUI fDJText;
    [SerializeField] private GameObject alertFDJ;

    //[SerializeField] private GameObject perso1;
    //[SerializeField] private GameObject perso2;
    //[SerializeField] private GameObject perso3;
    //[SerializeField] private GameObject perso4;
    //[SerializeField] private GameObject perso5;

    [SerializeField] private GameObject[] persoList;
    


    int salary;
    public int Salary => salary;

    int heure = 7;
    int minutes = 0;

    float timer;
    public float timeSpeed;
    bool isPaused = false;
    int day;

    int requiredFoodClicks;   // nombre de clics n�cessaires pour ce repas
    int currentFoodClicks;    // combien de fois le joueur a cliqu�


    int lives = 3;

    private bool alertShown = false;

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

        alertImage.SetActive(false);
        alertImageAssurance.SetActive(false);
        alertImageFood.SetActive(false);
        alertFDJ.SetActive(false);

    }
    private void Start()
    {
        salary = Random.Range(150, 350);
        UpdateUi();
        ActivateRandomPersos();
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
        UpdateClockUI();

        if (day == 2)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "GAGNE !";
            isPaused = true;

            
        }
        if (isPaused == true) { return; }

        Temps();
        GameOver();
       

    }


    void Temps()
    {
        
        timer += Time.deltaTime;
        isPaused = false;

        

        if (timer >= timeSpeed)
        {
            timer = 0f;
            minutes++;


            if (minutes >= 60)
            {
                minutes = 0;
                heure++;

                if (heure >= 24)
                    heure = 0;
                

            }

           
            if (heure == 8 && minutes == 00 || heure == 12 && minutes == 0 || heure == 19 && minutes == 0)
            {
                alertImageFood.gameObject.SetActive(true);
                foodText.text = "Il est l'heure de manger. appuie sur YES si tu veux faire manger la famille. Attention ils doivent tous manger";
                isPaused = true;
                

                requiredFoodClicks = GetActivePersoCount();
                currentFoodClicks = 0;

               

                if (requiredFoodClicks == 0)
                {
                    isPaused = false;
                }
               
            }

            if (heure == 22 && minutes == 0)
            {
                alertFDJ.gameObject.SetActive(true);
                fDJText.text = "fin de journée...";
                isPaused = true;
                day++;
                if (day == 2)
                {
                    isPaused = true ;
                }
               
            }
            if (heure == 10 && minutes == 0)
            {
                AlertMamie();

                isPaused = true;
                alertShown = true;
            }
            if (heure == 14 && minutes == 0)
            {
                AlertAssurance();
            }
        
        }
    


    }

    public void OnMangerButtonClicked()
    {

        if (!isPaused) return;

        currentFoodClicks++;

        if (currentFoodClicks < requiredFoodClicks)
            return;

        isPaused = false;
        alertImage.gameObject.SetActive(false);
        alertImageFood.gameObject.SetActive(false);
        alertFDJ.gameObject.SetActive(false);

        alertShown = false;


    }
    void UpdateClockUI()
    {
        clockText.text = $"{heure:D2}:{minutes:D2}";
    }

    private int rdnMess; 
    private int rdnMont;

    void AlertMamie()
    {
        rdnMess = Random.Range(1, 9);
        rdnMont = Random.Range(0, 19);
        alertImage.gameObject.SetActive(true);

        montantAlert = requestDb.depenseData.member[rdnMess].montant;
        messageAlert = $"{requestDb.eventData.member[rdnMess].nomEvenement} :  {montantAlert}€";
        MamieText.text = messageAlert;

        add(montantAlert);
        Debug.Log($"{messageAlert}, {montantAlert}");
        UpdateUi();


    }

    void UpdateUi()
    {
        salaryText.text = Salary.ToString();
    }

    void AlertAssurance()
    {
        AssuranceText.gameObject.SetActive(true);

        AssuranceText.text = "Ta compagnie d'assurance te réclame 30 euros";

        retire(30);
        UpdateUi();

    }

    public void ActivateRandomPersos()
    {
        
        foreach (GameObject p in persoList)
        {
            p.SetActive(false);
        }

        int maxPossible = persoList.Length;
        int amount = Random.Range(1, maxPossible + 1);

        List<int> usedIndexes = new List<int>();

        while (usedIndexes.Count < amount)
        {
            int randomIndex = Random.Range(0, persoList.Length);

            if (!usedIndexes.Contains(randomIndex))
            {
                usedIndexes.Add(randomIndex);
            }
        }

      
        foreach (int index in usedIndexes)
        {
            persoList[index].SetActive(true);
        }

      
    }

    int GetActivePersoCount()
    {
        int count = 0;
        foreach (GameObject perso in persoList)
        {
            if (perso.activeSelf)
            {
                count++;
            }
        }
        return count;
    }




}



