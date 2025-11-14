using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI salaryText;
    [SerializeField] private Image alertImage;
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
        //MamieText.gameObject.SetActive(false);
        //alertImage.gameObject.SetActive(false);


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
