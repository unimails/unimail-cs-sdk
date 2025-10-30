# unimail-cs-sdk

This is a c# SDK for Unimail. Quickly integrate into your project

[中文文档](README_zh.md)

<!-- @import "[TOC]" {cmd="toc" depthFrom=1 depthTo=6 orderedList=false} -->

<!-- code_chunk_output -->

- [unimail-cs-sdk](#unimail-cs-sdk)
  - [simple usage](#simple-usage)
  - [api docs](#api-docs)
  - [support language](#support-language)

<!-- /code_chunk_output -->

## simple usage

- install

```shell
<PackageReference Include="UnimailCsSdk" Version="0.3.0" />
```

- init a unimail client

you need a authorization key.

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

        var checkConnection = await client.CheckConnectionAsync();
        if (!checkConnection)
        {
            Console.WriteLine("连接失败");
            return;
        }
        Console.WriteLine("连接成功");
    }
}
```

- send email

example
receiver: aaa@gmail.com  
email subject: email subject  
email content: this is a email content

```cs
    var sendResult = await client.SendEmailAsync("i-curve@qq.com", "cs sdk test",
        "this is a email from unimail-cs-sdk project.");
    if (sendResult.IsError)
    {
        Console.WriteLine($"send email fail, the message is {sendResult.Msg}");
    }
```

- batch send email

example
receivers: aaa@gmail.com,bbb@gmail.com  
email subject: email subject  
email content: this is a email content

```cs
    var sendResult = await client.BatchSendEmailAsync(new List<string>()
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

3. Task<Boolean> client.CheckConnectAsync()

check the host and key is ok

4. Task<UnimailError> client.SendEmailAsync(string receiver,string subject, string content)

send email to receiver. if you have many receiver, you can concat the receiver by ";" or use BatchSendEmail

5. Task<UnimailError> client.BatchSendEmailAsync(List<string> receivers,string subject,string content)

like SendEmail, but receivers is a slice

## support language

chinese is the default language for the sdk.

- [x] english (en)
- [x] simple chinese (zh)
- [x] vietnamese (vi)
- [x] idonesian (id)
- [x] thai (th)
- [x] gujarati (gu)

if you want to support other language, please open a issue.
