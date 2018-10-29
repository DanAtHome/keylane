using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TriangleAnalyzer.API.Models;
using TriangleAnalyzer.Service.Interfaces;

namespace TriangleAnalyzer.API.Controllers
{
    public class TriangleController : ApiController
    {
        ITriangleService _triangleService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TriangleController(ITriangleService service)
        {
            _triangleService = service;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_triangleService.GetAll());
            }
            catch (Exception ex)
            {
                log.Error("Internal error getting all triangles", ex);
                   return InternalServerError(ex);               
            }
        }

        [HttpPost]
        public IHttpActionResult Analyse([FromBody]Triangle triangle)
        {
            try
            {
                var triangleType = _triangleService.Analyze(new int[] { triangle.A, triangle.B, triangle.C });

                return Ok(triangleType);
            }
            catch(Exception ex)
            {
                if(ex is ArgumentException)
                {
                    log.Warn("Error validating triangle", ex);
                    return BadRequest(ex.Message);
                }
                else
                {
                    log.Error("Error analyzing triangle", ex);
                    return InternalServerError(ex);
                }
            }
        }
    }
}
