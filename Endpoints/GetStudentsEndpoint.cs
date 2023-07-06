using EndpointsDemo.Data;
using EndpointsDemo.Endpoints.Contracts.Requests;
using EndpointsDemo.Endpoints.Contracts.Response;
using FastEndpoints;

namespace EndpointsDemo.Endpoints
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
            Get("students");
            Description(d => d
            .WithName("Students")
            .Produces<GetStudentsResponse>(200, "application/json")
            .ProducesProblemFE<InternalErrorResponse>(500));
            Options(options => options.WithTags("Students"));
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetStudentRequest req, CancellationToken ct)
        {
            var student = studentDbContext.Students;

            var response = new GetStudentsResponse
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
