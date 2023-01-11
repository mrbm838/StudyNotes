---
created: 2023-01-07T13:44:26 (UTC +08:00)
tags: [c#,dictionary,key-value]
source: https://qa.1r1g.com/sf/ask/317722611/
author: 
---

# 根据值获取C#字典中键/值对的索引 |

> ## Excerpt
> 如何解决根据值获取C#字典中键/值对的索引经验，为你挑选了4个好方法。

---
[Jon\*\_\*eet](https://qa.1r1g.com/sf/users/1585951/ "Jon*_*eet") 31

在字典中没有"索引"这样的概念 - 它从根本上是无序的.当然,当你迭代它时,你会得到_某些_顺序的项目,但是这个顺序不能保证,并且可以随着时间的推移而改变(特别是如果你添加或删除条目).

显然你可以`KeyValuePair`通过使用`Key`属性来获取密钥,这样就可以使用字典的索引器了:

```
var pair = ...;
var value = dictionary[pair.Key];
Assert.AreEqual(value, pair.Value);
```

你还没有真正说出你想要做的事情.如果您正在尝试查找与特定值对应的某个键,则可以使用:

```
var key = dictionary.Where(pair => pair.Value == desiredValue)
                    .Select(pair => pair.Key)
                    .FirstOrDefault();
```

`key` 如果条目不存在,则为null.

这假设键类型是引用类型...如果它是值类型,则需要稍微不同地执行操作.

当然,如果你真的想按键查找值,你应该考虑使用另一个字典,除了你现有的字典之外,它还会相反地映射.

___

[Eri\*\_\*icM](https://qa.1r1g.com/sf/users/369502801/ "Eri*_*icM") 25

假设您有一个名为fooDictionary的词典

```
fooDictionary.Values.ToList().IndexOf(someValue);
```

Values.ToList()将您的字典值转换为someValue对象的List.

IndexOf(someValue)搜索新列表,查找有问题的someValue对象,并返回与字典中键/值对的索引匹配的索引.

此方法不关心字典键,它只返回您要查找的值的索引.

但是,这并不能解决可能存在多个匹配的"someValue"对象的问题.

___

[max\*\_\*max](https://qa.1r1g.com/sf/users/24970151/ "max*_*max") 9

考虑使用[`System.Collections.Specialized.OrderedDictionary`](http://msdn.microsoft.com/en-us/library/system.collections.specialized.ordereddictionary.aspx),虽然它不是通用的,或实现自己的([例子](http://www.codeproject.com/KB/recipes/GenericOrderedDictionary.aspx)).

`OrderedDictionary`不支持`IndexOf`,但它很容易实现:

```
public static class OrderedDictionaryExtensions
{
    public static int IndexOf(this OrderedDictionary dictionary, object value)
    {
        for(int i = 0; i < dictionary.Count; ++i)
        {
            if(dictionary[i] == value) return i;
        }
        return -1;
    }
}
```

___

[mal\*\_\*sis](https://qa.1r1g.com/sf/users/121717361/ "mal*_*sis") 5

```
    您可以在字典中按键/值查找索引

```

```
Dictionary<string, string> myDictionary = new Dictionary<string, string>();
myDictionary.Add("a", "x");
myDictionary.Add("b", "y");
int i = Array.IndexOf(myDictionary.Keys.ToArray(), "a");
int j = Array.IndexOf(myDictionary.Values.ToArray(), "y");
```

___
