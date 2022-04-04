Feature: Cadastro de Bugs
	
	Background: 
		Given acesso o sistema Mantis
		When eu preencho os campos com dados corretos
		And Clico em relembrar usuario
		And eu clico em Entrar
		And acesso a interface de Cadastro de Bugs

@Automatizado
Scenario: Verificar se esta na pagina Report Issue
	Then Verifico se estou na pagina Report issue

@Automatizado
Scenario: Cadastrar novo bug
	Given preencho todos os campos obrigatórios do Cadastro de Bugs
	When salvo o novo registro
	Then uma mensagem de sucesso de cadastro deverá ser apresentada

@Automatizado
Scenario: Cadastrar um bug sem informacao obrigatoria Categoria
	Given Nao preencho o campo obrigatorio Categoria no Cadastro de Bugs
	When salvo o novo registro
	Then uma mensagem de erro referente a informacao obrigatoria CATEGORIA e exibida

@Automatizado
Scenario: Cadastrar um bug sem informacao obrigatoria Sumario
	Given Nao preencho campo obrigatorio Sumario no Cadastro de Bugs
	When salvo o novo registro
	Then uma mensagem de erro referente a informacao obrigatorio Sumario e exibido

@Automatizado
Scenario: Cadastrar um bug sem informacao obrigatoria Descricao
	Given Nao preencho campo obrigatorio Descricao no Cadastro de Bugs
	When salvo o novo registro
	Then uma mensagem de erro referente a informacao obrigatorio Descricao e exibido

@Automatizado
Scenario Outline: Preencher um bug com informacoes distintas
	Given preencho todos os campos obrigatórios do Cadastro de Bugs
	And seleciono o severity "<severity>"
	When salvo o novo registro
	Then uma mensagem de sucesso de cadastro deverá ser apresentada

	Examples: severitys corretos
	| severity	 |
	| feature    |
	| trivial    |
	| text       |
	| tweak      |
	| minor      |