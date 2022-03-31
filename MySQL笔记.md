# MySQL笔记

## 一、安装和启动

[MySQL :: MySQL Community Downloads](https://dev.mysql.com/downloads/)

安装类型选择Custom，即可自定义安装。

启动/关闭 MySQL服务

```powershell
C:\WINDOWS\system32>net start mysql80
C:\WINDOWS\system32>net stop mysql80
```

连接到数据库

1. cmd

   ```powershell
   MySQL -h 127.0.0.1 -P 3306 -u root -p
   mysql -u root -p
   123456
   ```

   此方式需要配置环境变量C:\Program Files\MySQL\MySQL Server 8.0\binch

2. MySQL 8.0 command line client -Unicode

## 二、SQL

##### 1.SQL语句不区分大小写，关键字建议大写

##### 2.注释

1. 单行： -- 注释内容

   \# 注释内容（SQL特有）

2. 多行：/* 注释内容  */

##### 3.分类

1. DDL：数据定义语言，用来定义数据库对象（数据库、表、字段）
2. DML：数据操作语言，用来对数据库表中的数据进行增删改
3. DQL：数据查询语言，用来查询数据库中表的记录
4. DCL：数据控制语言，用来创建数据库用户、控制数据库的访问权限

##### 4.DDL

###### （1）数据库的操作

1. 查询

   查询所有数据库

   ```sql
   SHOW DATABASES;
   ```

   查询当前数据库

   ```sql
   SELECT DATABASE();
   ```

2. 创建

   ```sql
   CREATE DATABASE [IF NOT EXISTS] 数据库名 [DEFAULT CHARSET 字符集] [COLLATE 排序规则];
   -- 创建db_Test数据库
   CREATE DATABASE IF NOT EXISTS db_Test DEFAULT CHARSET utf8mb4;
   ```

3. 删除

   ```sql
   DROP DATABASE [IF EXISTS] 数据库名;
   -- 删除db_Test数据库
   DROP DATABASE IF EXISTS db_Test;
   ```

4. 使用

   ```sql
   USE 数据库名;
   ```

###### （2）表的操作

1. 查询当前数据库所有表

   ```sql
   SHOW TABLES;
   ```

2. 查询表结构

   ```sql
   DESC 表名;
   ```

3. 查询指定表的建表语句

   ```sql
   SHOW CREATE TABLE 表名;
   ```

###### （3）表的创建

```sql
CREATE TABLE 表名(
	字段1 数据类型[COMMENT 注释],
    字段2 数据类型[COMMENT 注释],
    ...
)[COMMENT 表注释];
```

###### （4）数据类型







































