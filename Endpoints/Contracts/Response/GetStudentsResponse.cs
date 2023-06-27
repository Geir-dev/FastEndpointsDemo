using FastEndpointsDemo.Data;

namespace FastEndpointsDemo.Endpoints.Contracts.Response
{
    public class GetStudentsResponse
    {
        public IEnumerable<GetStudentResponse>? Students { get; set; }
    }
}
