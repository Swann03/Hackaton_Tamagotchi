using UnityEngine;

using TMPro;



public class Alerts : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    public TextMeshProUGUI MamieText;
    public TextMeshProUGUI AssuranceText;
    public TextMeshProUGUI NoelText;
    [SerializeField] private TextMeshProUGUI salaryText;



    //recup salary


    // donne des alertes toutes les x tps pour donner nouvelles aléatoires 
    void Start()
    {
        AlertMamie();
        
    }

    void Update()
    {

    }

    void AlertMamie()
    {
        MamieText.gameObject.SetActive(true);

        MamieText.text = "Ta mamie t'a envoyé 150 euros !";
        gameManager.add(150);
        UpdateUi();

        //if (Input.GetMouseButtonDown(0)) 
        //{
        //    MamieText.gameObject.SetActive(false);

        //}

        
    }

    void AlertAssurance()
    {
        AssuranceText.gameObject.SetActive(true);

        AssuranceText.text = "Ta compagnie d'assurance te réclame 30 euros";

        if (Input.GetMouseButtonDown(0))
        {
            AssuranceText.gameObject.SetActive(false);

        }

        gameManager.retire(300);
    }

    void AlertNoel()
    {
        NoelText.gameObject.SetActive(true);

        NoelText.text = "C'est Noel! Tu débourse 100 euros pour les cadeaux";

        if (Input.GetMouseButtonDown(0))
        {
            NoelText.gameObject.SetActive(false);

        }

        gameManager.retire(100);
    }
    void UpdateUi()
    {
        salaryText.text = gameManager.Salary.ToString();
    }
}
