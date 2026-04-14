using MySolution.Application.Queries;
using MySolution.Domain.Orders;
using Moq;
using System.Reflection;
public class GetOrderByIdhandlerTests
{
    [Fact]
     public async Task Return_Order_When_Order_Exists()
    {
        Guid id = Guid.NewGuid();
         var order = new Order(id,520,"new description");
        var mockRepo =new Mock<IOrderRepository>();
        var handler = new GetOrderByIdHandler(mockRepo.Object);

        mockRepo.Setup(r=> r.GetByIdAsync(id)).ReturnsAsync(order);

        var query = new GetOrderByIdQuery(order.Id);
        var result = await handler.Handle(query,default);

        Assert.Equal(order.Id,result.Id);
        

    }

    public async Task Return_Exception_When_Order_NotExists()
    {
        Guid id = Guid.NewGuid();
         var order = new Order(id,520,"new description");
        var mockRepo =new Mock<IOrderRepository>();
        var handler = new GetOrderByIdHandler(mockRepo.Object);

        mockRepo.Setup(r=> r.GetByIdAsync(id)).ReturnsAsync(order);

        var query = new GetOrderByIdQuery(order.Id);
        var result = await handler.Handle(query,default);

        Assert.NotEqual(order.Id,result.Id);
        

    }
}