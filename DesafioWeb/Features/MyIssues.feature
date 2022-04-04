Feature: MyIssues

		Background: 
		Given acesso o sistema Mantis
		When eu preencho os campos com dados corretos
		And Clico em relembrar usuario
		And eu clico em Entrar
		And seleciono o menu MyIssues

@Automatizado
Scenario: Verificar se esta na pagina MyIssues
	Then Verifico se estou na pagina MyIssues

@Automatizado
Scenario: Verificar se meu projeto esta sendo exibido
	Given Verifico se estou na pagina MyIssues
	When verifico se meu projeto foi cadastrado
	And entro no projeto
	Then sou redirecionado a pagina do projeto

@Automatizado
Scenario: Cadastrar uma observação para o projeto
	Given Verifico se estou na pagina MyIssues
	When verifico se meu projeto foi cadastrado
	And entro no projeto
	And clico para adicionar observacao
	And Preencho uma observacao
	And clico em salvar observacao
	Then sou redirecionado a pagina do projeto

@Automatizado
Scenario: Deletar uma observação
	Given Verifico se estou na pagina MyIssues
	When verifico se meu projeto foi cadastrado
	And entro no projeto
	And clico para deletar uma observacao
	And confirmo a exclusão
	Then sou redirecionado a pagina do projeto

@Automatizado
Scenario: Cadastrar um arquivo a esse projeto
	Given Verifico se estou na pagina MyIssues
	When verifico se meu projeto foi cadastrado
	And entro no projeto
	And escolho um arquivo para incluir ao projeto
	And e subo o arquivo
	And o aruivo e adicionado com sucesso
	Then sou redirecionado a pagina do projeto

@Automatizado
Scenario: Selecionar a opção para subir o arquivo sem o mesmo selecionado
	Given Verifico se estou na pagina MyIssues
	When verifico se meu projeto foi cadastrado
	And entro no projeto
	And e subo o arquivo
	And o aruivo e adicionado com sucesso
	Then sou redirecionado a pagina do projeto

	# Nota-se que houve um bug pois foi possível subir uma imagem sem nem seleciona-la

@Automatizado
Scenario: Verificase foi gerado um print do projeto
	Given Verifico se estou na pagina MyIssues
	When verifico se meu projeto foi cadastrado
	And entro no projeto
	And clico em tirar um print
	Then verifico se estou na pagina de print

@Automatizado
	Scenario: Verifica se filtros avancados esta selecionado
	Given Verifico se estou na pagina MyIssues
	And verifico se opcoes avancadas esta senoo exibida
	When Clico em opcoes de filtro avancadas
	Then Devera ser selecionado o filtro avancadas

@Automatizado
	Scenario: Verifica se filtros Simples esta selecionado
	Given Verifico se estou na pagina MyIssues
	And verifico se opcoes simples esta senoo exibida
	When Clico em opcoes de filtro simples
	Then Devera ser selecionado o filtro simples


