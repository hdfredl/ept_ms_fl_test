using System.Xml;

Console.WriteLine("Hello, Etteplan!");

XmlDocument xmlDoc = new XmlDocument();
// spara sml_gentext.xml till XML Path (1)
string XMLPath = Directory.GetCurrentDirectory() + @"\sma_gentext.xml";
xmlDoc.Load(XMLPath);

// hämta ut alla "trans-unit", XML = nodes (2)
XmlNodeList xmlList = xmlDoc.GetElementsByTagName("trans-unit");

string transUnitId = "42007";
string target = "Obs!";
string myTest;

// Se om det finns några trans-units (3)
if (xmlList.Count > 0)
{
    // printa ut alla Id:er/targets, avsluta när vi hittar "42007" och deras targets syns(4)
    for (int i = 0; i < xmlList.Count; i++)
    {
        Console.WriteLine(xmlList[i].OuterXml.ToString());
        Thread.Sleep(1000);
        if (xmlList[i].OuterXml.ToString().Contains(transUnitId) && xmlList[i].OuterXml.ToString().Contains(target))
        {
            Console.WriteLine(myTest = "Hittade Id:et " + transUnitId + " och target: " + target);
            // Printa till en textfil (5)
            StreamWriter writeText = new StreamWriter("myTestToEP.txt", true);
            writeText.Write(myTest);
            writeText.Flush();
            writeText.Close();
            break;
        }
    }
}
Console.ReadLine();
