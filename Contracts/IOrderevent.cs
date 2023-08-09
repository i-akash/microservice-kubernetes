namespace Contracts;

public interface IOrderevent
{
    public Guid OrderId { get; set; }
}

public class Orderevent : IOrderevent
{
    public Guid OrderId { get; set; }
}