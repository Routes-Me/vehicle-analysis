using System;
using System.Threading.Tasks;
using VehicleAnalyticsService.Abstraction;
using VehicleAnalyticsService.Models;
using VehicleAnalyticsService.Models.DBModels;
using VehicleAnalyticsService.Models.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehicleAnalyticsService.Controllers
{
    [Route("api")]
    [ApiController]
    public class VehicleAnalyticsController : ControllerBase
    {
        private readonly IVehicleAnalyticsRepository _vehicleAnalyticsRepository;
        private readonly VehicleAnalyticsServiceContext _context;
        public VehicleAnalyticsController(IVehicleAnalyticsRepository vehicleAnalyticsRepository, VehicleAnalyticsServiceContext context)
        {
            _vehicleAnalyticsRepository = vehicleAnalyticsRepository;
            _context = context;
        }

        [HttpPost]
        [Route("operations/devices/logs")]
        public async Task<IActionResult> PostDeviceRunningTimes(OperationLogsDto operationLogsDto)
        {
            try
            {
                OperationLogs operationLogs = _vehicleAnalyticsRepository.InsertOpertionLogs(operationLogsDto);
                await _context.OperationLogs.AddAsync(operationLogs);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                dynamic errorResponse = ReturnResponse.ExceptionResponse(ex);
                return StatusCode(StatusCodes.Status400BadRequest, errorResponse.message);
            }
            dynamic response = ReturnResponse.SuccessResponse(CommonMessage.OperationLogsInserted, true);
            return StatusCode((int)response.statusCode, response);
        }
    }
}
