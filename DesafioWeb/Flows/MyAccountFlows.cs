using CSharpSpecflowTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Flows
{
    public class MyAccountFlows
    {
        #region construtores
        MyAccountPage myAccountPage;

        public MyAccountFlows()
        {
            myAccountPage = new MyAccountPage();
        }

        #endregion

        public void PreencherAlteracaoSenha(string senha, string confirmacaoSenha, string email)
        {
            myAccountPage.PreencherSenha(senha);
            myAccountPage.PreencherConfirmarSenha(confirmacaoSenha);
            myAccountPage.PreencherEmail(email);
        }

        public void NaoPreencherConfirmarSenha(string senha, string email)
        {
            myAccountPage.PreencherSenha(senha);
            myAccountPage.PreencherEmail(email);
        }

        public void NaoPreencherEmail(string senha, string confirmacaoSenha)
        {
            myAccountPage.PreencherSenha(senha);
            myAccountPage.PreencherConfirmarSenha(confirmacaoSenha);
            myAccountPage.LimparCampoEmail(); 
        }

        public void PreencherCamposAddProfile(string plataform, string operationSystem, string osversion)
        {
            myAccountPage.PreencherCampoPlataform(plataform);
            myAccountPage.PreencherOperationSystem(operationSystem);
            myAccountPage.PreencherOsVersion(osversion);
         //   myAccountPage.PreencherAdditionalversion(additionalDescription);
        }

        public void CadastrarProfileSemCampoObrigatorioPlataform(string operationSystem, string osVersion)
        {
            myAccountPage.PreencherOperationSystem(operationSystem);
            myAccountPage.PreencherOsVersion(osVersion);
        }

        public void CadastrarProfileSemCampoObrigatorioOperationSystem(string plataform, string osVersion)
        {
            myAccountPage.PreencherCampoPlataform(plataform);
            myAccountPage.PreencherOsVersion(osVersion);
        }

        public void CadastrarProfileSemCampoObrigatorioVersion(string operationSystem, string plataform)
        {
            myAccountPage.PreencherOperationSystem(operationSystem);
            myAccountPage.PreencherCampoPlataform(plataform);
        }

        public void AlterarManageColumnsDeixandoAInformacaoViewIssuesNaoPreenchida(string view, string print, string csv, string excel)
        {
            myAccountPage.PreencherViewColumns(view);
            myAccountPage.PreencherPrintIssueColumns(print);
            myAccountPage.PreencherCsvColumns(csv);
            myAccountPage.PreencherExcelColumns(excel);
        }

        public void AlterarManageColumnsDeixandoAInformacaoPrintIssuesNaoPreenchida(string view, string print, string csv, string excel)
        {
            myAccountPage.PreencherViewColumns(view);
            myAccountPage.PreencherPrintIssueColumns(print);
            myAccountPage.PreencherCsvColumns(csv);
            myAccountPage.PreencherExcelColumns(excel);
        }

        public void AlterarManageColumnsDeixandoAInformacaoCsvIssuesNaoPreenchida(string view, string print, string csv, string excel)
        {
            myAccountPage.PreencherViewColumns(view);
            myAccountPage.PreencherPrintIssueColumns(print);
            myAccountPage.PreencherCsvColumns(csv);
            myAccountPage.PreencherExcelColumns(excel);
        }

        public void AlterarManageColumnsDeixandoAInformacaoExcelIssuesNaoPreenchida(string view, string print, string csv, string excel)
        {
            myAccountPage.PreencherViewColumns(view);
            myAccountPage.PreencherPrintIssueColumns(print);
            myAccountPage.PreencherCsvColumns(csv);
            myAccountPage.PreencherExcelColumns(excel);
        }

        public void PreencherTodosOsCamposObrigatoriosDoFormularioManage(string view, string print, string csv, string excel)
        {
            myAccountPage.PreencherViewColumns(view);
            myAccountPage.PreencherPrintIssueColumns(print);
            myAccountPage.PreencherCsvColumns(csv);
            myAccountPage.PreencherExcelColumns(excel);
        }

        public void PreencherCamposPreferences(string refresh, string redirect)
        {
            myAccountPage.PreencherCampoRefreshDelay(refresh);
            myAccountPage.PreencherCampoRefreshDelay(redirect);
        }
    }
}
