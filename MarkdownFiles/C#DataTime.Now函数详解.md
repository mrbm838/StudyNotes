---
created: 2023-03-15T22:56:02 (UTC +08:00)
tags: [c# datetime.now]
source: https://blog.csdn.net/qq_44034384/article/details/105599611
author: 成就一亿技术人!
---

# (2条消息) C#中DataTime.Now函数详解_c# datetime.now_何极光的博客-CSDN博客

> ## Excerpt
> C#中DataTime.Now函数详解一、获取日期+时间DateTime.Now.ToString();            // 2020/4/18 15:35:15DateTime.Now.ToLocalTime().ToString();        // 2020/4/18 15:35:47  取得当前系统日期和时间，格式根据本机设定的地区和语言来定二、获取日期DateTi...

---
![](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

[何极光](https://luckylifes.blog.csdn.net/ "何极光") ![](https://csdnimg.cn/release/blogv2/dist/pc/img/newCurrentTime2.png) 于 2020-04-18 15:49:52 发布 ![](https://csdnimg.cn/release/blogv2/dist/pc/img/articleReadEyes2.png) 2814 ![](https://csdnimg.cn/release/blogv2/dist/pc/img/tobarCollectionActive2.png) 已收藏 17

版权声明：本文为博主原创文章，遵循 [CC 4.0 BY-SA](http://creativecommons.org/licenses/by-sa/4.0/) 版权协议，转载请附上原文出处链接和本声明。

## C#中DataTime.Now函数详解

**一、获取日期+时间**

```
DateTime.Now.ToString();            // 2020/4/18 15:35:15
DateTime.Now.ToLocalTime().ToString();        // 2020/4/18 15:35:47  取得当前系统日期和时间，格式根据本机设定的地区和语言来定
```

**二、获取日期**

```
DateTime.Now.ToLongDateString().ToString();    // 2008年9月4日
DateTime.Now.ToShortDateString().ToString();    // 2008-9-4
DateTime.Now.ToString("yyyy-MM-dd");        // 2008-09-04
DateTime.Now.Date.ToString();            // 2008-9-4 0:00:00
```

**三、获取时间**

```
DateTime.Now.ToLongTimeString().ToString();   // 20:16:16
DateTime.Now.ToShortTimeString().ToString();   // 20:16
DateTime.Now.ToString("hh:mm:ss");        // 08:05:57
DateTime.Now.TimeOfDay.ToString();        // 20:33:50.7187500
```

**四、其他**

```
DateTime.ToFileTime().ToString();       // 128650040212500000
DateTime.Now.ToFileTimeUtc().ToString();   // 128650040772968750
DateTime.Now.ToOADate().ToString();       // 39695.8461709606
DateTime.Now.ToUniversalTime().ToString();   // 2020/4/18 7:46:51

DateTime.Now.Year.ToString();          获取年份   // 2020
DateTime.Now.Month.ToString();      获取月份   // 4
DateTime.Now.DayOfWeek.ToString(); 获取星期   // Saturday
DateTime.Now.DayOfYear.ToString(); 获取第几天   // 109
DateTime.Now.Hour.ToString();          获取小时   // 15
DateTime.Now.Minute.ToString();     获取分钟   // 45
DateTime.Now.Second.ToString();     获取秒数   // 31

//n为一个数,可以数整数,也可以事小数
dt.AddYears(n).ToString();   //时间加n年
dt.AddDays(n).ToString();   //加n天
dt.AddHours(n).ToString();   //加n小时
dt.AddMonths(n).ToString();   //加n个月
dt.AddSeconds(n).ToString();   //加n秒
dt.AddMinutes(n).ToString();   //加n分
```
