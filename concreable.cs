
Func<(int, IntPtr)> Concrete(Func<IntPtr> filter, IntPtr @event, int deap, int level)
{
    // 32비트에서는 ToInt64->32 분기
    var queues = EOM.Call(flower, $"objects.all(obj=>{obj.force(&event)}).send({@event.ToInt64()})", deap, level);
    var complatedStream = EOM.StreamOfModel(queues, -1);
    var streamModelSizePtr = complatedStream.ToPtr();
    IntPtr concretedModelPtr = filter(streamModelSizePtr); 
    return () =>
    {
        return (complatedStream.ToArray().Length()-1, concretedModelPtr);
    };
}





 
