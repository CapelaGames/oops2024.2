using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{
    [SerializeField] Camera _camera;

    private void Awake()
    {
        if(_camera == null) 
        {
            _camera = Camera.main ? Camera.main : GetComponent<Camera>();
        }
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                IClickable clicked = hit.transform.gameObject.GetComponent<IClickable>();

                if(clicked != null)
                {
                    clicked.OnClick();
                }
            }
        }
    }
}
