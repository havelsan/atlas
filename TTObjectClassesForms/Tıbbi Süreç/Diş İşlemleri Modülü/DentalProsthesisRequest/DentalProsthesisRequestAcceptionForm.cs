
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
    /// Diş Protez 
    /// </summary>
    public partial class DentalProsthesisRequestAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            SuggestedProsthesis.CellContentClick += new TTGridCellEventDelegate(SuggestedProsthesis_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SuggestedProsthesis.CellContentClick -= new TTGridCellEventDelegate(SuggestedProsthesis_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SuggestedProsthesis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DentalProsthesisRequestAcceptionForm_SuggestedProsthesis_CellContentClick
   if(this.SuggestedProsthesis.CurrentCell.OwningColumn.Name.Equals(SuggestedToothSchema.Name))
              this.SuggestedProsthesis.ShowTTObject(rowIndex, false);
#endregion DentalProsthesisRequestAcceptionForm_SuggestedProsthesis_CellContentClick
        }

        protected override void PreScript()
        {
#region DentalProsthesisRequestAcceptionForm_PreScript
    base.PreScript();
            
            
               // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
#endregion DentalProsthesisRequestAcceptionForm_PreScript

            }
                }
}