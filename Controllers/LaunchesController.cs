using System.Collections.Generic;
using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Mvc;
using SpaceX.Models;
using SpaceX.Models.Launch;
using SpaceX.Models.Launches;

namespace SpaceX.Controllers;

[ApiController]
[Route("[controller]")]
public class LaunchesController : ControllerBase
{
    private readonly ILogger<LaunchesController> _logger;
    private readonly IGraphQLClient _client;
    private readonly IMapper _mapper;

    public LaunchesController(ILogger<LaunchesController> logger, IGraphQLClient client, IMapper mapper)
    {
        _logger = logger;
        _client = client;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetLaunches")]
    public async Task<ActionResult<LaunchesResultModel>> Get([FromQuery] LaunchesPaginationModel model)
    {
        int offset = (model.Page - 1) * model.Per_Page;

        int limit = model.Per_Page + offset;

        var query = new GraphQLRequest
        {
            Query = @"
                query LaunchesQuery($limit: Int, $offset: Int) {
                    launches(limit: $limit, offset: $offset) {
                        id,
                        mission_name
                    }
                }
            ",
            Variables = new { limit, offset }
        };

        var response = await _client.SendQueryAsync<LaunchesDataModel>(query);

        var result = response.Data.Launches.Select(x => _mapper.Map<LaunchesResultModel>(x));

        return Ok(result);
    }

    [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "id" })]
    [HttpGet("{id}", Name = "GetLaunch")]
    public async Task<ActionResult<LaunchResultModel>> Get(string id)
    {
        var query = new GraphQLRequest
        {
            Query = @"
                query LaunchQuery($launchId: ID!) {
                  launch(id: $launchId) {
                    id
                    launch_date_local
                    mission_name
                    rocket {
                      rocket_name
                      rocket {
                        first_flight
                        success_rate_pct
                      }
                    }
                  }
                }
            ",
            Variables = new { launchId = id  }
        };

        var response = await _client.SendQueryAsync<LaunchDataModel>(query);

        if (response.Data.Launch == null)
        {
            return NotFound();
        }

        var result = _mapper.Map<LaunchResultModel>(response.Data.Launch);

        return Ok(result);
    }
}