using Microsoft.AspNetCore.Mvc;

namespace ai_assistan2.Controllers;

[ApiController]
[Route("api")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;

    private readonly Copilot copilot;

    public ChatController(ILogger<ChatController> logger)
    {
        _logger = logger;
        copilot = new Copilot();
    }

    [HttpPost(Name = "Chat")]
    public async Task<ChatResponse> ChatAsync(ChatRequest request)
    {
        ChatResponse result = await copilot.ChatAsync(request.Message);
        return result;
    }
}

