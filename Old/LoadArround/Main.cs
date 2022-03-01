using LoadManagement;
using UnityEngine;
using WorldStuff;

public class Main : MonoBehaviour
{
    public World world;
    public LoadReceiver loadReceiver;
    public LoadSender loadSender;

    private void Awake()
    {
        world.Init();
        loadReceiver.Init(world);
        loadSender.Init(loadReceiver);
    }
}