using Pix.Entities;
using Pix.Enum;
using QrCodePix.Models;

namespace QrCodePix
{
    public class PayLoad
    {
        //Método responsável por gerar a string do PayLoad
        public string GerarStringPayLoad(PixEntity dadosPix)
        {
            string payLoad = CalcularValores(IdBrCodeEnum.Id_Payload_Format_Indicator, ValorBrCodeEnum.Valor_Payload_Format_Indicator)
                           + CalcularValores(IdBrCodeEnum.Id_Merchant_Account_Information, GetMerchantAccountInformation(dadosPix.pixKey))
                           + CalcularValores(IdBrCodeEnum.Id_Merchant_Category_Code, ValorBrCodeEnum.Valor_Merchant_Category_Code)
                           + CalcularValores(IdBrCodeEnum.Id_Transaction_Currency, ValorBrCodeEnum.Valor_Transaction_Currency)
                           + CalcularValores(IdBrCodeEnum.Id_Transaction_Amount, dadosPix.amount.ToString("F2").Replace(",", "."))
                           + CalcularValores(IdBrCodeEnum.Id_Country_Code, ValorBrCodeEnum.Valor_Country_Code)
                           + CalcularValores(IdBrCodeEnum.Id_Merchant_Name, dadosPix.merchantName)
                           + CalcularValores(IdBrCodeEnum.Id_Merchant_City, dadosPix.merchantCity)
                           + CalcularValores(IdBrCodeEnum.Id_Additional_Field_Template, GetAdditionalFieldTemplate())
                           + IdBrCodeEnum.Id_CRC16 + TamanhoCRC16Enum.CRC16;

            return payLoad + new CRC16().CalcularCRC16(payLoad);
        }

        //Método responsável por retornar valor completo de um objeto do payload
        public string CalcularValores(string id, string valor)
        {
            string tamanho = valor.Length.ToString().PadLeft(2, '0');

            return id + tamanho + valor;
        }

        //Método responsável por retornar os valores do campo adicional
        public string GetAdditionalFieldTemplate()
        {
            string txId = CalcularValores(IdBrCodeEnum.Id_Additional_Field_Template_TxId, "***");

            return txId;
        }

        //Método responsável por retornar os valores completos da informação da conta
        public string GetMerchantAccountInformation(string chavePix)
        {
            string gui = CalcularValores(IdBrCodeEnum.Id_Merchant_Account_Infomation_Gui, "br.gov.bcb.pix");
            string pixKey = CalcularValores(IdBrCodeEnum.Id_Merchant_Account_Infomation_Key, chavePix);
            string description = CalcularValores(IdBrCodeEnum.Id_Merchant_Account_Information_Description, "Pix");

            return gui + pixKey + description;
        }
    }
}