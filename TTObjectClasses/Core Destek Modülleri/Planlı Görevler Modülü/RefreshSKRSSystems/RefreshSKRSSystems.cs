
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
    /// SKRS Sistemler Güncelleme
    /// </summary>
    public  partial class RefreshSKRSSystems : BaseScheduledTask
    {
#region Methods
         public override void TaskScript()
        {
            try
            {
                AddLog("RefreshSKRSSystems has started");
                //BaseSKRSDefinition.RefreshSKRSSistemKodlari();
                //BaseSKRSDefinition.RefreshSKRSTables();
                //BaseSKRSDefinition.RefreshSKRSTablesRestAll();
                BaseSKRSDefinition.RefreshSKRSSistemKodlariRest();
                string log = BaseSKRSDefinition.RefreshSKRSTablesRest();
                if (String.IsNullOrEmpty(log) == false)
                    AddLog(log);
                BaseSKRSDefinition.RefreshMaterialAktifForSkrs();
                AddLog("RefreshSKRSSystems has finished succesfully");
            }
            catch (Exception ex)
            {
                AddLog("ERROR in RefreshSKRSSystems: " + ex.ToString());
            }
        }
        
#endregion Methods

    }
}