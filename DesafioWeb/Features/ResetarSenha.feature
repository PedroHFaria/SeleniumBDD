Feature: ResetarSenha

	Background: 
		Given acesso o sistema Mantis
		And seleciono a opcao resetar senha

@Automatizado
Scenario: Verificar se esta na pagina Resetar Senha
	Then Verifico se estou na pagina Resetar Senha

@Automatizado
Scenario: Preencher email invalido
	Given Preencho um usuario invalido
	And preencho um email invalido
	When seleciono submeter
	Then deve me redirecionar para uma página nova contendo informações sobre o erro usuario invalido

@Automatizado
Scenario: Não preenchimento de nenhuma informação
	Given Nao preencho nenhuma informacao
	When seleciono submeter
	Then deve me redirecionar para uma página nova contendo informações sobre o erro usuario nao preenchido