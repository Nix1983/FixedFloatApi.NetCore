# FixedFloatApi.NetCore 

.Net Core library for accessing the [FixedFloat Api](https://fixedfloat.com/api) for C#/NET.

## Installation
Use the nuget package manager to install
```bash
Install-Package FixedFloatApi -Version 1.0.0
```

## Usage
For this API you need a [API KEY](https://fixedfloat.com/?ref=3s9m95mc) <br />

To see how this library is used, I recommend the Unittest Project. Every function is used.<br /><br/>

<b> All functions can also called async</b>
```c#
//get a client
 var auth = new Authentication("Your Key", "Your Secret");
 var client = FixedFloatClient.Instance(auth);

//get available currencies
var cur = client.GetCurrencies();

//get pair
var pair = new PairRequest("btc", "eth", 0.5);
var result = client.GetPair(pair);

//get price
var price = new PriceRequest("btc", "eth", "0.3", ExchangeType.Fixed, 0);
var result = client.GetPrice(price));

//create order
 var order = new CreateOrderRequest("btc", "eth", "0.3", "0x6E2876b9d7aa6b877d77643D962F0c3237Bf023f", ExchangeType.Fixed);
 var result = client.CreateOrder(order);
 
//get order status
var order = new GetOrderRequest("Your Valid Id", "Your Valid token"); // you get id and token from CreateOrder response
var result = client.GetOrder(order);
 
```




## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


## Buy me new socks
[BTC] 31hA6mRWcGihPhiuChqerESdazQJgbbjeb <br />
[ETH] 0x6E2876b9d7aa6b877d77643D962F0c3237Bf023f <br />
[LTC] MNFzK7SAXiRTzvQwjynsAioKectM42jev6<br />
[GRS] grs1qaspw4a89arun2vw2tceur8f542ceyw6wjn35nr <br />
[Doge] D9V1LUdQV8EakUjfHH9rAzFzLeNGWoqTXr <br />
[Dash] XfQtuiiLsiDnGFwKgLWXKJFtBh9EGMfKWH <br />
