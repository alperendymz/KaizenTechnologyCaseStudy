namespace KaizenCaseStudy;

using Newtonsoft.Json;

public class Program
{
    private static void Main()
    {
        try
        {
            //AŞAĞIDA FILE PATH İÇİN BİR MANİPÜLASYON YAPILMASI GEREKİYORDU BU YOLLARI İZLEDİM. 
            //ÖNCE PROJENİN ÇALIŞTIĞI DIRECTORY'I ALDIM SONRASINDA PROJE İÇİNDEKİ DIRECTORY'I BULUP jsonFilePath,
            //ADINDAKİ DEĞİŞKENE ATARKEN Path.Combine YAPARAK HER KONUMDA ÇALIŞABİLECEK DURUMA GETİRDİM.
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
            if (projectDirectory != null)
            {
                var jsonFilePath = Path.Combine(projectDirectory, "Data", "response.json");
                var json = File.ReadAllText(jsonFilePath);

                var items = JsonConvert.DeserializeObject<List<Item>>(json);
                items = items?.OrderBy(item => item.BoundingPoly.vertices.Min(v => v.y))
                    .ThenBy(item => item.BoundingPoly.vertices.Min(v => v.x)).ToList();

                var combinedOutput = new List<string>();
                var currentLine = items?[0].Description;

                if (items != null)
                {
                    var previousX = items[0].BoundingPoly.vertices[0].x;
                    var lineNumber = 1;

                    // Her bir item'ı birleştirilmiş çıktıya ekle
                    for (int i = 1; i < items.Count; i++)
                    {
                        var currentX = items[i].BoundingPoly.vertices[0].x;

                        // Eğer bir önceki x değeri, şu anki x değerinden küçükse bir sonraki satıra geç
                        if (currentX < previousX)
                        {
                            //Şu anki satırı birleştirilmiş çıktıya ekle
                            combinedOutput.Add($"{lineNumber} {currentLine}");

                            //Yeni satır oluştur
                            currentLine = items[i].Description;
                            previousX = currentX;

                            //Satır numarasını bir arttır
                            lineNumber++;
                        }
                        else
                        {
                            //X değerleri artıyorsa aynı satıra ekle
                            currentLine += " " + items[i].Description;
                            previousX = currentX;
                        }
                    }

                    //Son satırı ekle
                    combinedOutput.Add($"{lineNumber} {currentLine}");

                    //Birleştirilmiş çıktıyı yazdır
                    foreach (var line in combinedOutput)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurs while reading the json file! {ex.Message}");
        }
    }
}

public class Item
{
    public string Description { get; set; }
    public BoundingPoly BoundingPoly { get; set; }
}

public class BoundingPoly
{
    public List<Vertex> vertices { get; set; }
}

public class Vertex
{
    public int x { get; set; }
    public int y { get; set; }
}