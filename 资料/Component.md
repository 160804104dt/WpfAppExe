# ComponentDemo

## 0.ShohouInputSuggestBox:TextBox

```xaml
<c:EmTabItem Header="0.SuggestBox" IsSelected="True">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

    <componentdemo:ShohouInputSuggestBox 
        Grid.Column="1"
        BorderBrush="SkyBlue"
        BorderThickness="0,0,0,1"
        VerticalAlignment="Top" 
        MaxDropDownHeight="222"
        MinimumPopulateDelay="1"
        ItemsCountPerPage="20"
        SelectedTabIndex ="2"
        TextChanged="ShohouInputSuggestBox_TextChanged"
        Text="{Binding RandomText}"
        ItemsSource="{Binding RandomList}" >
    </componentdemo:ShohouInputSuggestBox>
    </Grid>
</c:EmTabItem>
```

那几个选项从哪来的。。

## 1.EmBunSyoTextBox : TextBox

```xaml
<c:EmTabItem Header="1.EmBunSyoTextBox">
    <StackPanel>
        <c:EmBunSyoTextBox Width="100" Height="25" HorizontalAlignment="Left" VerticalAlignment="Top" Text="inspection" Style="{StaticResource EmBunSyoTextBox.Inspection}"/>
        <c:EmBunSyoTextBox Width="100" Height="25" HorizontalAlignment="Left" VerticalAlignment="Top" Text="run" Style="{StaticResource EmBunSyoTextBox.Master.Bun}"/>
    </StackPanel>
</c:EmTabItem>
```

HorizontalAlignment，VerticalAlignment是指子元素相对于父元素的位置

HorizontalAlignment属性值Left,Right,Center,Stretch

VerticalAlignment属性值Top,Bottom,Center,Stretch

## 2.EmBusyIndicator

```xaml
<c:EmTabItem Header="2.EmBusyIndicator">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50"/>
            <RowDefinition />
        </Grid.RowDefinitions>
        <CheckBox Name="cb0" Content="EmBusyIndicator Works" VerticalAlignment="Center" Margin="5"/>
        <c:EmBusyIndicator Grid.Row="1" IsBusy="{Binding ElementName=cb0, Path=IsChecked, UpdateSourceTrigger=PropertyChanged}">
            <Border BorderBrush="Red" BorderThickness="1" Margin="5">
                <Button Content="Click Me" Width="100" Height="50"/>
            </Border>
        </c:EmBusyIndicator>
    </Grid>
</c:EmTabItem>
```

样式表示正在加载中

- `IsBusy="{Binding ElementName=cb0, Path=IsChecked, UpdateSourceTrigger=PropertyChanged}"`绑定的是Name为cb0的CheckBox控件，path是isChecked是否选中
- `UpdateSourceTrigger=PropertyChanged`，当界面上的值发生改变，绑定的数据源也会发生变化，除了PropertyChanged，还有Explicit（需要调用UpdateSource方法），LostFocus（失去焦点时数据源发生改变），Default

## 3.EmButton : Button

```xaml
<Grid.RowDefinitions>
    <RowDefinition Height="25"/>
    <RowDefinition Height="25"/>
    <RowDefinition Height="25"/>
    <RowDefinition Height="25"/>
    <RowDefinition />
</Grid.RowDefinitions>
<Grid.ColumnDefinitions>
    <ColumnDefinition Width="200"/>
    <ColumnDefinition Width="200"/>
    <ColumnDefinition />
</Grid.ColumnDefinitions>
<!--定义五行三列，使用的话需要用到Grid.Row="index"，Grid.Column="index"-->

<CheckBox Grid.Row="1" Name="cb3" Content="IsShowHotKeyMark Works"/>
<CheckBox Grid.Row="2" Name="cb4" Content="NoneMouseOver Works"/>
<CheckBox Grid.Row="3" Name="cb5" Content="IconSource Works"/>
<!--这几个CheckBox占据三行-->
```

```xaml
<ComboBox Name="cb2" Grid.Column="1" SelectedValuePath="Content" SelectedIndex="3">
    <ComboBoxItem Content="NormalButton"/>
    <ComboBoxItem Content="FavoriteButton"/>
    <ComboBoxItem Content="FoucsButton"/>
    <ComboBoxItem Content="NoEffectButton"/>
    <ComboBoxItem Content="OptionsPanelButton"/>
</ComboBox>
<!--SelectedValuePath="Content" 表示绑定的是ComboBoxItem的Content属性-->
```

