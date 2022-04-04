Feature: MyAccount

	Background: 
		Given acesso o sistema Mantis
		When eu preencho os campos com dados corretos
		And Clico em relembrar usuario
		And eu clico em Entrar
		And seleciono o menu MyAccount

@Automatizado
Scenario: Verificar se esta na pagina MyAccount
	Then Verifico se estou na pagina MyAccount

@Automatizado
Scenario: Alterar a senha do usuario
	Given preencho todos os campos para alteracao de senha
	When clico em atualizar informacoes
	Then a mensagem de usuario atualizado e exibida

@Automatizado
Scenario: Não informar o campo obrigatório confirmar senha
	Given nao preencho o campo obrigatorio confirmar senha
	When clico em atualizar informacoes
	Then a mensagem de erro referente ao campo de confirmacao de senha e exibido

@Automatizado
Scenario: Não informar o campo obrigatório email
	Given nao preencho o campo obrigatorio email
	When clico em atualizar informacoes
	Then a mensagem de erro referente ao campo de email e exibido

@Automatizado
Scenario: Alterar o Real name
	Given preencho todos os campos para alteracao de senha
	And altero a informacao do Real Name
	When clico em atualizar informacoes
	Then mensagem de alteracao do real name e exibida

|Observacao: Bug - Consigo não preencher uma senha e confirmar uma diferente|

@Automatizado
Scenario: Verificar se esta na sub pagina Profile
	Given Clico na opcao profiles
	Then Verifico se estou na subpagina Profile

@Automatizado
Scenario: Adicionar Profile sem o campo obrigatorio plataform
	Given Clico na opcao profiles
	And preencho os campos para adicao do profile menos o campo plataform
	When clico em adicionar profile
	Then Deve ser apresentado a mensagem de erro "A necessary field "Platform" was empty. Please recheck your inputs."

@Automatizado
Scenario: Adicionar Profile sem o campo obrigatorio operation System
	Given Clico na opcao profiles
	And preencho os campos para adicao do profile menos o campo Operation System
	When clico em adicionar profile
	Then Deve ser apresentado a mensagem de erro "A necessary field "Operating System" was empty. Please recheck your inputs."

@Automatizado
Scenario: Adicionar Profile sem o campo obrigatorio Version
	Given Clico na opcao profiles
	And preencho os campos para adicao do profile menos o campo Version
	When clico em adicionar profile
	Then Deve ser apresentado a mensagem de erro "A necessary field "Version" was empty. Please recheck your inputs."

@Automatizado
Scenario: Adicionar Profile
	Given Clico na opcao profiles
	And preencho os campos para adicao do profile
	When clico em adicionar profile
	Then ele deve ser apresentado na lista Select profile

@Automatizado
Scenario: Excluir sem selecionar uma opcao
	Given Clico na opcao profiles
	And Clico na opcao Delete Profile sem selecionar alguma opcao
	When Clico em submeter 
	Then E apresentado a mensagem de erro

@Automatizado
Scenario: Excluir a ocao que foi cadastrada da lista
	Given Clico na opcao profiles
	And Clico na opcao Delete Profile
	And Seleciono o Profile a ser excluirdo
	When Clico em submeter 
	Then ele não deve ser apresentado na lista Select profile

@Automatizado
Scenario: Editar Profile sem selecionar uma opcao
	Given Clico na opcao profiles
	And Clico na opcao Editar Profile
	And Nao seleciono um profile para ser editado
	When Clico em submeter 
	Then E apresentado a mensagem de erro

@Automatizado
Scenario: Editar Profile
	Given Clico na opcao profiles
	And Clico na opcao Editar Profile
	And Seleciono um profile para ser editado
	When Clico em submeter 
	And Edito o campo observacao
	Then E apresentado a tela profile novamente

@Automatizado
Scenario: Marcar um profile como default
	Given Clico na opcao profiles
	And Clico na opcao Make Default
	And Seleciono o Profile a ser Marcado
	When Clico em submeter 
	Then E apresentado a tela profile novamente

@Automatizado
Scenario: Verificar se foi direcionado para a sub pagina Preferences
	Given Clico na opcao preferences
	Then Verifico se estou na sub pagina Preferences

@Automatizado
Scenario: Atualizar informacoes de preferencia
	Given Clico na opcao preferences
	And Preencho os campos
	When Clico em atualizar preferences
	Then a mensagem de atualizacao efetuada com sucesso e exibida

@Automatizado
Scenario: Resetar informacoes de preferencia
	Given Clico na opcao preferences
	When Clico em resetar preferencias
	Then Verifico se estou na sub pagina Preferences

@Automatizado
Scenario: Verificar se foi direcionado para a sub pagina Manage Columns
	Given Clico na opcao Manage Columns
	Then Verifico se estou na sub pagina Manage Columns

@Automatizado
Scenario: Nao preenchimento a informacao obrigatoria do campo View Issues Columns
	Given Clico na opcao Manage Columns
	And nao preencho o campo obrigatorio View Issues Columns
	When clico em atualizar Colunas
	Then a mensagem de erro referente ao campo de View Issues Columns e exibido

@Automatizado
Scenario: Nao preenchimento a informacao obrigatoria do campo Print Issues Columns
	Given Clico na opcao Manage Columns
	And nao preencho o campo obrigatorio Print Issues Columns
	When clico em atualizar Colunas
	Then a mensagem de erro referente ao campo de Print Issues Columns e exibido

@Automatizado
Scenario: Nao preencher a informacao obrigatoria do campo Excel Columns
	Given Clico na opcao Manage Columns
	And nao preencho o campo obrigatorio Excel Columns
	When clico em atualizar Colunas
	Then a mensagem de erro referente ao campo de Excel Columns e exibido

@Automatizado
Scenario: Nao preencher a informacao obrigatoria do campo CSV Columns
	Given Clico na opcao Manage Columns
	And nao preencho o campo obrigatorio CSV Issues Columns
	When clico em atualizar Colunas
	Then a mensagem de erro referente ao campo de Csv Issues Columnsa e exibido

@Automatizado
Scenario: Atualizar informacoes de Manage Columns
	Given Clico na opcao Manage Columns
	And Preencho todos os campos obrigatorios
	When clico em atualizar Colunas
	Then a mensagem de atualizacao efetuada com sucesso e exibida

@Automatizado
Scenario: Resetar informacoes de Manage Columns
	Given Clico na opcao Manage Columns
	When clico em resetar configuracoes de coluna
	Then a mensagem de atualizacao efetuada com sucesso e exibida