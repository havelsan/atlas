
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
    /// Tıbbi Kurul Heyet Teşkili Tanımlama
    /// </summary>
    public partial class MemberOfMedicalCommitteeDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            Members.CellValueChanged += new TTGridCellEventDelegate(Members_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Members.CellValueChanged -= new TTGridCellEventDelegate(Members_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void Members_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MemberOfMedicalCommitteeDefinitionForm_Members_CellValueChanged
   if(rowIndex > -1 && columnIndex > -1 && columnIndex == 0)
            {
                ResUser pDoctor = (ResUser)this._MemberOfMedicalCommitteeDefinition.ObjectContext.GetObject(((Guid)this.Members.CurrentCell.Value), typeof(ResUser));
                MultiSelectForm pForm = new MultiSelectForm();
                foreach(ResourceSpecialityGrid sect in pDoctor.ResourceSpecialities)
                {
                    if(!pForm.IsItemExists(sect.Speciality.ObjectID.ToString()))
                        pForm.AddMSItem(sect.Speciality.Name, sect.ObjectID.ToString(), sect.Speciality);
                }
                
                string sKey = pForm.GetMSItem(this, "Uzmanlık Dalı seçiniz", true);
                if(!string.IsNullOrEmpty(sKey))
                {
                    this.Members.Rows[rowIndex].Cells[1].Value = ((SpecialityDefinition)pForm.MSSelectedItemObject).ObjectID;
                }
            }
#endregion MemberOfMedicalCommitteeDefinitionForm_Members_CellValueChanged
        }
    }
}