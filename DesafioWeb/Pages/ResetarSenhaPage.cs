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
   public class ResetarSenhaPage : PageBase
    {
        #region mapeamentos
        By EsqueceuSenhaForm = By.XPath("//form[@name='lost_password_form']");
        By UsuarioField = By.XPath("//input[@name='username']");
        By EmailField = By.XPath("//input[@name='email']");
        By SubmitButton = By.XPath("//input[@value='Submit']");
        By PáginaErroPage = By.XPath("//td[@class='form-title'][text()= 'APPLICATION ERROR #1200']");
        By PaginaErroUsuarioInvalido = By.XPath("//td[@class='form-title'][text()= 'APPLICATION ERROR #1903']");
        #endregion

        public void PreencherUsuarioReset(string usuario)
        {
            SendKeys(UsuarioField, usuario);
        }

        public void PreencherEmailReset(string email)
        {
            SendKeys(EmailField, email);
        }

        public void ClicarSubmeter()
        {
            Click(SubmitButton);
        }

        #region validacoes
        public void VerificaSePaginaErroEstaAberta()
        {
            Assert.IsTrue(driver.FindElement(PáginaErroPage).Displayed);
        }

        public void VerificaSePaginaErroUsuarioInvalidoEstaAberta()
        {
            Assert.IsTrue(driver.FindElement(PaginaErroUsuarioInvalido).Displayed);
        }

        public void VerificaSeTelaResetarSenhaEstaAberta()
        {
            Assert.IsTrue(driver.FindElement(EsqueceuSenhaForm).Displayed);
        }
        #endregion
    }
}