```xaml
<Border Grid.Row="4" BorderBrush="Yellow" BorderThickness="5" Grid.ColumnSpan="3" Margin="5">
    <StackPanel Orientation="Vertical" >
        <c:EmButton Name="btn0" Width="200" DisplayPattern="{Binding ElementName=cb2, Path=SelectedValue}" ButtonHotKey="F1" IsShowHotKeyMark="{Binding ElementName=cb3, Path=IsChecked}" Style="{StaticResource EmButton.Default.Style}" NoneMouseOver="{Binding ElementName=cb4, Path=IsChecked}" />
    </StackPanel>
</Border>
<!--
Border:
BorderBrush：边框颜色
BorderThickness：厚度
Grid.ColumnSpan="3" ：占有单元格的个数，默认是1
-->

<!--
EmButton:
DisplayPattern:显示的样式
ButtonHotKey：热键
IsShowHotKeyMark：是否显示热键标
NoneMouseOver：？
-->
```

## 4.EmCalendar : XamMonthCalendar

```xaml
<c:EmCalendar AutoAdjustCalendarDimensions="True" BorderBrush="#bfbfbf" BorderThickness="1,0,1,0" CalendarDimensions="1,2" ContentWidth="21.2" JpDateStrType="C" 
MinCalendarMode="Days" SelectionType="Single" HeaderContentEnable="{Binding}"
ZoomOutEnable="{Binding}"/>
<!--
AutoAdjustCalendarDimensions:自动调整日历尺寸
CalendarDimensions：尺寸：3，5表示三行五列
MinCalendarMode：最小单位，值有Days，Months，Years，Decades，Centuries
SelectionType：选择类型，值由Single，SingleAutoDrag，Default，Extend。。。
ContentWidth：
JpDateStrType：
HeaderContentEnable：
ZoomOutEnable：
-->
```

几个style的区别

```c#
ec41.KarteDates = true.Equals(cb.IsChecked) ? lst41 : null;
ec42.KarteDates = true.Equals(cb.IsChecked) ? lst41 : null;
ec43.KarteDates = true.Equals(cb.IsChecked) ? lst41 : null;
//关于日期的选取，只有第三个生效
```

## 5.EmCheckBox : CheckBox

```xaml
<c:EmCheckBox Content="選択内容1" IsChecked="True" Style="{StaticResource CheckBoxStyleMark}" CheckMarkVisibilty="{Binding Converter={StaticResource BoolToVisibilityConverter}}" IsEnabled="{Binding ElementName=cb51,Path=IsChecked}"/>

<!--
CheckMarkVisibilty:复选框是否显示
IsEnabled：是否启用
TextProperty：内容是否显示
Converter：
-->
<!--关于几个style-->
<Style="{StaticResource EmCheckBox.Default.Style}"/>默认样式
<Style="{StaticResource CheckBoxStyleMarkForPatientDetailView}"/>圆角button，绿色渲染，无复选框，禁用后样式消失
<Style="{StaticResource CheckBoxStyleMark}" />圆角button，无复选框，禁用后样式消失
<Style="{StaticResource EmCheckBox.TextStyle.Red}"/>直角button，红色渲染，无复选框，禁用后样式不会消失
<Style="{StaticResource EmCheckBox.TextStyle.Blue}"/>直角button，蓝色渲染，无复选框，禁用后样式不会消失
<Style="{StaticResource CheckBoxTextBackColorStyle}"/>正方形button，浅绿色渲染，不选中内容会消失
<Style="{StaticResource CheckBoxStyle1}" />点击内容所在的地方才有效果，只改变边框样式
<Style="{StaticResource CheckBoxTextCycleStyle}" />可以设置不选中时的Content
<Style="{StaticResource CheckBoxStyleMarkChangeText}" />不选中时，Content也不会显示
```

## 6.EmComboBox : XamComboEditor

```xaml
<Style="{StaticResource EmComboBox.WithColorItem.Style}"/>不显示内容
<SettingMenuVisibility=""/>是否显示设置按钮
DisplayMemberPath相当于Path
```

## 7.EmDataGrid : XamDataGrid

