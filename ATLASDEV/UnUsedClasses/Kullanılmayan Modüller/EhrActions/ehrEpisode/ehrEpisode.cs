
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
    public  partial class ehrEpisode : BaseEhr, IOldActions, Itest
    {
        
                    
#region Methods
        //        public string OldActionReportHtml()
        //        {
        //            string report="";
        //            report=report+"<html><table border=1 width='100%'>";
        //            report=report+"<tr>" + Common.FormatAsOldActionTitle("Kabul Sebebi",null) + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(ReasonForAdmission)," colspan=3");
        //            report=report+"<tr>" + Common.FormatAsOldActionTitle("Vaka Açılış Tarihi",null)  + Common.FormatAsOldActionValue(Common.ReturnObjectAsString(OpeningDate),null);
        //            if(this.MainSpeciality!=null)
        //                report=report+"<tr>" + Common.FormatAsOldActionTitle("Vaka Uzmanlık Dalı",null) +Common.FormatAsOldActionValue(Common.ReturnObjectAsString(this.MainSpeciality.Name)," colspan=3");
        //            report=report + "</table></html>";
//
        //            return report;
        //        }
        
        public string OldActionReportHtml()
        {
            string report = "";
            
            return report;

        }
        
#endregion Methods

    }
}