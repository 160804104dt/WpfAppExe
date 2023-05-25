using System;
using System.Collections.Generic;
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

    }
}
