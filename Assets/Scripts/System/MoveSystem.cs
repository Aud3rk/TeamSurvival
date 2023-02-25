using Entitas;
using UnityEngine;

public class MoveSystem : IExecuteSystem
{
    private Contexts _contexts;

    public MoveSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        var move = _contexts.game.input.moveDir;
        var chracterController = _contexts.game.playerEntity.view.value.transform.GetComponent<CharacterController>();
        var speed = _contexts.game.gameSetup.value.speed;
        
        var look = _contexts.game.input.lookDir;
        var sensX = _contexts.game.gameSetup.value.sensivityX;
        var sensY = _contexts.game.gameSetup.value.sensivityY;

        Vector3 direction = move;
        direction.y = -5;
        direction = chracterController.gameObject.transform.TransformDirection(direction);
        chracterController.Move(direction*speed*Time.deltaTime);
        
        chracterController.transform.gameObject.transform.Rotate(new Vector3(0,look.y,0)*sensX,Space.Self);
        Camera.main.transform.localEulerAngles = new Vector3(look.x, 0, 0)*sensY;
    }
}
