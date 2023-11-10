using System.Threading;
using System.Threading.Tasks;
class Proga
{
    static async Task WriteToFileAsync(string Data, string Filename)
    {
        using (StreamWriter writer = new StreamWriter(Filename))
        {
            await writer.WriteLineAsync(Data);
        }
    }
    static void DoOthertask()
    {
        int g = 0;
        Console.WriteLine($"Запись завершена на {g}%");
        for (int i = 9; i >=0; i--)
        {
            g += 10;
            Console.WriteLine($"Запись завершена на {g}%");
        }
        Console.WriteLine($"Запись завершена");
    }
    static async Task Main()
    {
        try
        {
            Console.WriteLine("Введите название файла");
            string Filename = Console.ReadLine();
            Console.WriteLine("Введите данные в файл");
            string Data = Console.ReadLine();
            Console.WriteLine("Ожидание записи");
            DoOthertask();
            Console.WriteLine("Если хотите Добавить в файл новые данные введите 1");
            string r = Console.ReadLine();
            if (r == "1")
            {
                Console.WriteLine("Введите новую информацию в файл");
                string nData = Console.ReadLine();
                Data += nData;
            }
            Task task = WriteToFileAsync(Data, $"{Filename}.txt");
            DoOthertask();
            await task;
        }
        catch 
        {
            Console.WriteLine("Не тем вы занимаетесь");
        }

    }
}
