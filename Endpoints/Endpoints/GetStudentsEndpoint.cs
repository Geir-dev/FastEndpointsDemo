using FastEndpoints;
using FastEndpointsDemo.Data;
using FastEndpointsDemo.Endpoints.Contracts.Requests;
using FastEndpointsDemo.Endpoints.Contracts.Response;

namespace FastEndpointsDemo.Endpoints.Endpoints
{
    public class GetStudentsEndpoint : Endpoint<GetStudentRequest, GetStudentsResponse> 
    {
        private readonly StudentDbContext studentDbContext;

        public GetStudentsEndpoint(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }
        public override void Configure()
        {
            Get("/student");
            Description(d => d
            .Produces<GetStudentsResponse>(200, "application/json")
            .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public async Task HandleAsync(GetStudentsResponse response, CancellationToken ct)
        {
            var student = studentDbContext.Students;

           response = new GetStudentsResponse
            {
                Students = student.Select(x => new GetStudentResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    LastName = x.LastName,
                    Email = x.Email,
                    Phone = x.Phone,
                    Age = x.Age,
                    Created = x.Created,
                })
            };

            await SendAsync(response, cancellation: ct);
 
        }
    }
}
