using Entitas;
using UnityEngine;

public class BuriningSystem : IExecuteSystem
{
    private Contexts _contexts;
    public BuriningSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        Timer();
    }

    private void Timer()
    {
        var burningTime = _contexts.game.bonfireEntity.actualTimer.seconds;
        burningTime -= Time.deltaTime;
        if (burningTime <= 0)
        {
            Debug.Log("Huy");
        }
        _contexts.game.bonfireEntity.ReplaceActualTimer(burningTime);
    }
}
