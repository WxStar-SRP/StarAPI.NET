using System.Net;
using WxStarManager.Models;

namespace WxStarManager;

public partial class Api
{
    private readonly HttpClient _client = new();

    private string Uri { get; }

    public Api(string uri)
    {
        Uri = uri;
    }

    /// <summary>
    /// Checks if the API connects and returns an OK response.
    /// </summary>
    /// <returns>Boolean based on the result</returns>
    public async Task<bool> IsApiUp()
    {
        try
        {
            var response = await _client.GetAsync(Uri);
            response.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException e)
        {
            return false;
        }
    }

    private string StarModelToString(WxStarModel starModel)
    {
        string starModelString = String.Empty;

        switch (starModel)
        {
            case WxStarModel.IntelliStar:
                starModelString = "i1";
                break;
            case WxStarModel.IntelliStar2:
                starModelString = "i2";
                break;
            case WxStarModel.WeatherStarXl:
                starModelString = "wsxl";
                break;
            default:
                throw new Exception("Invalid star model. Use generic models instead of specifics.");
        }

        return starModelString;
    }
}