using CSharpSpecflowTemplate.Flows;
using CSharpSpecflowTemplate.Pages;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CSharpSpecflowTemplate.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
       LoginPage loginPage;
       LoginFlows loginFlows;
       HomePage homePage;
       BugReportPage bugReportPage;
       BugReportFlows bugReportFlows;
       BugListPage bugListPage;

            public LoginSteps()
            {
                loginPage = new LoginPage();
                loginFlows = new LoginFlows();
                homePage = new HomePage();
                bugReportPage = new BugReportPage();
                bugReportFlows = new BugReportFlows();
                bugListPage = new BugListPage();
            }

        [StepDefinition(@"eu preencho os campos com dados incorretos")]
        public void StepDefinitionEuPreenchoOsCamposComDadosIncorretos()
        {
            loginFlows.RealizarLogin("pedro123", "1234");
        }
        
        [StepDefinition(@"eu clico em Entrar")]
        public void StepDefinitionEuClicoEmEntrar()
        {
            loginPage.ClicarEmLogin();
        }
        
        [StepDefinition(@"eu preencho os campos com ""(.*)"" e (.*)")]
        public void StepDefinitionEuPreenchoOsCamposComE(string p0, int p1)
        {
            loginFlows.RealizarLogin("","123456");
        }

        [StepDefinition(@"Clico em relembrar usuario")]
        public void StepDefinitionClicoEmRelembrarUsuario()
        {
            loginPage.ClicarRelembrarUsuario();
        }
        
        [StepDefinition(@"o sistema deve exibir a mensagem de alerta ""(.*)""")]
        public void StepDefinitionOSistemaDeveExibirAMensagemDeAlerta(string p0)
        {
            loginPage.VerificaSeMensagemusuarioIncorretoEstaVisivel();
        }
 

        [StepDefinition(@"Verifico se estou no site mantis corretaemnte")]
        public void StepDefinitionVerificoSeEstouNoSiteMantisCorretaemnte()
        {
            loginPage.VerificaSeEstaNaPaginaLoginMantis();
        }

        [StepDefinition(@"eu preencho os campos com dados corretos")]
        public void StepDefinitionEuPreenchoOsCamposComDadosCorretos()
        {
            loginFlows.RealizarLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }

        [StepDefinition(@"sou redirecionado para a pagina inicial do mantis")]
        public void StepDefinitionSouRedirecionadoParaAPaginaInicialDoMantis()
        {
            loginPage.VerificaSeEstaNaPaginaInicial();
        }

    }
}
