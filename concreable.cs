
Func<(int, IntPtr)> Concrete(Func<IntPtr> filter, IntPtr @event, int deap, int level)
{
    // 32비트에서는 ToInt64->32 분기
    var queues = EOM.Call(flower, $"objects.all(obj=>{obj.force(&event)}).send({@event.ToInt64()})", deap, level);
    var complatedStream = EOM.StreamOfModel(queues, -1);
    var streamModelSizePtr = complatedStream.ToPtr();
    IntPtr concretedModelPtr = filter(streamModelSizePtr);
    return () =>
    {
        return (complatedStream.ToArray().Length() - 1, concretedModelPtr);
    };
} 
void StartHost(int block, int node)
{
    var remote = new Thread(() => { });
    var id = remote.ManagedThreadId;
    var filterObject = EOM.Filter(id, block, node);
    var test = EOM.StartThread(EOM.ObjectManager.Instance.main);

    var deap = EOM.FindNode(node).deap;
    //Concrete
    Concrete(filterObject.filter, id, deap, 0);
    if(block == 0) 
    {
        EOM.Application.Instance.Quit();
        return;
    }
    else StartHost(block-1, node); 
}

StartHost(99, 0); // stress test
