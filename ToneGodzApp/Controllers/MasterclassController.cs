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
    private readonly IMemoryCache _cache;
    public MasterClassController(IHttpClientFactory httpClientFactory, IMemoryCache cache)
    {
        _httpClient = httpClientFactory.CreateClient("Vimeo");
        _cache = cache;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        List<object> folderDetailUris = new();
        var cacheKey = "mainFolders";
        if (_cache.TryGetValue(cacheKey, out var mainFolders))
        {
            folderDetailUris = (List<object>)mainFolders;
        }

        else
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

                foreach (var item in itemsArray.EnumerateArray())
                {
                    var folder = item.GetProperty("folder");
                    var uri = folder.GetProperty("uri").GetString();
                    string[] parts = uri.Split('/');
                    string lastNumberBeforeSlash = parts[parts.Length - 1];

                    folderDetailUris.Add(new { id = lastNumberBeforeSlash, name = folder.GetProperty("name").GetString() });
                    _cache.Set(cacheKey, folderDetailUris, TimeSpan.FromDays(1));
                }
            }

        }

        return Inertia.Render("Masterclass/Index", new { folders = folderDetailUris });
    }

    [HttpGet]
    [Route("subfolders/{id}")]
    public async Task<IActionResult> SubFolders(int id)
    {
        List<object> folderDetailUris = new();
        string folderName = null;
        var cacheKey = "subFolder-" + id;

        if (_cache.TryGetValue(cacheKey, out var mainFolders))
        {
            var itemsFolderTuple = (Tuple<List<object>, string>)mainFolders;
            folderDetailUris = itemsFolderTuple.Item1;
            folderName = itemsFolderTuple.Item2;
        }

        else
        {
            var response = await _httpClient.GetAsync($"users/232493424/projects/{id}");
            if (response.IsSuccessStatusCode)
            {
                folderName = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement.GetProperty("name").GetString();
            }
            response = await _httpClient.GetAsync($"users/232493424/projects/{id}/items");
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

                    var isVideo = false;
                    foreach (var item in itemsArray.EnumerateArray())
                    {
                        if (item.TryGetProperty("folder", out JsonElement folder))
                        {
                            var uri = folder.GetProperty("uri").GetString();
                            string[] parts = uri.Split('/');
                            string lastNumberBeforeSlash = parts[parts.Length - 1];
                            folderDetailUris.Add(new { itemId = lastNumberBeforeSlash, itemName = folder.GetProperty("name").GetString(), thumbnail = "", type = "folder" });
                        }
                        else
                        {
                            if (item.TryGetProperty("video", out JsonElement video))
                            {
                                var uri = video.GetProperty("uri").GetString();
                                string[] parts = uri.Split('/');
                                string lastNumberBeforeSlash = parts[parts.Length - 1];
                                folderDetailUris.Add(new { itemId = lastNumberBeforeSlash, itemName = video.GetProperty("name").GetString(), thumbnail = video.GetProperty("pictures").GetProperty("base_link").GetString(), type = "video" });
                                isVideo = true;
                            }
                        }


                    }

                    _cache.Set(cacheKey, Tuple.Create<List<object>, string>(folderDetailUris, folderName), TimeSpan.FromDays(1));

                }
            }
            else
            {
                return NotFound("Project id not found");
            }
        }

        return Inertia.Render("Masterclass/Subfolders", new { items = folderDetailUris, folderName = folderName });

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
                    List<object> siblings = new();
                    // Step 4: Parse the JSON string using JsonDocument
                    using (var jsonDoc2 = JsonDocument.Parse(jsonString2))
                    {
                        // Assuming the root JSON object contains an array of folders under a "data" property
                        var itemsArray2 = jsonDoc2.RootElement.GetProperty("data");

                        // Step 5: Loop through the folders array and check for the required keys

                        foreach (var item in itemsArray2.EnumerateArray())
                        {
                            if (item.TryGetProperty("video", out JsonElement video))
                            {
                                var uri = video.GetProperty("uri").GetString();
                                string[] parts = uri.Split('/');
                                string lastNumberBeforeSlash = parts[parts.Length - 1];
                                if (lastNumberBeforeSlash != id.ToString())   // Now you can check if the folderElement is a boolean and get its value
                                    siblings.Add(new { id = lastNumberBeforeSlash, name = video.GetProperty("name").GetString(), thumbnail = video.GetProperty("pictures").GetProperty("base_link").GetString() });
                            }
                        }

                    }

                    return Inertia.Render("Masterclass/Videos", new
                    {
                        video = new { name = name, embed = embed, siblings = siblings },
                        folderName = jsonDoc.RootElement.GetProperty("parent_folder").GetProperty("name").GetString()
                    });
                }
            }

        }
        return NotFound("Video id not found");
    }
}
