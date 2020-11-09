using StoneCase.Domain.Entity;
using StoneCase.Repository.DAL;
using StoneCase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneCase.Web.Models
{
    public class CobrancaModel
    {
        public void GerarCobranca(List<Cliente> clientes, DateTime dataVencimento)
        {
            CobrancaService cobrancaService = new CobrancaService();
            CobrancaDAO cobrancaDAO = new CobrancaDAO();

            foreach (Cliente cliente in clientes)
            {
                Cobranca cobranca = new Cobranca();
                cobranca.ClienteId = cliente.Id;
                cobranca.DataVencimento = dataVencimento;
                cobranca.Valor = cobrancaService.CalculoConsumo(cliente.CPF);

                cobrancaDAO.InserirCobranca(cobranca);

            }
            
        }
    }
}
