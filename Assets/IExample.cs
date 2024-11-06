using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IClick
{
    void Click();

    void Press();

}

interface IPoints
{
    void Score();

}

public class MyTV : MonoBehaviour, IClick, IPoints
{

    public void Click()
    {
        Debug.Log("Turn on TV");
    }

    public void Press()
    {
        Debug.Log("Also Turn on TV");
    }

    public void Score()
    {
        Debug.Log("Scored 3 points");
    }
}

public class Switch: MonoBehaviour, IClick
{
    public void Click()
    {
        Debug.Log("Turn on lights");
    }

    public void Press()
    {
        Debug.Log("Blows up lightbulb");
    }

}

public class Button : Switch
{

}

public class Player : MonoBehaviour
{
    [SerializeField] private Switch light;
    [SerializeField] private Button button;
    [SerializeField] private MyTV tv;

    void ListMaker()
    {
        light.Press();
        light.Click();

        IClick test = light;

        List<IClick> stuff = new List<IClick>();
        stuff.Add(light);
        stuff.Add(tv);
        stuff.Add(button);

        stuff[0].Click();
        stuff[0].Press();
    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit,2f))
            {
                IClick clicked = hit.transform.gameObject.GetComponent<IClick>();
                if (clicked != null)
                {
                    clicked.Click();
                    //clicked.Press();
                }

                IPoints points = hit.transform.gameObject.GetComponent<IPoints>();
                if(points != null)
                {
                    points.Score();
                }
            }
        }
    }
}
