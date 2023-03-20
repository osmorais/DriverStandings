using DotNet6.DriverStandings.Api.TransferObjects;
using DotNet6.DriverStandings.Application.Business.Interface;
using DotNet6.DriverStandings.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.DriverStandings.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RaceController : ControllerBase
    {

        [HttpGet]
        public TransferObjects.RaceResponseList ListRaces()
        {
            TransferObjects.RaceResponseList raceResponse = new TransferObjects.RaceResponseList();

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
        public TransferObjects.RaceResponse GetRaceById([FromBody] RaceRequest raceRequest)
        {
            TransferObjects.RaceResponse raceResponse = new TransferObjects.RaceResponse();

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

        [HttpPost]
        public TransferObjects.RaceResponse UploadRaceByFile([FromBody] RaceRequest raceRequest)
        {
            TransferObjects.RaceResponse raceResponse = new TransferObjects.RaceResponse();

            try
            {
                if (raceRequest.Item == null || string.IsNullOrEmpty(raceRequest.Item.ToString()))
                {
                    raceResponse.Message = "Objeto invalido.";
                    raceResponse.Success = false;
                    return raceResponse;
                }

                raceResponse.Item = new Application.Business.RaceBusiness().UploadRace(raceRequest.Item.ToString());
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

        [HttpPost]
        public TransferObjects.RaceResponse DeleteRace([FromBody] RaceRequest raceRequest)
        {
            TransferObjects.RaceResponse raceResponse = new TransferObjects.RaceResponse();

            try
            {
                if (raceRequest.RaceId <= 0)
                {
                    raceResponse.Message = "RaceId invalido.";
                    raceResponse.Success = false;
                    return raceResponse;
                }

                new Application.Business.RaceBusiness().DeleteRaceById(new Domain.Model.Race() { RaceId = raceRequest.RaceId });
                raceResponse.Success = true;
                raceResponse.Message = "Sucesso ao deletar a corrida.";

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
