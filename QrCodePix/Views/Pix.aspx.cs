using Pix.Entities;
using QrCodePix.Models;
using System;
using System.Web;
using System.Web.UI;

namespace QrCodePix
{
    public partial class Pix : Page
    {
        protected void btnGeraPix_Click(object sender, EventArgs e)
        {
            string diretorioQRCode = GerarExibirQrcodePix(ReceberDadosPix());

            imgPix.Src = "\\Arquivos\\" + diretorioQRCode.Split('\\')[diretorioQRCode.Split('\\').Length - 1];
        }

        private PixEntity ReceberDadosPix()
        {
            return new PixEntity()
            {
                merchantName = txtNome.Text,
                merchantCity = txtCidade.Text,
                amount = Convert.ToDouble(txtValor.Text),
                pixKey = txtChavePix.Text,
                typeKey = "E",
            };
        }

        private string GerarExibirQrcodePix(PixEntity dadosPix)
        {
            string payLoad = new PayLoad().GerarStringPayLoad(dadosPix);

            string diretorio = HttpContext.Current.Server.MapPath("~");

            string caminhoQRCode = new QrCode().GerarQRCodeLogo(payLoad, diretorio);

            return caminhoQRCode;
        }
    }
}