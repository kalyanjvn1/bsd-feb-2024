using Microsoft.AspNetCore.Mvc;

namespace IssueTrackerAppi.Controllers;

public class WelcomeController : ControllerBase
{
    [HttpGet("/welcome")]
    public string ShowWelcome()
    {
        return "Hey! This is working";
    }
}
