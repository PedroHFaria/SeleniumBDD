Feature: Login

	Background: 
		Given acesso o sistema Mantis

@Automatizado
Scenario: Verifica se foi direcionado para o site mantis corretamente
	Then Verifico se estou no site mantis corretaemnte

@Automatizado
Scenario: Autentificar com dados validos
	When eu preencho os campos com dados corretos
	And Clico em relembrar usuario
	And eu clico em Entrar
	Then sou redirecionado para a pagina inicial do mantis

@Automatizado	
Scenario: Autenticar informando dados inválidos
	When eu preencho os campos com dados incorretos
	And Clico em relembrar usuario
	And eu clico em Entrar
	Then o sistema deve exibir a mensagem de alerta "Your account may be disabled or blocked or the username/password you entered is incorrect."

@Automatizado
Scenario: Autenticar sem infromar usuário
	When eu preencho os campos com "" e 123456
	And Clico em relembrar usuario
	And eu clico em Entrar
	Then o sistema deve exibir a mensagem de alerta "Your account may be disabled or blocked or the username/password you entered is incorrect."

@Automatizado
Scenario: Autenticar sem informar senha
	When eu preencho os campos com pedro e ""
	And Clico em relembrar usuario
	And eu clico em Entrar
	Then o sistema deve exibir a mensagem de alerta "Your account may be disabled or blocked or the username/password you entered is incorrect."

@Automatizado
Scenario: Autenticar sem informar usuário e senha
	When eu clico em Entrar 
	Then o sistema deve exibir a mensagem de alerta "Your account may be disabled or blocked or the username/password you entered is incorrect."