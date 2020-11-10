# StoneCase

Olá, 
Este é um sistema que realiza um processamento de cobrança de diversos clientes.

As API's criadas foram:

Api de Clientes:

/ (raiz) 
Exibe todos os clientes cadastrados 

Registrar(Cliente) - Insere um novo cliente
Exemplo de dados para POST:
{
  "nome": "Juliana",
  "Estado":"SP",
  "CPF": "39115227898"
}

GerarCobranca

Executa o serviço CobrancaService que realiza o cálculo de cobrança para todos os clientes, e persiste os resultados na base de dados


