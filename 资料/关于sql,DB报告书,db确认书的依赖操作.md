**关于Next外部依赖中需要创建新表的依赖单，作出以下使用步骤：**

（<font color="red">**如果有字段需要修改，添加，删除的，需确认是否按照创建新表的步骤来**</font>）

### 1.文件位置：

\Emsoft-server\調剤sql\DB修正時資料作成模板这个目录下

DB 報告書(HXXXXXX原本NoXXXXXX).xlsx

R5テーブル構造追加・変更・削除確認書(HXXXXXX原本NoXXXXXX).xlsx

添付SQL_(HXXXXXX原本NoXXXXXX).TXT

### 2.文件作成顺序：

添付SQL_(HXXXXXX原本NoXXXXXX).TXT

=>DB 報告書(HXXXXXX原本NoXXXXXX).xlsx

=>R5テーブル構造追加・変更・削除確認書(HXXXXXX原本NoXXXXXX).xlsx

### 3.将以上三个文件复制到一个文件夹下

### 4.文件名称修改：

每次的外部依赖都会放在当月的workdir文件夹下，例如\\EMSOFT-SERVER\FromJP\202201-202212\202210\workdir放的就是2022年的10月份的外部依赖。关于文件名中的HXXXXXX原本NoXXXXXX，举例说明

\\EMSOFT-SERVER\FromJP\202201-202212\202210\workdir下的20221031配信分修正依頼(開発).xlsx有个No12032

文件名就要改成R041031開発No12032。R041031就是日本和历。

### 5.\\Emsoft-server\調剤sql文件夹下创建一个文件夹，名称是配信名，例如R041031，把上面的三个文件放在这个目录下

### 6.添付SQL_(HXXXXXX原本NoXXXXXX).TXT的sql文作成：

创建表的操作，eg：

--調剤結果CSV情報
CREATE TABLE R5SCM.EPS_DISPENISING_CSV(
  EPS_DISPENISING_CSVSEQ INTEGER NOT NULL,
  EPS_SHOHO_LIST_SEQ INTEGER NOT NULL,
  SSHNO INTEGER NOT NULL,
  CSV_CREATE_TIME TIMESTAMP NOT NULL WITH DEFAULT CURRENT TIMESTAMP,
  DISPENSING_ID CHAR(36) NOT NULL WITH DEFAULT '',
  DISPENSING_CSV_DATA CLOB NOT NULL WITH DEFAULT '',
  DISPENISING_SEND_TIME TIMESTAMP NOT NULL WITH DEFAULT CURRENT TIMESTAMP,
  SIGNED_DISPENSING_XML CLOB NOT NULL WITH DEFAULT '',
  SEND_TYPE SMALLINT NOT NULL WITH DEFAULT 1,
  CONSTRAINT PK_EPS_DISPENISING_CSV PRIMARY KEY(EPS_DISPENISING_CSVSEQ)
)IN R5DB;
CREATE ALIAS DB2ADMIN.EPS_DISPENISING_CSV FOR R5SCM.EPS_DISPENISING_CSV; 
REORG TABLE R5SCM.EPS_DISPENISING_CSV; 
RUNSTATS ON TABLE R5SCM.EPS_DISPENISING_CSV AND INDEXES ALL; 

说明：

--調剤結果CSV情報这个注释在db资料中有，复制下来即可；

字段名，类型，大小，默认值都在资料中写好，要确保一一对应正确

R5SCM是schema名

R5DB是数据库名

CREATE ALIAS DB2ADMIN.EPS_DISPENISING_CSV FOR R5SCM.EPS_DISPENISING_CSV; 
REORG TABLE R5SCM.EPS_DISPENISING_CSV; 
RUNSTATS ON TABLE R5SCM.EPS_DISPENISING_CSV AND INDEXES ALL; 

最后都要加上，不同的表名替换即可

<font color='red'>**写完之后一定要自己执行一下sql，确保能运行**</font>

**样例参照添付SQL_R040925原本No11644.txt**

### 7.DB 報告書(HXXXXXX原本NoXXXXXX).xlsx作成

（1）右上角担当者写自己的名字

（2）スキーマ名写R5SCM

（3）テーブル名写表名

（4）Index名：根据db资料要求和sql生成的表去查看index名和字段名

（5）項目名，型等就根据db资料上按顺序写，确保一一对应

有几个新表，就做几个sheet

**样例参照\\Emsoft-server\調剤sql\R040925\DB 報告書(R040925原本No11644).xlsx**

### 8.R5テーブル構造追加・変更・削除確認書(HXXXXXX原本NoXXXXXX).xlsx作成

这个excel文件中第一个sheet是作成/更新履歴，需要写作成更新者，日期，シート，内容

左上角是配信名加上依赖单号，右上角是担当者和更新日

シート点击后会到对应的sheet，需添加超链接，内容就是对应的sheet名

雛形sheet中要写业务名和第一个sheet中内容一致

右上角写担当者和更新日

SQL部分把前面写的sql文复制过来

確認項目中，如果是创建新表，要给新规作成打勾；后面几个选项需要都确认

**样例参照\\Emsoft-server\調剤sql\R040925\R5テーブル構造追加・変更・削除確認書(R040925原本No11644).xlsx**

### 9.文件保存

上面三个文件都做好后，在\\Emsoft-server\調剤sql下创建一个文件夹，名称是配信名，例如R041031，在这个配信文件夹下再创建一个文件夹，名称是依赖号，比如No12032，然后把三个文件放在这个依赖号文件夹下

### 10.南京添附资料

在\\EMSOFT-SERVER\FromJP\202201-202212\202210\workdir\南京添付資料下如果有当天日期的文件夹，创建上一步的相同文件夹，把上面的三个文件复制到这个文件夹下

### 11.依赖单填写

在对应的依赖单中写上添附，例如\\EMSOFT-SERVER\FromJP\202201-202212\202210\workdir\20221031配信分修正依頼(開発).xlsx中的No12032

在修正内容/連絡事項这一列里写上添付あり：写上三个文件名



**注：当有新的sql依赖时，这个时候需要添加字段修改类型大小等等，如果还是按照创建新表的操作来，一定要确保是在上一次修改的基础上进行对应，不然上次的修改就没了**
