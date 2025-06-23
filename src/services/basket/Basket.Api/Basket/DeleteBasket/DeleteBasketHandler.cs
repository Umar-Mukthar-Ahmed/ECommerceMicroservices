﻿namespace Basket.Api.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required!");
        }
    }
    public class DeleteBasketHandler(IBasketRepository repository) 
        : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            //TODO : delete the cart from the database
            //TODO : delete the cart from the cache
            await repository.DeleteBasket(command.UserName, cancellationToken);
            return new DeleteBasketResult(true);
        }
    }
   
}
