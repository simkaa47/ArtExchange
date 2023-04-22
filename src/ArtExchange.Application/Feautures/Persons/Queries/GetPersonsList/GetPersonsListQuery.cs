using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Queries.GetPersonsList
{
    public class GetPersonsListQuery:IRequest<List<PersonVm>>
    {
    }
}
