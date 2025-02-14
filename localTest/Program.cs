namespace localTest
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var client = UnimailCsSdk.Factory.New("");
            //client.
            var res = client.SetLang("zh");
            if (res.IsError)
            {
                Console.WriteLine(res);
                return;
            }

            var checkConnection = await client.CheckConnection();
            if (!checkConnection)
            {
                Console.WriteLine("连接失败");
                return;
            }
            Console.WriteLine("连接成功");

            //var sendResult = await client.SendEmail("i-curve@qq.com", "cs sdk test",
            //    "this is a email from unimail-cs-sdk project.");

            var sendResult = await client.BatchSendEmail(new List<string>()
                {
                    "i-curve@qq.com", "i_curve@qq.com"
                }, "cs batch sdk test",
                "this is a batch email from unimail-cs-sdk project");
            Console.WriteLine(sendResult);
        }
    }
}