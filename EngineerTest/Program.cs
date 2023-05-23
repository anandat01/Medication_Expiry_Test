using System.Text.Json;
using EngineerTest;



try
{
    //list of drug (string Name, int ExpiresIn, int Benefit)
    var drugs = new[] {
        new Drug("Doliprane", 20, 30),
        new Drug("Herbal Tea", 10, 5),
        new Drug("Fervex", 12, 35),
        new Drug("Magic Pill", 15, 40),
        new Drug("Dafalgan", 20, 30)
    };
    IPharmacy pharmacy = new Pharmacy(drugs);

    var log = new List<Drug[]?>();

    for (var elapsedDays = 0; elapsedDays < 30; elapsedDays++) {
        log.Add(JsonSerializer.Deserialize<Drug[]>(JsonSerializer.Serialize(pharmacy.UpdateBenefitValue())));
    }

    //writing output in file: new_output.json
    File.WriteAllText(
        "new_output.json",
        JsonSerializer.Serialize(new { Result = log }, options: new JsonSerializerOptions { WriteIndented = true })
    );
    Console.WriteLine("Success, please check new_output.Json file for generated output");

}
catch
{
    Console.WriteLine("Error");
}
