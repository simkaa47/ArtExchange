using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Queries.GetPersonsList
{
    public class GetPersonsListQueryHandler : IRequestHandler<GetPersonsListQuery, List<PersonVm>>
    {
        private readonly IRepositoryAsync<Person> _personRepository;
        private readonly IMapper _mapper;

        public GetPersonsListQueryHandler(IRepositoryAsync<Person> personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async  Task<List<PersonVm>> Handle(GetPersonsListQuery request, CancellationToken cancellationToken)
        {
            var persons = await _personRepository.ListAllAsync();
            return _mapper.Map<List<PersonVm>>(persons);
        }
    }
}
