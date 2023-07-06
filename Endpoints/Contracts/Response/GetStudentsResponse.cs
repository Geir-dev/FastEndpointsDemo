using EndpointsDemo.Data;

namespace EndpointsDemo.Endpoints.Contracts.Response
{
    public class GetStudentsResponse
    {
        public IEnumerable<GetStudentResponse>? Students { get; set; }
    }
}
