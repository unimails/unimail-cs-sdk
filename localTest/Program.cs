using UnimailCsSdk;

namespace localTest {
    internal class Program {
        private static async Task Main(string[] args) {
            var client = UnimailCsSdk.Factory.New("");
            test(client);
        }

        private static void test(UnimailClient client) {
            //client.
            var res = client.SetLanguage("en");
            if (res.IsError) {
                Console.WriteLine(res);
                return;
            }

            var checkConnection = client.CheckConnectionAsync().GetAwaiter().GetResult();
            if (!checkConnection) {
                Console.WriteLine("连接失败");
                return;
            }
            Console.WriteLine("连接成功");

            var req = new UnimailReq {
                // From = "",
                Receivers = new List<string> { "email1", "email2" },
                // Cc = "email3",
                // Bcc = "email4",
                Subject = "cs sdk test",
                TxtContent = "this is an email from unimail-cs-sdk project",
                HtmlContent = "<div class=\"otQkpb\" aria-level=\"3\" role=\"heading\" data-animation-nesting=\"\" data-sfc-cp=\"\" jsaction=\"\" jscontroller=\"a7qCn#ZxCkTb\" data-sfc-root=\"c\" jsuid=\"GvYoab_k\" data-sfc-cb=\"\">优秀范文：Technology and Human Connection<span jsuid=\"GvYoab_l\" class=\"DHPVt Wg1cdb notranslate\" jsaction=\"rcuQ6b:&amp;GvYoab_l|npT2md\" data-wiz-attrbind=\"class=GvYoab_l/R4Tih\" jscontroller=\"XqmSxe#JjQTXe\" data-sfc-root=\"c\" data-wiz-uids=\"GvYoab_m,GvYoab_n\" data-sfc-cb=\"\"><span class=\"NMq1me\" data-animation-atomic=\"\" data-wiz-attrbind=\"class=GvYoab_l/TKHnVd\"><span aria-hidden=\"true\"><!--BVUQsc GvYoab_l/kMntnd-->&nbsp;<!--BipLCb GvYoab_l/kMntnd--></span><!--qkimaf GvYoab_l/HugV6--><!--cqw1tb GvYoab_l/HugV6--><button jsuid=\"GvYoab_n\" tabindex=\"0\" disabled=\"true\" data-amic=\"true\" data-icl-uuid=\"9b0ace91-c2bb-426a-be4b-d8c1a92afd4f\" aria-label=\"查看相关链接\" class=\"vDOt8c\" jsaction=\"click:&amp;GvYoab_l|S9kKve;mouseenter:&amp;GvYoab_l|sbHm2b;mouseleave:&amp;GvYoab_l|Tx5Rb\" data-wiz-attrbind=\"disabled=GvYoab_l/C5gNJc;aria-label=GvYoab_l/bOjMyf;class=GvYoab_l/UpSNec\" data-ved=\"2ahUKEwjUu63X5YOVAxUama8BHWIuFEgQye0OegoIAggACAAIAxAA\" data-hveid=\"CAIIAAgACAMQAA\"><span class=\"pxxQye T6UJT\"><div class=\"a14YJe\" jsaction=\"\" jscontroller=\"sRLmTc#WhfBh\" data-sfc-root=\"c\" jsuid=\"GvYoab_o\" data-sfc-cb=\"\"><svg xmlns=\"http://www.w3.org/2000/svg\" fill=\"currentColor\" height=\"12px\" viewBox=\"0 -960 960 960\" width=\"12px\"><path d=\"M440-280H280q-83 0-141.5-58.5T80-480q0-83 58.5-141.5T280-680h160v80H280q-50 0-85 35t-35 85q0 50 35 85t85 35h160v80ZM320-440v-80h320v80H320Zm200 160v-80h160q50 0 85-35t35-85q0-50-35-85t-85-35H520v-80h160q83 0 141.5 58.5T880-480q0 83-58.5 141.5T680-280H520Z\"></path></svg><!--TgQPHd||[]--></div></span><div jsuid=\"GvYoab_m\" style=\"display: none;\" data-ved=\"2ahUKEwjUu63X5YOVAxUama8BHWIuFEgQlZkRegoIAggACAAIAxAB\"></div></button></span><!--TgQPHd||[[&quot;9b0ace91-c2bb-426a-be4b-d8c1a92afd4f&quot;,null,null,0,&quot;&quot;,&quot;&quot;,0,null,null,null,null,0]]--></span><!--TgQPHd||[]--></div>"
            };
            req.AppendFile("test.txt", "./attachment.txt");
            var sendResult = client.SendEmailAsync(req).GetAwaiter().GetResult();
            if (sendResult.IsError) {
                Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
            }

            Console.WriteLine(sendResult);
        }
    }
}