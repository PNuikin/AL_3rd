using System.Reflection;
using System.Xml.Linq;
using Lab08_Library;

void Serialize(Animal animal, XElement program)
{
    XElement element = new XElement(animal.Name!);
    element.Add(new XElement("HideFromOtherAnimals", animal.HideFromOtherAnimals),
        new XElement("Country", animal.Country),
        new XElement("WhatAnimal", animal.GetClassificationAnimal()));
    program.Add(element);
}


Animal dog = new Animal("Russia", false, "Dog", eClassificationAnimal.Carnivores);
Lion lion = new Lion("Africa");
Cow cow = new Cow("Germany");
XElement program = new XElement("Animals");
Serialize(dog, program);
Serialize(lion, program);
Serialize(cow, program);
XDocument newDoc = new XDocument(program);
newDoc.Save("C:\\Users\\Hp\\AL_3rd\\Lab 08\\Lab08_Serialize_App\\animals.xml");