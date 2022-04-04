using CSharpSpecflowTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Flows
{
    public class LoginFlows
    {

        #region Page Object and Constructor
        LoginPage loginPage;
        ResetarSenhaPage resetarSenhaPage;

        public LoginFlows()
        {
            loginPage = new LoginPage();
            resetarSenhaPage = new ResetarSenhaPage();
        }
        #endregion


        public void RealizarLogin(string username, string password)
        {
            loginPage.PreencherUsuario(username);
            loginPage.PreencherSenha(password);
        }
    }
}
