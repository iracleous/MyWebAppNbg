namespace DomainProject.Dto;

public class ResponseApi<T>
{
    public T? Data { get; set; }
    public int Status { get; set; }
    public string? Message { get; set; }
}
