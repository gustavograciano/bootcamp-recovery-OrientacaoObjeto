using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoOO.Models.FormaDePagamento
{
    class FormaDePagamentoCreditoImpl : FormaDePagamento, IFormaDePagamentoCartao
    {
        public override void EfetuarPagamento()
        {
            IsCartaoComSaldo();
            Console.WriteLine("Pagamento efetuado com Cartão De Credito");
        }

        public void IsCartaoComSaldo()
        {
            Console.WriteLine("Cartao com Saldo");
        }
    }
}
