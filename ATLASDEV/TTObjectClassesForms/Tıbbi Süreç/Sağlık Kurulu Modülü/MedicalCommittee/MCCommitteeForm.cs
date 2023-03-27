
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
    /// Tıbbi Kurullar
    /// </summary>
    public partial class MCCommitteeForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            MemberOfMedicalCommittee.CellValueChanged += new TTGridCellEventDelegate(MemberOfMedicalCommittee_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MemberOfMedicalCommittee.CellValueChanged -= new TTGridCellEventDelegate(MemberOfMedicalCommittee_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void MemberOfMedicalCommittee_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MCCommitteeForm_MemberOfMedicalCommittee_CellValueChanged
   if (columnIndex == 2 && rowIndex != -1)
            {
                if(MemberOfMedicalCommittee.Rows.Count != 0 && MemberOfMedicalCommittee.Rows[rowIndex].Cells[2].Value != null)
                {
                    foreach(ITTGridRow row in MemberOfMedicalCommittee.Rows)
                    {
                        if(row.Cells["NotAttend"].Value != null)
                        {
                            if((bool)row.Cells["NotAttend"].Value)
                                row.Cells["Description"].ReadOnly = false;
                            else
                                row.Cells["Description"].ReadOnly = true;
                        }
                    }
                }
            }
#endregion MCCommitteeForm_MemberOfMedicalCommittee_CellValueChanged
        }
    }
}