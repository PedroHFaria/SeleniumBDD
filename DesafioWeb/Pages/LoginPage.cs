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
    public class LoginPage : PageBase
    {

        #region Mapeamento
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.XPath("//input[@value='Login']");
        By RelembrarUsuarioCheckList = By.XPath("//input[@name='perm_login']");
        By UsarioOuSenhaIncorretoText = By.XPath("//font[@color='red'][text()='Your account may be disabled or blocked or the username/password you entered is incorrect.']");
        By LoginPagina = By.XPath("//img[@alt='MantisBT']");
        By ResetarButton = By.XPath("//a[@href='lost_pwd_page.php']");
        By PaginaInicialPage = By.XPath("//td[@class='login-info-left']//span[text()='templateautomacao']");
        #endregion

        #region Actions

        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        public void ClicarResetarSenha()
        {
            Click(ResetarButton);
        }

        public void ClicarRelembrarUsuario()
        {
            Thread.Sleep(1000);
            Click(RelembrarUsuarioCheckList);
        }
        #endregion

        #region validações
        public void VerificaSeMensagemusuarioIncorretoEstaVisivel()
        {
            Assert.IsTrue(driver.FindElement(UsarioOuSenhaIncorretoText).Displayed);
        }

        public void VerificaSeEstaNaPaginaLoginMantis()
        {
            Assert.IsTrue(driver.FindElement(LoginPagina).Displayed);
        }

        public void VerificaSeEstaNaPaginaInicial()
        {
            Assert.IsTrue(driver.FindElement(PaginaInicialPage).Displayed);
        }
        #endregion

    }
}
