using CSharpSpecflowTemplate.Bases;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Pages
{
    public class BugListPage : PageBase
    {

        By mensagemCadastroBug = By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='My Account'])[1]/following::div[1]");


        public void VerificarCadastroBugSucesso()
        {
            Assert.IsTrue(WaitForElement(mensagemCadastroBug).Text.Contains("Operation successful"));
        }
    }
}
