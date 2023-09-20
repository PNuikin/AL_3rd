using System.Net.Mail;

namespace Lab_02
{
    class Pupil
    {
        public virtual void Study()
        {
            Console.WriteLine($"Studying: ");
        }

        public virtual void Read()
        {
            Console.WriteLine($"Reading:");
        }

        public virtual void Write()
        {
            Console.WriteLine($"Writing:");
        }

        public virtual void Relax()
        {
            Console.WriteLine($"Relaxing:");
        }
    }

    class ExcellentPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Studying: Excellent");
        }

        public override void Read()
        {
            Console.WriteLine("Reading: Excellent");
        }

        public override void Write()
        {
            Console.WriteLine("Writing: Excellent");
        }

        public override void Relax()
        {
            Console.WriteLine("Relaxing: Excellent");
        }
    }

    class GoodPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Studying: Good");
        }

        public override void Read()
        {
            Console.WriteLine("Reading: Good");
        }

        public override void Write()
        {
            Console.WriteLine("Writing: Good");
        }

        public override void Relax()
        {
            Console.WriteLine("Relaxing: Good");
        }
    }

    class BadPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Studying: Bad");
        }

        public override void Read()
        {
            Console.WriteLine("Reading: Bad");
        }

        public override void Write()
        {
            Console.WriteLine("Writing: Bad");
        }

        public override void Relax()
        {
            Console.WriteLine("Relaxing: Bad");
        }
    }

    class ClassRoom
    {
        private List<Pupil> lst = new List<Pupil>();

        public ClassRoom(params Pupil[] lstin)
        {
            foreach (var man in lstin)
            {
                lst.Add(man);
            }
        }

        public void Print()
        {
            int i = 1;
            foreach (var man in lst)
            {
                Console.WriteLine($"{i}) ");
                man.Study();
                man.Read();
                man.Write();
                man.Relax();
                i++;
            }
        }
    }

    public static class Program
    {
        static void Main()
        {
            ExcellentPupil man1 = new();
            GoodPupil man2 = new(), man3 = new();
            BadPupil man4 = new();
            ClassRoom group = new ClassRoom(man1, man2, man3, man4);
            group.Print();
        }
    }
}

