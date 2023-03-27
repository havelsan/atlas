
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
    /// Doğum Raporunu Yazıldığı Temel Nesnedir
    /// </summary>
    public  partial class BirthReport : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
        public partial class GetBirtfReport_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetBirthReport_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetCancelledBirthReport_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "BIRTHREPORTREQUEST":
                    {
                        BirthReportRequest value = (BirthReportRequest)newValue;
#region BIRTHREPORTREQUEST_SetParentScript
                        if(value!=null)
            {
                MasterResource=value.MasterResource;
                FromResource=value.FromResource;
                Episode=value.Episode;
                if(value.MasterAction!=null && value.MasterAction is EpisodeAction)
                {
                    BirthEpisodeAction=(EpisodeAction)value.MasterAction;
                }
                MedulaHastaKabul=value.MedulaHastaKabul;
            }
#endregion BIRTHREPORTREQUEST_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.BirthReport;
            }
        }
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject pObject = (ITTObject)this;
            if(pObject.IsNew)
            {
                ReportNo.GetNextValue();
                //this.QuarantineProtocolNo.GetNextValue();
            }
        }
        
      
        public BirthReport(TTObjectContext objectContext, BirthReportRequest birthReportRequest): this(objectContext)
        {
            CurrentStateDefID = BirthReport.States.ReportEntry;
            Episode = birthReportRequest.Episode;
            BirthReportRequest=birthReportRequest;
        }
        
#endregion Methods

    }
}