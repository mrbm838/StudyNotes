# TCP,IP,HTTP,SOCKET区别和联系

---
### 网络层次

可划分为[五层因特网协议栈](https://baike.baidu.com/item/五层因特网协议栈/8353884?fromModule=lemma_inlink)和七层因特网协议栈。

因特网协议栈共有五层：[应用层](https://baike.baidu.com/item/应用层/4329788?fromModule=lemma_inlink)、[传输层](https://baike.baidu.com/item/传输层/4329536?fromModule=lemma_inlink)、[网络层](https://baike.baidu.com/item/网络层/4329439?fromModule=lemma_inlink)、[链路层](https://baike.baidu.com/item/链路层/10624635?fromModule=lemma_inlink)和[物理层](https://baike.baidu.com/item/物理层/4329158?fromModule=lemma_inlink)。不同于[OSI七层模型](https://baike.baidu.com/item/OSI七层模型/9763441?fromModule=lemma_inlink)这也是实际使用中使用的分层方式。

（1）应用层

支持[网络应用](https://baike.baidu.com/item/网络应用/2196523?fromModule=lemma_inlink)，[应用协议](https://baike.baidu.com/item/应用协议/5927523?fromModule=lemma_inlink)仅仅是网络应用的一个组成部分，运行在不同主机上的进程则使用[应用层协议](https://baike.baidu.com/item/应用层协议/3668945?fromModule=lemma_inlink)进行通信。主要的协议有：http、ftp、telnet、smtp、pop3等。

（2）传输层

负责为信源和信宿提供[应用程序](https://baike.baidu.com/item/应用程序/5985445?fromModule=lemma_inlink)进程间的[数据传输](https://baike.baidu.com/item/数据传输/2987565?fromModule=lemma_inlink)服务，这一层上主要定义了两个[传输协议](https://baike.baidu.com/item/传输协议/8048821?fromModule=lemma_inlink)，传输控制协议即[TCP](https://baike.baidu.com/item/TCP/33012?fromModule=lemma_inlink)和用户数据报协议UDP。

（3）网络层

负责将[数据报](https://baike.baidu.com/item/数据报/2194617?fromModule=lemma_inlink)独立地从[信源](https://baike.baidu.com/item/信源/9032775?fromModule=lemma_inlink)发送到信宿，主要解决路由[选择](https://baike.baidu.com/item/选择/980212?fromModule=lemma_inlink)、[拥塞控制](https://baike.baidu.com/item/拥塞控制/732651?fromModule=lemma_inlink)和[网络互联](https://baike.baidu.com/item/网络互联/10501073?fromModule=lemma_inlink)等问题。

（4）[数据链路层](https://baike.baidu.com/item/数据链路层/4329290?fromModule=lemma_inlink)

负责将[IP数据报](https://baike.baidu.com/item/IP数据报/1581132?fromModule=lemma_inlink)封装成合适在[物理网络](https://baike.baidu.com/item/物理网络/6639862?fromModule=lemma_inlink)上传输的[帧格式](https://baike.baidu.com/item/帧格式/5921425?fromModule=lemma_inlink)并传输，或将从物理网络接收到的帧解封，取出IP数据报交给网络层。

（5）物理层

负责将[比特流](https://baike.baidu.com/item/比特流/6435599?fromModule=lemma_inlink)在结点间传输，即负责物理传输。该层的协议既与链路有关也与[传输介质](https://baike.baidu.com/item/传输介质/5538029?fromModule=lemma_inlink)有关。



### TCP,IP,HTTP

网络由下往上分为: 对应

　　物理层--

　　数据链路层--

　　网络层-- IP协议

　　传输层-- TCP协议

　　应用层-- HTTP协议

　　socket 则是对TCP/IP协议的封装和应用(程序员层面上)。也可以说，TPC/IP协议是传输层协议，主要解决数据 如何在网络中传输，而HTTP是应用层协议，主要解决如何包装数据。关于 TCP/IP和HTTP协议的关系，网络有一段比较容易理解的介绍：

　　“我们在传输数据时，可以只使用(传输层)TCP/IP协议，但是那样的话，如 果没有应用层，便无法识别数据内容，如果想要使传输的数据有意义，则必须使用到应用层协议，应用层协议有很多，比如HTTP、FTP、TELNET等，也 可以自己定义应用层协议。WEB使用HTTP协议作应用层协议，以封装HTTP文本信息，然后使用TCP/IP做传输层协议将它发到网络上。”

　　我们平时说的最多的socket是什么呢，实际上socket是对TCP/IP协议的封装，Socket本身并不是协议，而是一个调用接口(API)，通过Socket，我们才能使用TCP/IP协议。 实际上，Socket跟TCP/IP协议没有必然的联系。Socket编程接口在设计的时候，就希望也能适应其他的网络协议。所以说，Socket的出现 只是使得程序员更方便地使用TCP/IP协议栈而已，是对TCP/IP协议的抽象，从而形成了我们知道的一些最基本的函数接口，比如create、 listen、connect、accept、send、read和write等等。网络有一段关于socket和TCP/IP协议关系的说法比较容易理 解：

　　“TCP/IP只是一个协议栈，就像操作系统的运行机制一样，必须要具体实现，同时还要提供对外的操作接口。这个就像操作系统会提供标准的编程接口，比如win32编程接口一样，TCP/IP也要提供可供程序员做网络开发所用的接口，这就是Socket编程接口。”

　　总结一些基于基于TCP/IP协议的应用和编程接口的知识，也就是刚才说了很多的 HTTP和Socket。

　　==实际上，传输层的TCP是基于网络层的IP协议的，而应用层的HTTP协议又是基于传输层的TCP协议的，而Socket本身不算是协议，就像上面所说，它只是提供了一个针对TCP或者UDP编程的接口。==

### 什么是TCP连接的三次握手

　　第一次握手：客户端发送syn包(syn=j)到[服务器](https://product.pconline.com.cn/server/)，并进入SYN\_SEND状态，等待服务器确认;

　　第二次握手：服务器收到syn包，必须确认客户的SYN(ack=j+1)，同时自己也发送一个SYN包(syn=k)，即SYN+ACK包，此时服务器进入SYN\_RECV状态;

　　第三次握手：客户端收到服务器的SYN+ACK包，向服务器发送确认包ACK(ack=k+1)，此包发送完毕，客户端和服务器进入ESTABLISHED状态，完成三次握手。

　　握手过程中传送的包里不包含数据，三次握手完毕后，客户端与服务器才正式开始传送数据。理想状态下，TCP连接一旦建立，在通信双方中的任何一方主动关闭 连接之前，TCP 连接都将被一直保持下去。断开连接时服务器和客户端均可以主动发起断开TCP连接的请求，断开过程需要经过“四次握手”(过程就不细写了，就是服务器和客 户端交互，最终确定断开)

### 利用Socket建立网络连接的步骤

　　建立Socket连接至少需要一对套接字，其中一个运行于客户端，称为ClientSocket ，另一个运行于服务器端，称为ServerSocket 。

　　套接字之间的连接过程分为三个步骤：服务器监听，客户端请求，连接确认。

　　1。服务器监听：服务器端套接字并不定位具体的客户端套接字，而是处于等待连接的状态，实时监控网络状态，等待客户端的连接请求。

　　2。客户端请求：指客户端的套接字提出连接请求，要连接的目标是服务器端的套接字。为此，客户端的套接字必须首先描述它要连接的服务器的套接字，指出服务器端套接字的地址和端口号，然后就向服务器端套接字提出连接请求。

　　3。连接确认：当服 务器端套接字监听到或者说接收到客户端套接字的连接请求时，就响应客户端套接字的请求，建立一个新的线程，把服务器端套接字的描述发给客户端，一旦客户端 确认了此描述，双方就正式建立连接。而服务器端套接字继续处于监听状态，继续接收其他客户端套接字的连接请求。

### HTTP链接的特点

　　HTTP协议即超文本传送协议(Hypertext Transfer Protocol )，是Web联网的基础，也是[手机](https://product.pconline.com.cn/mobile/)联网常用的协议之一，HTTP协议是建立在TCP协议之上的一种应用。

　　HTTP连接最显著的特点是客户端发送的每次请求都需要服务器回送响应，在请求结束后，会主动释放连接。从建立连接到关闭连接的过程称为“一次连接”。

### TCP和UDP的区别

　　1。TCP是面向链 接的，虽然说网络的不安全不稳定特性决定了多少次握手都不能保证连接的可靠性，但TCP的三次握手在最低限度上(实际上也很大程度上保证了)保证了连接的 可靠性;而UDP不是面向连接的，UDP传送数据前并不与对方建立连接，对接收到的数据也不发送确认信号，发送端不知道数据是否会正确接收，当然也不用重 发，所以说UDP是无连接的、不可靠的一种数据传输协议。

　　2。也正由于1所说的特点，使得UDP的开销更小数据传输速率更高，因为不必进行收发数据的确认，所以UDP的实时性更好。

　　知道了TCP和 UDP的区别，就不难理解为何采用TCP传输协议的MSN比采用UDP的QQ传输文件慢了，但并不能说QQ的通信是不安全的，因为程序员可以手动对UDP 的数据收发进行验证，比如发送方对每个数据包进行编号然后由接收方进行验证啊什么的，即使是这样，UDP因为在底层协议的封装上没有采用类似TCP的“三次握手”而实现了TCP所无法达到的传输效率。

### WebService到底是什么

  一言以蔽之：**WebService是一种跨编程语言和跨操作系统平台的远程调用技术。**

XML+XSD,SOAP和WSDL就是构成WebService平台的三大技术。

#### 1、XML+XSD

　　WebService采用HTTP协议传输数据，采用XML格式封装数据（即XML中说明调用远程服务对象的哪个方法，传递的参数是什么，以及服务对象的 返回结果是什么）。XML是WebService平台中表示数据的格式。除了易于建立和易于分析外，XML主要的优点在于它既是平台无关的，又是厂商无关 的。无关性是比技术优越性更重要的：软件厂商是不会选择一个由竞争对手所发明的技术的。 

　　XML解决了数据表示的问题，但它没有定义一套标准的数据类型，更没有说怎么去扩展这套数据类型。例如，整形数到底代表什么？16位，32位，64位？这 些细节对实现互操作性很重要。XML Schema(XSD)就是专门解决这个问题的一套标准。它定义了一套标准的数据类型，并给出了一种语言来扩展这套数据类型。WebService平台就 是用XSD来作为其数据类型系统的。当你用某种语言(如VB.NET或C#)来构造一个Web service时，为了符合WebService标准，所 有你使用的数据类型都必须被转换为XSD类型。你用的工具可能已经自动帮你完成了这个转换，但你很可能会根据你的需要修改一下转换过程。

#### 2、SOAP

  WebService通过HTTP协议发送请求和接收结果时，发送的请求内容和结果内容都采用XML格式封装，并增加了一些特定的HTTP消息头，以说明 HTTP消息的内容格式，这些特定的HTTP消息头和XML内容格式就是SOAP协议。SOAP提供了标准的RPC方法来调用Web Service。

 **SOAP协议 = HTTP协议 + XML数据格式**

 SOAP协议定义了SOAP消息的格式，SOAP协议是基于HTTP协议的，SOAP也是基于XML和XSD的，XML是SOAP的数据编码方式。打个比 喻：HTTP就是普通公路，XML就是中间的绿色隔离带和两边的防护栏，SOAP就是普通公路经过加隔离带和防护栏改造过的高速公路。

#### 3、WSDL

　　好比我们去商店买东西，首先要知道商店里有什么东西可买，然后再来购买，商家的做法就是张贴广告海报。 WebService也一样，WebService客户端要调用一个WebService服务，首先要有知道这个服务的地址在哪，以及这个服务里有什么方 法可以调用，所以，WebService务器端首先要通过一个WSDL文件来说明自己家里有啥服务可以对外调用，服务是什么（服务中有哪些方法，方法接受 的参数是什么，返回值是什么），服务的网络地址用哪个url地址表示，服务通过什么方式来调用。

　　WSDL(Web Services Description Language)就是这样一个基于XML的语言，用于描述Web Service及其函数、参数和返回值。它是WebService客户端和服务器端都 能理解的标准格式。因为是基于XML的，所以WSDL既是机器可阅读的，又是人可阅读的，这将是一个很大的好处。一些最新的开发工具既能根据你的 Web service生成WSDL文档，又能导入WSDL文档，生成调用相应WebService的代理类代码。

　　WSDL 文件保存在Web服务器上，通过一个url地址就可以访问到它。客户端要调用一个WebService服务之前，要知道该服务的WSDL文件的地址。 WebService服务提供商可以通过两种方式来暴露它的WSDL文件地址：1.注册到UDDI服务器，以便被人查找；2.直接告诉给客户端调用者。
