using System.Diagnostics;

namespace Logistic.Delivery.Common.Helpers
{
    public class ApplicationExecuter
    {
        public (string Saida, string Erro, int CodigoSaida) Executar(string caminhoExe, string arguments = "")
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\caminho\exe", //caminho
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                using (Process process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();
                    var saida = process.StandardOutput.ReadToEnd();
                    var erro = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    return (saida, erro, process.ExitCode);
                }

            }
            catch (Exception ex)
            {
                return ($"Error{ex.Message}", string.Empty, -1);
            }

        }
    }
}
