
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
    /// Karargah İçi Mütalaa
    /// </summary>
    public  partial class InternalCorrespondenceKIMK : TTObject
    {
        public partial class InternalCorrespondenceKIMKNQL_Class : TTReportNqlObject 
        {
        }

#region Methods
        override protected void OnConstruct()
        {
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                Caption = "KARARGAH İÇİ MÃœTALAA KAĞIDI (KİMK)";
            }
        }
        
        //TODO: Daha sonra değerlendirilecek.
        /*public void Print()
        {
            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            
            TTReportTool.PropertyCache<object> objID = new TTReportTool.PropertyCache<object>();
            objID.Add("VALUE", ObjectID.ToString());
            
            parameters.Add("TTOBJECTID",objID);
            
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KIMK), true, 1, parameters);
        }*/
        
#endregion Methods

    }
}