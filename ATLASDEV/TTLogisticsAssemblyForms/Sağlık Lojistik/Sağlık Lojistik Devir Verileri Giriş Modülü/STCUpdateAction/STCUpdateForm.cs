
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
    /// Sayım Tartı Verilerinin Güncellenmesi
    /// </summary>
    public partial class STCUpdateForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdGetSTC.Click += new TTControlEventDelegate(cmdGetSTC_Click);
            YeniMevcutSTCAction.TextChanged += new TTControlEventDelegate(YeniMevcutSTCAction_TextChanged);
            KullanilmisMevcutSTCAction.TextChanged += new TTControlEventDelegate(KullanilmisMevcutSTCAction_TextChanged);
            HEKMevcutSTCAction.TextChanged += new TTControlEventDelegate(HEKMevcutSTCAction_TextChanged);
            MuvakkatenVerilenSTCAction.TextChanged += new TTControlEventDelegate(MuvakkatenVerilenSTCAction_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetSTC.Click -= new TTControlEventDelegate(cmdGetSTC_Click);
            YeniMevcutSTCAction.TextChanged -= new TTControlEventDelegate(YeniMevcutSTCAction_TextChanged);
            KullanilmisMevcutSTCAction.TextChanged -= new TTControlEventDelegate(KullanilmisMevcutSTCAction_TextChanged);
            HEKMevcutSTCAction.TextChanged -= new TTControlEventDelegate(HEKMevcutSTCAction_TextChanged);
            MuvakkatenVerilenSTCAction.TextChanged -= new TTControlEventDelegate(MuvakkatenVerilenSTCAction_TextChanged);
            base.UnBindControlEvents();
        }

        private void cmdGetSTC_Click()
        {
#region STCUpdateForm_cmdGetSTC_Click
   if (_STCUpdateAction.Material != null)
            {
                IList findStcAction = _STCUpdateAction.ObjectContext.QueryObjects("STCACTION", "MATERIAL =" + ConnectionManager.GuidToString(_STCUpdateAction.Material.ObjectID));
                if (findStcAction.Count > 0)
                {
                    _STCUpdateAction.STCAction = (STCAction)findStcAction[0];
                    this.Material.ReadOnly = true;
                    this.cmdGetSTC.ReadOnly = true;
                    if (_STCUpdateAction.STCAction.Material.StockCard.StockMethod != StockMethodEnum.SerialNumbered)
                    {
                        this.DCActionsDCAction.ReadOnly = true;
                    }
                }
                else
                {
                    throw new TTException("Seçmiş olduğunuz malzemeye hiç bir Sayım Tartı Verisi girilmemiştir.");
                }
            }
            else
            {
                throw new TTException("Malzeme seçmelisiniz!");
            }
#endregion STCUpdateForm_cmdGetSTC_Click
        }

        private void YeniMevcutSTCAction_TextChanged()
        {
#region STCUpdateForm_YeniMevcutSTCAction_TextChanged
   if (this.YeniMevcutSTCAction.Text != "" && this.KullanilmisMevcutSTCAction.Text != "" && this.HEKMevcutSTCAction.Text != "" && this.MuvakkatenVerilenSTCAction.Text != "")
                this._STCUpdateAction.STCAction.Toplam = Convert.ToDouble(this.YeniMevcutSTCAction.Text) + Convert.ToDouble(this.KullanilmisMevcutSTCAction.Text) + Convert.ToDouble(this.HEKMevcutSTCAction.Text) + Convert.ToDouble(this.MuvakkatenVerilenSTCAction.Text);
#endregion STCUpdateForm_YeniMevcutSTCAction_TextChanged
        }

        private void KullanilmisMevcutSTCAction_TextChanged()
        {
#region STCUpdateForm_KullanilmisMevcutSTCAction_TextChanged
   if (this.YeniMevcutSTCAction.Text != "" && this.KullanilmisMevcutSTCAction.Text != "" && this.HEKMevcutSTCAction.Text != "" && this.MuvakkatenVerilenSTCAction.Text != "")
                this._STCUpdateAction.STCAction.Toplam = Convert.ToDouble(this.YeniMevcutSTCAction.Text) + Convert.ToDouble(this.KullanilmisMevcutSTCAction.Text) + Convert.ToDouble(this.HEKMevcutSTCAction.Text) + Convert.ToDouble(this.MuvakkatenVerilenSTCAction.Text);
#endregion STCUpdateForm_KullanilmisMevcutSTCAction_TextChanged
        }

        private void HEKMevcutSTCAction_TextChanged()
        {
#region STCUpdateForm_HEKMevcutSTCAction_TextChanged
   if (this.YeniMevcutSTCAction.Text != "" && this.KullanilmisMevcutSTCAction.Text != "" && this.HEKMevcutSTCAction.Text != "" && this.MuvakkatenVerilenSTCAction.Text != "")
                this._STCUpdateAction.STCAction.Toplam = Convert.ToDouble(this.YeniMevcutSTCAction.Text) + Convert.ToDouble(this.KullanilmisMevcutSTCAction.Text) + Convert.ToDouble(this.HEKMevcutSTCAction.Text) + Convert.ToDouble(this.MuvakkatenVerilenSTCAction.Text);
#endregion STCUpdateForm_HEKMevcutSTCAction_TextChanged
        }

        private void MuvakkatenVerilenSTCAction_TextChanged()
        {
#region STCUpdateForm_MuvakkatenVerilenSTCAction_TextChanged
   if (this.YeniMevcutSTCAction.Text != "" && this.KullanilmisMevcutSTCAction.Text != "" && this.HEKMevcutSTCAction.Text != "" && this.MuvakkatenVerilenSTCAction.Text != "")
                this._STCUpdateAction.STCAction.Toplam = Convert.ToDouble(this.YeniMevcutSTCAction.Text) + Convert.ToDouble(this.KullanilmisMevcutSTCAction.Text) + Convert.ToDouble(this.HEKMevcutSTCAction.Text) + Convert.ToDouble(this.MuvakkatenVerilenSTCAction.Text);
#endregion STCUpdateForm_MuvakkatenVerilenSTCAction_TextChanged
        }

        protected override void PreScript()
        {
#region STCUpdateForm_PreScript
    base.PreScript();
            this.cmdOK.Visible = false;
#endregion STCUpdateForm_PreScript

            }
                }
}