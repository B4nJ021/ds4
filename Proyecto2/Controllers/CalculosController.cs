using Proyecto2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Proyecto2.Controllers
{
    [RoutePrefix("api/calculos")]
    public class CalculosController : ApiController
    {
        private readonly ICalculoRepository _repository;

        public CalculosController()
        {
            
            string connectionString = @"Server=localhost;Database=CalculadoraDB;Integrated Security=true;";
            

            _repository = new CalculoRepository(connectionString);
        }

        // GET: api/calculos
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetTodosLosCalculos()
        {
            try
            {
                var calculos = _repository.GetTodosLosCalculos();
                return Ok(calculos);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/calculos/sumas
        [HttpGet]
        [Route("sumas")]
        public IHttpActionResult GetSumas()
        {
            try
            {
                var sumas = _repository.GetSumas();
                return Ok(sumas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/calculos/restas
        [HttpGet]
        [Route("restas")]
        public IHttpActionResult GetRestas()
        {
            try
            {
                var restas = _repository.GetRestas();
                return Ok(restas);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/calculos/multiplicaciones
        [HttpGet]
        [Route("multiplicaciones")]
        public IHttpActionResult GetMultiplicaciones()
        {
            try
            {
                var multiplicaciones = _repository.GetMultiplicaciones();
                return Ok(multiplicaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/calculos/divisiones
        [HttpGet]
        [Route("divisiones")]
        public IHttpActionResult GetDivisiones()
        {
            try
            {
                var divisiones = _repository.GetDivisiones();
                return Ok(divisiones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
