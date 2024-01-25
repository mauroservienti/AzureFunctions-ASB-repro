using NServiceBus;

public class ThisHappened : IEvent, IMyEvent<This>
{
    public PropertyValue<This> TheValueExposedByTheEvent { get; set; }
}

public class ThatHappened : IEvent, IMyEvent<That>
{
    public PropertyValue<That> TheValueExposedByTheEvent { get; set; }
}

public interface IMyEvent<T> where T : class
{
    PropertyValue<T> TheValueExposedByTheEvent { get; set; }
}

public class PropertyValue<T> where T : class
{
    public T Value { get; set; }
}

public class This
{
    public string What { get; set; }
}

public class That
{
    public string What { get; set; }
}