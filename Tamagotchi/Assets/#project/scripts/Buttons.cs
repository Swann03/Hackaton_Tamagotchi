using UnityEngine;
using TMPro;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI salaryText;

    


    //recup salary

    private void Start()
    {
        UpdateUi();
    }
 
    public void OnClickButtonUp()
    {
        Food();
        
    }

    public void OnClickButtonDown()
    {
        NoFood();

    }


    public void Food()
    {
      
        gameManager.retire(5);
        Debug.Log("food");
        UpdateUi();
        
    }

    public void NoFood()
    {
        gameManager.Lives(1);
        Debug.Log("nofood");
        UpdateUi();
    }

    void UpdateUi()
    {
        salaryText.text = gameManager.Salary.ToString();
    }

}
