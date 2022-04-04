using CSharpSpecflowTemplate.Bases;
using CSharpSpecflowTemplate.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpSpecflowTemplate.Pages
{
    public class MyAccountPage : PageBase
    {
        #region mapeamentos
        By MyAccountLink = By.XPath("//a[@href='/account_page.php']");
        By PasswordField = By.XPath("//input[@name='password']");
        By ConfirmPasswordField = By.XPath("//input[@name='password_confirm']");
        By EmailField = By.XPath("//input[@name='email']");
        By RealNameField = By.XPath("//input[@name='realname']");
        By UpdateUserButton = By.XPath("//input[@class='button']");
        By TituloPagina = By.XPath("//td[@class='form-title'][contains(text(), 'Edit Account')]");
        By DadosAlteradosSucessoText = By.XPath("//div[contains(text(), 'Operation')]");
        By MensagemErroCOnfirmarSenha = By.XPath("//p[@class='center'][text()='Password does not match verification.']");
        By MensagemErroEmail = By.XPath("//p[@class='center'][text()='Invalid e-mail address.']");
        #endregion

        #region Mapeamentos Sub Pagina Profile
        By ProfilesLink = By.XPath("//a[text()='Profiles']");
        By AddprofileTitle= By.XPath("//td[@class='form-title']");
        By PlataformField = By.XPath("//input[@name='platform']");
        By OperationSystemField = By.XPath("//input[@name='os']");
        By OsversionField = By.XPath("//input[@name='os_build']");
        By AdditionaDescriptionField = By.XPath("//textarea[@name='description']");
        By AddprofileButton = By.XPath("//input[@value='Add Profile']");
        By SelectProfileList = By.XPath("//select[@name='profile_id']");
        By EditProfileRadioButton = By.XPath("//input[@value='edit']");
        By MakeDefaultRadioButton = By.XPath("//input[@value='make_default']");
        By DeleteProfileRadioButton = By.XPath("//input[@value='delete']");
        By SubmitButton = By.XPath("//input[@value='Submit']");
        By RegistroAddProfile = By.XPath("//select[@name='profile_id']//option[text()='Teste Windows12 1'][1]");
        By ErroNaoSelecionarProfileText = By.XPath("//p[@class='center'][contains(text(), 'Select Profile')]");
        By OpcaoMakeDefaultOption = By.XPath("//select[@name='profile_id']//option[contains(text(), 'Desktop  Windows 10')]");
        By MensagemErroSemCampoPlatformText = By.XPath("//p[contains(text(), 'Platform')]");
        By MensagemErroSemCampoOperationSystem = By.XPath("//p[contains(text(), 'Operating System')]");
        By MensagemErroSemCmpoVersiontext = By.XPath("//p[contains(text(), 'Version')]");
        By OpcaoEdicaoProfileList = By.XPath("//select[@name='profile_id']//option[text()='ds df dfs']");
        #endregion

        #region Mapeamento Sub Pagina Preferences
        By PreferencesForm = By.XPath("//form[@action='account_prefs_update.php']");
        By PreferencesLink = By.XPath("//a[text()='Preferences']");
        By RefreshDelayField = By.XPath("//input[@name='refresh_delay']");
        By RedirectDelayField = By.XPath("//input[@name='redirect_delay']");
        By UpdatePreferencesButton = By.XPath("//input[@value='Update Prefs']");
        By ResetPreferencesButton = By.XPath("//input[@value='Reset Prefs']");
        #endregion

        #region mapeamento Sub Pagina Manage Columns
        By ManageColumnsForm = By.XPath("//form[@name='manage-columns-form']");
        By ManageColumnsLink = By.XPath("//a[text()='Manage Columns']");
        By ViewIssueColumnsTextArea = By.XPath("//textarea[@name='view_issues_columns']");
        By PrintissuesColumnstextArea = By.XPath("//textarea[@name='print_issues_columns']");
        By CsvColumnsTextArea = By.XPath("//textarea[@name='csv_columns']");
        By ExcelColumnsTextArea = By.XPath("//textarea[@name='excel_columns']");
        By updateColumnsButton = By.XPath("//input[@name='update_columns_for_current_project']");
        By ResetColumnsButtom = By.XPath("//input[@value='Reset Columns Configuration']");
        By MensagemErroFaltandoCampoViewText = By.XPath("//p[@class='center'][contains(text(), 'view_issues')]");
        By MensagemErroFaltandoCampoPrintText = By.XPath("//p[@class='center'][contains(text(), 'print_issues')]");
        By MensagemErroFaltandoCampoCsvText = By.XPath("//p[@class='center'][contains(text(), 'csv')]");
        By MensagemErroFaltandoCampoExcelText = By.XPath("//p[@class='center'][contains(text(), 'excel')]");
        By MensagemManageColumnsSucessoText = By.XPath("//div[@align='center'][text()='Operation successful.']");
        #endregion

        public void PreencherSenha(string senha)
        {
            Clear(PasswordField);
            SendKeys(PasswordField, senha);
        }

        public void PreencherConfirmarSenha(string confirmacaoSenha)
        {
            Clear(ConfirmPasswordField);//textarea[@name='description']
            SendKeys(ConfirmPasswordField, confirmacaoSenha);
        }

        public void PreencherEmail(string email)
        {
            Clear(EmailField);
            SendKeys(EmailField, email);
        }

        public void PreencherRealName()
        {
            Clear(RealNameField);
            string realName = "RealName - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            SendKeys(RealNameField, realName);
        }

        public void ClicarAtualizarInformacoes()
        {
            Click(UpdateUserButton);
        }

        public void ClicarMenuMyAccount()
        {
            Click(MyAccountLink);
        }

        public void LimparCampoEmail()
        {
            Clear(EmailField);
        }

        public void PreencherCampoPlataform(string plataform)
        {
            SendKeys(PlataformField, plataform);
        }

        public void PreencherOperationSystem(string operationSystem)
        {
            SendKeys(OperationSystemField, operationSystem);
        }

        public void PreencherOsVersion(string osversion)
        {
            SendKeys(OsversionField, osversion);
        }

        public void PreencherAdditionalversion(string additionalDescription)
        {
            SendKeys(AdditionaDescriptionField, additionalDescription);
        }

        public void ClicarParaAdicionarProfile()
        {
            Click(AddprofileButton);
        }

        public void ClicarEditarProfile()
        {
            Click(EditProfileRadioButton);
        }

        public void ClicarMakeDefault()
        {
            Click(MakeDefaultRadioButton);
        }

        public void ClicarDeletarProfile()
        {
            Click(DeleteProfileRadioButton);
        }

        public void ClicarLinkProfile()
        {
            Click(ProfilesLink);
        }

        public void ClicarOpcaoASerExcluida()
        {
            Click(RegistroAddProfile);
        }

        public void ClicarSubmeterAcao()
        {
            Click(SubmitButton);
        }

        public void SelecionarOpcaoParaMarcar()
        {
            Click(OpcaoMakeDefaultOption);
        }

        public void ClicarManageLink()
        {
            Click(ManageColumnsLink);
        }

        public void ClicarPreferencesLink()
        {
            Click(PreferencesLink);
        }

        public void ClicarOpcaoEdicao()
        {
            Click(OpcaoEdicaoProfileList);
        }

        public void PreencherViewColumns(string view)
        {
            Clear(ViewIssueColumnsTextArea);
            SendKeys(ViewIssueColumnsTextArea, view);
        }

        public void PreencherPrintIssueColumns(string print)
        {
            Clear(PrintissuesColumnstextArea);
            SendKeys(PrintissuesColumnstextArea, print);
        }

        public void PreencherCsvColumns(string csv)
        {
            Clear(CsvColumnsTextArea);
            SendKeys(CsvColumnsTextArea, csv);
        }

        public void PreencherExcelColumns(string excel)
        {
            Clear(ExcelColumnsTextArea);
            SendKeys(ExcelColumnsTextArea, excel);
        }

        public void ClicarAtualizarColumns()
        {
            Click(updateColumnsButton);
        }

        public void ClicarResetarColumns()
        {
            Click(ResetColumnsButtom);
        }

        public void PreencherCampoRefreshDelay(string refresh)
        {
            Clear(RefreshDelayField);
            SendKeys(RefreshDelayField, refresh);
        }

        public void PreencherCamporedirectDelay(string redirect)
        {
            Clear(RedirectDelayField);
            SendKeys(RedirectDelayField, redirect);
        }

        public void ClicarUpdatePreferences()
        {
            Click(UpdatePreferencesButton);
        }

        public void ClicarResetPreferences()
        {
            Click(ResetPreferencesButton);
        }

        #region Verificacoes
        public void VerificaSeMensagemRegistroAlteradoComSucessoEstaAberta()
        {
            Assert.IsTrue(driver.FindElement(DadosAlteradosSucessoText).Displayed);
        }

        public void VerificaSeEstaNaPaginaMyAccount()
        {
            Assert.IsTrue(driver.FindElement(TituloPagina).Displayed);
        }

        public void VerificaSeMensagemConfirmacaoSenhaEExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroCOnfirmarSenha).Displayed);
        }

        public void VeficiaSeMensagemEmailEExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroEmail).Displayed);
        }

        public void VerificaSeRegistroProfileEstaSendoExibido()
        {
            Assert.IsTrue(driver.FindElement(RegistroAddProfile).Displayed);
        }

        public void VerificaSeMensagemErroDeNaoSelecionarProfileEExibido()
        {
            Assert.IsTrue(driver.FindElement(ErroNaoSelecionarProfileText).Displayed);
        }

        public void VerificaSeSubPaginaProfileEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(AddprofileTitle).Displayed);
        }

        public void VerificaSeSubPaginaPreferencesEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(PreferencesForm).Displayed);
        }

        public void VerificaSeSubPaginaManageColumnsEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(ManageColumnsForm).Displayed);
        }

        public void VerificaSemensagemDeErroCampoPlataformEExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroSemCampoPlatformText).Displayed);
        }

        public void VerificaSemensagemDeErroCampoOperationSystemEExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroSemCampoOperationSystem).Displayed);
        }

        public void VerificaSemensagemDeErroCampoVersionEExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroSemCmpoVersiontext).Displayed);
        }

        public void VerificaSeMensagemViewInvalidoEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroFaltandoCampoViewText).Displayed);
        }

        public void VerificaSeMensagemPrintInvalidoEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroFaltandoCampoPrintText).Displayed);
        }

        public void VerificaSeMensagemCsvInvalidoEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroFaltandoCampoCsvText).Displayed);
        }

        public void VerificaSeMensagemExcelInvalidoEstaSendoExibida()
        {
            Assert.IsTrue(driver.FindElement(MensagemErroFaltandoCampoExcelText).Displayed);
        }

        public void VerificaSemensagemManageColumnsSalvaComSucessoEApresentada()
        {
            Assert.IsTrue(driver.FindElement(MensagemManageColumnsSucessoText).Displayed);
        }
        #endregion

    }
}