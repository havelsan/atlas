
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
    public partial class SKRSGuncellemeForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            SKRSListView.DoubleClick += new TTControlEventDelegate(SKRSListView_DoubleClick);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            TopluGetir.Click += new TTControlEventDelegate(TopluGetir_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            SKRSListView.DoubleClick -= new TTControlEventDelegate(SKRSListView_DoubleClick);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            TopluGetir.Click -= new TTControlEventDelegate(TopluGetir_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton3_Click()
        {
#region SKRSGuncellemeForm_ttbutton3_Click
   try
            {
                TTObjectContext cnx = new TTObjectContext(false);
                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
                {
                    if (objDef.IsOfType(typeof(BaseSKRSCommonDef).Name.ToUpperInvariant()))
                    {
                        if(objDef.ID.ToString() == txtmatchDef.Text)
                        {
                            txtSonuc.Text += objDef.Name;
                            IBindingList bl = cnx.QueryObjects(objDef.Name, "");
                            if (bl.Count > 0)
                            {
                                foreach(BaseSKRSCommonDef obj in bl)
                                {
                                    IBindingList SKRSEnumMatchDefinitionList = SKRSEnumMatchDefinition.GetBySKRSObjectId(cnx,obj.ObjectID);
                                    if(SKRSEnumMatchDefinitionList.Count<=0)
                                    {
                                        if(obj.AKTIF == "1" && obj.CanMatchByEnumValue() == true)
                                        {
                                            SKRSEnumMatchDefinition skrsEnumMatchDefinition = new SKRSEnumMatchDefinition(cnx);
                                            skrsEnumMatchDefinition.SKRSDefinition = obj;
                                            skrsEnumMatchDefinition.SKRSDefinitionObjectId = objDef.ID;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                cnx.Save();
                cnx.Dispose();
            }
            catch (Exception ex)
            {
                txtSonuc.Text += ex.ToString() + "\t\t\r\n";
            }
#endregion SKRSGuncellemeForm_ttbutton3_Click
        }

        private void SKRSListView_DoubleClick()
        {
#region SKRSGuncellemeForm_SKRSListView_DoubleClick
   if (this.SKRSListView.SelectedItems[0] != null)
            {
                if (SKRSListView.SelectedItems.Count > 0)
                {
                    System.Diagnostics.Debugger.Break();
                    ITTListViewItem listViewItem = SKRSListView.SelectedItems[0];
                    //txtSistemKodu.Text = listViewItem.Tag.ToString();
                    txtmatchDef.Text = listViewItem.Tag.ToString();                   
                    txtSonuc.Text = "";                   
                }
           }
#endregion SKRSGuncellemeForm_SKRSListView_DoubleClick
        }

        private void ttbutton1_Click()
        {
            #region SKRSGuncellemeForm_ttbutton1_Click

            SKRSSistemlerServis.wsskrsSistemlerResponse service = SKRSSistemlerServis.WebMethods.SistemlerSync(TTObjectClasses.Sites.SiteLocalHost);

            if (service.hata == null)
            {
                foreach (var item in service.sistemler)
                {
                    TTObjectContext cnx = new TTObjectContext(false);

                    if (item.aktif == true)
                    {
                        ITTListViewItem listViewItem = SKRSListView.Items.Add(item.adi.ToString());
                        listViewItem.SubItems.Add(item.olusturulmaTarihi.ToString());
                        listViewItem.SubItems.Add(item.guncellenmeTarihi.ToString());
                        listViewItem.Tag = item.kodu;

                        var skrsSistemKodlariList = SKRSSistemKodlari.GetBySKRSGuid(cnx, item.kodu);

                        if (skrsSistemKodlariList.Count == 0)
                        {
                            SKRSSistemKodlari skrsSistemKodlari = (SKRSSistemKodlari)cnx.CreateObject("SKRSSISTEMKODLARI");
                            skrsSistemKodlari.AKTIF = Convert.ToString(item.aktif);
                            skrsSistemKodlari.SKRSGuid = item.kodu;
                            skrsSistemKodlari.Adi = item.adi;
                            cnx.Save();
                        }
                    }
                    else
                    {
                        if (SKRSSistemKodlari.IsSKRSActive(item.kodu).Count == 0)//pasif yap
                        {
                            SKRSSistemKodlari skrsSistemKodlari = (SKRSSistemKodlari)cnx.GetObject(new Guid(item.kodu), "SKRSSISTEMKODLARI");
                            skrsSistemKodlari.AKTIF = Convert.ToString(item.aktif);
                            cnx.Save();
                        }
                    }

                    cnx.Dispose();
                }
            }
#endregion SKRSGuncellemeForm_ttbutton1_Click
        }

        private void ttbutton2_Click()
        {
#region SKRSGuncellemeForm_ttbutton2_Click
   try
            {
                TTObjectContext cnx = new TTObjectContext(false);
                foreach (TTObjectDef objDef in TTObjectDefManager.Instance.ObjectDefs.Values)
                {
                    if (objDef.IsOfType(typeof(BaseSKRSCommonDef).Name.ToUpperInvariant()))
                    {
                        txtSonuc.Text += objDef.Name + "\t\t\r\n";
                        IBindingList bl = cnx.QueryObjects(objDef.Name, "");
                        if (bl.Count > 0)
                        {
                            foreach(BaseSKRSCommonDef obj in bl)
                            {
                                IBindingList SKRSEnumMatchDefinitionList = SKRSEnumMatchDefinition.GetBySKRSObjectId(cnx,obj.ObjectID);
                                if(SKRSEnumMatchDefinitionList.Count<=0)
                                {
                                    if(obj.AKTIF == "1" && obj.CanMatchByEnumValue() == true)
                                    {
                                        SKRSEnumMatchDefinition skrsEnumMatchDefinition = new SKRSEnumMatchDefinition(cnx);
                                        skrsEnumMatchDefinition.SKRSDefinition = obj;
                                        skrsEnumMatchDefinition.SKRSDefinitionObjectId = objDef.ID;
                                    }
                                }
                            }
                        }
                    }
                }
                cnx.Save();
                cnx.Dispose();
                txtSonuc.Text += " oldu, gözlerim doldu.\t\t\r\n";
            }
            catch (Exception ex)
            {
                txtSonuc.Text += ex.Message + "\t\t\r\n";
            }
#endregion SKRSGuncellemeForm_ttbutton2_Click
        }

        private void TopluGetir_Click()
        {
            #region SKRSGuncellemeForm_TopluGetir_Click
            //BaseSKRSDefinition.RefreshSKRSSistemKodlari();
            BaseSKRSDefinition.RefreshSKRSSistemKodlariRest();
            //BaseSKRSDefinition.RefreshSKRSTables();
            BaseSKRSDefinition.RefreshSKRSTablesRest();
            #endregion SKRSGuncellemeForm_TopluGetir_Click
        }

#region SKRSGuncellemeForm_Methods

      
        
#endregion SKRSGuncellemeForm_Methods
    }
}