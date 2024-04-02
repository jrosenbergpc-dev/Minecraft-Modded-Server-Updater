using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Minecraft_Modded_Server_Updater.models;

namespace Minecraft_Modded_Server_Updater.Tools
{
	public static class Downloader
	{
		public static event EventHandler<int> DownloadProgressChanged;
		public static event EventHandler<bool> DownloadCompleted;

		public static async Task<bool> DownloadModFile(Mod modfile)
		{
			bool isComplete = false;

			try
			{
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage response = await client.GetAsync(API.ServerAddress + modfile.FileName))
					{
						using (Stream contentStream = await response.Content.ReadAsStreamAsync())
						{
							using (Stream fileStream = new FileStream(App.RunningDirectory + "\\tempdl\\" + modfile.FileName, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
							{
								byte[] buffer = new byte[4096];
								int bytesRead;
								long totalBytesRead = 0;
								long totalBytes = response.Content.Headers.ContentLength ?? -1;

								while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
								{
									await fileStream.WriteAsync(buffer, 0, bytesRead);
									totalBytesRead += bytesRead;

									// Calculate download progress
									int progressPercentage = (int)((double)totalBytesRead / totalBytes * 100);

									// Raise progress changed event
									DownloadProgressChanged?.Invoke(null, progressPercentage);
								}

								// Raise download completed event
								DownloadCompleted?.Invoke(null, true);
								isComplete = true;
							}
						}
					}
				}
			}
			catch (Exception)
			{
				DownloadCompleted?.Invoke(null, false);
				isComplete = false;
			}
			

			return isComplete;
		}
	}
}
