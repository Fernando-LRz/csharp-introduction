// Primera parte - POO
/*
// ---- Instanciar una Clase ----

// Primera Forma
Sale mySale1 = new Sale(10);
string message1 = mySale1.GetInfo();

Console.WriteLine(message1);

// Segunda Forma
var mySale2 = new Sale(20);
var message2 = mySale2.GetInfo();

Console.WriteLine(message2);

// Tercera Forma
SaleWithTax mySaleWithTax = new(30, 3.14m);
var message3 = mySaleWithTax.GetInfo();
var message4 = mySaleWithTax.GetTax();

Console.WriteLine(message3);
Console.WriteLine(message4);


// ---- Herencia ----
class SaleWithTax : Sale
{
    public decimal Tax { get; set; }

    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
    }

    public string GetTax()
    {
        return "El impuesto es " + Tax;
    }

    // Sobreescritura
    public override string GetInfo()
    {
        return "El total es " + Total + " y el impuesto es " + Tax;
    }

    // Sobrecarga
    public string GetInfo(string message)
    {
        return "El total es " + Total + ", el impuesto es " + Tax + ", y su mensaje es: " + message;
    }
}

class Sale
{
    // --- Modificadores de Acceso ---

    // public - se puede acceder desde cualquier parte
    // private - se puede acceder solo desde los métodos de la misma clase, no clases hijas
    // protected - se puede acceder solo desde los métodos de la misma clase y clases hijas

    public decimal Total { get; set; }
    private decimal _totalX3;

    public Sale(decimal total)
    {
        Total = total;
        _totalX3 = total * 3;
    }

    // Este método se puede sobreescribir
    public virtual string GetInfo()
    {
        return "El total es " + Total + " y su triple es " + _totalX3;
    }
}
*/

// Segunda parte - Interfaces
/*
var mySale = new Sale();
var mySaleWithTax = new SaleWithTax();

RunSaveMethod(mySale);
RunSaveMethod(mySaleWithTax);

void RunSaveMethod(ISave isave)
{
    isave.Save();
}

// Sirven para abstraer el funcionamiento mínimo a cumplir
interface ISale
{
    decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

public class Sale: ISale, ISave
{
    public decimal Total { get; set; }

    public void Save()
    {
        Console.WriteLine("Guardando venta...");
    }
}

public class SaleWithTax : ISale, ISave // Implementar múltiples interfaces
{
    public decimal Total { get; set; }

    public void Save()
    {
        Console.WriteLine("Guardando venta con impuestos...");
    }
}
*/

// Tercera parte - Generics
/*
var numbers = new MyList<int>(3);
var strings = new MyList<string>(2);
var clubs = new MyList<FootballClub>(1);

numbers.AddElement(1);
numbers.AddElement(2);
numbers.AddElement(3);
numbers.AddElement(4);

strings.AddElement("C#");
strings.AddElement(".NET");
strings.AddElement("Hello");

clubs.AddElement(new FootballClub()
    {
        Name = "FC Barcelona",
        Champions = 5
    }
);
clubs.AddElement(new FootballClub()
    {
        Name = "Manchester City",
        Champions = 1
    }
);

Console.WriteLine(numbers.GetContent());
Console.WriteLine(strings.GetContent());
Console.WriteLine(clubs.GetContent());

// Los generics sirven para hacer métodos y clases genericas
public class MyList<T>
{
    private List<T> _list;
    private int _listSize;

    public MyList(int listSize)
    {
        _listSize = listSize;
        _list = new List<T>();
    }

    public void AddElement(T item)
    {
        if(_list.Count < _listSize) {
            _list.Add(item);
        }
    }

    public string GetContent()
    {
        string content = "";

        foreach(var element in _list) content += element + ", ";
        return content;
    }
}

public class FootballClub
{
    public string Name { get; set; }
    public int Champions { get; set; }

    public override string ToString()
    {
        return Name + " -> Champions league: " + Champions;
    }
}
*/

