using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Add
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, long>
    {
        private readonly IRepositoryAsync<Person> _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IRepositoryAsync<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = _mapper.Map<Person>(request);  
            var result = await _personRepository.AddAsync(person);
            return result.Id;
        }
    }
}
