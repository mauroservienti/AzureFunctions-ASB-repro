using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class ThisAndThatHappenedHandler : IHandleMessages<ThisHappened>, IHandleMessages<ThatHappened>
{
    static readonly ILog Log = LogManager.GetLogger<ThisAndThatHappenedHandler>();

    public Task Handle(ThisHappened message, IMessageHandlerContext context)
    {
        Log.Warn($"Handling {nameof(ThisHappened)} in {nameof(ThisAndThatHappenedHandler)}: {message.TheValueExposedByTheEvent.Value.What}.");
        
        return Task.CompletedTask;
    }

    public Task Handle(ThatHappened message, IMessageHandlerContext context)
    {
        Log.Warn($"Handling {nameof(ThatHappened)} in {nameof(ThisAndThatHappenedHandler)}: {message.TheValueExposedByTheEvent.Value.What}.");
        
        return Task.CompletedTask;
    }
}