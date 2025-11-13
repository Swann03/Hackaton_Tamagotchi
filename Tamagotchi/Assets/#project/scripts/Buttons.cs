using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
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
        //Console.Log("food");
    }

    public void NoFood()
    {
        gameManager.Lives(1);
        //Console.Log("nofood");
    }



}
