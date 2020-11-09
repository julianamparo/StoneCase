using StoneCase.Domain.Entity;
using StoneCase.Domain.Response;
using StoneCase.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneCase.Web.Models
{
    public class ClienteModel
    {
        public Cliente BuscarCliente(int id)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            return clienteDAO.BuscarCliente(id);
        }
        public Cliente BuscarClientePorCPF(string cpf)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            return clienteDAO.BuscarClientePorCPF(cpf);
        }

        public List<Cliente> BuscarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            return clienteDAO.BuscarClientes();
        }

        public void InserirCliente(Cliente cliente)
        {
            try
            {
                ClienteDAO clienteDAO = new ClienteDAO();
                clienteDAO.InserirCliente(cliente);
            }
            catch (Exception ex)
            {
            }
        }
    }

}
