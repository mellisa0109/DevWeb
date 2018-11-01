using RecoWeb.Module.Infrastructure.Concrete;
using RecoWeb.Domain.LocalResource;
using RecoWeb.Module.Models.POCO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecoWeb.Module.Models
{
    public class COW_MenuInquiryViewModel
    {
        public IEnumerable<COW_MenuListByJsonInquiry_Result> COW_MenuListByJsonInquiry { get; set; }

        [Display(Name = "Example", ResourceType = typeof(Resource))]
        public string Example { get; set; }

        public ResourceWrapper resourceManager { get; set; }
    }

    public class NavMenuInquiryViewModel
    {
        public IEnumerable<COW_NavMenuListInquiry_Result> COW_NavMenuListInquiry { get; set; }
        public ResourceWrapper resourceManager { get; set; }
    }

    //public class PRW_PlantInquiryViewModel
    //{
    //    public IEnumerable<PRW_PlantInquiry_Result> PRW_PlantInquiry { get; set; }

    //    [Display(Name = "Example", ResourceType = typeof(Resource))]
    //    public string Example { get; set; }

    //    public ResourceWrapper resourceManager { get; set; }
    //}

    //public class COW_DataStackInquiryViewModel
    //{
    //    public IEnumerable<COW_DataStackInquiryViewModel> COW_DataStackInquiry { get; set; }

    //    [Display(Name = "Example", ResourceType = typeof(Resource))]
    //    public string Example { get; set; }

    //    public ResourceWrapper resourceManager { get; set; }
    //}

    public class COW_MenuListInquiryViewModel
    {
        public IEnumerable<COW_RootMenuListInquiry_Result> COW_RootMenuListInquiry { get; set; }
        public IEnumerable<COW_SubMenuListInquiry_Result> COW_SubMenuListInquiry { get; set; }

        public List<string> MenuLocation { get; set; }
        public string ActivePage { get; set; }

        public ResourceWrapper resourceManager { get; set; }

        [DefaultValue(true)]
        public bool isUse { get; set; }

    }

    public class PermissionViewModel
    {
        public List<string> MenuLocation { get; set; }
        public string ActivePage { get; set; }

        public ResourceWrapper resourceManager { get; set; }

        //public string plantId { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime startDate { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime endDate { get; set; }

        //public IEnumerable<PRW_PlantInquiry_Result> PRW_PlantInquiry { get; set; }

        //public IEnumerable<SMW_CarTypesInquiry_Result> SMW_CarTypesInquiry { get; set; }

        //// 전체:2, 발행:1, 미발행:0
        //public string printType { get; set; }

        //public IEnumerable<SMW_RankHistorySummaryInquiry_Result> SMW_RankHistorySummaryInquiry { get; set; }
        //public IEnumerable<SMW_RankHistorySummaryDPartInquiry_Result> SMW_RankHistorySummaryDPartInquiry { get; set; }
        //public IEnumerable<SMW_RankHistorySummaryDRawInquiry_Result> SMW_RankHistorySummaryDRawInquiry { get; set; }

        public COW_NavMenuAuthorizeInquiry_Result Auth { get; set; }
        public string UserId { get; set; }

        public string MenuCode { get; set; }
        public string Ids { get; set; }

    }

    public class PreferencesViewModel
    {
        public string Title { get; set; }

        public string RecentVisit { get; set; }

        public bool isFooterFixed { get; set; }

    }

    public class ExtremeModel
    {
        public IList COW_WorkTypeInquiry { get; set; }
        public IList COW_PlantInquiry { get; set; }

    }


}
