using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

[ApiController]
[Route("[controller]")]
public class TestThreadController : Controller
{

    [HttpGet("sync-wait")]
    public async Task<IActionResult> AsyncWait()
    {
        var task1 = Task.Delay(2000);
        var task2 = Task.Delay(2000);

        await Task.WhenAll(task1, task2);

        return Ok("Finished");
    }


    /**
     * Sync => Thread ينتظر ويحجز
     * Async => ينتظر لكن لا يحجز thread
    */


    [HttpGet("async-wait")]
    public async Task<IActionResult> Cpu()
    {
        // Thread Started
        await Task.Delay(2000);
        await Task.Delay(2000);
        // Thread End
        return Ok("Finished");
    }
}
