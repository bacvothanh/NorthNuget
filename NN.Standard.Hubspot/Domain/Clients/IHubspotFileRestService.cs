using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NN.Standard.Hubspot.Domain.Dto.Engagement;
using NN.Standard.Hubspot.Domain.Dto.File;
using RestEase;
using RestEase.Implementation;

namespace NN.Standard.Hubspot.Domain.Clients
{
    public interface IHubspotFileRestService
    {
        IRequester Requester { get; }

        [Post("engagements/v1/engagements")]
        [AllowAnyStatusCode]
        Task<Response<CreateEngagementDto>> CreateEngagement([Body] CreateEngagementDto request);
    }

    public static class HubspotFileRestServiceExtensions
    {
        public static Task<Response<FileListDto>> UploadAsync(this IHubspotFileRestService api, string apiKey, byte[] imageData, string fileNames,
            string folderPaths, string folderId = "", string fileType = "image/jpeg", bool overwrite = true, bool hidden = false)
        {
            var content = new MultipartFormDataContent();

            var imageContent = new ByteArrayContent(imageData);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue(fileType);
            content.Add(imageContent, "files", fileNames);
            content.Add(new StringContent(fileNames), "file_names");
            content.Add(new StringContent(folderPaths), "folder_paths");
            content.Add(new StringContent(folderId), "folder_id");

            var requestInfo = new RequestInfo(HttpMethod.Post, $"filemanager/api/v2/files?overwrite={overwrite}&hidden={hidden}&hapikey={apiKey}");
            
            requestInfo.SetBodyParameterInfo(BodySerializationMethod.Default, content);
            return api.Requester.RequestWithResponseAsync<FileListDto>(requestInfo);
        }
    }
}
