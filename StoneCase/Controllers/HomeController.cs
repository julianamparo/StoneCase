using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoneCase.Domain.Entity;
using StoneCase.Domain.Response;
using StoneCase.Models;
using StoneCase.Web.Models;
using StoneCase.Web.Util;

namespace StoneCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Popular lista inicial de todos os clientes
        public IActionResult Index()
        {
            ClienteModel clienteModel = new ClienteModel();

            ViewBag.ListaClientes = clienteModel.BuscarClientes();

            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        //Registro de um novo cliente
        [HttpPost]
        public IActionResult Registrar(Cliente cliente)
        {
            Result result = new Result();
            try
            {
                CpfValidacao cpfValidacao = new CpfValidacao();

                ClienteModel clienteModel = new ClienteModel();
                if ((cpfValidacao.CpfJaCadastrado(cliente.CPF)) && (cpfValidacao.CpfValido(cliente.CPF)))
                {
                    clienteModel.InserirCliente(cliente);
                    result.Sucesso = true;
                    result.ErrorMessage = string.Empty;
                    return Ok();
                }
                else
                {
                    result.Sucesso = false;
                    result.ErrorMessage = cpfValidacao.Erros.FirstOrDefault();
                    return BadRequest(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                result.ErrorMessage = "Erro ao tentar inserir cliente: " + ex.Message;
                return BadRequest(result.ErrorMessage);
            }
        }

        //Método que gera o valor de cobranca para todos os clientes cadastrados a partir do serviço de Cobrança
        [HttpGet]
        public IActionResult GerarCobranca()
        {
            Result result = new Result();
            CobrancaModel cobrancaModel = new CobrancaModel();

            DateTime dataTeste = DateTime.Now.AddDays(30);
            try
            {
                ClienteModel clienteModel = new ClienteModel();
                List<Cliente> todosClientes = clienteModel.BuscarClientes();
                cobrancaModel.GerarCobranca(todosClientes, DateTime.Parse(dataTeste.ToShortDateString()));
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                result.ErrorMessage = "Erro ao tentar gerar cobrancas: " + ex.Message;

            }
            ViewBag.Relatorio = cobrancaModel.GerarRelatorioCobranca();

            return Ok();
        }
    }
}

