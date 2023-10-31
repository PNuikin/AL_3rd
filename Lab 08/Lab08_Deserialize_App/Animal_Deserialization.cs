using System.Xml;
using System.Xml.Linq;
using Lab08_Library;

List<Animal> Deserialize(XmlDocument xDocument)
{
    string[] temp = { "Cow", "Lion", "Pig" };
    List<Animal> animals = new List<Animal>();
    XmlElement? xRoot = xDocument.DocumentElement;
    if (xRoot is not null)
    {
        foreach (XmlNode node in xRoot)
        {
            
            eClassificationAnimal ClassificationAnimal(string? str)
            {
                switch (str)
                {
                    case "Carnivores":
                        return eClassificationAnimal.Carnivores;
                    case "Herbivores":
                        return eClassificationAnimal.Herbivores;
                    default:
                        return eClassificationAnimal.Omnivores;
                }
            }

            var country = "";
            var hideFromOtherAnimals = false;
            eClassificationAnimal whatAnimal = eClassificationAnimal.Carnivores;
            
            foreach (XmlNode childnode in node.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "Country":
                    {
                        country = childnode.InnerText;
                        break;
                    }
                    case "HideFromOtherAnimals":
                    {
                        hideFromOtherAnimals = Convert.ToBoolean(childnode.InnerText);
                        break;
                    }
                    case "WhatAnimal":
                        whatAnimal = ClassificationAnimal(childnode.InnerText);
                        break;
                }
            }
            
            if (!temp.Contains(node.Name))
            {
                animals.Add(new Animal(country, hideFromOtherAnimals, node.Name, whatAnimal));
            }
            else
            {
                switch (node.Name)
                {
                    case "Cow": animals.Add(new Cow(country));
                        break;
                    case "Lion": animals.Add(new Lion(country));
                        break;
                    default: animals.Add(new Pig(country)); break;
                }
            }
        }
    }

    return animals;
}

XmlDocument xmlDocument = new XmlDocument();
xmlDocument.Load("C:\\Users\\Hp\\AL_3rd\\Lab 08\\Lab08_Serialize_App\\animals.xml");
List<Animal> animals = Deserialize(xmlDocument);
foreach (var animal in animals)
{
    Console.WriteLine($"{animal.Name} {animal.Country} {animal.HideFromOtherAnimals} {animal.WhatAnimal}");
}