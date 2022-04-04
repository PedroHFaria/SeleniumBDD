using CSharpSpecflowTemplate.Flows;
using CSharpSpecflowTemplate.Pages;
using System;
using TechTalk.SpecFlow;

namespace CSharpSpecflowTemplate.StepDefinitions
{
    [Binding]
    public class MyAccountSteps
    {
        LoginPage loginPage;
        LoginFlows loginFlows;
        HomePage homePage;
        BugReportPage bugReportPage;
        BugReportFlows bugReportFlows;
        BugListPage bugListPage;
        MyAccountPage myAccountPage;
        MyAccountFlows myAccountFlows;

        public MyAccountSteps()
        {
            loginPage = new LoginPage();
            loginFlows = new LoginFlows();
            homePage = new HomePage();
            bugReportPage = new BugReportPage();
            bugReportFlows = new BugReportFlows();
            bugListPage = new BugListPage();
            myAccountPage = new MyAccountPage();
            myAccountFlows = new MyAccountFlows();
        }


        [StepDefinition(@"preencho todos os campos para alteracao de senha")]
        public void StepDefinitionPreenchoTodosOsCamposParaAlteracaoDeSenha()
        {
            myAccountFlows.PreencherAlteracaoSenha("123456", "123456", "email@email.com.br");
        }
        
