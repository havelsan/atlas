
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
    /// Cerrahi Ekibi
    /// </summary>
    public partial class SurgeryPersonnelForm : TTForm
    {
        override protected void BindControlEvents()
        {
            SurgeryPersonnelGrid.CellValueChanged += new TTGridCellEventDelegate(SurgeryPersonnelGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SurgeryPersonnelGrid.CellValueChanged -= new TTGridCellEventDelegate(SurgeryPersonnelGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void SurgeryPersonnelGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryPersonnelForm_SurgeryPersonnelGrid_CellValueChanged
   if ( rowIndex < this.SurgeryPersonnelGrid.Rows.Count && rowIndex>-1)
            {
                SurgeryPersonnel  surgeryPersonel = (SurgeryPersonnel)((ITTGridRow)this.SurgeryPersonnelGrid.Rows[rowIndex]).TTObject;
                
                if(surgeryPersonel.Personnel!=null && surgeryPersonel.Role!=null)
                {
                    if (surgeryPersonel.Personnel.UserType == UserTypeEnum.Technician)
                    {
                        return;
                    }
                    else
                    {
                        if(surgeryPersonel.Personnel.UserType != UserTypeEnum.Dentist && surgeryPersonel.Personnel.UserType != UserTypeEnum.Doctor)
                        InfoBox.Show(surgeryPersonel.Personnel.Name.ToString() + "kullanıcısı doktor değildir lütfen rolünü kontrol ediniz");
                    }
                }
            }
#endregion SurgeryPersonnelForm_SurgeryPersonnelGrid_CellValueChanged
        }

        protected override void PreScript()
        {

            #region SurgeryPersonnelForm_PreScript
     
            //TODO pnlButtons!
            //for (int i = 0; i < (this.pnlButtons.Controls.Count); i++)
            //        {
            //            if (this.pnlButtons.Controls[i].Name.ToString() != "cmdOK")
            //            {
            //                this.pnlButtons.Controls[i].Visible = false;
            //            }
            //        }
           var a = 1;
#endregion SurgeryPersonnelForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryPersonnelForm_PostScript
    base.PostScript(transDef);
#endregion SurgeryPersonnelForm_PostScript

            }
                }
}