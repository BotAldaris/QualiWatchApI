using Google.Cloud.Vision.V1;
using QualiWatchApi.Application.Common.Interfaces.Image;
using QualiWatchApi.Domain.Common;
using System.Text.RegularExpressions;

namespace QualiWatchApi.Infrastructure.Image;

public class ImagemParaTexto : IImagemParaTexto 
{
    private ImageAnnotatorClient _client;

    private ImageAnnotatorClient GetClient()
    {
        if(_client == null)
        {
            _client = ImageAnnotatorClient.Create();
        }
        return _client;
    }

    private IReadOnlyList<EntityAnnotation> PegarMatchesNoGoogleApi(string base64)
    {
        // var client = GetClient();
        ImageAnnotatorClient client = ImageAnnotatorClient.Create();
        ImageContext context = new();
        context.LanguageHints.Add("pt");
        byte[] imagemBytes = Convert.FromBase64String(base64);
        var image = Google.Cloud.Vision.V1.Image.FromBytes(imagemBytes);
        IReadOnlyList<EntityAnnotation> annotations = client.DetectText(image, context);
        return annotations;
    }

    public List<ImageResponse> PegarValidade(string base64)
    {
        var annotations = PegarMatchesNoGoogleApi(base64);
        List<ImageResponse> result = new List<ImageResponse>();
        int id = 1;
        string pattern = @"\d{1,2}[-./\s]?\d{1,2}[-./\s]?\d{2,4}";
        foreach (EntityAnnotation annotation in annotations)
        {
            MatchCollection matches = Regex.Matches(annotation.Description, pattern);
            foreach (Match match in matches)
            {
                Console.WriteLine($"mmatch: {match.Value}");

                result.Add(new ImageResponse() { Data = match.Value, Id = id });
                id++;
            }
            Console.WriteLine(annotation.Description);
        }
        return result;
    }

    public List<ImageResponse> PegarTexto(string base64)
    {
        var annotations = PegarMatchesNoGoogleApi(base64);
        List<ImageResponse> result = new List<ImageResponse>();
        int id = 1;
        foreach (EntityAnnotation annotation in annotations)
        {
            result.Add(new ImageResponse() { Data = annotation.Description, Id = id });
            id++;
        }

        return result;
    }

}
