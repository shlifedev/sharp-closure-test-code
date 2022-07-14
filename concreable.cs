
//concreteable function sample
//require
Func<(int, IntPtr)> Concrete(Func<IntPtr> filter, IntPtr @event, int deap, int level)
{
    var queues = EOM.Call(flower, "objects.all(obj=>{obj.force(&event)})", deap, level);
    var complatedStream = EOM.StreamOfModel(queues, -1);
    var streamModelSizePtr = complatedStream.ToPtr();
    IntPtr concretedModelPtr = filter(streamModelSizePtr); 
    return () =>
    {
        return (complatedStream.ToArray().Length()-1, concretedModelPtr);
    };
}





 
