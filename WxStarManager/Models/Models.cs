using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WxStarManager.Models;

public class WxStarIn
{
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("model")] public string Model { get; set; } = "IntelliStar2";
    [JsonProperty("ip_addr")] public string IpAddress { get; set; } = "127.0.0.1";
    [JsonProperty("data_port")] public string DataPort { get; set; } = "7777";
    [JsonProperty("data_port_pri")] public string DataPortPri { get; set; } = "7787";
    [JsonProperty("gfxpkg_lf")] public string? GfxPkgLf { get; set; } = null;
    [JsonProperty("gfxpkg_ldl")] public string? GfxPkgLdl { get; set; } = null;
}

public class SystemServiceIn
{
    [JsonProperty("name")] public string? Name { get; set; }
    [JsonProperty("host")] public string Host { get; set; } = "127.0.0.1";
    [JsonProperty("pid")] public int? ProcessId { get; set; }
}

public class SystemServiceReport
{
    [JsonProperty("online")] public bool Online { get; set; } = false;
    [JsonProperty("update_timestamp")] public DateTime UpdateTimestamp { get; set; } = DateTime.Now;
    [JsonProperty("json_stats")] public string? JsonStats { get; set; } = null;
}

public class WxStarLocationUpdate
{
    [JsonProperty("locations")] public List<string> Locations { get; set; } = new();
    [JsonProperty("zones")] public List<string>? Zones { get; set; }
}