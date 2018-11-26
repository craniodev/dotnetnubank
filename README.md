NuBank API with RestSharp
==========
Not related to NuBank Inc.

## Install
```
Copy class "NuBank.cs" to your project
```

## Is it ok to use this? NuBank won't block me?

As of this tweet, seems that there is no problem in using this!
https://twitter.com/nubankbrasil/status/766665014161932288

# Usage

```csharp
     
    [TestMethod]
    public void GetWholeFeed()
    {
      var nubanck = new NuBank();

      const string login = "[your CPF]";
      const string password = "[your password]";
      // First of all you need to sign in to your account using your credentials
      var token = nubanck.GetLoginToken(login, password);
      Assert.IsNotNull(token);
      
      // Get whole your feeds
      var feed = nubanck.GetWholeFeed();
      Assert.IsNotNull(feed);

      Console.WriteLine("Feed:");
      Console.WriteLine(feed);
    }      
      
```


## Thanks
For NuBank for having such a great API! 

## Notes
This API _IS NOT_ a official API from NuBank Inc. but it does use the same REST api that
their web app uses.

## Contribute
Send your pull requests :wink:
