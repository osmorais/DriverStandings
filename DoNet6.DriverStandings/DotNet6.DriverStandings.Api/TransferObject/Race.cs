using DotNet6.DriverStandings.Domain.Model;
using System.Reflection;
using static DotNet6.DriverStandings.Api.TransferObjects._Base;

namespace DotNet6.DriverStandings.Api.TransferObjects
{
    public class RaceRequest : _BaseRequest
    {
        public int RaceId { get; set; }
    }
    public class RaceResponse : _BaseResponse
    {
    }

    public class RaceResponseList : _BaseListResponse<Race>
    {
    }
}
