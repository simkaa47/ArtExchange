using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Queries.GetPerson
{
    public class GetPersonQuery:IRequest<PersonVm>
    {
        public long Id { get; set; }
    }
}
