using System;
using System.Collections.Generic;
using System.Text;

namespace EntendendoOO.Models.FormaDePagamento
{
    class FormaDePagamentoPix : FormaDePagamento
    {
        public override void EfetuarPagamento()
        {
            throw new Exception("Pix nao disponivel");
        }
    }
}
