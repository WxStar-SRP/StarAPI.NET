using System;
using System.Threading.Tasks;
using NuGet.Frameworks;
using NUnit.Framework;
using WxStarManager.Models;

namespace UnitTests;

public class Tests
{
    private WxStarManager.Api _api;
    
    [SetUp]
    public void Setup()
    {
        _api = new WxStarManager.Api("http://wxstar-data.cascadia.local:8000");
    }

    [Test]
    public async Task TestApiUp()
    {
        bool apiStatus = await _api.IsApiUp();

        if (apiStatus)
        {
            Assert.Pass();
            return;
        }
        
        Assert.Fail();
    }

    [Test]
    public async Task TestGetMoonLocations()
    {
        var locations = await _api.GetMoonLocations(WxStarModel.IntelliStar2);
        
        Console.WriteLine($"Endpoint returned with {locations.Count} location(s).");
        
        Assert.Pass();
    }
}