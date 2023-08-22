using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfAppExe.Enum.EnumExtension;

namespace WpfAppExe.Enum
{
    public class EnumConstant
    {
        public enum ContextParameterKey
        {
            [Code("Template_EditTemplateProperty_Object")]
            Template_EditTemplateProperty_Object,
            Template_EditTemplate_Seq,
            Template_SelectedCategory_Seq,
            Template_SelectedType_Seq,
            Template_ReeditTemplate_IsCopy,
            Template_MergeTemplate_TemplateList,
            Template_ReeditRegion_SelectedRegion,
            Template_TemplateClick_Object,
            Template_EditTemplateType_Seq,
            Uketsuke_Patient_ViewOperationMode,
            Schema_EditImageTypeName_Flag,
            Schema_IsImageTypeDirectEdit,
            KarteFrame_OpenFunction_FunctionName,
            Schema_WindowLoactionSize_PointAndSize,
            Schema_SelectedStampType_Index,
            Schema_WindowSize_Size,
            Yoyaku_AddMiraiKarte
        }

        public enum PubEventScopeKbn
        {
            DoNotCare,
            Patient,
            Window,

        }

        public enum YouhouZaikeiCode
        {
            [Description("すべて"), Code("0"), Abbreviation("全")]
            [DescriptionEn("すべて")]
            AllOrNone = 0,
            [Description("内服")]
            [DescriptionEn("内服")]
            [Code("1"), Abbreviation("内")]
            Naifuku = 1,
            [Description("内滴")]
            [DescriptionEn("内滴")]
            [Code("2"), Abbreviation("滴")]
            Naiteki = 2,
            [Description("頓服")]
            [DescriptionEn("頓服")]
            [Code("3"), Abbreviation("頓")]
            Tonpuku = 3,
            [Description("注射")]
            [DescriptionEn("注射")]
            [Code("4"), Abbreviation("注")]
            Tyusha = 4,
            [Description("外用")]
            [DescriptionEn("外用")]
            [Code("5"), Abbreviation("外")]
            Gaiyou = 5,
            [Description("浸煎")]
            [DescriptionEn("浸煎")]
            [Code("6"), Abbreviation("浸")]
            Shinsen = 6,
            [Description("湯")]
            [DescriptionEn("湯薬")]
            [Code("7"), Abbreviation("湯")]
            Tou = 7,
            [Description("自費")]
            [DescriptionEn("自費")]
            [Code("8"), Abbreviation("自")]
            Jihi = 8,
            [Description("器材")]
            [DescriptionEn("器材")]
            [Code("9"), Abbreviation("材")]
            Zairyou = 9,
            [Description("コメント")]
            [DescriptionEn("コメント")]
            [Code("10"), Abbreviation("コ")]
            Comment = 10,
        }

        public enum YTSize
        {
            [Description("小薬袋")][Code("1")] SmallTZ = 1,
            [Description("中薬袋")][Code("2")] MiddleTZ = 2,
            [Description("大薬袋")][Code("3")] BigTZ = 3,
            [Description("フリー")][Code("4")] FuriTZ = 4,
            [Description("ラベル")][Code("5")] LabelTZ = 5,
        }

    }
}
