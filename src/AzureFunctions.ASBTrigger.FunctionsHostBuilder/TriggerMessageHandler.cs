using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

#region TriggerMessageHandler

public class TriggerMessageHandler : IHandleMessages<TriggerMessage>
{
    static readonly ILog Log = LogManager.GetLogger<TriggerMessageHandler>();
    readonly CustomComponent customComponent;

    public TriggerMessageHandler(CustomComponent customComponent)
    {
        this.customComponent = customComponent;
    }

public async Task Handle(TriggerMessage message, IMessageHandlerContext context)
{
    Log.Warn($"Handling {nameof(TriggerMessage)} in {nameof(TriggerMessageHandler)}");
    Log.Warn($"Custom component returned: {customComponent.GetValue()}");

    await context.SendLocal(new FollowupMessage());
    await context.Publish(new ThisHappened() { TheValueExposedByTheEvent = new PropertyValue<This>()
    {
        Value = new This
        {
            What = "Wow, it's this!"
        }
    }});
    
    await context.Publish(new ThatHappened() { TheValueExposedByTheEvent = new PropertyValue<That>()
    {
        Value = new That
        {
            What = "Wow, it's that!"
        }
    }});
}
}

#endregion