using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbDto
{
    public class HokenshaNoMDto:BindableBase
    {
        public string hokenshaNo;
        public string houbetsuKbn;
        public DateTime startSate;
        public DateTime endDate;
        public string hokenshaKanjiName;
        public string hokenshaKanjiShortName;
        public string hokenshaKanaName;
        public string prefectureCode;
        public decimal kumiaiinKyuufuWariai;
        public decimal familyKyuufuWariai;
        public string postalNo;
        public string address1;
        public string address2;
        public string phoneNo;
        public string idouKbn;
        public int createdBy;
        public DateTime createdAt;
        public int updatedBy;
        public DateTime updatedAt;

        [JsonProperty("hokensha_no")]
        public string HokenshaNo { get => hokenshaNo; set => SetProperty(ref hokenshaNo, value); }

        [JsonProperty("houbetsu_kbn")]
        public string HoubetsuKbn { get => houbetsuKbn; set => SetProperty(ref houbetsuKbn, value); }

        [JsonProperty("start_date")]
        public DateTime StartSate { get => startSate; set => SetProperty(ref startSate, value); }

        [JsonProperty("end_date")]
        public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value); }

        [JsonProperty("hokensha_kanji_name")]
        public string HokenshaKanjiName { get => hokenshaKanjiName; set => SetProperty(ref hokenshaKanjiName, value); }

        [JsonProperty("hokensha_kanji_short_name")]
        public string HokenshaKanjiShortName { get => hokenshaKanjiShortName; set => SetProperty(ref hokenshaKanjiShortName, value); }

        [JsonProperty("hokensha_kana_name")]
        public string HokenshaKanaName { get => hokenshaKanaName; set => SetProperty(ref hokenshaKanaName, value); }

        [JsonProperty("prefecture_code")]
        public string PrefectureCode { get => prefectureCode; set => SetProperty(ref prefectureCode, value); }

        [JsonProperty("kumiaiin_kyuufu_wariai")]
        public decimal KumiaiinKyuufuWariai { get => kumiaiinKyuufuWariai; set => SetProperty(ref kumiaiinKyuufuWariai, value); }

        [JsonProperty("family_kyuufu_wariai")]
        public decimal FamilyKyuufuWariai { get => familyKyuufuWariai; set => SetProperty(ref familyKyuufuWariai, value); }

        [JsonProperty("postal_no")]
        public string PostalNo { get => postalNo; set => SetProperty(ref postalNo, value); }

        [JsonProperty("address_1")]
        public string Address1 { get => address1; set => SetProperty(ref address1, value); }

        [JsonProperty("address_2")]
        public string Address2 { get => address2; set => SetProperty(ref address2, value); }

        [JsonProperty("phone_no")]
        public string PhoneNo { get => phoneNo; set => SetProperty(ref phoneNo, value); }

        [JsonProperty("idou_kbn")]
        public string IdouKbn { get => idouKbn; set => SetProperty(ref idouKbn, value); }

        [JsonProperty("created_by")]
        public int CreatedBy { get => createdBy; set => SetProperty(ref createdBy, value); }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get => createdAt; set => SetProperty(ref createdAt, value); }

        [JsonProperty("updated_by")]
        public int UpdatedBy { get => updatedBy; set => SetProperty(ref updatedBy, value); }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get => updatedAt; set => SetProperty(ref updatedAt, value); }
    }
}
