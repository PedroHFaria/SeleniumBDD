using CSharpSpecflowTemplate.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSpecflowTemplate.Helpers
{
    public class GeneralHelpers
    {
        public static string RetornaCaminhoDoProjeto()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));

            return new Uri(actualPath).LocalPath;
        }  

        public static string RetornaStringComCaracteresRandomicos(int tamanho)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, tamanho)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetScreenshot(string path)
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string date = DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss-fff");

            Screenshot screenShot = ((ITakesScreenshot)DriverFactory.INSTANCE).GetScreenshot();
            string filePathAndName = path + "/" + testName + "_" + date + ".png";
            screenShot.SaveAsFile(filePathAndName, ScreenshotImageFormat.Png);

            return filePathAndName;
        }

        public static bool RetornaSeExisteUmArquivoNoDiretorio(string diretorio, string nomeArquivo)
        {
            bool exists = false;
            string[] fileList = null;
            int timeOut = 1;

            while (timeOut <= Convert.ToInt32(ConfigurationManager.AppSettings["timeout_default"].ToString()))
            {
                fileList = Directory.GetFiles(diretorio);

                foreach (string arquivo in fileList)
                {
                    if (arquivo.Contains(nomeArquivo))
                    {
                        FileInfo thisFile = new FileInfo(arquivo);
                        //Verifica se o arquivo foi criado nos últimos 3 minutos
                        if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                        thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        {
                            exists = true;
                        }

                        break;
                    }
                }
                if (exists)
                {
                    break;
                }

                Thread.Sleep(1000);
                timeOut++;
            }

            return exists;
        }

        public static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public static void EnsureDirectoryExists(string fullReportFilePath)
        {
            var directory = Path.GetDirectoryName(fullReportFilePath);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        public static void DeleteFileFromADirectory(string fileName, string directoryPath)
        {
            File.Delete(directoryPath + "/" + fileName);
        }
    }
}
