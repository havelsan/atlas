
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
    public partial class DisTaahhutKayitForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            taahhutDissTaahhutDisDVO.CellContentClick += new TTGridCellEventDelegate(taahhutDissTaahhutDisDVO_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            taahhutDissTaahhutDisDVO.CellContentClick -= new TTGridCellEventDelegate(taahhutDissTaahhutDisDVO_CellContentClick);
            base.UnBindControlEvents();
        }

        private void taahhutDissTaahhutDisDVO_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DisTaahhutKayitForm_taahhutDissTaahhutDisDVO_CellContentClick
   ITTGridCell selectedCell = taahhutDissTaahhutDisDVO.Rows[rowIndex].Cells[columnIndex];
            if (selectedCell.OwningColumn.Name.Equals(semadanSec.Name))
            {
                TaahhutDisDVO taahhutDisDVO = (TaahhutDisDVO)selectedCell.OwningRow.TTObject;
                int? selectedValue = taahhutDisDVO.disNo;
                TaahhutDisDVODisSemasiForm taahhutDisDVODisSemasiForm = new TaahhutDisDVODisSemasiForm();
                DialogResult dialogResult = taahhutDisDVODisSemasiForm.ShowEdit(this, taahhutDisDVO, true);
                if (dialogResult != DialogResult.OK)
                    taahhutDisDVO.disNo = selectedValue;
            }
#endregion DisTaahhutKayitForm_taahhutDissTaahhutDisDVO_CellContentClick
        }

        protected override void PreScript()
        {
#region DisTaahhutKayitForm_PreScript
    base.PreScript();
            _DisTaahhutKayit.taahhutKayitDVO.saglikTesisKodu = _DisTaahhutKayit.HealthFacilityID.Value;

            if(((ITTObject)_DisTaahhutKayit).IsNew && string.IsNullOrEmpty(_DisTaahhutKayit.taahhutKayitDVO.taahhut.taahhutAlanAd) && string.IsNullOrEmpty(_DisTaahhutKayit.taahhutKayitDVO.taahhut.taahhutAlanSoyad))
            {
                string[] names = TTUser.CurrentUser.FullName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (names.Length > 0)
                {

                    for (int i = 0; i < names.Length; i++)
                    {
                        if (i != (names.Length - 1))
                        {
                            _DisTaahhutKayit.taahhutKayitDVO.taahhut.taahhutAlanAd += names[i];
                            if (names.Length > 2 && i < (names.Length - 2))
                                _DisTaahhutKayit.taahhutKayitDVO.taahhut.taahhutAlanAd += " ";
                        }
                        else
                        {
                            _DisTaahhutKayit.taahhutKayitDVO.taahhut.taahhutAlanSoyad= names[i];
                        }
                    }
                }
            }
#endregion DisTaahhutKayitForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DisTaahhutKayitForm_PostScript
    base.PostScript(transDef);

            CheckTheIdentificationNumber(hastaTCKimlikNoTaahhutDVO.Text);
#endregion DisTaahhutKayitForm_PostScript

            }
                }
}