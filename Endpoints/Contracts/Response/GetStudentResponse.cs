using FastEndpointsDemo.Data;
using System.Text.Json.Serialization;

namespace FastEndpointsDemo.Endpoints.Contracts.Response
{
    public class GetStudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public int Age { get; set; }
        public DateTimeOffset Created { get; set; }
    }

    
}
