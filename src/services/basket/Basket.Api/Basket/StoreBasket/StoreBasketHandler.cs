
using Discount.Grpc;

namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart cart) : ICommand<StoreBasketResult>;

    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.cart).NotNull().WithMessage("Cart cannot be null!");
            RuleFor(x => x.cart.UserName).NotEmpty().WithMessage("Username is required!");
        }
    }
    public class StoreBasketCommandHandler
        (IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.cart;

            await DeductDiscount(command.cart, cancellationToken);
            //TODO : save the cart to the database(use Marten upsert if exist = update 
            //TODO ; update cache

            await repository.StoreBasket(command.cart, cancellationToken);
            return new StoreBasketResult(command.cart.UserName);
        }

        private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            // Communicate with Discount.Grpc and calculate lastest prices of products into sc
            foreach (var item in cart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}

