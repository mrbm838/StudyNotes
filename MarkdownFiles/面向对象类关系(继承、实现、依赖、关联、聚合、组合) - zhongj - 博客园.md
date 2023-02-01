---
created: 2023-02-01T19:20:04 (UTC +08:00)
tags: []
source: https://www.cnblogs.com/zhongj/p/11169780.html
author: zhongj
---

# [面向对象类关系(继承、实现、依赖、关联、聚合、组合)](https://www.cnblogs.com/zhongj/p/11169780.html)

 在进行一个OO系统设计时候我们需要根据系统的需求来抽象出一些类，并且设计类与类之间的关系，也就是我们常说的业务建模，设计优良的类间关系是实现我们常说的“高内聚，低耦合”系统的前提条件，这里我就来梳理下面向对象中类与类有哪几种关系和它们的使用场景。

## 继承(泛化Generalization)

### 1.概念

 指的是一个类（称为子类、子接口）继承另外的一个类（称为父类、父接口）的功能，在Java中使用extends关键字实现,如果继承的父类是抽象类，并且父类中有抽象方法，抽象方法必须在子类(这里子类是非抽象类，如果是抽象类可以不必实现)中实现，在Java中一个子类只能继承一个父类。

### 2.图例

![Object_Oriented_Generalization](https://gitee.com/mrbm868/graphic-bed/raw/master/img/Object_Oriented_Generalization.png)

### 3.代码

[https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/generalization](https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/generalization)

## 实现(Realization)

### 1.概念

 指的是一个类实现一个接口的功能，在Java中一个类可以实现多个接口，使用implements作为关键字。

### 2.图例

![Object_Oriented_Realization](https://gitee.com/mrbm868/graphic-bed/raw/master/img/Object_Oriented_Realization.png)

### 3.代码

[https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/realization](https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/realization)

## 依赖(Dependency)

### 1.概念

 指两个相对独立的对象，当一个对象负责构造另一个对象的实例，或者依赖另一个对象的服务时，这两个对象之间主要体现为依赖关系。在Java中，类A当中使用了类B，其中类B是作为类A的方法参数、方法中的局部变量、或者静态方法调用。

### 2.图例

![Object_Oriented_Dependency](https://gitee.com/mrbm868/graphic-bed/raw/master/img/Object_Oriented_Dependency.png)

### 3.代码

[https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/dependency](https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/dependency)

## 关联(Association)

### 1.概念

 指一个类的实例A使用另外一个类的实例B，这两个对象之间为关联关系，关联关系分为单项关联和双向关联。在Java中，单向关联表现为：类A当中使用了类B，其中B作为类A的成员变量。双向关联表现为：类A当中使用了类B作为成员变量；同时类B中也使用了类A作为成员变量。

### 2.图例

![Object_Oriented_Association](https://gitee.com/mrbm868/graphic-bed/raw/master/img/Object_Oriented_Association.png)

### 3.代码

[https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/association](https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/association)

## 聚合(Aggregation)

### 1.概念

 聚合关系是关联关系的一种，耦合度强于关联，他们的代码表现是相同的，仅仅是在语义上有所区别：关联关系的对象间是相互独立的，而聚合关系的对象之间存在着包容关系，他们之间是“整体-个体”的相互关系。

### 2.图例

![Object_Oriented_Aggregation](https://gitee.com/mrbm868/graphic-bed/raw/master/img/Object_Oriented_Aggregation.png)

### 3.代码

[https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/aggregation](https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/aggregation)

## 组合(Compostion)

### 1.概念

 相比于聚合，组合是一种耦合度更强的关联关系。存在组合关系的类表示“整体-部分”的关联关系，“整体”负责“部分”的生命周期，他们之间是共生共死的；并且“部分”单独存在时没有任何意义。

### 2.图例

![Object_Oriented_Composition](https://gitee.com/mrbm868/graphic-bed/raw/master/img/Object_Oriented_Composition.png)

### 3.代码

[https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/compostion](https://github.com/lanhei/DesignPattern/tree/master/src/com/lanhei/relation/compostion)

-   分类 [设计模式](https://www.cnblogs.com/zhongj/category/1498863.html)
