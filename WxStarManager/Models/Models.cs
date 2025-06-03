using System.Text.Json.Serialization;

namespace WxStarManager.Models;

public class WxStarIn
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("model")] public WxStarModel Model { get; set; } = WxStarModel.NoneSpecified;
    [JsonPropertyName("ip_addr")] public string IpAddress { get; set; } = "127.0.0.1";
    [JsonPropertyName("data_port")] public int DataPort { get; set; } = 7777;
    [JsonPropertyName("data_port_pri")] public int DataPortPri { get; set; } = 7788;
    [JsonPropertyName("gfxpkg_lf")] public string? GfxPkgLf { get; set; } = null;
    [JsonPropertyName("gfxpkg_ldl")] public string? GfxPkgLdl { get; set; } = null;
}

public class SystemServiceIn
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("host")] public string Host { get; set; } = "127.0.0.1";
    [JsonPropertyName("pid")] public int? ProcessId { get; set; }
}

public class SystemServiceReport
{
    [JsonPropertyName("online")] public bool Online { get; set; } = false;
    [JsonPropertyName("update_timestamp")] public DateTime UpdateTimestamp { get; set; } = DateTime.Now;
    [JsonPropertyName("json_stats")] public string? JsonStats { get; set; } = null;
}

public class WxStarLocationUpdate
{
    [JsonPropertyName("locations")] public List<string> Locations { get; set; } = new();
    [JsonPropertyName("zones")] public List<string>? Zones { get; set; }
}