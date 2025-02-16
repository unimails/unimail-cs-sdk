namespace PackageTest
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var client = UnimailCsSdk.Factory.New("");
            var checkConnection = client.CheckConnection();
            if (!checkConnection)
            {
                Console.WriteLine("连接失败");
            }

            var result = client.SendEmail("i_curve@qq.com", "nuget package test", "asdfival");
            Console.WriteLine($"?: {!result.IsError}, msg: {result.Msg}");
        }
    }
}