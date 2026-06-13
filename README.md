# unimail-cs-sdk

> The current SDK version is v2. If you need to use the previous v1 version, please switch to the v1 branch.

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
<PackageReference Include="UnimailCsSdk" Version="1.0.0" />
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

        var checkConnection = await client.CheckConnectionAsync()GetAwaiter().GetResult();
        if (!checkConnection)
        {
            Console.WriteLine("connect error");
            return;
        }
        Console.WriteLine("connect success");
    }
}
```

- send email

```cs
    var req = new UnimailReq {
        // From = "Notice",
        Receivers = new List<string> { "email1", "email2" },
        // Cc = "",
        // Bcc = "",
        Subject = "cs sdk test",
        TxtContent = "this is an email from unimail-cs-sdk project",
        HtmlContent = "<div>html content</div>"
    };
    // add file attachment
    req.AppendFile("test.txt", "./attachment.txt");
    // add uri attachment
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

## support language

chinese is the default language for the sdk.

- [x] english (en)
- [x] simple chinese (zh)
- [x] vietnamese (vi)
- [x] idonesian (id)
- [x] thai (th)
- [x] gujarati (gu)

if you want to support other language, please open a issue.

- tips

> If you want to use this SDK, please contact the author via i-curve@qq.com.
