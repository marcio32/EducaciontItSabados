using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
	public class GenerateLogHelper
	{
		public static async Task LogError(Exception ex, string modulo, string metodo)
		{
			var path = string.Format(@"C:\Logs\{0:dd-MM-yyyy}\{1}", DateTime.Now, modulo);

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

            var file = string.Format(@"{0}\{1:dd-MM-yyyy}.txt",path, DateTime.Now);

			var contenido = $"======================\n" +
							$"---------------{DateTime.Now:dd/MM/yyyy H:mm:ss}---------------\n" +
							$"Error: {ex.Message}\n" +
							$"Modulo: {modulo}\n" +
							$"Metodo: {metodo}\n" +
							$"Ubicacion: {ex.StackTrace}\n" +
							$"======================\n\n";

			await File.AppendAllTextAsync(file, contenido);
        }
	}
}
