
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
    public partial class PhysicianApplicationSingleNursingOrderForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
            GridNursingOrders.CellContentClick += new TTGridCellEventDelegate(GridNursingOrders_CellContentClick);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            GridNursingOrders.CellContentClick -= new TTGridCellEventDelegate(GridNursingOrders_CellContentClick);
        }


        //TODO  in ts 
        //GridNursingOrders_CellContentClick Kodu  Talimat tekrarla  butonuna bind et 
        private void GridNursingOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region PhysicianApplicationSingleNursingOrderForm_GridNursingOrders_CellContentClick
            if (rowIndex < this.GridNursingOrders.Rows.Count && rowIndex > -1)
            {
                if (((ITTGrid)this.GridNursingOrders).Columns[columnIndex].Name == "RPT")
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayýr", "E,H", "Uyarý", "Bu Talimatý tekrarlamak istediðinize emin misiniz?", "", 1);
                    if (result == "E")
                    {
                        string tresult = "E";
                        bool getTime = false;
                        while (getTime == false)
                        {
                            if (tresult == "E")
                            {
                                DateTime? bTarih = InputForm.GetDateTime("Talimat Baþlama Zamaný Seçiniz", "dd/mm/yyyy hh:mm");
                                if (bTarih == null)
                                {
                                    tresult = ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayýr", "E,H", "Uyarý", "Talimat Baþlama Zamanýný girmeden talimat tekrarlayamazsýnýz.Talimatý tekrarlamak istediðinize emin misiniz?", "", 1);
                                    if (tresult == "H")
                                    {
                                        getTime = true;
                                        InfoBox.Show("Talimat Tekrardan vazgeçildi");
                                        break;
                                    }
                                }
                                else
                                {
                                    SingleNursingOrder nursingOrder = (SingleNursingOrder)((ITTGridRow)this.GridNursingOrders.Rows[rowIndex]).TTObject;
                                    if (nursingOrder != null)
                                    {
                                        SingleNursingOrder newNursingOrder = new SingleNursingOrder(this._PhysicianApplication.ObjectContext);
                                        newNursingOrder.ProcedureObject = nursingOrder.ProcedureObject;
                                        newNursingOrder.Frequency = nursingOrder.Frequency;
                                        newNursingOrder.AmountForPeriod = nursingOrder.AmountForPeriod;
                                        newNursingOrder.RecurrenceDayAmount = nursingOrder.RecurrenceDayAmount;
                                        newNursingOrder.PeriodStartTime = bTarih;
                                        newNursingOrder.PhysicianApplication = this._PhysicianApplication;
                                    }
                                    getTime = true;
                                    break;

                                }
                            }
                        }
                    }
                    else
                    {
                        InfoBox.Show("Talimat Tekrardan vazgeçildi");
                    }
                }
                
            }
            #endregion PhysicianApplicationSingleNursingOrderForm_GridNursingOrders_CellContentClick
        }

       


    }
}