using Entitas;
public class HelloWorldSystem : IInitializeSystem
{
    public void Initialize()
    {
        UnityEngine.Debug.Log("hello world");
    }
}