```xaml
<c:EmDataGrid EmDataGridTypeSetting="{Binding ElementName=cb71, Path=SelectedValue,UpdateSourceTrigger=PropertyChanged}" >
    <dataPresenter:XamDataGrid.FieldLayoutSettings>
        <dataPresenter:FieldLayoutSettings AllowFieldGroupCollapsing="False" AllowFieldMoving="No" AutoFitMode="Always" AutoGenerateFields="False" FixedFieldUIType="None" FixedRecordSortOrder="FixOrder" RecordSelectorLocation="None" />
    </dataPresenter:XamDataGrid.FieldLayoutSettings>
    <dataPresenter:XamDataGrid.FieldSettings>
        <dataPresenter:FieldSettings AllowEdit="False" AllowResize="False" CellClickAction="SelectRecord" LabelClickAction="SelectField" SortComparisonType="Default" />
    </dataPresenter:XamDataGrid.FieldSettings>
    <dataPresenter:XamDataGrid.FieldLayouts>
        <dataPresenter:FieldLayout>
            <dataPresenter:Field Name="UserID" Label="ユーザーID"/><!--绑定的属性Path-->
            <dataPresenter:Field Name="Name" Label="ユーザー名" /><!--label是表头名-->
        </dataPresenter:FieldLayout>
    </dataPresenter:XamDataGrid.FieldLayouts>
</c:EmDataGrid>
<!--

在后台的代码中进行数据绑定：emDataGrid1.DataSource = UserList;
CellClickAction：选中某一行，属性值有EnterEditModeIfAllowed，SelectCell，SelectRecord，Default
LabelClickAction：选中表头，属性有SortByMultipleFields，SelectField等等
-->
```

## 8.EmDateTimeEditor : TextBox

```xaml
<ScrollButtonVisibility/>
<AllowDropDown/>显示日历
<WaterMark/>textbox中提示信息
```

TextBox和EmCalendar结合组成的类

## 9.EmExpander : Expander

```xaml
<PlusMinusVisibilitySetting/>折叠按钮，属性值有Visible，Collapsed，Hidden
<IsExpanded/>是否折叠
<HeaderWidthSetting/>设置头部宽度
```

## 10.EmFollowablePopup : Popup

弹出框

```xaml
<PlacementTarget = "{Binding ElementName=rb3}"/>弹出位置目标
<IsOpen/>是否弹出
```

## 11.EmImage:Image

## 12.EmImageSwitchLabel : Label

```xaml
<StackPanel Orientation="Horizontal" VerticalAlignment="Center">
    <TextBlock Text="表示する画像を選択" VerticalAlignment="Center" Margin="5,0"/>
    <ComboBox Name="cmb" SelectedValuePath="Content" SelectedIndex="0" Height="25" Margin="10,0">
        <ComboBoxItem>1</ComboBoxItem>
        <ComboBoxItem>2</ComboBoxItem>
        <ComboBoxItem>3</ComboBoxItem>
        <ComboBoxItem>4</ComboBoxItem>
    </ComboBox>
</StackPanel>
<Border Grid.Row="1" BorderBrush="Blue" BorderThickness="10" Margin="5" >
    <c:EmImageSwitchLabel  Width="160" Height="160" Name="ImageSwitch1" BindingPath="{Binding Path=SelectedValue, ElementName=cmb, UpdateSourceTrigger=PropertyChanged}">
        <c:EmImageSwitchLabel.MatchDictionary>
            <common:ImageDictinary>
                <Image x:Key="1" Source="1.png" Stretch="Uniform" />
                <Image x:Key="2" Source="2.png" Stretch="Uniform" />
                <Image x:Key="3" Source="3.png" Stretch="Uniform" />
                <Image x:Key="4" Source="4.png" Stretch="Uniform" />
            </common:ImageDictinary>                               
        </c:EmImageSwitchLabel.MatchDictionary>
    </c:EmImageSwitchLabel>
</Border>
```

可以选择不同的图片。<font color = "red">如何选择特定的图片？</font>

EmImageSwitchLabel的BindingPath属性是获取BindingPathProperty的值，值发生变化时，会调用相应的方法判断MatchDictionary是否匹配到对应的图片（MatchDictionary.ContainsKey(key)方法）

<common:ImageDictinary/>是图片列表，MatchDictionary可以获取ImageDictinary的value，这样就可以绑定特定的图片

## 13.EmLabel:Label

注意几个style即可



## 14.EmListView : ListView

## 15.EmMarkButton : ComboBox

ComboBox原本是下拉选择框，现在改成了按钮样式，但本质上是不变的，每点一次就会换一个item

```xaml
<c:EmTabItem Header="15.EmMarkbutton">
    <StackPanel >
        <c:EmMarkButton Text="defaultStyle" ItemsSource="{Binding Source={StaticResource FacilitiesXml4}, XPath=/Marks/Mark}" SelectedValuePath="@Text"/>
    </StackPanel>
</c:EmTabItem>
```



## 16.EmOptionsPanel : ItemsControl

## 17.EmPopup : System.Windows.Controls.Primitives.Popup

和EmFollowablePopup差不多



## 18.EmRadioButton : RadioButton

单选框，主要是几个样式的使用



## 19.EmScrollViewer : ScrollViewer

