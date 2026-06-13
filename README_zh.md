# unimail-cs-sdk

> 当前sdk的版本是v2, 如果你需要用以前的v1版本, 请切换v1分支

unimail 的 cs 语言 sdk, 快速集成到你的项目

[english docs](README.md)

<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

<!-- code_chunk_output -->

- [unimail-cs-sdk](#unimail-cs-sdk)
  - [使用](#使用)
  - [api docs](#api-docs)
  - [支持的语言](#支持的语言)

<!-- /code_chunk_output -->

## 使用

- 安装

```shell
<PackageReference Include="UnimailCsSdk" Version="1.0.0" />
```

- 初始化客户端

你需要申请一个 key

```cs
internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var client = UnimailCsSdk.Factory.New("write your key");
        if (res.IsError)
        {
            Console.WriteLine(res);
            return;
        }

        var checkConnection = await client.CheckConnectionAsync().GetAwaiter().GetResult();
        if (!checkConnection)
        {
            Console.WriteLine("connect error");
            return;
        }
        Console.WriteLine("connect success");
    }
}
```

- 发邮件

```cs
    var req = new UnimailReq {
        // From = "通知",
        Receivers = new List<string> { "email1", "email2" },
        // Cc = "",
        // Bcc = "",
        Subject = "cs sdk test",
        TxtContent = "this is an email from unimail-cs-sdk project",
        HtmlContent = "<div>html content</div>"
    };
    // 添加文件附件
    req.AppendFile("test.txt", "./attachment.txt");
    // 添加uri附件
    // req.AppendUri("text2.txt", "https://...");
    var sendResult = client.SendEmailAsync(req).GetAwaiter().GetResult();
    if (sendResult.IsError) {
        Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
    }
```

## api docs

1. UnimailClient Factory.New(string key)

init a client by key

2. UnimailError client.SetLanguage(string language)

set language for the client, default is zh

3. Task<Boolean> client.CheckConnectAsync()

check the host and key is ok

4. Task<UnimailError> client.SendEmailAsync(UnimailReq req)

please see usage

## 支持的语言

sdk 默认返回的 msg 为中文

- [x] english (en)
- [x] simple chinese (zh)
- [x] vietnamese (vi)
- [x] idonesian (id)
- [x] thai (th)
- [x] gujarati (gu)

如果你需要添加了更多语言，欢迎提 issue
