﻿using Models.Interfaces.Config;
using Models.Interfaces.Services.JsonSerialiser;
using Models.Interfaces.Services.ReadFromConfigService;
using Models.Models.Config;

namespace Application.ReadFromConfigService;

public class ReadFromConfigService : IReadFromConfigService
{
  private readonly IJsonSerialiser jsonSerialiser;
  public ReadFromConfigService(IJsonSerialiser jsonSerialiser)
  {
    this.jsonSerialiser = jsonSerialiser;
  }

  public IConfig ReadFromConfig()
  {
    // Read in the contents from the config.json file
    string basePath = Path.Combine(AppContext.BaseDirectory);
    var configFilePath = Path.Combine(basePath, "config.json");
    var configJson = File.ReadAllText(configFilePath) ?? string.Empty;

    // Deserialise the JSON to an object
    var deserialisedObject = jsonSerialiser.DeserializeObject<Config>(configJson) ?? new Config();
    return deserialisedObject;
  }
}