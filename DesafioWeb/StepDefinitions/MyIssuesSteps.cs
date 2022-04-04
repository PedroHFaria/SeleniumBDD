using CSharpSpecflowTemplate.Pages;
using System;
using TechTalk.SpecFlow;

namespace CSharpSpecflowTemplate.StepDefinitions
{
    [Binding]
    public class MyIssuesSteps
    {
        MyIssuesPage myIssuesPage;

        public MyIssuesSteps()
        {
            myIssuesPage = new MyIssuesPage();
        }

        [StepDefinition(@"Verifico se estou na pagina MyIssues")]
        public void StepDefinitionVerificoSeEstouNaPaginaMyIssues()
        {
            myIssuesPage.VerificaSeEstaNaPaginaMyIssues();    
        }
        
        [StepDefinition(@"seleciono o menu MyIssues")]
        public void StepDefinitionSelecionoOMenuMyIssues()
        {
            myIssuesPage.SelecionarMenuMyIssues();    
        }
        
        [StepDefinition(@"verifico se meu projeto foi cadastrado")]
        public void StepDefinitionVerificoSeMeuProjetoFoiCadastrado()
        {
            myIssuesPage.VerificaSeMeuProjetoEstaCadastrado();
        }
        
        [StepDefinition(@"entro no projeto")]
        public void StepDefinitionEntroNoProjeto()
        {
            myIssuesPage.SelecionarProjeto();    
        }
        
        [StepDefinition(@"clico para adicionar observacao")]
        public void StepDefinitionClicoParaAdicionarObservacao()
        {
            myIssuesPage.ClicarObservacao();    
        }
        
        [StepDefinition(@"clico em salvar observacao")]
        public void StepDefinitionClicoEmSalvarObservacao()
        {
            myIssuesPage.ClicarAdicionarObservacao();    
        }

        [StepDefinition(@"Preencho uma observacao")]
        public void StepDefinitionPreenchoUmaObservacao()
        {
            myIssuesPage.PreencherObservacao("teste");    
        }


        [StepDefinition(@"sou redirecionado a pagina do projeto")]
        public void StepDefinitionSouRedirecionadoAPaginaDoProjeto()
        {
            myIssuesPage.VerificaSeEstaNaPaginaDoProjeto();    
        }

        [StepDefinition(@"escolho um arquivo para incluir ao projeto")]
        public void StepDefinitionEscolhoUmArquivoParaIncluirAoProjeto()
        {
           // myIssuesPage.SelecionarArquivo();
        }

        [StepDefinition(@"e subo o arquivo")]
        public void StepDefinitionESuboOArquivo()
        {
            myIssuesPage.UploadArquivo();
        }

        [StepDefinition(@"o aruivo e adicionado com sucesso")]
        public void StepDefinitionOAruivoEAdicionadoComSucesso()
        {
           myIssuesPage.VerificaSeArquivoFoiSalvo();
        }

        [StepDefinition(@"clico em tirar um print")]
        public void StepDefinitionClicoEmTirarUmPrint()
        {
            myIssuesPage.ClicarPrint();
        }

        [StepDefinition(@"verifico se estou na pagina de print")]
        public void StepDefinitionVerificoSeEstouNaPaginaDePrint()
        {
            myIssuesPage.VerificaSeEstaNaPaginaPrint();
        }

        [StepDefinition(@"clico para deletar uma observacao")]
        public void StepDefinitionClicoParaDeletarUmaObservacao()
        {
            myIssuesPage.ClicarDeletarObservacao();    
        }

        [StepDefinition(@"confirmo a exclusão")]
        public void StepDefinitionConfirmoAExclusao()
        {
            myIssuesPage.ConfirmarExclusao();
        }
        [StepDefinition(@"verifico se opcoes avancadas esta senoo exibida")]
        public void StepDefinitionVerificoSeOpcoesAvancadasEstaSenooExibida()
        {
            myIssuesPage.VerificaSeOpcaoSimplesEstaSelecionada();
        }

        [StepDefinition(@"Clico em opcoes de filtro avancadas")]
        public void StepDefinitionClicoEmOpcoesDeFiltroAvancadas()
        {
            myIssuesPage.ClicarButtonFiltrosAvancados();
        }


        [StepDefinition(@"verifico se opcoes simples esta senoo exibida")]
        public void StepDefinitionVerificoSeOpcoesSimplesEstaSenooExibida()
        {
            myIssuesPage.ClicarButtonFiltrosAvancados();
            myIssuesPage.VerificaSeOpcaoAvancadaEstaSelecionada();
        }

        [StepDefinition(@"Clico em opcoes de filtro simples")]
        public void StepDefinitionClicoEmOpcoesDeFiltroSimples()
        {
            myIssuesPage.ClicarButtonFiltrosSimples();
        }

        [StepDefinition(@"Devera ser selecionado o filtro avancadas")]
        public void ThenDeveraSerSelecionadoOFiltroAvancadas()
        {
            myIssuesPage.VerificaSeOpcaoAvancadaEstaSelecionada();
        }

        [StepDefinition(@"Devera ser selecionado o filtro simples")]
        public void ThenDeveraSerSelecionadoOFiltroSimples()
        {
            myIssuesPage.VerificaSeOpcaoSimplesEstaSelecionada();   
        }

    }
}
