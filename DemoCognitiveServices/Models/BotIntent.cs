using System;
namespace DemoCognitiveServices.Models
{
    /// <summary>
    /// Bot intent.
    /// </summary>
    public enum BotIntent
    {
        [EnumDescription("Indicando problema com o produto ")]
        IndicandoProblemaComProduto,

        [EnumDescription("Intenção de Compra")]
        IntencaoCompra
    }
}
