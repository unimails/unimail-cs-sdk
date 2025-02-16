using UnimailCsSdk;

namespace localTest
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var client = UnimailCsSdk.Factory.New("");
            test(client);
            await testAsync(client);
        }

        private static async Task testAsync(UnimailClient client)
        {
            //client.
            var res = client.SetLanguage("en");
            if (res.IsError)
            {
                Console.WriteLine(res);
                return;
            }

            var checkConnection = await client.CheckConnectionAsync();
            if (!checkConnection)
            {
                Console.WriteLine("连接失败");
                return;
            }
            Console.WriteLine("连接成功");

            //var sendResult = await client.SendEmail("i-curve@qq.com", "cs sdk test",
            //    "this is a email from unimail-cs-sdk project.");

            var sendResult = await client.BatchSendEmailAsync(new List<string>()
                {
                    "i-curve@qq.com", "i_curve@qq.com"
                }, "cs batch sdk test",
                "this is a batch email from unimail-cs-sdk project");
            if (sendResult.IsError)
            {
                Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
            }

            Console.WriteLine(sendResult);
        }

        private static void test(UnimailClient client)
        {
            //client.
            var res = client.SetLanguage("en");
            if (res.IsError)
            {
                Console.WriteLine(res);
                return;
            }

            var checkConnection = client.CheckConnection();
            if (!checkConnection)
            {
                Console.WriteLine("连接失败");
                return;
            }
            Console.WriteLine("连接成功");

            //var sendResult = await client.SendEmail("i-curve@qq.com", "cs sdk test",
            //    "this is a email from unimail-cs-sdk project.");

            var sendResult = client.BatchSendEmail(new List<string>()
                {
                    "i-curve@qq.com", "i_curve@qq.com"
                }, "cs batch sdk test",
                "this is a batch email from unimail-cs-sdk project");
            if (sendResult.IsError)
            {
                Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
            }

            Console.WriteLine(sendResult);
        }
    }
}