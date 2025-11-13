using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    //recup salary


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
    }

    public void NoFood()
    {

        gameManager.Lives(1);
        Debug.Log("nofood");
    }



}
