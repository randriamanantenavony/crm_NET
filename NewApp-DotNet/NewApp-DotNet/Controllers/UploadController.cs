using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class UploadController : Controller
{

      public IActionResult Index()
    {
        return View(); // cela retourne Views/Upload/Index.cshtml
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile uploadedFile)
    {
        if (uploadedFile != null && uploadedFile.Length > 0)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            using (var stream = uploadedFile.OpenReadStream())
            {
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                content.Add(fileContent, "file", uploadedFile.FileName);

                var response = await client.PostAsync("http://localhost:8080/api/upload", content);
                var result = await response.Content.ReadAsStringAsync();

                ViewBag.Message = $"Réponse du serveur Java : {result}";
            }
        }
        else
        {
            ViewBag.Message = "Aucun fichier sélectionné.";
        }

        return View("Index");
    }
}
