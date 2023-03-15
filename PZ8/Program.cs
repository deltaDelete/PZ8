using System.Linq;
using System;

namespace PZ8;

public static class Program {
    static readonly Random r = new Random();
    public static void Main(string[] args) {
        Enumerable.Range(0, 10)
            .Select(x => {
                // Это чтобы рандомный тип зачета был
                var nestedTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ISessionType).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)
                .ToArray();
                var count = nestedTypes.Length;
                var rnd = r.Next(count);

                var session = new Session();
                session.Subject = x.ToString();
                session.ChangeSessionType((ISessionType)Activator.CreateInstance(nestedTypes[rnd]));

                var student = new Student(x.ToString());

                return (student, session);

            }
            )
            .ToList()
            .ForEach(x => {
                Console.WriteLine(x.student.FIO);
                x.student.PassSession(x.session);
            });

        Console.ReadLine();
    }
}