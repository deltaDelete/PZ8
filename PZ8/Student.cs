using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ8;
public class Student {
    public string FIO { get; private set; }
    public Student(string fio = "") {
        FIO = fio;
    }

    public void PassSession(Session session) {
        session.Pass();
    }
}

public class Session {
    public ISessionType SessionType { get; private set; }

    public string Subject { get; set; }

    public void ChangeSessionType(ISessionType sessionType) {
        SessionType = sessionType;
    }

    public void Pass() {
        SessionType.Pass();
    }
}

public interface ISessionType {
    public void Pass();
}

/// <summary>
/// Зачет
/// </summary>
public class Report : ISessionType {
    public void Pass() {
        Console.WriteLine("Зачет");
    }
}

/// <summary>
/// Диф зачет
/// </summary>
public class DiffReport : ISessionType {
    public void Pass() {
        Console.WriteLine("Диф зачет");
    }
}

/// <summary>
/// Экзамен
/// </summary>
public class Exam : ISessionType {
    public void Pass() {
        Console.WriteLine("Экзамен");
    }
}