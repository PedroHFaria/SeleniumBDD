using CSharpSpecflowTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Pages
{
    public class HomePage : PageBase
    {
        #region Mapeamento
        By myViewText = By.LinkText("My View");
        By reportIssueText = By.LinkText("Report Issue");
        #endregion


        public void VerificarMenuMinhaVisao()
        {
            WaitForElement(myViewText);
        }

        public void ClicarMenuReportarTarefa()
        {
            Click(reportIssueText);
        }
    }
}
