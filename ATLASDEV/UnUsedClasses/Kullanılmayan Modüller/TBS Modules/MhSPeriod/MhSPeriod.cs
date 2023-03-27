
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
    /// Çalışma Yılı
    /// </summary>
    public  partial class MhSPeriod : TTDefinitionSet
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            MhSPeriod prePeriod = FindPreviousPeriod();
            if(prePeriod != null && prePeriod.IsPeriodClosed()){
                PreviousPeriod = prePeriod;
            }else if(prePeriod != null){
               throw new Exception("Önceki Period kapalı değil");
            }
#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            CreateChartOfAccounts();
#endregion PostInsert
        }

#region Methods
        private MhSPeriod FindPreviousPeriod(){
            long? preYear = Year - 1;
            System.ComponentModel.IBindingList list = ObjectContext.QueryObjects<MhSPeriod>("Year = " + preYear.ToString());
            if(list.Count == 0){
                return null;
            }
            MhSPeriod prePeriod = list[0] as MhSPeriod;
            return prePeriod;
        }
        private void CreateChartOfAccounts(){
            MhSChartOfAccounts chart = TemplateChartOfAccounts.CreateACopy();
            chart.IsTemplate = false;
            chart.Firm = Firm;
            chart.Period = this;
            chart.Name = Alias + " " + "Hesap Planı";
            chart.Comment = Alias + " " + "Hesap Planı";
            chart.CurrentStateDefID = MhSChartOfAccounts.States.New;
        }
        public bool IsPeriodClosed(){
            return ClosingSlip != null;
        }
        
#endregion Methods

    }
}