using MySolution.Application.Command;
using MySolution.Domain.Orders;
using Moq;
namespace MySolution.Tests;

public class UpdateDescriptionOrderHandlerTests
{
    [Fact]
    public async Task Should_update_description_when_Order_Exists()
    {
        var id = Guid.NewGuid();
        var order = new Order(id,520,"new description");
        var mockRepo = new Mock<IOrderRepository>();

        mockRepo.Setup(r=> r.GetByIdAsync(order.Id))
        .ReturnsAsync(order);

        var handler = new UpdateDescriptionOrderHandler(mockRepo.Object);
        var command = new UpdateDescriptionOrderCommand("new description",order.Id);

        var result = await handler.Handle(command,default);

        Assert.Equal("new description",result);
    }
}
