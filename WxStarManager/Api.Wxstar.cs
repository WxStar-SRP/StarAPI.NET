using System.Net.Http.Json;
using WxStarManager.Models;

namespace WxStarManager;

public partial class Api
{
    public async Task<StarInfo> RegisterStar(WxStarIn inModel)
    {
        var response = await _client.PostAsJsonAsync($"{Uri}/wxstar/register", inModel); 
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<StarInfo>();

        return responseContent;
    }

    public async Task<StarInfo> GetStarInfo(string starUuid)
    {
        var response = await _client.GetAsync($"{Uri}/wxstar/{starUuid}");
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadFromJsonAsync<StarInfo>();

        return responseContent;
    }

    public async Task<bool> UnregisterStar(string starUuid)
    {
        try
        {
            var response = await _client.DeleteAsync($"{Uri}/wxstar/unregister?star_uuid={starUuid}");
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (HttpRequestException e)
        {
            return false;
        }
    }

    public async Task<List<StarCueSetting>> GetStarCueSettings(WxStarModel starModel)
    {
        var starModelString = StarModelToString(starModel);

        var response = await _client.GetAsync($"{Uri}/services/cuer/star_cue_settings?star_model={starModelString}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<StarCueSettings>();

        return content.CueSettings;
    }
}