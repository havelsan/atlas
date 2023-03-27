//$B74E281C
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class BaseMultipleDataEntryServiceController
    {

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MultipleDataComponent_SummaryInfo GetSummaryInfoByObjectId(Guid ObjectId)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            var baseMultipleDataEntry = objectContext.GetObject(ObjectId, typeof(BaseMultipleDataEntry)) as BaseMultipleDataEntry;
            if (baseMultipleDataEntry != null)
                return GetMySummaryInfo(baseMultipleDataEntry);
            return null;
        }

        private MultipleDataComponent_SummaryInfo GetMySummaryInfo(BaseMultipleDataEntry baseMultipleDataEntry)
        {
            MultipleDataComponent_SummaryInfo multipleSummaryInfo = new MultipleDataComponent_SummaryInfo();
            multipleSummaryInfo.EntryDate = baseMultipleDataEntry.EntryDate;
            if (baseMultipleDataEntry.EntryUser != null)
                multipleSummaryInfo.EntryUserName = baseMultipleDataEntry.EntryUser.Name;
            multipleSummaryInfo.Summary = baseMultipleDataEntry.Summary;
            multipleSummaryInfo.ObjectID = baseMultipleDataEntry.ObjectID;
            multipleSummaryInfo.RowColor = baseMultipleDataEntry.GetRowColor();
            return multipleSummaryInfo;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<MultipleDataComponent_SummaryInfo> GetNextSummaryInfoSetAndAddToList(int count, string objectDefName, Guid episodeActionID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            List<MultipleDataComponent_SummaryInfo> summaryInfoList = null;
            //int summaryLimitCount = Convert.ToInt16(TTObjectClasses.SystemParameter.GetParameterValue("NURSINGSUMMARYLIMITCOUNT", "5"));
            int summaryLimitCount = 5;
            BindingList <BaseMultipleDataEntry> baseMultipleDataEntry = BaseMultipleDataEntry.GetBaseMultipleDataByType(objectContext, episodeActionID, objectDefName);
            if (baseMultipleDataEntry != null)
                summaryInfoList = GetBaseMultipleDataEntrySummaryInfoList(count, summaryLimitCount, baseMultipleDataEntry.ToList<BaseMultipleDataEntry>());
            return summaryInfoList;
        }

        public  List<MultipleDataComponent_SummaryInfo> GetBaseMultipleDataEntrySummaryInfoList(int BegginnerRowIndex, int RowCount, List<BaseMultipleDataEntry> BaseMultipleDataEntryDataArray)
        {
            List<MultipleDataComponent_SummaryInfo> summaryInfoList = new List<MultipleDataComponent_SummaryInfo>();
            var summaryList = BaseMultipleDataEntryDataArray.OrderByDescending(dr => dr.EntryDate).Skip(BegginnerRowIndex).Take(RowCount);
            foreach (var nursingAppProgress in summaryList)
            {
                MultipleDataComponent_SummaryInfo summaryInfo = GetMySummaryInfo(nursingAppProgress);
                summaryInfoList.Add(summaryInfo);
            }

            return summaryInfoList;
        }

        public string DeleteMultibleDataEntry(string objectID)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                ITTObject baseMultipleDataEntry = (ITTObject)objectContext.GetObject(new Guid(objectID), typeof(BaseMultipleDataEntry));
                ((ITTObject)baseMultipleDataEntry).Delete();
                objectContext.Save();
                return string.Empty;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

namespace Core.Models
{
    public partial class BaseMultipleDataEntryFormViewModel
    {
    }

    public class MultipleDataComponent_SummaryInfo
    {
        public Guid ObjectID;
        public DateTime? EntryDate;
        public string EntryUserName;
        public string Summary;
        public string RowColor;
    }
}
