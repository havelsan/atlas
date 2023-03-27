
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
    /// Muayene Detayları
    /// </summary>
    public partial class CheckListForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region CheckListForm_PreScript
    base.PreScript();
            
//            Guid guid = new Guid("f0478622-55cd-42c9-a46c-ecbeb93a164d");
//            if(Common.CurrentUser.HasRole(guid) || Common.CurrentUser.IsSuperUser)
//                return;
            
            Guid guid = new Guid("90427562-7d6b-47f6-830a-2ce09327f99d");
            if(Common.CurrentUser.HasRole(guid))
                CheckListGrid.AllowUserToAddRows = true;
            else
                CheckListGrid.AllowUserToAddRows = false;
            
            ArrayList resSections = new ArrayList();
            foreach(ResSection res in Common.CurrentResource.SelectedResources)
            {
                resSections.Add(res.ObjectID);
            }
            
            ExaminationDetail ed = null;
            foreach(ITTGridRow row in CheckListGrid.Rows)
            {
                ed = (ExaminationDetail)row.TTObject;
                if(ed.ResSection != null)
                {
                    if(resSections.Contains(ed.ResSection.ObjectID) == true)
                    {
                        foreach(ITTGridCell cell in row.Cells)
                        {
                            cell.ReadOnly = false;
                        }
                    }
                }
                else
                {
                    foreach(ITTGridCell cell in row.Cells)
                    {
                        cell.ReadOnly = false;
                    }
                }
            }
#endregion CheckListForm_PreScript

            }
                }
}