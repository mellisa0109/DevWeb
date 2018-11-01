using RecoWeb.Module.Infrastructure.Concrete;
using RecoWeb.Module.Models.POCO;
using RecoWeb.WebUI.Models.POCO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecoWeb.WebUI.Models
{
    public class LotTraceTreeViewModel
    {
        public List<string> MenuLocation { get; set; }
        public string ActivePage { get; set; }

        public ResourceWrapper resourceManager { get; set; }

        public string plantId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime startDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime endDate { get; set; }

        public IEnumerable<PRW_PlantInquiry_Result> PRW_PlantInquiry { get; set; }

        public IEnumerable<SMW_CarTypesInquiry_Result> SMW_CarTypesInquiry { get; set; }

        // 전체:2, 발행:1, 미발행:0
        public string printType { get; set; }

        public COW_NavMenuAuthorizeInquiry_Result Auth { get; set; }


        public IEnumerable<COW_FilterPlantInquiry_Result> COW_FilterPlantInquiry { get; set; }
        public IEnumerable<COW_FilterFactoriesInquiry_Result> COW_FilterFactoriesInquiry { get; set; }
        public IEnumerable<COW_FilterWorkshopTypesInquiry_Result> COW_FilterWorkshopTypesInquiry { get; set; }
        public IEnumerable<COW_FilterWorkshopsInquiry_Result> COW_FilterWorkshopsInquiry { get; set; }
    }

    public class PRW_NotworkTop10ViewModel
    {


        public List<string> MenuLocation { get; set; }
        public string ActivePage { get; set; }

        public ResourceWrapper resourceManager { get; set; }

        public string plantId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime startDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime endDate { get; set; }

        public IEnumerable<PRW_PlantInquiry_Result> PRW_PlantInquiry { get; set; }

        public IEnumerable<SMW_CarTypesInquiry_Result> SMW_CarTypesInquiry { get; set; }

        // 전체:2, 발행:1, 미발행:0
        //public string printType { get; set; }

        public IEnumerable<PRW_DowntimeHistoryTop10Inquiry_Result> PRW_DowntimeHistoryTop10Inquiry { get; set; }
        public IEnumerable<PRW_DowntimeHistoryTop10Chart1Inquiry_Result> PRW_DowntimeHistoryTop10Chart1Inquiry { get; set; }


        public COW_NavMenuAuthorizeInquiry_Result Auth { get; set; }


        public IEnumerable<COW_FilterPlantInquiry_Result> COW_FilterPlantInquiry { get; set; }
        public IEnumerable<COW_FilterFactoriesAllInquiry_Result> COW_FilterFactoriesAllInquiry { get; set; }
        public IEnumerable<COW_FilterWorkshopTypesAllInquiry_Result> COW_FilterWorkshopTypesAllInquiry { get; set; }
        public IEnumerable<COW_FilterWorkshopsAllInquiry_Result> COW_FilterWorkshopsAllInquiry { get; set; }

        public string Gubun2 { get; set; }
        public string Gubun1 { get; set; }

    }

    public class TQW_TCIViewModel
    {
        public List<string> MenuLocation { get; set; }
        public string ActivePage { get; set; }

        public ResourceWrapper resourceManager { get; set; }
        public COW_NavMenuAuthorizeInquiry_Result Auth { get; set; }

        // 사용:1, 정지:0
        public bool isUse { get; set; }

        public IEnumerable<TQW_CheckSheetItemManageInquiry_Result> TQW_CheckSheetItemManageInquiry { get; set; }
        public IEnumerable<TQW_CheckSheetItemManageDetailInquiry_Result> TQW_CheckSheetItemManageDetailInquiry { get; set; }

        public IEnumerable<TQW_CheckSheetImageInquiry_Result> TQW_CheckSheetImageInquiry { get; set; }
        public IEnumerable<COW_FilterPlantInquiry_Result> COW_FilterPlantInquiry { get; set; }
        public IEnumerable<COW_FilterFactoriesInquiry_Result> COW_FilterFactoriesInquiry { get; set; }
        public IEnumerable<COW_FilterWorkshopTypesInquiry_Result> COW_FilterWorkshopTypesInquiry { get; set; }
        public IEnumerable<COW_FilterWorkshopsInquiry_Result> COW_FilterWorkshopsInquiry { get; set; }

    }

    public class SMW_DYP5ViewModel
    {
        public List<string> MenuLocation { get; set; }
        public string ActivePage { get; set; }

        public ResourceWrapper resourceManager { get; set; }

        public string plantId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime startDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime endDate { get; set; }

        public IEnumerable<PRW_PlantInquiry_Result> PRW_PlantInquiry { get; set; }

        public IEnumerable<SMW_CarTypesInquiry_Result> SMW_CarTypesInquiry { get; set; }

        // 전체:2, 발행:1, 미발행:0
        public string printType { get; set; }

        public IEnumerable<SMW_RankHistorySummaryInquiry_Result> SMW_RankHistorySummaryInquiry { get; set; }
        public IEnumerable<SMW_RankHistorySummaryDPartInquiry_Result> SMW_RankHistorySummaryDPartInquiry { get; set; }
        public IEnumerable<SMW_RankHistorySummaryDRawInquiry_Result> SMW_RankHistorySummaryDRawInquiry { get; set; }

        //public COW_NavMenuAuthorizeInquiry_Result Auth { get; set; }

    }
}