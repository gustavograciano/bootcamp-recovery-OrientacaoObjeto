using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoOO.Models.FormaDePagamento
{
    class FormaDePagamentoDinheiro : FormaDePagamento
    {
        public override void EfetuarPagamento()
        {
            Console.WriteLine("Pagamento efetuado com Dinheiro");
        }
    }
}
