R050425检证No13324

TR5Memo的BiDiMode属性一开始是bdRightToLeftNoAlign属性，一般先加的控件，初始属性都是bdLeftToRight；

原因TR5Memo的外面套了一个控件TPanel设置了bdRightToLeftNoAlign属性，把TR5Memo放进去之后，自动变成了bdRightToLeftNoAlign属性；是因为子控件的ParentBiDiMode = True；跟着父控件来；



zip压缩工具：TVCLZip

设置Grid中每行的颜色：

MessageDataGrid.Canvas.Font.Color :=clRed;

设置背景色：

MessageDataGrid.Canvas.Brush.Color :=clRed;

设置行选中时字的颜色：

TR4Grid(Sender).HighlightTextColor :=clRed;

设置行选中时的背景色

TR4Grid(Sender).HighlightColor:= clAqua;