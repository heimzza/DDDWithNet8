namespace HR.LeaveManagement.Application.Responses;

public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }

    public BaseCommandResponse(int id, bool success, string message, List<string> errors = null)
    {
        this.Id = id;
        this.Success = success;
        this.Message = message;
        this.Errors = errors ?? new List<string>();
    }

    public BaseCommandResponse()
    {
        
    }
}
