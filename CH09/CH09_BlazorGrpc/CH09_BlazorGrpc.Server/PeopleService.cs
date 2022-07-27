namespace CH09_BlazorGrpc.Server;

using Grpc.Core;
using CH09_BlazorGrpc.Client;

public class PeopleService : Person.PersonBase
{
    public override async Task<PeopleResponse> GetPeople(PeopleRequest request, ServerCallContext context)
    {
        PeopleResponse response = new PeopleResponse();
        response.People.Add(new PersonResponse { Name = "Person One" });
        response.People.Add(new PersonResponse { Name = "Person Two" });
        response.People.Add(new PersonResponse { Name = "Person Three" });
        return response;
    }
}