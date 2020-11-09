using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoneCase.Domain.Entity;
using StoneCase.Domain.Response;
using StoneCase.Web.Models;
using StoneCase.Web.Util;

namespace StoneCase.Controllers
{
    [Route("api/[controller]")]
    public class CobrancaController : ControllerBase
    {
        private readonly ILogger<CobrancaController> _logger;

        public CobrancaController(ILogger<CobrancaController> logger)
        {
            _logger = logger;
        }      

        [HttpPost]
        [Route("GerarCobranca")]
        public Result GerarCobranca()
        {
            Result result = new Result();
            try
            {
                CobrancaModel cobrancaModel = new CobrancaModel();
                ClienteModel clienteModel = new ClienteModel();
                List<Cliente> todosClientes = clienteModel.BuscarClientes();
                cobrancaModel.GerarCobranca(todosClientes, DateTime.Now);
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                result.ErrorMessage = "Erro ao tentar gerar cobrancas: " + ex.Message;

            }

            return result;
        }
    }
}
