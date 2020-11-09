using StoneCase.Domain.Entity;
using StoneCase.Web.Models;
using System.Collections.Generic;

namespace StoneCase.Web.Util
{
    public class CpfValidacao
    {
        public List<string> Erros { get; set; }
        public CpfValidacao()
        {
            Erros = new List<string>();       
        }        

        public bool CpfJaCadastrado(string cpf)
        {
            ClienteModel clienteModel = new ClienteModel();
            Cliente clienteExistente = clienteModel.BuscarClientePorCPF(cpf);

            if (clienteExistente.Id == 0)
                return true;
            else
            {
                Erros.Add("CPF Já Cadastrado");
                return false;
            }
        }

        public bool CpfValido(string cpf)
        {
            string valor = cpf.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11) {
                Erros.Add("CPF deve ter 11 dígitos");
                return false;
                }

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
            {
                Erros.Add("Numero inválido de CPF");
                return false;
            }

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    Erros.Add("Numero inválido de CPF");
                    return false;
                }
            }

            else if (numeros[9] != 11 - resultado)
            {
                Erros.Add("Numero inválido de CPF");
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    Erros.Add("Numero inválido de CPF");
                    return false;
                }

            }
            else
                if (numeros[10] != 11 - resultado)
            {
                Erros.Add("Numero inválido de CPF");
                return false;
            }
            return true;
        }
    }
}

