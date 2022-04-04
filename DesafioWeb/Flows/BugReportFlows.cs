using CSharpSpecflowTemplate.Helpers;
using CSharpSpecflowTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Flows
{
    public class BugReportFlows
    {

        #region Page Object and Constructor
        BugReportPage bugReportPage;

        public BugReportFlows()
        {
            bugReportPage = new BugReportPage();
        }
        #endregion


        public void PreencherCamposObrigatoriosBug()
        {
            #region Valores
            string sumario = "Sumário - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            string descricao = "Descrição - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            #endregion

            bugReportPage.EscolherCategoriaAleatoria();
            bugReportPage.PreencherSumario(sumario);
            bugReportPage.PreencherDescricao(descricao);
        }


        public void NaoPreenchimentoCampoCategoria()
        {
            #region Valores
            string sumario = "Sumário - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            string descricao = "Descrição - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            #endregion

            bugReportPage.PreencherSumario(sumario);
            bugReportPage.PreencherDescricao(descricao);
        }

        public void NaoPreenchimentoCampoSumario()
        {
            #region Valores
            string sumario = "Sumário - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            string descricao = "Descrição - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            #endregion

            bugReportPage.EscolherCategoriaAleatoria();
            bugReportPage.PreencherDescricao(descricao);
            bugReportPage.EscolherCategoriaAleatoria();
        }

        public void NaoPreenchimentoDescricao()
        {
            #region Valores
            string sumario = "Sumário - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            string descricao = "Descrição - " + GeneralHelpers.RetornaStringComCaracteresRandomicos(10);
            #endregion

            bugReportPage.EscolherCategoriaAleatoria();
            bugReportPage.PreencherSumario(sumario);
            bugReportPage.EscolherCategoriaAleatoria();
        }

        public void VerificarSeReportComSeveridadeInformada(string Severity)
        {
            if (Severity.Equals("feature"))
            {
                bugReportPage.ClicarSeveridade();
            }
            else if (Severity.Equals("trivial"))
            {
                bugReportPage.ClicarSeveridade();
            }
            else if (Severity.Equals("text"))
            {
                bugReportPage.ClicarSeveridade();
            }
            else if (Severity.Equals("tweak"))
            {
                bugReportPage.ClicarSeveridade();
            }
            else if (Severity.Equals("minor"))
            {
                bugReportPage.ClicarSeveridade();
            }
        }
    }
}
