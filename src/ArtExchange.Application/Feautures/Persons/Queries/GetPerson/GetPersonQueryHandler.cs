using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities.Administration;
using MapsterMapper;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Queries.GetPerson
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonVm>
    {
        private readonly IRepositoryAsync<Person> _personRepository;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IRepositoryAsync<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<PersonVm> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.Id);
            return _mapper.Map<PersonVm>(person);
        }
    }
}
