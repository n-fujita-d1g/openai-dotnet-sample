using Microsoft.AspNetCore.Mvc;
using OpenAI_API;

namespace test_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenerateController : ControllerBase
{
  private readonly ILogger<GenerateController> _logger;

  public GenerateController(ILogger<GenerateController> logger)
  {
    _logger = logger;
  }

  [HttpPost]
  public async Task<IActionResult> GetAsync([FromBody] GenerateInput input)
  {
    String model = "";
    switch (input.Model){
      case 0:
        model = "text-ada-001";
        break;
      case 1:
        model = "text-babbage-001";
        break;
      case 2:
        model = "text-curie-001";
        break;
      default:
        model = "text-davinci-003";
        break;
    }
    OpenAIAPI api = new OpenAIAPI(engine: model);
    var result = await api.Completions.CreateCompletionAsync(input.Input, input.MaxTokens, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1);

    GeneratedInfo info = new GeneratedInfo();
    info.Result = result.ToString();
    return Ok(info);
  }
}
