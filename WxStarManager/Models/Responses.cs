using System.Text.Json.Serialization;

namespace WxStarManager.Models;

public class StarInfo
{
    [JsonPropertyName("id")] public string StarId { get; set; } = "";
    [JsonPropertyName("model")] public string Model { get; set; } = "";
    [JsonPropertyName("locations")] public List<string>? Locations { get; set; } = null;
    [JsonPropertyName("zones")] public List<string>? Zones { get; set; } = null;
    [JsonPropertyName("name")] public string Name { get; set; } = "";
    [JsonPropertyName("ip_addr")] public string IpAddress { get; set; } = "";
    [JsonPropertyName("online")] public bool Online { get; set; } = false;
    [JsonPropertyName("data_port")] public int DataPort { get; set; }
    [JsonPropertyName("data_port_pri")] public int DataPortPri { get; set; }
    [JsonPropertyName("gfxpkg_lf")] public string? GfxPkgLf { get; set; } = null;
    [JsonPropertyName("gfxpkg_ldl")] public string? GfxPkgLdl { get; set; } = null;
}

public class MoonLocationResponse
{
    [JsonPropertyName("locations")] public List<string> Locations { get; set; } = new();
}

public class StarCueSettings
{
    [JsonPropertyName("cue_settings")] public List<StarCueSetting> CueSettings { get; set; } = new();
}

public class StarCueSetting
{
    [JsonPropertyName("id")] public string StarId { get; set; } = "";
    [JsonPropertyName("ldl")] public string GfxPkgLdl { get; set; } = "";
    [JsonPropertyName("lf")] public string GfxPkgLf { get; set; } = "";
}