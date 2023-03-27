
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
    /// Temel Yazışma
    /// </summary>
    public  partial class BaseCorrespondence : TTObject
    {
        public partial class NonMilitaryCorrespondenceNQL_Class : TTReportNqlObject 
        {
        }

#region Methods
        override protected void OnConstruct()
        {
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                string city = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","");
                Caption = "T.C.";
                Caption = Caption + "\r\nXXXXXX";
                Caption = Caption + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","");
                Caption = Caption + "\r\n" + city.ToUpper();
            }
        }
       
        
        ///NE Hiç bir yerde kullanılmamış
//        public void Print()
//        {
//            ArrayList printList = new ArrayList();
//            
//            foreach(DistributionPlace dp in this.DistributionPlaces)
//            {
//                printList.Add(dp.DistributionLine);
//            }
//            
//            foreach(Info info in this.Infos)
//            {
//                printList.Add(info.InfoLine);
//            }
//            
//            printList.Add("Dosya");
//            
//            foreach(string s in printList)
//            {
//                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
//                
//                TTReportTool.PropertyCache<object> objID = new TTReportTool.PropertyCache<object>();
//                objID.Add("VALUE", ObjectID.ToString());
//                TTReportTool.PropertyCache<object> to = new TTReportTool.PropertyCache<object>();
//                to.Add("VALUE", s);
//                
//                parameters.Add("TTOBJECTID",objID);
//                parameters.Add("TO",to);
//                
//                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_NonMilitaryCorrespondence), true, 1, parameters);
//            }
//        }
//
        
#endregion Methods

    }
}