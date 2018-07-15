using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace mp3Cataloguer.Logic
{
    public static class GoogleDrive
    {
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "mp3Cataloguer";

        private static string Search(string search)
        {
            string id = null;

            UserCredential credential;

            using (var stream =
                            new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string pageToken = null;
            do
            {
                var request = service.Files.List();
                //request.Q = "mimeType='application/vnd.google-apps.folder' and name='mp3Cataloguer' and trashed=false";
                // request.Q = "mimeType='text/plain' and name='Name' and trashed=false";
                request.Q = search;
                request.Spaces = "drive";
                request.Fields = "nextPageToken, files(id, name)";
                request.PageToken = pageToken;
                var result = request.Execute();
                if(result.Files.Count > 1)
                {
                    foreach(var file in result.Files)
                    {
                        Delete(file.Id);
                    }
                }

                foreach (var file in result.Files)
                {
                    Console.WriteLine(String.Format(
                            "Found file: {0} ({1})", file.Name, file.Id));
                    id = file.Id;
                }
                pageToken = result.NextPageToken;
            } while (pageToken != null);

            return id;
        }

        public static void Upload(string fileName)
        {
            UserCredential credential;

            using (var stream =
                            new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var oldFolred = Search("mimeType = 'application/vnd.google-apps.folder' and name = 'mp3Cataloguer' and trashed = false");
            if(oldFolred != null)
            {
                Delete(oldFolred);
            }

            var folder = new Google.Apis.Drive.v3.Data.File()
            {
                Name = "mp3Cataloguer",
                MimeType = "application/vnd.google-apps.folder"
            };
            var requestFolder = service.Files.Create(folder);
            requestFolder.Fields = "id";
            var fileFolder = requestFolder.Execute();
            //Console.WriteLine("Folder ID: " + file2.Id);

            var file = new Google.Apis.Drive.v3.Data.File
            {
                MimeType = "text/xml",
                Name = "Data",
                Parents = new List<string>
                {
                    fileFolder.Id
                }
            };

            FilesResource.CreateMediaUpload request;
            using (var stream = new System.IO.FileStream(fileName,
                        System.IO.FileMode.Open))
            {
                request = service.Files.Create(
                    file, stream, file.MimeType);
                request.Fields = "id";
                request.Upload();
            }
            var fileData = request.ResponseBody;
            Console.WriteLine("File ID: " + fileData.Id);
        }

        public static void Download(string fileName)
        {
            UserCredential credential;

            using (var stream =
                            new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string fileId = Search("mimeType = 'text/xml' and name = 'Data' and trashed = false");

            var request = service.Files.Get(fileId);
            var memoryStream = new System.IO.MemoryStream();

            request.MediaDownloader.ProgressChanged +=
                (IDownloadProgress progress) =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                            {
                                Console.WriteLine(progress.BytesDownloaded);
                                break;
                            }
                        case DownloadStatus.Completed:
                            {
                                Console.WriteLine("Download complete.");
                                break;
                            }
                        case DownloadStatus.Failed:
                            {
                                Console.WriteLine("Download failed.");
                                break;
                            }
                    }
                };
            request.Download(memoryStream);

            memoryStream.Position = 0;
            System.IO.File.WriteAllBytes(fileName, memoryStream.ToArray());
        }

        private static void Delete(string fileId)
        {
            UserCredential credential;

            using (var stream =
                            new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            var request = service.Files.Delete(fileId);
            request.Execute();
        }

        public static void Delete()
        {
            var oldFolred = Search("mimeType = 'application/vnd.google-apps.folder' and name = 'mp3Cataloguer' and trashed = false");
            if (oldFolred != null)
            {
                Delete(oldFolred);
            }
        }

        public static void LogOut()
        {
            Delete();
            string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");
            Directory.Delete(credPath, true);
        }
    }
}
