## 1、UK0001PatientDetailSearch（患者詳細検索）

1.OritatamiCommand：用于折叠/展开其他检索条件

2.OritatamiSearchInfo：检索条件是否显示Visibility：Collapsed ？Visible;

3.GridPatientList_PreviewMouseLeftButtonDown：根据字段对集合排序

前提：EmpdDataGrid的FieldSettings.LabelPresenterStyle需要使用DataGrid_LabelPresenterSortStyle样式，有Tag属性用于标记升序降序flag

排序字段：带下划线的

（1）收集字段Filed信息

（2）利用VisualTreeHelperWrapperUtility工具类找到LabelPresenter控件

（3）判断是哪个字段触发了点击事件，找到对应的字段

（4）排序字段：默认，患者番号，患者氏名，フリガナ，最終来局日

（5）得到当前的排序字段和升序类型（升序，降序，默认）

（6）设置排序的字段 ResetSortType(Field field, UK0001PatientDetailSearchViewModel vm)方法

（7）设置升序/降序labelPresenter.Tag

（8）排序 vm.ReSort()；

注意：Resort()方法中，有个GetFirstSortType()方法获取当前的排序字段，返回值是object类型

分类マーク下拉框：EmComboBox

这种带有checkbox的combobox用到了EmpdComboBox.PatientDetailSearch.Style

Template用的是EmpdComboBox.Muti.CheckBox.Template

Rectangle,VisualStateManager,ToggleButton,ContentPresenter，Path

4.检索功能：

先进行检索条件检查：

SearchPatientDetail()进行检索

5.三横线按钮

上面几个单选按钮可以设置画面打开时，F1的初始检索条件是哪一个；下面的复选框可以控制datagrid的cell显不显示，需要注意的是datagrid中cell绑定用的是FieldBinding，而不是Binding



## 2、分割処方患者

在结果一览中，使用ObserveElementProperty方法，来检测来局日的变化做后续处理；因为从无到有也会进入到这个方法中，所以可以在绑定的数据源中加一个IsFirstAdd字段过滤掉首次加载

在打开右键菜单和調剤日付指定画面时，如果焦点在来局日中，就不能打开，这个时候，用到VisualTreeHelperWrapperUtility().FindAncestor<DependencyObject>(dp)方法判断



## 3、服用法マスター

F1：服用法名检索框

F2：检索

F3：检索结果

F4：mark区分

F5~F10：keyword

F11：服用法追加

F12：决定

画面结果：

マーク：m_display_seigyo_m.mark_kbn

カナ名称：group_youhou_chouzai_m.youhou_kana_name

名称：group_youhou_chouzai_m.youhou_kanji_name

F1检索框检索的是youhou_kanji_name

F6~F10：youhou_keyword_filter.search_name，youhou_kbn保存服用法的种类，keyword保存的是画面上的顺序，用SearchName1~SearchName5表示；SetSearchName方法用来设置选中状态，当不同的服用法类型tab切换时，已选中的keyword状态不会消失；

从処方入力传进来的参数中有服用法名称，調剤日，一般名薬品，薬品剤型，前回编辑的用法名称，前回编辑的用法seq；

➀当処方入力上没有服用法时，服用法默认选中第一行；

②有服用法时，如果是剤型是材料，服用法master画面不启动；其他剤型时，定位到该服用法

③ 処方入力画面上有输入内容时，并且是以。或者.开头的内容，会打开服用法画面，并将输入内容展示在F1检索框中；如果匹配到相应的服用法，定位，没有的话，检索结果为空

检索对象符合的条件：

①調剤日<=group_youhou_chouzai_m.end_date

②group_youhou_chouzai_m.is_deleted＝False

③調剤日<=youhou_saiyou_m.display_expiration_date 

FirstSearchYouHouData処方入力服用法明细行没有输入内容时调用

SearchYouHouData処方入力服用法明细行有输入内容时调用

在FirstSearchYouHouData方法中，MasterTableCacheStatusCheck先检查服用法数据有没有变化，如果有变化把DataManager中的数据更新一下；GroupYouhouChouzaiM和YouhouSaiyouM进行匹配(以YouhouSaiyouM为主)，再通过MDisplaySeigyoM制御得到isDisplay信息，GroupYouhouChouzaiMWebDto.GroupYouhouSeq=MDisplaySeigyoM.masterCode；

在SearchYouHouData方法中，多了一个服用法是否包含输入内容的判断，其余都是和FirstSearchYouHouData一样的

服用法右击会有表示/非表示，用法编辑菜单。表示/非表示更新的是m_display_seigyo_m表中的is_display的值

keyword右击有キーワード設定菜单，可以设置keyword的内容，更新youhou_keyword_filter的search_name字段

## 4、コメントマストー画面

F4：两个tab:コメントandフリーコメント

在コメント中：

F3检索结果中：

マーク：m_display_seigyo_m.mark_kbn (master_type:C,F)

コード：group_comment_teikeibun_m.comment_code

名称：group_comment_teikeibun_m.teikeibun

処方内：group_comment_teikeibun_m.is_rezept_prescription_print

摘要欄：group_comment_teikeibun_m.is_rezept_tekiyou_comment

薬歴簿：group_comment_teikeibun_m.is_yakurekibo_print

調剤録：group_comment_teikeibun_m.is_chouzairoku_print

手帳：group_comment_teikeibun_m.is_handbook_print

薬情：group_comment_teikeibun_m.is_yakujou_print

薬袋：group_comment_teikeibun_m.is_yakutai_print

结果需要满足的条件：

➀group_comment_teikeibun_m.start_date <= 調剤日 <=  group_comment_teikeibun_m.end_date

②group_comment_teikeibun_m.is_deleted=false

③group_comment_teikeibun_m.teikeibun Like '検索名称%' (或は　group_comment_teikeibun_m.teikeibun Like '%検索名称%')

④group_comment_teikeibun_m.comment_code Like '電算コード%'

画面打开时：param.CommentSeq = 0 && "0".Equals(param.CommentCode)是フリーコメント，否则就是コメント

SetGridData用于收集コメント数据：CommentList

MasterTableCacheStatusCheck检查数据集有没有变化，有的话就刷新；

GetCommentTeikeibunSaiyouMDataManager()从comment_teikeibun_saiyou_m表中读取全部数据，再和

GetGroupCommentTeikeibunMDataManager()中的数据进行匹配：group_comment_teikeibun_m.group_comment_seq=comment_teikeibun_saiyou_m.group_comment_seq

SetFreeCommentGridData方法用于收集フリーコメント数据：FreeCommentList

在OnWindowLoaded方法中，先把焦点设置在检索结果上，得到comment在集合中的下标index，然后用dataGrid.ScrollInfo.SetVerticalOffset(index)方法定位到comment所在的位置，如果没有就默认第一行

EmTabControl里有两个EmTabItem，第一个TabItem里放的コメント，第二个放的フリコメント；

在datagrid中，平时用的都是Field，后面的几个用的是FieldGroup，下面的几个小项数据绑定用的是TextField

