using CSharpSpecflowTemplate.Flows;
using CSharpSpecflowTemplate.Helpers;
using CSharpSpecflowTemplate.Pages;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CSharpSpecflowTemplate.StepDefinitions
{
    [Binding]
    public class CadastroDeBugsSteps
    {

        LoginPage loginPage;
        LoginFlows loginFlows;
        HomePage homePage;
        BugReportPage bugReportPage;
        BugReportFlows bugReportFlows;
        BugListPage bugListPage;

        public CadastroDeBugsSteps()
        {
            loginPage = new LoginPage();
            loginFlows = new LoginFlows();
            homePage = new HomePage();
            bugReportPage = new BugReportPage();
            bugReportFlows = new BugReportFlows();
            bugListPage = new BugListPage();
        }

        [StepDefinition(@"acesso o sistema Mantis")]
        public void AcessoSistemaMantis()
        {
            DriverFactory.INSTANCE.Navigate().GoToUrl(ConfigurationManager.AppSettings["base_url"]);
        }

        [StepDefinition(@"efetuo login no sistema Mantis")]
        public void EfetuoLoginNoSistemaMantis()
        {
            loginFlows.RealizarLogin(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            homePage.VerificarMenuMinhaVisao();
        }
        
        [StepDefinition(@"acesso a interface de Cadastro de Bugs")]
        public void AcessoAInterfaceDeCadastroDeBugs()
        {
            homePage.ClicarMenuReportarTarefa();

        }
        
        [StepDefinition(@"preencho todos os campos obrigatórios do Cadastro de Bugs")]
        public void PreenchoTodosOsCamposObrigatorios()
        {
            bugReportFlows.PreencherCamposObrigatoriosBug();
        }
        
        [StepDefinition(@"salvo o novo registro")]
        public void SalvoONovoRegistro()
        {
            bugReportPage.ClicarEmReportar();
        }
        
        [StepDefinition(@"uma mensagem de sucesso de cadastro deverá ser apresentada")]
        public void UmaMensagemDeSucessoDeCadastroDeveraSerApresentada()
        {
            bugListPage.VerificarCadastroBugSucesso();
        }

        [StepDefinition(@"eu preencho os campos com pedro e ""(.*)""")]
        public void StepDefinitionEuPreenchoOsCamposComPedroE(string p0)
        {
            loginFlows.RealizarLogin("pedro","");
        }

        [StepDefinition(@"Nao preencho o campo obrigatorio Categoria no Cadastro de Bugs")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioCategoriaNoCadastroDeBugs()
        {
            bugReportFlows.NaoPreenchimentoCampoCategoria();
        }

        [StepDefinition(@"uma mensagem de erro referente a informacao obrigatoria CATEGORIA e exibida")]
        public void StepDefinitionUmaMensagemDeErroReferenteAInformacaoObrigatoriaCATEGORIAEExibida()
        {
            bugReportPage.VerificaSeMensagemCategoriaEstaSendoExibida();
        }

        [StepDefinition(@"Nao preencho campo obrigatorio Sumario no Cadastro de Bugs")]
        public void StepDefinitionNaoPreenchoCampoObrigatorioSumarioNoCadastroDeBugs()
        {
            bugReportFlows.NaoPreenchimentoCampoSumario();
        }

        [StepDefinition(@"uma mensagem de erro referente a informacao obrigatorio Sumario e exibido")]
        public void StepDefinitionUmaMensagemDeErroReferenteAInformacaoObrigatorioSumarioEExibido()
        {
            bugReportPage.VerificaSeMensagemSumarioEstaSendoExibida();
        }

        [StepDefinition(@"Nao preencho campo obrigatorio Descricao no Cadastro de Bugs")]
        public void StepDefinitionNaoPreenchoCampoObrigatorioDescricaoNoCadastroDeBugs()
        {
            bugReportFlows.NaoPreenchimentoDescricao();
        }

        [StepDefinition(@"uma mensagem de erro referente a informacao obrigatorio Descricao e exibido")]
        public void StepDefinitionUmaMensagemDeErroReferenteAInformacaoObrigatorioDescricaoEExibido()
        {
            bugReportPage.VerificaSeMensagemDescricaoEstaAberta();
        }

        [StepDefinition(@"seleciono uma opcao de feature")]
        public void StepDefinitionSelecionoUmaOpcaoDeFeature(string severity)
        {
            bugReportPage.SelecionarSeverety(severity);
        }

        [StepDefinition(@"Verifico se estou na pagina Report issue")]
        public void StepDefinitionVerificoSeEstouNaPaginaReportIssue()
        {
            bugReportPage.VerificaSePaginaReportIssueEstaAberta();
        }

        [StepDefinition(@"Clico na lista de severidade")]
        public void StepDefinitionClicoNaListaDeSeveridade()
        {
            bugReportPage.ClicarSeveridade();
        }

        [StepDefinition(@"o report com a severidade feature e cadastrado")]
        public void StepDefinitionOReportComASeveridadeFeatureECadastrado(string severity)
        {
            bugReportFlows.VerificarSeReportComSeveridadeInformada(severity);
        }

        [StepDefinition(@"o registro com a feature informada e salvo")]
        public void StepDefinitionORegistroComAFeatureInformadaESalvo(string severity)
        {
            bugReportFlows.VerificarSeReportComSeveridadeInformada(severity);
        }

        [StepDefinition(@"eu prencho os campos obrigatorios com ""(.*)""")]
        public void StepDefinitionEuPrenchoOsCamposObrigatoriosCom()
        {
            bugReportFlows.PreencherCamposObrigatoriosBug();

        }

        [StepDefinition(@"seleciono o severity ""(.*)""")]
        public void StepDefinitionSelecionoOSeverity(string severity)
        {
            if (severity.Equals("feature"))
            {
                bugReportPage.SelecionarSeverety("feature");
            }
            else if (severity.Equals("trivial"))
            {
                bugReportPage.SelecionarSeverety("trivial");
            }
            else if (severity.Equals("text"))
            {
                bugReportPage.SelecionarSeverety("text");
            }
            else if (severity.Equals("tweak"))
            {
                bugReportPage.SelecionarSeverety("tweak");
            }
            else if (severity.Equals("minor"))
            {
                bugReportPage.SelecionarSeverety("minor");
            }
        }
    }

}
