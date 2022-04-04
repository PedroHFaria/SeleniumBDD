using CSharpSpecflowTemplate.Flows;
using CSharpSpecflowTemplate.Pages;
using System;
using TechTalk.SpecFlow;

namespace CSharpSpecflowTemplate.StepDefinitions
{
    [Binding]
    public class ResetarSenhaSteps
    {
            LoginPage loginPage;
            LoginFlows loginFlows;
            HomePage homePage;
            BugReportPage bugReportPage;
            BugReportFlows bugReportFlows;
            BugListPage bugListPage;
            ResetarSenhaPage resetarSenhaPage;

            public ResetarSenhaSteps()
            {
                loginPage = new LoginPage();
                loginFlows = new LoginFlows();
                homePage = new HomePage();
                bugReportPage = new BugReportPage();
                bugReportFlows = new BugReportFlows();
                bugListPage = new BugListPage();
                resetarSenhaPage = new ResetarSenhaPage();
            }

        [StepDefinition(@"seleciono a opcao resetar senha")]
        public void StepDefinitionSelecionoAOpcaoResetarSenha()
        {
            loginPage.ClicarResetarSenha();
        }
        
        [StepDefinition(@"Preencho um usuario invalido")]
        public void StepDefinitionPreenchoUmUsuarioInvalido()
        {
            resetarSenhaPage.PreencherUsuarioReset("Teste");
        }
        
        [StepDefinition(@"preencho um email invalido")]
        public void StepDefinitionPreenchoUmEmailInvalido()
        {
            resetarSenhaPage.PreencherEmailReset("teste@teste.com.br");
        }
        
        [StepDefinition(@"Nao preencho nenhuma informacao")]
        public void StepDefinitionNaoPreenchoNenhumaInformacao()
        {
            resetarSenhaPage.PreencherUsuarioReset("");
            resetarSenhaPage.PreencherEmailReset("");
        }
        
        [StepDefinition(@"seleciono submeter")]
        public void StepDefinitionSelecionoSubmeter()
        {
            resetarSenhaPage.ClicarSubmeter();
        }

        [StepDefinition(@"deve me redirecionar para uma página nova contendo informações sobre o erro usuario invalido")]
        public void StepDefinitionDeveMeRedirecionarParaUmaPaginaNovaContendoInformacoesSobreOErroUsuarioInvalido()
        {
            resetarSenhaPage.VerificaSePaginaErroUsuarioInvalidoEstaAberta();
        }

        [StepDefinition(@"deve me redirecionar para uma página nova contendo informações sobre o erro usuario nao preenchido")]
        public void StepDefinitionDeveMeRedirecionarParaUmaPaginaNovaContendoInformacoesSobreOErroUsuarioNaoPreenchido()
        {
            resetarSenhaPage.VerificaSePaginaErroEstaAberta();
        }

        [StepDefinition(@"Verifico se estou na pagina Resetar Senha")]
        public void StepDefinitionVerificoSeEstouNaPaginaResetarSenha()
        {
            resetarSenhaPage.VerificaSeTelaResetarSenhaEstaAberta();
        }


    }
}
