using DotNet6.DriverStandings.Api.ViewModels;
using DotNet6.DriverStandings.Application.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.DriverStandings.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaceController : ControllerBase
    {

        [HttpGet]
        public ViewModels.RaceResponseList ListRaces()
        {
            ViewModels.RaceResponseList raceResponse = new ViewModels.RaceResponseList();

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

        [HttpPost]
        public ViewModels.RaceResponse GetRaceById([FromBody] RaceRequest raceRequest)
        {
            ViewModels.RaceResponse raceResponse = new ViewModels.RaceResponse();

            try
            {
                if (raceRequest.RaceId <= 0)
                {
                    raceResponse.Message = "RaceId invalido.";
                    raceResponse.Success = false;
                    return raceResponse;
                }

                raceResponse.Item = new Application.Business.RaceBusiness().GetRaceById(new Domain.Model.Race() { RaceId = raceRequest.RaceId });
                raceResponse.Success = true;
                raceResponse.Message = "Sucesso ao recuperar a corrida.";

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