        [StepDefinition(@"nao preencho o campo obrigatorio confirmar senha")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioConfirmarSenha()
        {
            myAccountFlows.NaoPreencherConfirmarSenha("123456", "email@email.com.br");
        }
        
        [StepDefinition(@"nao preencho o campo obrigatorio email")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioEmail()
        {
            myAccountFlows.NaoPreencherEmail("123456", "123456");
        }
        
        [StepDefinition(@"altero a informacao do Real Name")]
        public void StepDefinitionAlteroAInformacaoDoRealName()
        {
            myAccountPage.PreencherRealName();
        }

        [StepDefinition(@"seleciono o menu MyAccount")]
        public void StepDefinitionSelecionoOMenuMyAccount()
        {
            myAccountPage.ClicarMenuMyAccount();
        }
        
        [StepDefinition(@"clico em atualizar informacoes")]
        public void StepDefinitionClicoEmAtualizarInformacoes()
        {
            myAccountPage.ClicarAtualizarInformacoes();
        }
        
        [StepDefinition(@"Verifico se estou na pagina MyAccount")]
        public void StepDefinitionVerificoSeEstouNaPaginaMyAccount()
        {
            myAccountPage.VerificaSeEstaNaPaginaMyAccount();
        }
        
        [StepDefinition(@"a mensagem de usuario atualizado e exibida")]
        public void StepDefinitionAMensagemDeUsuarioAtualizadoEExibida()
        {
            myAccountPage.VerificaSeMensagemRegistroAlteradoComSucessoEstaAberta();
        }
        
        [StepDefinition(@"a mensagem de erro referente ao campo de confirmacao de senha e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDeConfirmacaoDeSenhaEExibido()
        {
            myAccountPage.VerificaSeMensagemConfirmacaoSenhaEExibida();
        }
        
        [StepDefinition(@"a mensagem de erro referente ao campo de email e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDeEmailEExibido()
        {
            myAccountPage.VeficiaSeMensagemEmailEExibida();
        }
        
        [StepDefinition(@"mensagem de alteracao do real name e exibida")]
        public void StepDefinitionMensagemDeAlteracaoDoRealNameEExibida(Table table)
        {
        }

        [StepDefinition(@"preencho os campos para adicao do profile")]
        public void StepDefinitionPreenchoOsCamposParaAdicaoDoProfile()
        {
            myAccountFlows.PreencherCamposAddProfile("Teste", "Windows12", "1");
        }

        [StepDefinition(@"clico em adicionar profile")]
        public void StepDefinitionClicoEmAdicionarProfile()
        {
            myAccountPage.ClicarParaAdicionarProfile();
        }

        [StepDefinition(@"ele deve ser apresentado na lista Select profile")]
        public void StepDefinitionEleDeveSerApresentadoNaListaSelectProfile()
        {
            myAccountPage.VerificaSeRegistroProfileEstaSendoExibido();
        }

        [StepDefinition(@"Clico na opcao profiles")]
        public void StepDefinitionClicoNaOpcaoProfiles()
        {
            myAccountPage.ClicarLinkProfile();
        }

        [StepDefinition(@"Clico na opcao Delete Profile")]
        public void StepDefinitionClicoNaOpcaoDeleteProfile()
        {
            myAccountPage.ClicarDeletarProfile();
        }

        [StepDefinition(@"Seleciono o Profile a ser excluirdo")]
        public void StepDefinitionSelecionoOProfileASerExcluirdo()
        {
            myAccountPage.ClicarOpcaoASerExcluida();
        }

        [StepDefinition(@"Clico em submeter")]
        public void StepDefinitionClicoEmSubmeter()
        {
            myAccountPage.ClicarSubmeterAcao();
        }

        [StepDefinition(@"ele não deve ser apresentado na lista Select profile")]
        public void StepDefinitionEleNaoDeveSerApresentadoNaListaSelectProfile()
        {
            
        }

        [StepDefinition(@"Clico na opcao Editar Profile")]
        public void StepDefinitionClicoNaOpcaoEditarProfile()
        {
            myAccountPage.ClicarEditarProfile();
        }

        [StepDefinition(@"Nao seleciono um profile para ser editado")]
        public void StepDefinitionNaoSelecionoUmProfileParaSerEditado()
        {
            
        }

        [StepDefinition(@"E apresentado a mensagem de erro")]
        public void StepDefinitionEApresentadoAMensagemDeErro()
        {
            myAccountPage.VerificaSeMensagemErroDeNaoSelecionarProfileEExibido();
        }

        [StepDefinition(@"Verifico se estou na subpagina Profile")]
        public void StepDefinitionVerificoSeEstouNaSubpaginaProfile()
        {
            myAccountPage.VerificaSeSubPaginaProfileEstaSendoExibida();
        }

        [StepDefinition(@"preencho os campos para adicao do profile menos o campo plataform")]
        public void StepDefinitionPreenchoOsCamposParaAdicaoDoProfileMenosOCampoPlataform()
        {
            myAccountFlows.CadastrarProfileSemCampoObrigatorioPlataform("Windows7", "1");
        }

        [StepDefinition(@"Deve ser apresentado a mensagem de erro ""(.*)""Platform""(.*)""")]
        public void StepDefinitionDeveSerApresentadoAMensagemDeErroPlatform(string p0, string p1)
        {
            myAccountPage.VerificaSemensagemDeErroCampoPlataformEExibida();
        }

        [StepDefinition(@"preencho os campos para adicao do profile menos o campo Operation System")]
        public void StepDefinitionPreenchoOsCamposParaAdicaoDoProfileMenosOCampoOperationSystem()
        {
            myAccountFlows.CadastrarProfileSemCampoObrigatorioOperationSystem("Plataform", "2");
        }

        [StepDefinition(@"Deve ser apresentado a mensagem de erro ""(.*)""Operating System""(.*)""")]
        public void StepDefinitionDeveSerApresentadoAMensagemDeErroOperatingSystem(string p0, string p1)
        {
            myAccountPage.VerificaSemensagemDeErroCampoOperationSystemEExibida();
        }

        [StepDefinition(@"preencho os campos para adicao do profile menos o campo Version")]
        public void StepDefinitionPreenchoOsCamposParaAdicaoDoProfileMenosOCampoVersion()
        {
            myAccountFlows.CadastrarProfileSemCampoObrigatorioVersion("Plat1", "Win8");
        }

        [StepDefinition(@"Deve ser apresentado a mensagem de erro ""(.*)""Version""(.*)""")]
        public void StepDefinitionDeveSerApresentadoAMensagemDeErroVersion(string p0, string p1)
        {
            myAccountPage.VerificaSemensagemDeErroCampoVersionEExibida();
        }

        [StepDefinition(@"Clico na opcao Delete Profile sem selecionar alguma opcao")]
        public void StepDefinitionClicoNaOpcaoDeleteProfileSemSelecionarAlgumaOpcao()
        {
            myAccountPage.ClicarDeletarProfile();
        }

        [StepDefinition(@"Seleciono um profile para ser editado")]
        public void StepDefinitionSelecionoUmProfileParaSerEditado()
        {
            myAccountPage.ClicarOpcaoEdicao();
        }

        [StepDefinition(@"Edito o campo observacao")]
        public void StepDefinitionEditoOCampoObservacao()
        {
            myAccountPage.PreencherAdditionalversion("teste");
        }

        [StepDefinition(@"E apresentado a tela profile novamente")]
        public void StepDefinitionEApresentadoATelaProfileNovamente()
        {
            myAccountPage.VerificaSeSubPaginaProfileEstaSendoExibida();
        }

        [StepDefinition(@"Clico na opcao Make Default")]
        public void StepDefinitionClicoNaOpcaoMakeDefault()
        {
            myAccountPage.ClicarMakeDefault();
        }

        [StepDefinition(@"Seleciono o Profile a ser Marcado")]
        public void StepDefinitionSelecionoOProfileASerMarcado()
        {
            myAccountPage.SelecionarOpcaoParaMarcar();
        }

        [StepDefinition(@"Verifico se estou na sub pagina Preferences")]
        public void StepDefinitionVerificoSeEstouNaSubPaginaPreferences()
        {
            myAccountPage.VerificaSeSubPaginaPreferencesEstaSendoExibida();
        }

        [StepDefinition(@"Verifico se estou na sub pagina Manage Columns")]
        public void StepDefinitionVerificoSeEstouNaSubPaginaManageColumns()
        {
            myAccountPage.VerificaSeSubPaginaManageColumnsEstaSendoExibida();
        }

        [StepDefinition(@"nao preencho o campo obrigatorio View Issues Columns")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioViewIssuesColumns()
        {
            myAccountFlows.AlterarManageColumnsDeixandoAInformacaoViewIssuesNaoPreenchida("", "category_id", "category_id", "category_id");
        }

        [StepDefinition(@"clico em atualizar Colunas")]
        public void StepDefinitionClicoEmAtualizarColunas()
        {
            myAccountPage.ClicarAtualizarColumns();
        }

        [StepDefinition(@"a mensagem de erro referente ao campo de View Issues Columns e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDeViewIssuesColumnsEExibido()
        {
            myAccountPage.VerificaSeMensagemViewInvalidoEstaSendoExibida();
        }

        [StepDefinition(@"nao preencho o campo obrigatorio Print Issues Columns")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioPrintIssuesColumns()
        {
            myAccountFlows.AlterarManageColumnsDeixandoAInformacaoPrintIssuesNaoPreenchida("category_id", "", "category_id", "category_id");
        }

        [StepDefinition(@"a mensagem de erro referente ao campo de Print Issues Columns e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDePrintIssuesColumnsEExibido()
        {
            myAccountPage.VerificaSeMensagemPrintInvalidoEstaSendoExibida();
        }

        [StepDefinition(@"nao preencho o campo obrigatorio Excel Columns")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioExcelColumns()
        {
            myAccountFlows.AlterarManageColumnsDeixandoAInformacaoExcelIssuesNaoPreenchida("category_id", "category_id", "category_id", "");
        }

        [StepDefinition(@"a mensagem de erro referente ao campo de Excel Columns e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDeExcelColumnsEExibido()
        {
            myAccountPage.VerificaSeMensagemExcelInvalidoEstaSendoExibida();
        }

        [StepDefinition(@"a mensagem de erro referente ao campo de View Issues Columnsa e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDeViewIssuesColumnsaEExibido()
        {
            ScenarioContext.Current.Pending();
        }

        [StepDefinition(@"Clico na opcao Manage Columns")]
        public void StepDefinitionClicoNaOpcaoManageColumns()
        {
            myAccountPage.ClicarManageLink();
        }

        [StepDefinition(@"Clico na opcao preferences")]
        public void StepDefinitionClicoNaOpcaoPreferences()
        {
            myAccountPage.ClicarPreferencesLink();
        }

        [StepDefinition(@"nao preencho o campo obrigatorio CSV Issues Columns")]
        public void StepDefinitionNaoPreenchoOCampoObrigatorioCSVIssuesColumns()
        {
            myAccountFlows.AlterarManageColumnsDeixandoAInformacaoCsvIssuesNaoPreenchida("category_id", "category_id", "", "category_id");
        }

        [StepDefinition(@"a mensagem de erro referente ao campo de Csv Issues Columnsa e exibido")]
        public void StepDefinitionAMensagemDeErroReferenteAoCampoDeCsvIssuesColumnsaEExibido()
        {
            myAccountPage.VerificaSeMensagemCsvInvalidoEstaSendoExibida();
        }

        [StepDefinition(@"Preencho todos os campos obrigatorios")]
        public void StepDefinitionPreenchoTodosOsCamposObrigatorios()
        {
            myAccountFlows.PreencherTodosOsCamposObrigatoriosDoFormularioManage("summary", "summary", "summary", "summary");
        }

        [StepDefinition(@"a mensagem de atualizacao efetuada com sucesso e exibida")]
        public void StepDefinitionAMensagemDeAtualizacaoEfetuadaComSucessoEExibida()
        {
            myAccountPage.VerificaSemensagemManageColumnsSalvaComSucessoEApresentada();
        }

        [StepDefinition(@"clico em resetar configuracoes de coluna")]
        public void StepDefinitionClicoEmResetarConfiguracoesDeColuna()
        {
            myAccountPage.ClicarResetarColumns();
        }

        [StepDefinition(@"Preencho os campos")]
        public void StepDefinitionPreenchoOsCampos()
        {
            myAccountFlows.PreencherCamposPreferences("40", "3");
        }

        [StepDefinition(@"Clico em atualizar preferences")]
        public void StepDefinitionClicoEmAtualizarPreferences()
        {
            myAccountPage.ClicarUpdatePreferences();
        }

        [StepDefinition(@"Clico em resetar preferencias")]
        public void StepDefinitionClicoEmResetarPreferencias()
        {
            myAccountPage.ClicarResetPreferences();
        }


    }
}
