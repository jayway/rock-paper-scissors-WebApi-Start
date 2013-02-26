#Api Starter-Kit for ES-Lab

Web Api starter-kit, with AutoFac and IntegrationTest bootstrap. 

###Instructions

- Run VS as Administrator
- Restore Nuget Packeges
- Test run the test in IntegrationTests - GameTests
- Reference your ES lab code
- Remove/Replace ICommand with a ref to your impl
- Implement Bootstrapping in Bootstrapper.cs
- Check routing
- Later on Remove OpenGame in GameController.

###Example

```
[Test]
public void CreateGameReturnsCreated()
{
    var request = CreateRequest
        ("api/Game", MediaType.Json, HttpMethod.Post, new { name = "test", firstTo = 3 },
        new JsonMediaTypeFormatter(), "test@jayway.com", "eslab");

    Send(request, res => res.Tap(Assert.IsNotNull)
        .Tap(r => Assert.AreEqual(HttpStatusCode.Created, r.StatusCode))
        .Tap(r => Assert.IsTrue(r.Headers.Location.OriginalString.StartsWith(UrlBase + "api/Game/"))));
}


```

