
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
    public class StoreBasketCommandHandler(IBasketRepository repository)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.cart;


            //TODO : save the cart to the database(use Marten upsert if exist = update 
            //TODO ; update cache

            await repository.StoreBasket(command.cart, cancellationToken);
            return new StoreBasketResult(command.cart.UserName);
        }
    }
}
