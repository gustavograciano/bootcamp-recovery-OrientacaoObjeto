using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoOO.Models.FormaDePagamento
{
    class FormaDePagamentoVAImpl : FormaDePagamento, IFormaDePagamentoCartao
    {
        public override void EfetuarPagamento()
        {
            IsCartaoComSaldo();
            Console.WriteLine("Pagamento efetuado com Vale Alimentacao");
        }

        public void IsCartaoComSaldo()
        {
            Console.WriteLine("Cartao com Saldo");
        }
    }
}