// Cuarta parte - JSON
/*
using System.Text.Json;

Console.WriteLine(Person.SayHello());

var myPerson1 = new Person()
{
    Name = "Fernando",
    Age = 21
};

string json = JsonSerializer.Serialize(myPerson1);
Console.WriteLine(json);

string myJson = @"";

Person? myPerson2 = JsonSerializer.Deserialize<Person>(myJson);

Console.WriteLine(myPerson2?.Name);
Console.WriteLine(myPerson2?.Age);

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // método estático
    public static string SayHello() => "Hello!"; // si es sólo una línea, se puede usar =>
}
*/

// Quinta parte - Funciones puras e impuras
/*
Console.WriteLine(Addition(14, 3));
Console.WriteLine(GetTomorrow(DateTime.Now));
Console.WriteLine(GetTomorrowNoArguments());

var myLanguage = new ProgrammingLanguage()
{
    Name = "javascript"
};

Console.WriteLine(myLanguage.Name);
Console.WriteLine(ToUpperNoModifyObject(myLanguage).Name);

// Funciones puras
int Addition(int a, int b)
{
    return a + b; // Retorna siempre lo mismo y no modifica un valor exterior.
}

DateTime GetTomorrow(DateTime date) // DateTime es un struct, no un objeto. Se pasa por valor, no por referencia.
{
    return date.AddDays(1);
}
ProgrammingLanguage ToUpperNoModifyObject(ProgrammingLanguage language)
{
    var myNewLanguage = new ProgrammingLanguage() 
    { 
        Name = language.Name.ToUpper() 
    };

    return myNewLanguage;
}

// Funciones no puras
DateTime GetTomorrowNoArguments()
{
    return DateTime.Now.AddDays(1); // El valor de retorno no siempre será el mismo
}

ProgrammingLanguage ToUpper(ProgrammingLanguage language) 
{
    language.Name = language.Name.ToUpper(); // Modifica un valor externo
    return language;
}

class ProgrammingLanguage
{
    public string Name { get; set; }
}
*/

// Sexta parte - Funciones de primera clase, Actions y Funcs
/*
var myShowMessage = ShowMessage;
myShowMessage("Hello!");

var myReturnMessage = ReturnMessage;
Console.WriteLine(myReturnMessage("Hi, I'm learning C#!"));

RunTasks1(myShowMessage, "Haciendo una tarea intermedia...");
RunTasks2(myReturnMessage, "Terminando una tarea intermedia...");

void ShowMessage(String message)
{
    Console.WriteLine(message);
}

string ReturnMessage(String message)
{
    return message;
}

void RunTasks1(Action<string> fn, string message) // Action es un tipo que no retorna nada
{
    Console.WriteLine("Haciendo algo aquí...");
    fn(message);
    Console.WriteLine("Haciendo algo para terminar...");
}

void RunTasks2(Func<string, string> fn, string message) // Func es un tipo que retorna algo
{
    Console.WriteLine("Haciendo algo aquí...");
    Console.WriteLine(fn(message));
    Console.WriteLine("Haciendo algo para terminar...");
}
*/

// Séptima parte - Expresiones lambda
/*
// Útiles si se ejecutan una vez o si se pasan como argumento a una función de orden superior
Func<int, int, int> sub = (a, b) => a - b;
Func<int, int> valueX2 = a => a * 2;

Console.WriteLine(Some((a, b) => a + b, 5));

int Some(Func<int, int, int> fn, int number)
{
    var result = fn(number, number);
    return result;
}
*/

// Ocatava parte - LINQ
/*
// Primera parte: Origen de datos
var names = new List<string>()
{
    "Fernando", "Frida", "Valeria", "Karla"
};

// Segunda parte: Declaración de la consulta
var sortedNames1 = from n in names 
                  where n.Length > 5 // &&, ||
                  orderby n descending
                  select n;

// Equivalente a...
var sortedNames2 = names.Where(element => element.Length > 5)
                        .OrderByDescending(element => element)
                        .Select(element => element);

// Tercera parte: Ejecución de la consula
foreach (var name in sortedNames1)
{
    Console.WriteLine(name);
}

// Resultado sin usar LINQ
foreach (var name in sortedNames2)
{
    Console.WriteLine(name);
}
*/