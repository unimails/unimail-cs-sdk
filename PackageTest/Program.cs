namespace PackageTest {
    internal class Program {
        private static async Task Main(string[] args) {
            Console.WriteLine("Hello, World!");
            var client = UnimailCsSdk.Factory.New("");
            var checkConnection = await client.CheckConnectionAsync();
            if (!checkConnection) {
                Console.WriteLine("连接失败");
            }

            var result = await client.SendEmailAsync("i_curve@qq.com", "nuget package test", "asdfival");
            Console.WriteLine($"?: {!result.IsError}, msg: {result.Msg}");

            //result = await client.BatchSendEmailAsync(new() { "i_curve@qq.com", "i-curve@qq.com" }, "nuget package test", "batch send, asdfival");
            //Console.WriteLine($"?: {!result.IsError}, msg: {result.Msg}");

            Console.ReadLine();
        }
    }
}