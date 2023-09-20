class DocumentWorker
{
    public void OpenDocument()
    {
        Console.WriteLine("Документ открыт");
    }

    public virtual void EditDocument()
    {
        Console.WriteLine("Редактирование документа доступно в версии Pro");
    }

    public virtual void SaveDocument()
    {
        Console.WriteLine("Сохранение документа доступно в версии Pro");
    }
}

class ProDocumentWorker : DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Документ отредактирован");
    }

    public override void SaveDocument()
    {
        Console.WriteLine(
            "Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
    }
}

class ExpertDocumentWorker : ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате");
    }
}

namespace Task_3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите ключ доступа к версии Pro или Expert (в случае его отсутствия введите 0): ");
            int code = Convert.ToInt32(Console.ReadLine());
            if (code == 101)
            {
                ProDocumentWorker worker = new ProDocumentWorker();
                worker.OpenDocument();
                worker.EditDocument();
                worker.SaveDocument();
            }
            else if (code == 202)
            {
                ExpertDocumentWorker worker = new ExpertDocumentWorker();
                worker.OpenDocument();
                worker.EditDocument();
                worker.SaveDocument();
            }
            else
            {
                DocumentWorker worker = new DocumentWorker();
                worker.OpenDocument();
                worker.EditDocument();
                worker.SaveDocument();
            }
        }
    }
}