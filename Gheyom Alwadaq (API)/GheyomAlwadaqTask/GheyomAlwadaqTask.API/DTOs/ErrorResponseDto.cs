namespace GheyomAlwadaqTask.API.DTOs
{
    public class ErrorResponseDto
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public ErrorResponseDto(int status,string entityName)
        {
            Status = status;
            switch (Status)
            {
                case 200:
                    Message = "success";
                    break;
                case 302:
                    Message = $"{entityName} is already registered";
                    break;
                case 400:
                    Message = "Bad Request";
                    break;
                case 401:
                    Message = "Unauthorized";
                    break;
                case 404:
                    Message = "Not Found";
                    break;
                default:
                    Message = "An Error Occurred";
                    break;

            }
        }
    }
}
