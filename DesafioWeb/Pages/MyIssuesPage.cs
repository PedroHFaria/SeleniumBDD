using CSharpSpecflowTemplate.Bases;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Pages
{
    public class MyIssuesPage : PageBase
    {
        #region Mapeamentos
        By MyIssuesMenu = By.XPath("//a[@href='/view_all_bug_page.php']");
        By Projeto = By.XPath("(//a[text()='0004474'])[1]");
        By PaginaMyIssues = By.XPath("//span[@class='floatleft'][contains(text(), 'Viewing Issues')]");
        By PaginaProjeto = By.XPath("//td[@class='form-title'][contains(text(), 'View Issue Details')]");
        By ObservacaoLink = By.XPath("//a[@href='#bugnotes'][text()='Jump to Notes']");
        By AdicionarObservacaoButton = By.XPath("//input[@value='Add Note']");
        By ObservacaoField = By.XPath("//textarea[@name='bugnote_text']");
        By EscolherArquivoButton = By.Id("ufile[]");
        By UploadButton = By.XPath("//input[@class='button'][@value='Upload File']");
        By OperacaoSucessoMensagem = By.XPath("//div[contains(text(), 'Operation successful')]");
        By PrintPagina = By.XPath("//table[@class='width100'][1]");
        By PrintButton = By.XPath("//a[@href='print_bug_page.php?bug_id=4474']");
        By DeleteObservacaoButton = By.XPath("(//input[@class='button-small'][@value='Delete'])[1]");
        By ConfirmaExclusaoButton = By.XPath("(//input[@class='button'][@value='Delete Note'])[1]");
        By FiltrosAvancadosButton = By.XPath("(//a[text()='Advanced Filters'])[1]");
        By FiltrosSimplesButton = By.XPath("(//a[text()='Simple Filters'])[1]");
        #endregion

        #region
        /*public By IdentificarProjeto(projeto)
        {
            By Projeto = By.XPath("(//a[text()='" + projeto + "'])");
        }
        */
        public void SelecionarMenuMyIssues()
        {
            Click(MyIssuesMenu);
        }

        public void SelecionarProjeto()
        {
            Click(Projeto);
        }

        public void ClicarObservacao()
        {
            Click(ObservacaoLink);
        }

        public void PreencherObservacao(string observacao)
        {
            Clear(ObservacaoField);
            SendKeys(ObservacaoField, observacao);
        }

        public void ClicarAdicionarObservacao()
        {
            Click(AdicionarObservacaoButton);
        }

        /*
        public void SelecionarArquivo()
        {
            Click(EscolherArquivoButton);
            SendKeys("..\csharpspecflowtemplate\hora_de_mudar.jpg");
        }*/

        public void UploadArquivo()
        {
            Click(UploadButton);
        }

        public void ClicarPrint()
        {
            Click(PrintButton);
        }

        public void ClicarDeletarObservacao()
        {
            Click(DeleteObservacaoButton);
        }

        public void ConfirmarExclusao()
        {
            Click(ConfirmaExclusaoButton);
        }

        public void ClicarButtonFiltrosAvancados()
        {
            Click(FiltrosAvancadosButton);
        }

        public void ClicarButtonFiltrosSimples()
        {
            Click(FiltrosSimplesButton);
        }

        #endregion
        #region
        public void VerificaSeEstaNaPaginaMyIssues()
        {
            Assert.IsTrue(driver.FindElement(PaginaMyIssues).Displayed);
        }

        public void VerificaSeMeuProjetoEstaCadastrado()
        {
            Assert.IsTrue(driver.FindElement(Projeto).Displayed);
        }

        public void VerificaSeEstaNaPaginaDoProjeto()
        {
            WaitForElement(PaginaProjeto);
            Assert.IsTrue(driver.FindElement(PaginaProjeto).Displayed);
        }

        public void VerificaSeArquivoFoiSalvo()
        {
            Assert.IsTrue(driver.FindElement(OperacaoSucessoMensagem).Displayed);
        }

        public void VerificaSeEstaNaPaginaPrint()
        {
            Assert.IsTrue(driver.FindElement(PrintPagina).Displayed);
        }

        public void VerificaSeOpcaoAvancadaEstaSelecionada()
        {
            Assert.IsTrue(driver.FindElement(FiltrosSimplesButton).Displayed);
        }

        public void VerificaSeOpcaoSimplesEstaSelecionada()
        {
            Assert.IsTrue(driver.FindElement(FiltrosAvancadosButton).Displayed);
        }
        #endregion
    }
}
