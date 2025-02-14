# unimail-cs-sdk

unimail 的 cs 语言 sdk, 快速集成到你的项目

[english docs](README.md)

<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

<!-- code_chunk_output -->

- [unimail-cs-sdk](#unimail-cs-sdk)
  - [简单使用](#简单使用)
  - [api docs](#api-docs)
  - [支持的语言](#支持的语言)

<!-- /code_chunk_output -->

## 简单使用

- 安装

```shell
<PackageReference Include="UnimailCsSdk" Version="0.1.0" />
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

        var checkConnection = await client.CheckConnection();
        if (!checkConnection)
        {
            Console.WriteLine("connect error");
            return;
        }
        Console.WriteLine("connect success");




        Console.WriteLine(sendResult);
    }
}
```

- 发邮件

例如
收件人: aaa@gmail.com  
邮件标题: email subject  
邮件正文: this is a email content

```cs
    var sendResult = await client.SendEmail("i-curve@qq.com", "cs sdk test",
        "this is a email from unimail-cs-sdk project.");
    if (sendResult.IsError)
    {
        Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
    }
```

- 批量发送邮件

例如
收件人: aaa@gmail.com,bbb@gmail.com  
邮件标题: email subject  
邮件正文: this is a email content

```cs
    var sendResult = await client.BatchSendEmail(new List<string>()
        {
            "i-curve@qq.com", "i_curve@qq.com"
        }, "cs batch sdk test",
        "this is a batch email from unimail-cs-sdk project");
    if (sendResult.IsError)
    {
        Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
    }
```

## api docs

1. UnimailClient Factory.New(string key)

init a client by key

2. UnimailError client.SetLanguage(string language)

set language for the client, default is zh

3. Task<Boolean> client.CheckConnect()

check the host and key is ok

4. UnimailError client.SendEmail(string receiver,string subject, string content)

send email to receiver. if you have many receiver, you can concat the receiver by ";" or use BatchSendEmail

5. UnimailError client.BatchSendEmail(List<string> receivers,string subject,string content)

like SendEmail, but receivers is a slice

## 支持的语言

sdk 默认返回的 msg 为中文

- [x] english (en)
- [x] simple chinese (zh)
- [x] vietnamese (vi)
- [x] idonesian (id)
- [x] thai (th)
- [x] gujarati (gu)

如果你需要添加了更多语言，欢迎提 issue
