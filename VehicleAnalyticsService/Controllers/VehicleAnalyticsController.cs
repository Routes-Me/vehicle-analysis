﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        public async Task<IActionResult> PostOpertionLogs(List<OperationLogsDto> operationLogsDtoList)
        {
            try
            {
                List<OperationLogs> operationLogsList = _vehicleAnalyticsRepository.InsertOpertionLogs(operationLogsDtoList);
                await _context.OperationLogs.AddRangeAsync(operationLogsList);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, CommonMessage.ExceptionMessage + ex.Message);
            }
            dynamic response = ReturnResponse.SuccessResponse(CommonMessage.OperationLogsInserted, true);
            return StatusCode((int)response.statusCode, response);
        }
    }
}
