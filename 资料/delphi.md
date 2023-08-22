Next项目编译账票工具时：
设置属性“リリース”报错：
解决方案：关闭账票工具时不保存，重新打开-->第六个选项下的ソース表示：复制-->设置属性“リリース”->粘贴之前的ソース-->重新编译

需要debug时，要把属性设置为debug，然后从头重新编译

```pascal
//变量的定义：
var
	i:Integer
//赋值
p := 2

//日期转字符串
DataTimeToStr(DateTime:TDateTime)	
```

字符串截取Copy

```pascal
function Copy ( Source : string; StartChar, Count : Integer ) : string;
//
var
	s : string;
begin
    s := 'www.hhit.edu.cn';
    s := Copy(s,5,4); // s = 'hhit'
    ShowMessage(s);
end;
```

```pascal
grid画面设置颜色，在OnDrawCell方法中写
设置行颜色：
MessageDataGrid.Canvas.Font.Color :=clRed;   //文字颜色
MessageDataGrid.Canvas.Brush.Color :=clBlack;//背景色
TR4Grid(Sender).HighlightTextColor :=clRed;  //行选中时文字色
```

关于变量的初始化：

```pascal
var
  pConfirmationRec  : PResultOfQualificationConfirmationRec;
  pSDCRec           : ^TSpecificDiseasesCertificateInfoRec;

  ConfirmationRec   : TResultOfQualificationConfirmationRec;
  SDCRec            : TSpecificDiseasesCertificateInfoRec;
begin
  FillChar(ResRec,          SizeOf(ResRec), 0);
  FillChar(ConfirmationRec, SizeOf(ConfirmationRec), 0);
  FillChar(SDCRec,          SizeOf(SDCRec), 0);

  ResRec.Body.ResultList := TEMMemList.Create(SizeOf(TResultOfQualificationConfirmationRec));
  ResRec.Body.ResultList.Add(ConfirmationRec);
  pConfirmationRec       := ResRec.Body.ResultList[0];

  pConfirmationRec.SpecificDiseasesCertificateList := TEMMemList.Create(SizeOf(TSpecificDiseasesCertificateInfoRec));
  pConfirmationRec.SpecificDiseasesCertificateList.Add(SDCRec);
  pSDCRec := pConfirmationRec.SpecificDiseasesCertificateList[0];
end
```



[DCC エラー] FrmEmMessageDlg.pas(89): F2051 ユニット uFreeRptPub は異なるバージョン TyohyoRDS.TRpt11110103 によりコンパイルされています：

[DCC错误]FrmEmMessageDlg.pas(89):F2051单元uFreeRptPub由不同版本TyohyoRDS.TRpt11110103编译
