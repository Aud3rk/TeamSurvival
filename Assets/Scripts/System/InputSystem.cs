using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
public class InputSystem : IExecuteSystem
{
    private Contexts _contexts;
    private float xRotation= 0;
    public InputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var lookHor = Input.GetAxis("Mouse X");
        var lookVert = Input.GetAxis("Mouse Y");
        
        xRotation -= lookVert;
        xRotation = Mathf.Clamp(xRotation, -10, 15f);
        _contexts.game.ReplaceInput(new Vector3(horizontal,0,vertical),new Vector3(xRotation,lookHor,0));
    }
}
