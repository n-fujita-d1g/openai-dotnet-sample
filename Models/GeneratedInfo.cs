namespace test_api;

public class GenerateInput
{
  public String Input { get; set; } = "";
  public int? Model { get; set; } = 1;
  public int? MaxTokens { get; set; } = 16;
}

public class GeneratedInfo
{
  public String Result { get; set; } = "";
}
