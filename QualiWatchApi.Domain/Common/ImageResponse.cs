namespace QualiWatchApi.Domain.Common;

[Serializable]
public class ImageResponse
{
    public required string Data { get; set; }
    public int Id { get; set; }
}
