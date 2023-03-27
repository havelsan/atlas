
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Kod Tablolarını Gönderme
    /// </summary>
    public partial class SendCodeTablesForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbutton4.Click += new TTControlEventDelegate(ttbutton4_Click);
            ttbutton5.Click += new TTControlEventDelegate(ttbutton5_Click);
            ttbutton6.Click += new TTControlEventDelegate(ttbutton6_Click);
            ttbutton7.Click += new TTControlEventDelegate(ttbutton7_Click);
            ttbutton8.Click += new TTControlEventDelegate(ttbutton8_Click);
            ttbutton9.Click += new TTControlEventDelegate(ttbutton9_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbutton4.Click -= new TTControlEventDelegate(ttbutton4_Click);
            ttbutton5.Click -= new TTControlEventDelegate(ttbutton5_Click);
            ttbutton6.Click -= new TTControlEventDelegate(ttbutton6_Click);
            ttbutton7.Click -= new TTControlEventDelegate(ttbutton7_Click);
            ttbutton8.Click -= new TTControlEventDelegate(ttbutton8_Click);
            ttbutton9.Click -= new TTControlEventDelegate(ttbutton9_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region SendCodeTablesForm_ttbutton1_Click
   // TTMessage m = TTRemoteMethods.SaveRank(Sites.SiteLocalHost,r);
            //TTMessage m  = TTMessageFactory.GetMessage(m.MessageID)
            //    m.ReturnValue
            System.Diagnostics.Debugger.Break();
            //ÖNEMLİ NOT......Şu anda combo çalışmıyor, platformda sorun düzelince aşağıdaki gibi yollanmaya başlanmalı!            
            //CodeManager.SendRankDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(this.SelectSendDataType.SelectedValue));
          //  CodeManager.SendRankDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.RankDefinitionInfo));
#endregion SendCodeTablesForm_ttbutton1_Click
        }

        private void ttbutton2_Click()
        {
#region SendCodeTablesForm_ttbutton2_Click
   System.Diagnostics.Debugger.Break();
            //ÖNEMLİ NOT......Şu anda combo çalışmıyor, platformda sorun düzelince aşağıdaki gibi yollanmaya başlanmalı!
            //CodeManager.SendRankDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(this.SelectSendDataType.SelectedValue));
           // CodeManager.SendMilitaryClassDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.MilitaryClassInfo));
#endregion SendCodeTablesForm_ttbutton2_Click
        }

        private void ttbutton3_Click()
        {
#region SendCodeTablesForm_ttbutton3_Click
   System.Diagnostics.Debugger.Break();
            //ÖNEMLİ NOT......Şu anda combo çalışmıyor, platformda sorun düzelince aşağıdaki gibi yollanmaya başlanmalı!
            //CodeManager.SendRankDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(this.SelectSendDataType.SelectedValue));
       //     CodeManager.SendEyeColorDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.EyeColorInfo));
#endregion SendCodeTablesForm_ttbutton3_Click
        }

        private void ttbutton4_Click()
        {
#region SendCodeTablesForm_ttbutton4_Click
   System.Diagnostics.Debugger.Break();
            //ÖNEMLİ NOT......Şu anda combo çalışmıyor, platformda sorun düzelince aşağıdaki gibi yollanmaya başlanmalı!
            //CodeManager.SendRankDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(this.SelectSendDataType.SelectedValue));
         //   CodeManager.SendForcesCommandDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.ForceCommand));
#endregion SendCodeTablesForm_ttbutton4_Click
        }

        private void ttbutton5_Click()
        {
#region SendCodeTablesForm_ttbutton5_Click
   System.Diagnostics.Debugger.Break();
            //ÖNEMLİ NOT......Şu anda combo çalışmıyor, platformda sorun düzelince aşağıdaki gibi yollanmaya başlanmalı!
            //CodeManager.SendRankDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(this.SelectSendDataType.SelectedValue));            
        //    CodeManager.SendJobTitleDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.JobTitleInfo));
#endregion SendCodeTablesForm_ttbutton5_Click
        }

        private void ttbutton6_Click()
        {
#region SendCodeTablesForm_ttbutton6_Click
   System.Diagnostics.Debugger.Break();
           // CodeManager.GetSpecialityDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.SpecialityInfo));
#endregion SendCodeTablesForm_ttbutton6_Click
        }

        private void ttbutton7_Click()
        {
#region SendCodeTablesForm_ttbutton7_Click
   System.Diagnostics.Debugger.Break();
           // CodeManager.GetDiagnosisDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.ICD10Info));
#endregion SendCodeTablesForm_ttbutton7_Click
        }

        private void ttbutton8_Click()
        {
#region SendCodeTablesForm_ttbutton8_Click
   System.Diagnostics.Debugger.Break();
           // CodeManager.GetSUTDefinitions(((TTDateTimePicker)this.startdate).Value,(SendDataTypesEnum)(SendDataTypesEnum.SUTInfo));
#endregion SendCodeTablesForm_ttbutton8_Click
        }

        private void ttbutton9_Click()
        {
#region SendCodeTablesForm_ttbutton9_Click
   System.Diagnostics.Debugger.Break();
            TTObjectContext objectContext = new TTObjectContext(false);
            TTFormDef formDef = TTObjectDefManager.Instance.ObjectDefs["Appointment"].FormDefs["AppointmentAndScheduleForm"];
            Appointment app = new Appointment(objectContext);
            bool hasright = Common.CurrentUser.HasRight(formDef,app,2000);
#endregion SendCodeTablesForm_ttbutton9_Click
        }
    }
}