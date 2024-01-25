// namespace KaizenCaseStudy;
// public class CodeGenerator
// {
//     private static Random random = new();
//     public static string GenerateCode()
//     {
//         //VERİLEN KARAKTERLERİ ASCII KODU İLE RANDOM SECMEYİ TERCİH ETTİM. EN UNIQUE BU SEKİLDE OLABİLİR DİYE DUSUNDUM.
//         char[] validCharacters = { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9' };
//         var codeArray = new char[8];
//
//         for (int i = 0; i < 8; i++)
//         {
//             int index = random.Next(validCharacters.Length);
//             codeArray[i] = validCharacters[index];
//         }
//
//         var generatedCode = new string(codeArray);
//         return generatedCode;
//     }
// }
//
// class Program
// {
//     static void Main()
//     {
//         //HASHSET KULLANILAMADIGI ICIN BURAYI COMMENT'E ALDIM. BU DAHA PERFORMANSLI.
//         // HashSet<string> generatedCodes = new HashSet<string>();
//         // int numberOfCodesToGenerate = 1000;
//         //
//         // for (int i = 0; i < numberOfCodesToGenerate; i++)
//         // {
//         //     string generatedCode = CodeGenerator.GenerateCode();
//         //
//         //     // Eğer oluşturulan kod daha önce eklenmişse unique değildir.
//         //     if (!generatedCodes.Add(generatedCode))
//         //     {
//         //         Console.WriteLine($"Non-unique code detected: {generatedCode}");
//         //     }
//         // }
//         //Console.WriteLine($"Total unique codes generated: {generatedCodes.Count}");
//
//         var generatedCodes = new string[1000];
//         var numberOfCodesToGenerate = 1000;
//         var uniqueCount = 0;
//
//         for (int i = 0; i < numberOfCodesToGenerate; i++)
//         {
//             string generatedCode = CodeGenerator.GenerateCode();
//
//             //UNIQUE'LIK KONTROLU
//             if (!CheckCode(generatedCodes, generatedCode))
//             {
//                 generatedCodes[uniqueCount] = generatedCode;
//                 uniqueCount++;
//             }
//             else
//             {
//                 Console.WriteLine($"Non-unique code detected: {generatedCode}");
//             }
//         }
//         Console.WriteLine($"Total unique codes generated: {uniqueCount}");
//     }
//
//     static bool CheckCode(string[] array, string value)
//     {
//         return array.Any(item => item == value);
//     }
// }
