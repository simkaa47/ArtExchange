using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Edit;

public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand>
{
    private readonly IRepositoryAsync<Person> _personRepository;
    private readonly IMapper _mapper;

    public EditPersonCommandHandler(IRepositoryAsync<Person> personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task Handle(EditPersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        await _personRepository.UpdateAsync(person);
    }
}
