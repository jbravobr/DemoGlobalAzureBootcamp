using System;
using System.Collections.Generic;

namespace DemoCognitiveServices.Models
{
    public class BotMessage
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DemoCognitiveServices.Models.BotMessage"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="text">Text.</param>
        public BotMessage(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }

    /// <summary>
    /// Bot message factory.
    /// </summary>
    public static class BotMessageFactory
    {
        /// <summary>
        /// Generates the bot messages.
        /// </summary>
        /// <returns>The bot messages.</returns>
        public static List<BotMessage> GenerateBotMessages() => new List<BotMessage>
        {
            new BotMessage(new Random().Next(1,100),"As experiências acumuladas demonstram que o acompanhamento das preferências de consumo representa uma abertura para a melhoria da gestão inovadora da qual fazemos parte."),
            new BotMessage(new Random().Next(1,100),"A prática cotidiana prova que a valorização de fatores subjetivos possibilita uma melhor visão global do sistema de participação geral."),
            new BotMessage(new Random().Next(1,100),"Neste sentido, a consolidação das estruturas garante a contribuição de um grupo importante na determinação dos níveis de motivação departamental."),
            new BotMessage(new Random().Next(1,100),"Pensando mais a longo prazo, a crescente influência da mídia obstaculiza a apreciação da importância do investimento em reciclagem técnica."),
            new BotMessage(new Random().Next(1,100),"Podemos já vislumbrar o modo pelo qual a hegemonia do ambiente político nos obriga à análise do sistema de formação de quadros que corresponde às necessidades."),
            new BotMessage(new Random().Next(1,100),"No mundo atual, a execução dos pontos do programa exige a precisão e a definição do remanejamento dos quadros funcionais."),
            new BotMessage(new Random().Next(1,100),"Acima de tudo, é fundamental ressaltar que o entendimento das metas propostas aponta para a melhoria dos métodos utilizados na avaliação de resultados."),
            new BotMessage(new Random().Next(1,100),"Caros amigos, o julgamento imparcial das eventualidades acarreta um processo de reformulação e modernização do levantamento das variáveis envolvidas."),
            new BotMessage(new Random().Next(1,100),"Todas estas questões, devidamente ponderadas, levantam dúvidas sobre se o aumento do diálogo entre os diferentes setores produtivos não pode mais se dissociar das diversas correntes de pensamento."),
            new BotMessage(new Random().Next(1,100),"Por outro lado, a hegemonia do ambiente político é uma das consequências do retorno esperado a longo prazo.")
        };
    }
}
