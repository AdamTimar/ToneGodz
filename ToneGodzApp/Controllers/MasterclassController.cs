using System.Text;
using System.Text.Json;
using InertiaCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using ToneGodzApp.Data;
using ToneGodzApp.Data.Models;
using ToneGodzApp.Models;

namespace ToneGodzApp.Controllers;

[Authorize(Policy = "HasAccess")]
[Route("[controller]")]
public class MasterClassController : Controller
{
    private readonly HttpClient _httpClient;
    public MasterClassController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Vimeo");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("users/232493424/projects/23455033/items");
        response.EnsureSuccessStatusCode();

        // Step 3: Read the JSON response as a string
        var jsonString = await response.Content.ReadAsStringAsync();

        // Step 4: Parse the JSON string using JsonDocument
        using (var jsonDoc = JsonDocument.Parse(jsonString))
        {
            // Assuming the root JSON object contains an array of folders under a "data" property
            var itemsArray = jsonDoc.RootElement.GetProperty("data");

            // Step 5: Loop through the folders array and check for the required keys
            List<Tuple<string, string>> folderDetailUris = new();
            foreach (var item in itemsArray.EnumerateArray())
            {
                var folder = item.GetProperty("folder");
                var uri = folder.GetProperty("uri").GetString();
                string[] parts = uri.Split('/');
                string lastNumberBeforeSlash = parts[parts.Length - 1];

                folderDetailUris.Add(Tuple.Create<string, string>(lastNumberBeforeSlash, folder.GetProperty("name").GetString()));
            }

            return Inertia.Render("Masterclass/Index", new { folders = folderDetailUris });
        }
    }

    [HttpGet]
    [Route("subfolders/{id}")]
    public async Task<IActionResult> SubFolders(int id)
    {
        var response = await _httpClient.GetAsync($"users/232493424/projects/{id}/items");
        if (response.IsSuccessStatusCode)
        {
            // Step 3: Read the JSON response as a string

            // Step 3: Read the JSON response as a string
            var jsonString = await response.Content.ReadAsStringAsync();

            // Step 4: Parse the JSON string using JsonDocument
            using (var jsonDoc = JsonDocument.Parse(jsonString))
            {
                // Assuming the root JSON object contains an array of folders under a "data" property
                var itemsArray = jsonDoc.RootElement.GetProperty("data");

                // Step 5: Loop through the folders array and check for the required keys
                List<Tuple<string, string, string, string>> folderDetailUris = new();
                var isVideo = false;
                foreach (var item in itemsArray.EnumerateArray())
                {
                    if (item.TryGetProperty("folder", out JsonElement folder))
                    {
                        var uri = folder.GetProperty("uri").GetString();
                        string[] parts = uri.Split('/');
                        string lastNumberBeforeSlash = parts[parts.Length - 1];
                        folderDetailUris.Add(Tuple.Create<string, string, string, string>(lastNumberBeforeSlash, folder.GetProperty("name").GetString(), null, "folder"));
                    }
                    else
                    {
                        if (item.TryGetProperty("video", out JsonElement video))
                        {
                            var uri = video.GetProperty("uri").GetString();
                            string[] parts = uri.Split('/');

                            string lastNumberBeforeSlash = parts[parts.Length - 1];   // Now you can check if the folderElement is a boolean and get its value
                            folderDetailUris.Add(Tuple.Create<string, string, string, string>(lastNumberBeforeSlash, video.GetProperty("name").GetString(), video.GetProperty("pictures").GetProperty("base_link").GetString(), "video"));
                            isVideo = true;
                        }
                    }


                }

                return Inertia.Render("Masterclass/Subfolders", new { items = folderDetailUris });
            }
        }
        return NotFound("Project id not found");
    }

    [HttpGet]
    [Route("videos/{id}")]
    public async Task<IActionResult> Videos(int id)
    {
        var response = await _httpClient.GetAsync($"videos/{id}");
        if (response.IsSuccessStatusCode)
        {
            // Step 3: Read the JSON response as a string

            // Step 3: Read the JSON response as a string
            var jsonString = await response.Content.ReadAsStringAsync();

            // Step 4: Parse the JSON string using JsonDocument
            using (var jsonDoc = JsonDocument.Parse(jsonString))
            {
                // Assuming the root JSON object contains an array of folders under a "data" property
                var embed = jsonDoc.RootElement.GetProperty("player_embed_url").GetString();
                var name = jsonDoc.RootElement.GetProperty("name").GetString();
                var parentFolder = jsonDoc.RootElement.GetProperty("parent_folder");
                var parentFolderUri = parentFolder.GetProperty("uri").GetString();
                string[] parts2 = parentFolderUri.Split('/');
                string lastNumberBeforeSlash2 = parts2[parts2.Length - 1];


                var response2 = await _httpClient.GetAsync($"users/232493424/projects/{lastNumberBeforeSlash2}/items");
                if (response2.IsSuccessStatusCode)
                {
                    // Step 3: Read the JSON response as a string

                    // Step 3: Read the JSON response as a string
                    var jsonString2 = await response2.Content.ReadAsStringAsync();
                    List<Tuple<string, string, string>> siblings = new();
                    // Step 4: Parse the JSON string using JsonDocument
                    using (var jsonDoc2 = JsonDocument.Parse(jsonString2))
                    {
                        // Assuming the root JSON object contains an array of folders under a "data" property
                        var itemsArray2 = jsonDoc2.RootElement.GetProperty("data");

                        // Step 5: Loop through the folders array and check for the required keys

                        var isVideo = false;
                        foreach (var item in itemsArray2.EnumerateArray())
                        {
                            if (item.TryGetProperty("video", out JsonElement video))
                            {
                                var uri = video.GetProperty("uri").GetString();
                                string[] parts = uri.Split('/');
                                string lastNumberBeforeSlash = parts[parts.Length - 1];
                                if (lastNumberBeforeSlash != id.ToString())   // Now you can check if the folderElement is a boolean and get its value
                                    siblings.Add(Tuple.Create<string, string, string>(lastNumberBeforeSlash, video.GetProperty("name").GetString(), video.GetProperty("pictures").GetProperty("base_link").GetString()));
                                isVideo = true;
                            }
                        }

                    }

                    return Inertia.Render("Masterclass/Videos", new
                    {
                        video = new { name = name, embed = embed, siblings = siblings }
                    });
                }
            }

        }
        return NotFound("Video id not found");
    }
}
