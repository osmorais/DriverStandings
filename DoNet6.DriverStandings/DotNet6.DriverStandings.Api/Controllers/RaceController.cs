using DotNet6.DriverStandings.Application.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.DriverStandings.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaceController : ControllerBase
    {

        [HttpGet]
        public ViewModels.RaceResponse ListRaces()
        {
            ViewModels.RaceResponse raceResponse = new ViewModels.RaceResponse();

            try
            {
                raceResponse.Items = new Application.Business.RaceBusiness().ListRaces();
                raceResponse.Success = true;
                raceResponse.Message = "Sucesso na listagem de corridas.";

                return raceResponse;
            }
            catch (Exception ex)
            {
                raceResponse.Message = $"Request com erro. Menssagem: {ex.Message}";
                raceResponse.Success = false;
                return raceResponse;
            }
        }
    }
}
