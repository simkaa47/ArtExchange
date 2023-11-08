using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Application.Contracts.Security;
using ArtExchange.Domain.Entities.Administration;
using MapsterMapper;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Edit;

public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand>
{
    private readonly IRepositoryAsync<Person> _personRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public EditPersonCommandHandler(IRepositoryAsync<Person> personRepository, IMapper mapper, 
        IPasswordHasher passwordHasher)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task Handle(EditPersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        person.Password = _passwordHasher.GetHash(request.Password);
        await _personRepository.UpdateAsync(person);
    }
}
