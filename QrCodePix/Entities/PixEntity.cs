namespace Pix.Entities
{
    public class PixEntity
    {
        //Chave Pix
        public string pixKey { get; set; }
        //Tipo de Chave Pix
        public string typeKey { get; set; }
        //Descrição do pagamento
        public string description { get; set; }
        //Nome do titular da conta
        public string merchantName { get; set; }
        //Cidade do titular da conta
        public string merchantCity { get; set; }
        //ID da transação
        public string txId { get; set; }
        //Valor da transação
        public double amount { get; set; }
    }
}
