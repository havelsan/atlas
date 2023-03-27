
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Randevu Kuyruğu Tanımlama
    /// </summary>
    public  partial class ExaminationQueueDefinition : TTDefinitionSet
    {
        public partial class GetExaminationQueues_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// Şu anki itemlarının sayısını döndürür.
    /// </summary>
        public long? CurrentItemsCount
        {
            get
            {
                try
                {
#region CurrentItemsCount_GetScript                    
                    long itemsCount = 0;
                IList<Resource> doctors = GetWorkingResources(ObjectContext);
                List<Guid> doctorGUIDs = new List<Guid>();
                
                foreach (ResUser doctor in doctors)
                {
                    doctorGUIDs.Add(doctor.ObjectID);
                }
                
                if (doctorGUIDs.Count == 0)
                    doctorGUIDs.Add(Guid.Empty);

                BindingList<ExaminationQueueItem> nextItems = ExaminationQueueItem.GetNextItemsByQueueByDate(ObjectContext, ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1).AddSeconds(-1), doctorGUIDs);
                if(nextItems.Count > 0)
                    itemsCount = nextItems.Count;
//                Dictionary<Guid, Common.SortedExaminationQueueItems> sortedQueueItems = Common.GetSortedQueueItems(this.ObjectContext,this);
//                foreach (KeyValuePair<Guid, Common.SortedExaminationQueueItems> kp in sortedQueueItems)
//                {
//                    itemsCount += kp.Value.ExaminationQueueItemList.Count;
//                }
                return itemsCount;
#endregion CurrentItemsCount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CurrentItemsCount") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Doktoru null olan queue itemların sayısı
    /// </summary>
        public long? CurrentItemsCountDocIsNull
        {
            get
            {
                try
                {
#region CurrentItemsCountDocIsNull_GetScript                    
                    long itemsCount = 0;
                IList<Resource> doctors = GetWorkingResources(ObjectContext);
                List<Guid> doctorGUIDs = new List<Guid>();
                
                foreach (ResUser doctor in doctors)
                {
                    doctorGUIDs.Add(doctor.ObjectID);
                }
                
                if (doctorGUIDs.Count == 0)
                    doctorGUIDs.Add(Guid.Empty);

                BindingList<ExaminationQueueItem> nextItems = ExaminationQueueItem.GetNextItemsByQueueByDate(ObjectContext, ObjectID, Common.RecTime().Date,  Common.RecTime().Date.AddDays(1).AddSeconds(-1), doctorGUIDs);
                if(nextItems.Count > 0)
                {
                    foreach(ExaminationQueueItem queueItem in nextItems)
                    {
                        if (queueItem.Doctor == null)
                            itemsCount++;
                    }
                }
                return itemsCount;
#endregion CurrentItemsCountDocIsNull_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CurrentItemsCountDocIsNull") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();
            
//            BindingList<ExaminationQueueDefinition> eqList = ExaminationQueueDefinition.GetEmergencyQueues(this.ObjectContext);
//            if(eqList.Count > 1)
//                throw new TTUtils.TTException("XXXXXXnizde tanımlı bir acil kuyruğu zaten var. İkinci tanımlanamaz.\r\n" + ((ExaminationQueueDefinition)eqList[0]).Name);

#endregion PreInsert
        }

#region Methods
        public BindingList<Resource> GetWorkingResources(TTObjectContext ctx, DateTime dateTime)
        {
            return Resource.GetResourcesForQueueInDate(ctx, ObjectID, dateTime.Date);
        }

        public static List<Resource> GetWorkingResourcesByQueueID(Guid queueID)
        {
            DateTime dateTime = Common.RecTime();
            TTObjectContext ctx = new TTObjectContext(true);
            BindingList<Resource> resList = Resource.GetResourcesForQueueInDate(ctx, queueID, dateTime.Date);
            List<Resource> retList = new List<Resource>();
            foreach (Resource res in resList)
                retList.Add(res);

            return retList;
        }

        public BindingList<Resource> GetWorkingResources(TTObjectContext ctx)
        {
            DateTime dateTime = Common.RecTime();
            BindingList<Resource> retList = Resource.GetResourcesForQueueInDate(ctx, ObjectID, dateTime.Date);
            if (retList.Count == 0)
            {
                if(SystemParameter.GetParameterValue("GETWORKINGRESOURCESBYMAXQUEUEDATE","FALSE") != "FALSE")
                {
                    BindingList<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class> maxList = QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue(ObjectID);
                    if (maxList.Count > 0)
                    {
                        if (maxList[0].Maxworkdate == null)
                        {
                            if(SystemParameter.GetParameterValue("ALLOWGETWORKINGRESOURCESNULL","TRUE") != "TRUE")
                                throw new TTUtils.TTException(SystemMessage.GetMessage(573));
                        }
                        else
                        {
                            dateTime = (DateTime)maxList[0].Maxworkdate;
                            retList = Resource.GetResourcesForQueueInDate(ctx, ObjectID, dateTime.Date);
                        }
                    }
                }
                else
                {
                    if(SystemParameter.GetParameterValue("ALLOWGETWORKINGRESOURCESNULL","TRUE") != "TRUE")
                        throw new TTUtils.TTException(SystemMessage.GetMessage(573));
                }
            }
            return retList;
        }

        public BindingList<Resource> GetWorkingDoctorResources(TTObjectContext ctx)
        {
            BindingList<Resource> retList = GetWorkingResources(ctx);
            
            //retList içinde doktor, diş hekimi ya da intern doktor olmayanlar ayıklanıyor.
            if (this.ResSection is ResPoliclinic)
            {
                BindingList<Resource> tempList = new BindingList<Resource>();
                foreach (Resource r in retList)
                    tempList.Add(r);
                foreach (Resource resource in tempList)
                {
                    if (resource is ResUser)
                    {
                        if (((ResUser)resource).UserType != UserTypeEnum.Doctor && ((ResUser)resource).UserType != UserTypeEnum.Dentist && ((ResUser)resource).UserType != UserTypeEnum.InternDoctor)
                            retList.Remove(resource);
                    }
                }
            }
            return retList;
        }

        public static BindingList<Resource> GetWorkingResources(ExaminationQueueDefinition examinationQueueDefinition)
        {
            DateTime dateTime = Common.RecTime();
            BindingList<Resource> retList = Resource.GetResourcesForQueueInDate(examinationQueueDefinition.ObjectContext, examinationQueueDefinition.ObjectID, dateTime.Date);
            if (retList.Count == 0)
            {
                if (SystemParameter.GetParameterValue("GETWORKINGRESOURCESBYMAXQUEUEDATE", "FALSE") != "FALSE")
                {
                    BindingList<QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue_Class> maxList = QueueResourceWorkPlanDefinition.GetMaxWorkdateForQueue(examinationQueueDefinition.ObjectID);
                    if (maxList.Count > 0)
                    {
                        if (maxList[0].Maxworkdate == null)
                        {
                            if (SystemParameter.GetParameterValue("ALLOWGETWORKINGRESOURCESNULL", "TRUE") != "TRUE")
                                throw new TTUtils.TTException(SystemMessage.GetMessage(573));
                        }
                        else
                        {
                            dateTime = (DateTime)maxList[0].Maxworkdate;
                            retList = Resource.GetResourcesForQueueInDate(examinationQueueDefinition.ObjectContext, examinationQueueDefinition.ObjectID, dateTime.Date);
                        }
                    }
                }
                else
                {
                    if (SystemParameter.GetParameterValue("ALLOWGETWORKINGRESOURCESNULL", "TRUE") != "TRUE")
                        throw new TTUtils.TTException(SystemMessage.GetMessage(573));
                }
            }
            return retList;
        }

        public static List<ExaminationQueueDefinition> GetMyExaminationQueueDefs(string WindowsUserName)
        {
            List<ExaminationQueueDefinition> retList = new List<ExaminationQueueDefinition>();
            TTObjectContext context = new TTObjectContext(true);
            BindingList<AppointmentViewerCompDef> compList = AppointmentViewerCompDef.GetAccCompDefByComputerName(context, WindowsUserName);
            BindingList<ExaminationQueueDefinition> resSectionQueues;
            AppointmentViewerCompDef appCompDef;
            if(compList.Count > 1)
                throw new TTUtils.TTException(SystemMessage.GetMessageV2(574, WindowsUserName.ToString() ));
            else if(compList.Count == 0)
                return retList;
            else
            {
                appCompDef = compList[0];
                if(appCompDef.RelatedQueues.Count > 0)
                {
                    foreach(RelatedQueues relQ in appCompDef.RelatedQueues)
                    {
                        retList.Add(relQ.ExaminationQueueDefinition);
                    }
                }
                else
                {
                    foreach (AppointmentViewerCompDef appCompDefcs in compList)
                    {
                        appCompDef = context.GetObject((Guid)appCompDefcs.ObjectID, typeof(AppointmentViewerCompDef).Name) as AppointmentViewerCompDef;
                        foreach (RelatedResource res in appCompDef.RelatedResources)
                        {
                            if (res.Resource is ResPoliclinic || res.Resource is ResClinic)
                            {
                                resSectionQueues = ExaminationQueueDefinition.GetQueueByResource(context, res.Resource.ObjectID.ToString());
                                foreach (ExaminationQueueDefinition exQueue in resSectionQueues)
                                {
                                    if (exQueue.IsActiveQueue.HasValue)
                                        if ((bool)exQueue.IsActiveQueue)
                                        retList.Add(exQueue);
                                }
                            }
                        }
                    }
                }
            }
            return retList;
        }
        
#endregion Methods

    }
}