滚动条几个样式



## 21.EmTabControl:XamTabControl，EmTabItem : TabItemEx

style的不同

## 22.EmTabGroupPane:TabGroupPane

<font color= "red">不明白</font>

## 24.EmTemplateField : TemplateField

```xaml
<dataPresenter:XamDataGrid.FieldLayouts>
    <dataPresenter:FieldLayout>
        <dataPresenter:FieldLayout.Fields>
            <c:EmTemplateField
                               Name="UserID"
                               Width="2*"
                               AllowEdit="True"
                               AllowResize="False"
                               FieldTypeSetting="StringType"
                               LabelTextAlignment="Left" />
        </dataPresenter:FieldLayout.Fields>
    </dataPresenter:FieldLayout>
</dataPresenter:XamDataGrid.FieldLayouts>
```

与DataTemplate进行对比

Name:绑定的数据源的属性，也是表头名

width：宽度，*表示百分比

AllowEdit：是否允许编辑文本

AllowResize：允许调整宽度

FieldTypeSetting：属性的类型设置，需要与数据源中的属性值匹配

## 25.EmTextBlock : TextBlock，EmTextBlockTips : TextBlock

<Run/>继承了<Inline/> ，内联元素可以完成复杂的文本设计，在同一个textBlock中使用不同的样式

```xaml
<TextBlock VerticalAlignment="Center" Margin="5,0">
    <Run Foreground="red" FontSize="15">
        TextBlock: Red Font Size 15
    </Run>
    <Run Foreground="Blue" FontSize="12">
        Blue Font Size 12
    </Run>
</TextBlock>
```

## 26.EmTextBox : TextBox，EmTextBoxArea : TextBox

```xaml
<c:EmTextBox NullText="(EmTextBox.Default.Style)Input Something Please!"
IsShowInputIcon="" 是否显示输入框的图标
IsShowNullText="" 是否显示提示信息
ValidateType="" 有效的文本格式
SpinButtonVisibility="" 
ClearButtonVisibility="" 清空按钮
IsForbiddenImeChange="true" 允许改变文本框内容
/>
<!--
经试验，ClearButtonVisibility优先级高于IsForbiddenImeChange
-->
```

后台为啥要写两个同名的方法

## 27.EmToggleButton : ToggleButton

按钮

## 28.EmTreeViewGroup : TreeView

折叠，下拉选项，双击可以展开或者折叠选项

<font color = "red">点击事件没找到在哪定义的</font>

```xaml
<c:EmTreeViewGroup ItemsSource="{Binding TreeViewDataCollection}"></c:EmTreeViewGroup>
```

```c#
TreeViewDataChild t11 = new TreeViewDataChild() { Name = "Head11", };
TreeViewDataChild t12 = new TreeViewDataChild() { Name = "Head12", };
TreeViewDataChild t21 = new TreeViewDataChild() { Name = "Head21", };
TreeViewDataChild t22 = new TreeViewDataChild() { Name = "Head22", };
TreeViewDataChild t31 = new TreeViewDataChild() { Name = "Head31", };
TreeViewDataChild t32 = new TreeViewDataChild() { Name = "Head32", };
TreeViewDataParent t1 = new TreeViewDataParent() { Name = "Head1", Children = new ObservableCollection<TreeViewDataChild>() { t11, t12 } };

TreeViewDataParent t2 = new TreeViewDataParent() { Name = "Head2", Children = new ObservableCollection<TreeViewDataChild>() { t21, t22 } };

TreeViewDataParent t3 = new TreeViewDataParent() { Name = "Head3", Children = new ObservableCollection<TreeViewDataChild>() { t31, t32 } };

TreeViewDataCollection.Add(t1);
TreeViewDataCollection.Add(t2);
TreeViewDataCollection.Add(t3);
```



## 29.EmVectorImage : FrameworkElement

一些图标，通过  VectorSource="{StaticResource Cyan_169_警告_ボタンアイコン}" />  实现

比如：![1642145357817](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145357817.png)，![1642145398768](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145398768.png)，![1642145431520](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145431520.png)，![1642145464424](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145464424.png),![1642145497864](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145497864.png)，![1642145543159](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145543159.png)，![1642145578311](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145578311.png)，![1642145614327](C:\Users\dt\AppData\Roaming\Typora\typora-user-images\1642145614327.png)等等

```xaml
<c:EmTabItem Header="32.EmVectorImage">
    <c:EmVectorImage Width="20" Height="20" Margin="10,8,0,0" UseLayoutRounding="True" VectorSource="{StaticResource Cyan_169_警告_ボタンアイコン}" />
</c:EmTabItem>
```

