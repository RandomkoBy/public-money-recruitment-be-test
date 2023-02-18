﻿using Models.ViewModels;
using VacationRental.Api.Repository;

namespace VacationRental.Api.Operations.RentalsOperations;

public sealed class RentalCreateOperation : IRentalCreateOperation
{
    private readonly IRentalRepository _rentalRepository;

    public RentalCreateOperation(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    public Task<ResourceIdViewModel> ExecuteAsync(RentalBindingModel model)
    {
        return DoExecuteAsync(model);
    }

    private async Task<ResourceIdViewModel> DoExecuteAsync(RentalBindingModel model)
    {
        var rentals = await _rentalRepository.GetAll();
        var key = new ResourceIdViewModel { Id = rentals.Count() + 1 };

        _rentalRepository.Create(key.Id, new RentalViewModel
        {
            Id = key.Id,
            Units = model.Units
        });

        return key;
    }
}
