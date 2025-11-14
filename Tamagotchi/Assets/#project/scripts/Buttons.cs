using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI salaryText;
    
    public TextMeshProUGUI MamieText;




    //recup salary

    private void Start()
    {
        UpdateUi();
    }
 
    public void OnClickButtonUp()
    {
        yes();
        
    }

    public void OnClickButtonDown()
    {
        No();

    }


    public void yes()
    {
      
        gameManager.retire(5);
        
        UpdateUi();
        gameManager.OnMangerButtonClicked();
       


    }

    public void No()
    {
        gameManager.Lives();
        Debug.Log("nofood");
        UpdateUi();
        gameManager.OnMangerButtonClicked();
    }

    void UpdateUi()
    {
        salaryText.text = gameManager.Salary.ToString();
    }

}
