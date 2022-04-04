using CSharpSpecflowTemplate.Bases;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Pages
{
    public class BugReportPage : PageBase
    {
        #region Mapeamento
        By ReportIssueTitle = By.XPath("//form[@name='report_bug_form']");
        By categoryCombo = By.Name("category_id");
        By summaryText = By.Name("summary");
        By descriptionText = By.Name("description");
        By submitReportButton = By.XPath("//input[@value='Submit Report']");
        By MensagemCategoriaNaoPreenchido = By.XPath("//p[@class='center'][contains(text(), 'Category')]");
        By MensagemSumaryNaoPreenchido = By.XPath("//p[@class='center'][contains(text(), 'Summary')]");
        By MensagemDescricaoNaoPreenchida = By.XPath("//p[@class='center'][contains(text(), 'Description')]");
        By SeveridadeCheckList = By.XPath("//select[@name='severity']");
        By MensagemSucessoText = By.XPath("//div[@align='center'][text()='Operation successful.']");

        public By SeverityList(string severity)
        {
            return By.XPath("//select[@name='severity']//option[text()='"+ severity +"']");
        }

        #endregion


        public void EscolherCategoriaAleatoria()
        {
            ComboBoxSelectRandomValue(categoryCombo);
        }

        public void SelecionarSeverety(string severity)
        {
            Click(SeverityList(severity));
        }

        public void PreencherSumario(string sumario)
        {
            SendKeys(summaryText, sumario);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(descriptionText, descricao);
        }

        public void ClicarEmReportar()
        {
            ScrollToElementJavaScript(submitReportButton);
            Click(submitReportButton);
        }

        public void ClicarSeveridade()
        {
            Click(SeveridadeCheckList);
        }

        #region Validações
        public void VerificaSeMensagemCategoriaEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemCategoriaNaoPreenchido).Displayed);
        }

        public void VerificaSeMensagemSumarioEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemSumaryNaoPreenchido).Displayed);
        }

        public void VerificaSeMensagemDescricaoEstaAberta()
        {
            Assert.IsTrue(driver.FindElement(MensagemDescricaoNaoPreenchida).Displayed);
        }

        public void VerificaSePaginaReportIssueEstaAberta()
        {
            Assert.IsTrue(driver.FindElement(ReportIssueTitle).Displayed);
        }

        public void VerificaSeMensagemReportCadastradoComSucessoEExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemSucessoText).Displayed);
        }
        #endregion
    }
}
