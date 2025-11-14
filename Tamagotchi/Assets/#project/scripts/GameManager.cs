using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private TextMeshProUGUI WinText;
    [SerializeField] private TextMeshProUGUI clockText; 
    [SerializeField] private TextMeshProUGUI perduText;
    [SerializeField] private GameObject alertImage;
    [SerializeField] private GameObject alertImageAssurance;
    [SerializeField] private TextMeshProUGUI salaryText;
    public TextMeshProUGUI AssuranceText;
    public TextMeshProUGUI MamieText;

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

    int requiredFoodClicks;   // nombre de clics nécessaires pour ce repas
    int currentFoodClicks;    // combien de fois le joueur a cliqué


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
        salary = Random.Range(350, 501);
        UpdateUi();
        ActivateRandomPersos();
        UpdateClockUI();
        alertImage.SetActive(false);
       alertImageAssurance.SetActive(false);

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

           
            if (heure == 8 && minutes == 0 || heure == 12 && minutes == 0 || heure == 19 && minutes == 0)
            {
                // on fige le temps
                isPaused = true;
                Debug.Log("pause temps (repas)");

                // on regarde combien il y a de persos à nourrir
                requiredFoodClicks = GetActivePersoCount();
                currentFoodClicks = 0;

                Debug.Log("Persos à nourrir : " + requiredFoodClicks);

                // si jamais il n’y a personne, on ne bloque pas pour rien
                if (requiredFoodClicks == 0)
                {
                    isPaused = false;
                }
                else
                {
                    // ici tu peux aussi afficher ton UI de repas (panel, bouton, etc.)
                    // ex : alertImage.SetActive(true);
                }
            }

            if (heure == 22 && minutes == 0)
            {
                isPaused = true;
                day++;
               
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

        // on ne fait quelque chose que si on est en pause repas
        if (!isPaused) return;

        // 1 clic "Food"
        currentFoodClicks++;
        Debug.Log("Food clic : " + currentFoodClicks + " / " + requiredFoodClicks);

        // si on n’a pas encore nourri tout le monde, on reste en pause
        if (currentFoodClicks < requiredFoodClicks)
            return;

        // ici : tous les persos ont mangé
        isPaused = false;
        alertImage.gameObject.SetActive(false);
        alertShown = false;

        Debug.Log("Tous les persos ont mangé, reprise du temps !");

    }
    void UpdateClockUI()
    {
        clockText.text = $"{heure:D2}:{minutes:D2}";
    }
    void AlertMamie()
    {

        alertImage.gameObject.SetActive(true);

        MamieText.text = "Ta mamie t'a envoyé 150 euros !";
        add(150);
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



