using Microsoft.AspNetCore.Mvc;

public class ImportController : Controller{
     
      private readonly IWebHostEnvironment _env;

    public ImportController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult LireCsv()
    {
        // Suppose que le fichier est dans wwwroot/fichiers/monfichier.csv
        string path = Path.Combine(_env.WebRootPath, "fichiers", "monfichier.csv");

        List<string[]> lignes = new List<string[]>();

        if (System.IO.File.Exists(path))
        {
            var toutesLignes = System.IO.File.ReadAllLines(path);
            foreach (var ligne in toutesLignes)
            {
                var colonnes = ligne.Split(',');
                lignes.Add(colonnes);
            }
        }

        return View(lignes);
    }
}