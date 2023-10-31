using Lab07_Library;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Lab07_App;

abstract class Program
{
    static void Main()
    {
        Assembly asm = Assembly.Load("Lab07_Library");
        var types = asm.GetExportedTypes();
        XElement program = new XElement("Program");
        foreach (var type in types)
        {
            XElement element = new XElement(type.Name);
            if (type.IsEnum)
            {
                element.Add(new XElement("MyComment", type.GetCustomAttribute<MyComment>()!.Comment));
                XElement enumValues = new XElement("Values");
                foreach (var t in type.GetEnumValues())
                {
                    enumValues.Add(t + " ");
                }
                element.Add(enumValues);
            }
            else
            {
                if (type.Name == "MyComment")
                {
                    element.Add(new XElement("Properties", from t in type.GetProperties() select t.Name + " "),
                        new XElement("Constructors", from t in type.GetConstructors() select t.DeclaringType + " "));
                }
                else
                {
                    element.Add(new XElement("MyComment", type.GetCustomAttribute<MyComment>()!.Comment),
                        new XElement("Properties", from t in type.GetProperties() select t.Name + " "),
                        new XElement("Constructors", from t in type.GetConstructors() select t.DeclaringType),
                        new XElement("Methods",
                            from t in type.GetMethods()
                            where (!t.Name.StartsWith("get_") && !t.Name.StartsWith("set_"))
                            select t.Name + " "));
                }
            }

            program.Add(element);
        }

        XDocument xDocument = new XDocument(program);

        // var type = (from T in types where T.Name == "Animal" select T).First();

        // XElement animalClassification = new XElement("AnimalClassification");
        // XElement foodClassifition = new XElement("FoodClassification");
        // XElement pig = new XElement("Pig");

        xDocument.Save(@"C:\Users\Hp\AL_3rd\Lab 07\Lab07_AppLab07_Library.xml");
    }
}