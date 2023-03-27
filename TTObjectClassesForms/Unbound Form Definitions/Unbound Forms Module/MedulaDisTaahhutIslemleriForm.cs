
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
    /// Medula Diş Taahhüt İşlemleri
    /// </summary>
    public partial class MedulaDisTaahhutIslemleri : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            chkTaahhutKaydet.CheckedChanged += new TTControlEventDelegate(chkTaahhutKaydet_CheckedChanged);
            TTListBox.SelectedObjectChanged += new TTControlEventDelegate(TTListBox_SelectedObjectChanged);
            ch1.CheckedChanged += new TTControlEventDelegate(ch1_CheckedChanged);
            ch2.CheckedChanged += new TTControlEventDelegate(ch2_CheckedChanged);
            ch3.CheckedChanged += new TTControlEventDelegate(ch3_CheckedChanged);
            ch7.CheckedChanged += new TTControlEventDelegate(ch7_CheckedChanged);
            ch5.CheckedChanged += new TTControlEventDelegate(ch5_CheckedChanged);
            ch6.CheckedChanged += new TTControlEventDelegate(ch6_CheckedChanged);
            ch4.CheckedChanged += new TTControlEventDelegate(ch4_CheckedChanged);
            ch18.CheckedChanged += new TTControlEventDelegate(ch18_CheckedChanged);
            ch17.CheckedChanged += new TTControlEventDelegate(ch17_CheckedChanged);
            ch16.CheckedChanged += new TTControlEventDelegate(ch16_CheckedChanged);
            ch15.CheckedChanged += new TTControlEventDelegate(ch15_CheckedChanged);
            ch14.CheckedChanged += new TTControlEventDelegate(ch14_CheckedChanged);
            ch13.CheckedChanged += new TTControlEventDelegate(ch13_CheckedChanged);
            ch12.CheckedChanged += new TTControlEventDelegate(ch12_CheckedChanged);
            ch31.CheckedChanged += new TTControlEventDelegate(ch31_CheckedChanged);
            ch32.CheckedChanged += new TTControlEventDelegate(ch32_CheckedChanged);
            ch75.CheckedChanged += new TTControlEventDelegate(ch75_CheckedChanged);
            ch33.CheckedChanged += new TTControlEventDelegate(ch33_CheckedChanged);
            ch74.CheckedChanged += new TTControlEventDelegate(ch74_CheckedChanged);
            ch34.CheckedChanged += new TTControlEventDelegate(ch34_CheckedChanged);
            ch81.CheckedChanged += new TTControlEventDelegate(ch81_CheckedChanged);
            ch35.CheckedChanged += new TTControlEventDelegate(ch35_CheckedChanged);
            ch73.CheckedChanged += new TTControlEventDelegate(ch73_CheckedChanged);
            ch36.CheckedChanged += new TTControlEventDelegate(ch36_CheckedChanged);
            ch82.CheckedChanged += new TTControlEventDelegate(ch82_CheckedChanged);
            ch37.CheckedChanged += new TTControlEventDelegate(ch37_CheckedChanged);
            ch72.CheckedChanged += new TTControlEventDelegate(ch72_CheckedChanged);
            ch38.CheckedChanged += new TTControlEventDelegate(ch38_CheckedChanged);
            ch48.CheckedChanged += new TTControlEventDelegate(ch48_CheckedChanged);
            ch71.CheckedChanged += new TTControlEventDelegate(ch71_CheckedChanged);
            ch83.CheckedChanged += new TTControlEventDelegate(ch83_CheckedChanged);
            ch65.CheckedChanged += new TTControlEventDelegate(ch65_CheckedChanged);
            ch84.CheckedChanged += new TTControlEventDelegate(ch84_CheckedChanged);
            ch47.CheckedChanged += new TTControlEventDelegate(ch47_CheckedChanged);
            ch85.CheckedChanged += new TTControlEventDelegate(ch85_CheckedChanged);
            ch64.CheckedChanged += new TTControlEventDelegate(ch64_CheckedChanged);
            ch46.CheckedChanged += new TTControlEventDelegate(ch46_CheckedChanged);
            ch45.CheckedChanged += new TTControlEventDelegate(ch45_CheckedChanged);
            ch63.CheckedChanged += new TTControlEventDelegate(ch63_CheckedChanged);
            ch44.CheckedChanged += new TTControlEventDelegate(ch44_CheckedChanged);
            ch62.CheckedChanged += new TTControlEventDelegate(ch62_CheckedChanged);
            ch43.CheckedChanged += new TTControlEventDelegate(ch43_CheckedChanged);
            ch61.CheckedChanged += new TTControlEventDelegate(ch61_CheckedChanged);
            ch42.CheckedChanged += new TTControlEventDelegate(ch42_CheckedChanged);
            ch51.CheckedChanged += new TTControlEventDelegate(ch51_CheckedChanged);
            ch41.CheckedChanged += new TTControlEventDelegate(ch41_CheckedChanged);
            ch52.CheckedChanged += new TTControlEventDelegate(ch52_CheckedChanged);
            ch53.CheckedChanged += new TTControlEventDelegate(ch53_CheckedChanged);
            ch54.CheckedChanged += new TTControlEventDelegate(ch54_CheckedChanged);
            ch55.CheckedChanged += new TTControlEventDelegate(ch55_CheckedChanged);
            ch28.CheckedChanged += new TTControlEventDelegate(ch28_CheckedChanged);
            ch11.CheckedChanged += new TTControlEventDelegate(ch11_CheckedChanged);
            ch21.CheckedChanged += new TTControlEventDelegate(ch21_CheckedChanged);
            ch27.CheckedChanged += new TTControlEventDelegate(ch27_CheckedChanged);
            ch26.CheckedChanged += new TTControlEventDelegate(ch26_CheckedChanged);
            ch25.CheckedChanged += new TTControlEventDelegate(ch25_CheckedChanged);
            ch24.CheckedChanged += new TTControlEventDelegate(ch24_CheckedChanged);
            ch23.CheckedChanged += new TTControlEventDelegate(ch23_CheckedChanged);
            ch22.CheckedChanged += new TTControlEventDelegate(ch22_CheckedChanged);
            gridTaahhutDisDVO.SelectionChanged += new TTControlEventDelegate(gridTaahhutDisDVO_SelectionChanged);
            gridTaahhutDisDVO.CellContentClick += new TTGridCellEventDelegate(gridTaahhutDisDVO_CellContentClick);
            buttonDisTaahhutKaydet.Click += new TTControlEventDelegate(buttonDisTaahhutKaydet_Click);
            buttonTaahhutNoileTaahhutOku.Click += new TTControlEventDelegate(buttonTaahhutNoileTaahhutOku_Click);
            buttonTaahhutSil.Click += new TTControlEventDelegate(buttonTaahhutSil_Click);
            buttonTCKimlikNoIleTaahhutSorgula.Click += new TTControlEventDelegate(buttonTCKimlikNoIleTaahhutSorgula_Click);
            chkTCKimlikNoIleSorgula.CheckedChanged += new TTControlEventDelegate(chkTCKimlikNoIleSorgula_CheckedChanged);
            chkTaahhutSil.CheckedChanged += new TTControlEventDelegate(chkTaahhutSil_CheckedChanged);
            chkTaahhutNoIleSorgula.CheckedChanged += new TTControlEventDelegate(chkTaahhutNoIleSorgula_CheckedChanged);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkTaahhutKaydet.CheckedChanged -= new TTControlEventDelegate(chkTaahhutKaydet_CheckedChanged);
            TTListBox.SelectedObjectChanged -= new TTControlEventDelegate(TTListBox_SelectedObjectChanged);
            ch1.CheckedChanged -= new TTControlEventDelegate(ch1_CheckedChanged);
            ch2.CheckedChanged -= new TTControlEventDelegate(ch2_CheckedChanged);
            ch3.CheckedChanged -= new TTControlEventDelegate(ch3_CheckedChanged);
            ch7.CheckedChanged -= new TTControlEventDelegate(ch7_CheckedChanged);
            ch5.CheckedChanged -= new TTControlEventDelegate(ch5_CheckedChanged);
            ch6.CheckedChanged -= new TTControlEventDelegate(ch6_CheckedChanged);
            ch4.CheckedChanged -= new TTControlEventDelegate(ch4_CheckedChanged);
            ch18.CheckedChanged -= new TTControlEventDelegate(ch18_CheckedChanged);
            ch17.CheckedChanged -= new TTControlEventDelegate(ch17_CheckedChanged);
            ch16.CheckedChanged -= new TTControlEventDelegate(ch16_CheckedChanged);
            ch15.CheckedChanged -= new TTControlEventDelegate(ch15_CheckedChanged);
            ch14.CheckedChanged -= new TTControlEventDelegate(ch14_CheckedChanged);
            ch13.CheckedChanged -= new TTControlEventDelegate(ch13_CheckedChanged);
            ch12.CheckedChanged -= new TTControlEventDelegate(ch12_CheckedChanged);
            ch31.CheckedChanged -= new TTControlEventDelegate(ch31_CheckedChanged);
            ch32.CheckedChanged -= new TTControlEventDelegate(ch32_CheckedChanged);
            ch75.CheckedChanged -= new TTControlEventDelegate(ch75_CheckedChanged);
            ch33.CheckedChanged -= new TTControlEventDelegate(ch33_CheckedChanged);
            ch74.CheckedChanged -= new TTControlEventDelegate(ch74_CheckedChanged);
            ch34.CheckedChanged -= new TTControlEventDelegate(ch34_CheckedChanged);
            ch81.CheckedChanged -= new TTControlEventDelegate(ch81_CheckedChanged);
            ch35.CheckedChanged -= new TTControlEventDelegate(ch35_CheckedChanged);
            ch73.CheckedChanged -= new TTControlEventDelegate(ch73_CheckedChanged);
            ch36.CheckedChanged -= new TTControlEventDelegate(ch36_CheckedChanged);
            ch82.CheckedChanged -= new TTControlEventDelegate(ch82_CheckedChanged);
            ch37.CheckedChanged -= new TTControlEventDelegate(ch37_CheckedChanged);
            ch72.CheckedChanged -= new TTControlEventDelegate(ch72_CheckedChanged);
            ch38.CheckedChanged -= new TTControlEventDelegate(ch38_CheckedChanged);
            ch48.CheckedChanged -= new TTControlEventDelegate(ch48_CheckedChanged);
            ch71.CheckedChanged -= new TTControlEventDelegate(ch71_CheckedChanged);
            ch83.CheckedChanged -= new TTControlEventDelegate(ch83_CheckedChanged);
            ch65.CheckedChanged -= new TTControlEventDelegate(ch65_CheckedChanged);
            ch84.CheckedChanged -= new TTControlEventDelegate(ch84_CheckedChanged);
            ch47.CheckedChanged -= new TTControlEventDelegate(ch47_CheckedChanged);
            ch85.CheckedChanged -= new TTControlEventDelegate(ch85_CheckedChanged);
            ch64.CheckedChanged -= new TTControlEventDelegate(ch64_CheckedChanged);
            ch46.CheckedChanged -= new TTControlEventDelegate(ch46_CheckedChanged);
            ch45.CheckedChanged -= new TTControlEventDelegate(ch45_CheckedChanged);
            ch63.CheckedChanged -= new TTControlEventDelegate(ch63_CheckedChanged);
            ch44.CheckedChanged -= new TTControlEventDelegate(ch44_CheckedChanged);
            ch62.CheckedChanged -= new TTControlEventDelegate(ch62_CheckedChanged);
            ch43.CheckedChanged -= new TTControlEventDelegate(ch43_CheckedChanged);
            ch61.CheckedChanged -= new TTControlEventDelegate(ch61_CheckedChanged);
            ch42.CheckedChanged -= new TTControlEventDelegate(ch42_CheckedChanged);
            ch51.CheckedChanged -= new TTControlEventDelegate(ch51_CheckedChanged);
            ch41.CheckedChanged -= new TTControlEventDelegate(ch41_CheckedChanged);
            ch52.CheckedChanged -= new TTControlEventDelegate(ch52_CheckedChanged);
            ch53.CheckedChanged -= new TTControlEventDelegate(ch53_CheckedChanged);
            ch54.CheckedChanged -= new TTControlEventDelegate(ch54_CheckedChanged);
            ch55.CheckedChanged -= new TTControlEventDelegate(ch55_CheckedChanged);
            ch28.CheckedChanged -= new TTControlEventDelegate(ch28_CheckedChanged);
            ch11.CheckedChanged -= new TTControlEventDelegate(ch11_CheckedChanged);
            ch21.CheckedChanged -= new TTControlEventDelegate(ch21_CheckedChanged);
            ch27.CheckedChanged -= new TTControlEventDelegate(ch27_CheckedChanged);
            ch26.CheckedChanged -= new TTControlEventDelegate(ch26_CheckedChanged);
            ch25.CheckedChanged -= new TTControlEventDelegate(ch25_CheckedChanged);
            ch24.CheckedChanged -= new TTControlEventDelegate(ch24_CheckedChanged);
            ch23.CheckedChanged -= new TTControlEventDelegate(ch23_CheckedChanged);
            ch22.CheckedChanged -= new TTControlEventDelegate(ch22_CheckedChanged);
            gridTaahhutDisDVO.SelectionChanged -= new TTControlEventDelegate(gridTaahhutDisDVO_SelectionChanged);
            gridTaahhutDisDVO.CellContentClick -= new TTGridCellEventDelegate(gridTaahhutDisDVO_CellContentClick);
            buttonDisTaahhutKaydet.Click -= new TTControlEventDelegate(buttonDisTaahhutKaydet_Click);
            buttonTaahhutNoileTaahhutOku.Click -= new TTControlEventDelegate(buttonTaahhutNoileTaahhutOku_Click);
            buttonTaahhutSil.Click -= new TTControlEventDelegate(buttonTaahhutSil_Click);
            buttonTCKimlikNoIleTaahhutSorgula.Click -= new TTControlEventDelegate(buttonTCKimlikNoIleTaahhutSorgula_Click);
            chkTCKimlikNoIleSorgula.CheckedChanged -= new TTControlEventDelegate(chkTCKimlikNoIleSorgula_CheckedChanged);
            chkTaahhutSil.CheckedChanged -= new TTControlEventDelegate(chkTaahhutSil_CheckedChanged);
            chkTaahhutNoIleSorgula.CheckedChanged -= new TTControlEventDelegate(chkTaahhutNoIleSorgula_CheckedChanged);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            base.UnBindControlEvents();
        }

        private void chkTaahhutKaydet_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_chkTaahhutKaydet_CheckedChanged
   if (((TTVisual.TTCheckBox)(lockCheckboxes)).Checked == false)
            {
                ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = true;

                txtboxOkunacakTaahhutNumarasi.Required = false;
                txtboxSilinecekTaahhutNo.Required = false;
                panelMedulaSonuc.Visible = false;
                
                if (((TTVisual.TTCheckBox)(chkTaahhutKaydet)).Checked)
                {
                    tabTahhutIslemleri.Visible = true;
                    this.tabTahhutIslemleri.ShowTabPage(TaahhutKayit);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutNumarasiIleTaahhutOku);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutSil);
                    this.tabTahhutIslemleri.HideTabPage(TCKimlikNoIleTaahhutOku);
                }
                else
                    tabTahhutIslemleri.Visible = false;
                
                ((TTVisual.TTCheckBox)(chkTaahhutNoIleSorgula)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTaahhutSil)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTCKimlikNoIleSorgula)).Checked = false;
            }
            ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = false;
#endregion MedulaDisTaahhutIslemleri_chkTaahhutKaydet_CheckedChanged
        }

        private void TTListBox_SelectedObjectChanged()
        {
#region MedulaDisTaahhutIslemleri_TTListBox_SelectedObjectChanged
   this.txtboxAdresIlce.ListFilterExpression = "CITY = '" + this.TTListBox.SelectedValue.ToString() + "'";
#endregion MedulaDisTaahhutIslemleri_TTListBox_SelectedObjectChanged
        }

        private void ch1_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch1_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch1)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "1";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch1), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch1_CheckedChanged
        }

        private void ch2_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch2_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch2)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "2";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch2), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch2_CheckedChanged
        }

        private void ch3_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch3_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch3)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "3";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch3), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch3_CheckedChanged
        }

        private void ch7_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch7_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch7)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "7";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch7), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch7_CheckedChanged
        }

        private void ch5_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch5_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch5)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "5";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch5), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch5_CheckedChanged
        }

        private void ch6_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch6_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch6)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "6";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch6), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch6_CheckedChanged
        }

        private void ch4_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch4_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch4)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "4";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch4), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch4_CheckedChanged
        }

        private void ch18_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch18_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch18)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "18";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch18), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch18_CheckedChanged
        }

        private void ch17_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch17_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch17)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "17";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch17), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch17_CheckedChanged
        }

        private void ch16_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch16_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch16)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "16";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch16), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch16_CheckedChanged
        }

        private void ch15_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch15_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch15)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "15";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch15), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch15_CheckedChanged
        }

        private void ch14_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch14_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch14)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "14";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch14), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch14_CheckedChanged
        }

        private void ch13_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch13_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch13)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "13";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch13), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch13_CheckedChanged
        }

        private void ch12_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch12_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch12)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "12";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch12), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch12_CheckedChanged
        }

        private void ch31_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch31_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch31)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "31";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch31), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch31_CheckedChanged
        }

        private void ch32_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch32_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch32)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "32";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch32), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch32_CheckedChanged
        }

        private void ch75_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch75_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch75)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "75";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch75), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch75_CheckedChanged
        }

        private void ch33_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch33_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch33)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "33";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch33), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch33_CheckedChanged
        }

        private void ch74_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch74_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch74)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "74";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch74), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch74_CheckedChanged
        }

        private void ch34_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch34_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch34)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "34";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch34), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch34_CheckedChanged
        }

        private void ch81_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch81_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch81)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "81";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch81), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch81_CheckedChanged
        }

        private void ch35_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch35_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch35)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "35";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch35), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch35_CheckedChanged
        }

        private void ch73_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch73_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch73)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "73";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch73), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch73_CheckedChanged
        }

        private void ch36_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch36_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch36)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "36";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch36), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch36_CheckedChanged
        }

        private void ch82_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch82_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch82)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "82";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch82), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch82_CheckedChanged
        }

        private void ch37_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch37_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch37)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "37";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch37), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch37_CheckedChanged
        }

        private void ch72_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch72_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch72)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "72";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch72), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch72_CheckedChanged
        }

        private void ch38_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch38_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch38)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "38";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch38), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch38_CheckedChanged
        }

        private void ch48_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch48_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch48)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "48";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch48), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch48_CheckedChanged
        }

        private void ch71_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch71_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch71)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "71";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch71), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch71_CheckedChanged
        }

        private void ch83_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch83_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch83)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "83";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch83), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch83_CheckedChanged
        }

        private void ch65_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch65_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch65)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "65";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch65), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch65_CheckedChanged
        }

        private void ch84_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch84_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch84)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "84";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch84), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch84_CheckedChanged
        }

        private void ch47_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch47_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch47)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "47";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch47), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch47_CheckedChanged
        }

        private void ch85_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch85_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch85)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "85";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch85), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch85_CheckedChanged
        }

        private void ch64_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch64_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch64)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "64";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch64), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch64_CheckedChanged
        }

        private void ch46_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch46_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch46)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "46";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch46), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch46_CheckedChanged
        }

        private void ch45_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch45_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch45)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "45";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch45), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch45_CheckedChanged
        }

        private void ch63_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch63_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch63)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "63";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch63), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch63_CheckedChanged
        }

        private void ch44_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch44_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch44)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "44";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch44), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch44_CheckedChanged
        }

        private void ch62_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch62_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch62)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "62";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch62), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch62_CheckedChanged
        }

        private void ch43_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch43_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch43)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "43";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch43), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch43_CheckedChanged
        }

        private void ch61_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch61_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch61)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "61";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch61), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch61_CheckedChanged
        }

        private void ch42_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch42_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch42)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "42";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch42), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch42_CheckedChanged
        }

        private void ch51_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch51_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch51)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "51";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch51), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch51_CheckedChanged
        }

        private void ch41_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch41_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch41)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "41";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch41), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch41_CheckedChanged
        }

        private void ch52_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch52_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch52)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "52";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch52), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch52_CheckedChanged
        }

        private void ch53_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch53_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch53)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "53";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch53), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch53_CheckedChanged
        }

        private void ch54_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch54_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch54)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "54";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch54), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch54_CheckedChanged
        }

        private void ch55_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch55_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch55)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "55";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch55), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch55_CheckedChanged
        }

        private void ch28_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch28_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch28)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "28";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch28), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch28_CheckedChanged
        }

        private void ch11_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch11_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch11)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "11";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch11), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch11_CheckedChanged
        }

        private void ch21_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch21_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch21)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "21";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch21), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch21_CheckedChanged
        }

        private void ch27_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch27_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch27)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "27";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch27), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch27_CheckedChanged
        }

        private void ch26_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch26_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch26)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "26";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch26), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch26_CheckedChanged
        }

        private void ch25_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch25_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch25)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "25";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch25), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch25_CheckedChanged
        }

        private void ch24_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch24_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch24)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "24";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch24), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch24_CheckedChanged
        }

        private void ch23_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch23_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch23)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "23";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch23), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch23_CheckedChanged
        }

        private void ch22_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_ch22_CheckedChanged
   if (((TTVisual.TTCheckBox)(ch22)).Checked == true)
            {
                if (gridTaahhutDisDVO.CurrentCell != null)
                {
                    switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                    {
                        case "DisNo":
                            gridTaahhutDisDVO.CurrentCell.Value = "22";

                            break;
                        default:
                            break;
                    }
                }
                CheckBoxControl((TTVisual.TTCheckBox)(ch22), false);
            }
#endregion MedulaDisTaahhutIslemleri_ch22_CheckedChanged
        }

        private void gridTaahhutDisDVO_SelectionChanged()
        {
#region MedulaDisTaahhutIslemleri_gridTaahhutDisDVO_SelectionChanged
   if (gridTaahhutDisDVO.CurrentCell != null)
            {
                if (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name == "DisNo")
                {
                  if ((string)gridTaahhutDisDVO.CurrentCell.Value != null)
                   {
                    if ((string)(string)gridTaahhutDisDVO.CurrentCell.Value == "1")
                        ((TTVisual.TTCheckBox)(ch1)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "2")
                        ((TTVisual.TTCheckBox)(ch2)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "3")
                        ((TTVisual.TTCheckBox)(ch3)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "4")
                        ((TTVisual.TTCheckBox)(ch4)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "5")
                        ((TTVisual.TTCheckBox)(ch5)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "6")
                        ((TTVisual.TTCheckBox)(ch6)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "7")
                        ((TTVisual.TTCheckBox)(ch7)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "11")
                        ((TTVisual.TTCheckBox)(ch11)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "12")
                        ((TTVisual.TTCheckBox)(ch12)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "13")
                        ((TTVisual.TTCheckBox)(ch13)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "14")
                        ((TTVisual.TTCheckBox)(ch14)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "15")
                        ((TTVisual.TTCheckBox)(ch15)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "16")
                        ((TTVisual.TTCheckBox)(ch16)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "17")
                        ((TTVisual.TTCheckBox)(ch17)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "18")
                        ((TTVisual.TTCheckBox)(ch18)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "21")
                        ((TTVisual.TTCheckBox)(ch21)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "22")
                        ((TTVisual.TTCheckBox)(ch22)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "23")
                        ((TTVisual.TTCheckBox)(ch23)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "24")
                        ((TTVisual.TTCheckBox)(ch24)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "25")
                        ((TTVisual.TTCheckBox)(ch25)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "26")
                        ((TTVisual.TTCheckBox)(ch26)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "27")
                        ((TTVisual.TTCheckBox)(ch27)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "28")
                        ((TTVisual.TTCheckBox)(ch28)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "31")
                        ((TTVisual.TTCheckBox)(ch31)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "32")
                        ((TTVisual.TTCheckBox)(ch32)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "33")
                        ((TTVisual.TTCheckBox)(ch33)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "34")
                        ((TTVisual.TTCheckBox)(ch34)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "35")
                        ((TTVisual.TTCheckBox)(ch35)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "36")
                        ((TTVisual.TTCheckBox)(ch36)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "37")
                        ((TTVisual.TTCheckBox)(ch37)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "38")
                        ((TTVisual.TTCheckBox)(ch38)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "41")
                        ((TTVisual.TTCheckBox)(ch41)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "42")
                        ((TTVisual.TTCheckBox)(ch42)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "43")
                        ((TTVisual.TTCheckBox)(ch43)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "44")
                        ((TTVisual.TTCheckBox)(ch44)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "45")
                        ((TTVisual.TTCheckBox)(ch45)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "46")
                        ((TTVisual.TTCheckBox)(ch46)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "47")
                        ((TTVisual.TTCheckBox)(ch47)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "48")
                        ((TTVisual.TTCheckBox)(ch48)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "51")
                        ((TTVisual.TTCheckBox)(ch51)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "52")
                        ((TTVisual.TTCheckBox)(ch52)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "53")
                        ((TTVisual.TTCheckBox)(ch53)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "54")
                        ((TTVisual.TTCheckBox)(ch54)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "55")
                        ((TTVisual.TTCheckBox)(ch55)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "61")
                        ((TTVisual.TTCheckBox)(ch61)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "62")
                        ((TTVisual.TTCheckBox)(ch62)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "63")
                        ((TTVisual.TTCheckBox)(ch63)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "64")
                        ((TTVisual.TTCheckBox)(ch64)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "65")
                        ((TTVisual.TTCheckBox)(ch65)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "71")
                        ((TTVisual.TTCheckBox)(ch71)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "72")
                        ((TTVisual.TTCheckBox)(ch72)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "73")
                        ((TTVisual.TTCheckBox)(ch73)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "74")
                        ((TTVisual.TTCheckBox)(ch74)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "75")
                        ((TTVisual.TTCheckBox)(ch75)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "81")
                        ((TTVisual.TTCheckBox)(ch81)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "82")
                        ((TTVisual.TTCheckBox)(ch82)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "83")
                        ((TTVisual.TTCheckBox)(ch83)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "84")
                        ((TTVisual.TTCheckBox)(ch84)).Checked = true;
                    if ((string)gridTaahhutDisDVO.CurrentCell.Value == "85")
                        ((TTVisual.TTCheckBox)(ch85)).Checked = true;
                   }
                  else
                     CheckBoxControl((TTVisual.TTCheckBox)(ch1),true);
                }
            }
            else 
            {
                CheckBoxControl((TTVisual.TTCheckBox)(ch1),true);
            }
#endregion MedulaDisTaahhutIslemleri_gridTaahhutDisDVO_SelectionChanged
        }

        private void gridTaahhutDisDVO_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region MedulaDisTaahhutIslemleri_gridTaahhutDisDVO_CellContentClick
   //switch (gridTaahhutDisDVO.CurrentCell.OwningColumn.Name)
                //{
                //    case "DisSemasi":
                //           TTObjectContext context = new TTObjectContext(false);
                //           DentalExaminationSuggestedProsthesis dentalExaminationSuggestedProsthesis = new DentalExaminationSuggestedProsthesis(context);
                //           TTVisual.TTForm dentalToothSchemaSugProsthesis = new TTFormClasses.DentalToothSchemaSugProsthesis();
                //           System.Windows.Forms.DialogResult dialogResult = dentalToothSchemaSugProsthesis.ShowEdit(this.FindForm(), dentalExaminationSuggestedProsthesis);
                             
                //           if (dialogResult != System.Windows.Forms.DialogResult.OK)
                //           {
                //                   throw new TTUtils.TTException(SystemMessage.GetMessage(140));
                //           }
                //           context.Save();
                //           gridTaahhutDisDVO.Rows[rowIndex].Cells[1].Value = (Common.GetEnumValueDefOfEnumValue(dentalExaminationSuggestedProsthesis.ToothNumber).Value) ;

                //          // (string)(Common.GetEnumValueDefOfEnumValue(this.AppointmentDefinitionName).DisplayText);
                //        break;
                //    default:
                //        break;
                //}
           // }
#endregion MedulaDisTaahhutIslemleri_gridTaahhutDisDVO_CellContentClick
        }

        private void buttonDisTaahhutKaydet_Click()
        {
#region MedulaDisTaahhutIslemleri_buttonDisTaahhutKaydet_Click
   try{
                txtSonucKoduTaahhutKaydet.Text ="";
                txtSonucMesajiTaahhutKaydet.Text="";
                txtAlınanTaahhutNo.Text ="";
                panelMedulaSonuc.Visible = true;
                this.TabMedulaSonuc.ShowTabPage(tabTaahhutKaydetSonuc);
                this.TabMedulaSonuc.HideTabPage(tabTaahhutNumarasiIleSorgulama);
                this.TabMedulaSonuc.HideTabPage(tabTaahhutSilSonuc);
                this.TabMedulaSonuc.HideTabPage(tabTCKimlikNoIleSorgulamaSonuc);
                
                TaahhutIslemleri.taahhutKayitDVO _taahhutKayitDVO = new TaahhutIslemleri.taahhutKayitDVO();
                
                _taahhutKayitDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                
                TaahhutIslemleri.taahhutDVO taahhutDVO = new TaahhutIslemleri.taahhutDVO();
                
                taahhutDVO.adressIlPlaka =Convert.ToInt32(((TTObjectClasses.City)(this.TTListBox.SelectedObject)).Code);
                //taahhutDVO.adressIlPlaka = Convert.ToInt32(txtboxAdresIlPlaka.Text.ToString());
                TownDefinitions ilce = (TownDefinitions)txtboxAdresIlce.SelectedObject;
                taahhutDVO.adressIlce = ilce.Name;
                taahhutDVO.adressPostaKodu = txtboxAdresPostaKodu.Text.ToString();
                taahhutDVO.adressCaddeSokak =  txtboxAdresCaddeSokak.Text.ToString();
                taahhutDVO.adressDisKapiNo =  txtboxAdresDisKapiNo.Text.ToString() ;
                taahhutDVO.adressIcKapiNo =  txtboxAdresIcKapiNo.Text.ToString();
                taahhutDVO.adressTelefon =  txtboxAdresTelefon.Text.ToString();
                taahhutDVO.adressEposta =  (txtboxEposta != null && txtboxEposta.Text != null) ? txtboxEposta.Text.ToString() : null;
                taahhutDVO.taahhutAlanAd =  txtboxTaahhutAlanAdi.Text.ToString();
                taahhutDVO.taahhutAlanSoyad =  txtboxTaahhutAlanSoyadi.Text.ToString();
                taahhutDVO.hastaTCKimlikNo = txtTCKNo.Text.Trim();
                
                _taahhutKayitDVO.taahhut = taahhutDVO;
                
                List<TaahhutIslemleri.taahhutDisDVO> taahhutDisDVOList= new List<TaahhutIslemleri.taahhutDisDVO>();
                
                
                if( this.gridTaahhutDisDVO != null && this.gridTaahhutDisDVO.Rows.Count > 0)
                {
                    for(int i= 0; i< this.gridTaahhutDisDVO.Rows.Count ; i++)
                    {
                        TaahhutIslemleri.taahhutDisDVO taahhutDisDVO = new TaahhutIslemleri.taahhutDisDVO();
                        if(gridTaahhutDisDVO.Rows[i].Cells["SUTCode"].Value == null)
                            throw new TTUtils.TTException("SUT Kodu boş olamaz.");
                        
                        Guid SUTguid = new Guid(gridTaahhutDisDVO.Rows[i].Cells["SUTCode"].Value.ToString());
                        TTObjectContext context = new TTObjectContext(true);
                        SUTDefinition sut = (SUTDefinition)context.GetObject(SUTguid, typeof(SUTDefinition).Name);
                        taahhutDisDVO.sutKodu = sut.Code;
                        taahhutDisDVO.disNo = Convert.ToInt32(this.gridTaahhutDisDVO.Rows[i].Cells["DisNo"].Value.ToString());
                        taahhutDisDVOList.Add(taahhutDisDVO);
                    }
                }
                else
                    throw new TTUtils.TTException("En az bir diş bilgisi gönderilmelidir.");
                
                
                _taahhutKayitDVO.taahhutDiss = taahhutDisDVOList.ToArray();
                
                if (gridHastaAktifTakipleri.CurrentCell != null && gridHastaAktifTakipleri.CurrentCell.RowIndex >= 0)
                {
                    ITTGridRow selectedRow = gridHastaAktifTakipleri.CurrentCell.OwningRow;
                    if (selectedRow != null )
                    {
                        _taahhutKayitDVO.takipNo  = selectedRow.Cells[0].Value.ToString();
                    }
                }
                else
                {
                    InfoBox.Show("Hastanın Bu Rapor İçin Geçerli Bir Branşta Takibi Bulunamamktadır ! ");
                    return;
                }

               // _taahhutKayitDVO.takipNo = txtboxTakipNo.Text.ToString();

                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TaahhutIslemleri.taahhutCevapDVO _taahhutCevapDVO = TaahhutIslemleri.WebMethods.disTaahhutKayit(siteID, _taahhutKayitDVO);
                
                //Takip No set edilecek.
                
                if(_taahhutCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(_taahhutCevapDVO.sonucKodu) == false)
                    {
                        txtSonucKoduTaahhutKaydet.Text = _taahhutCevapDVO.sonucKodu;
                        if(_taahhutCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoBox.Show( " Hastanın taahhüt bilgilerini kaydetme işlemi başarılı şekilde yapıldı. Taahhüt No: "+ _taahhutCevapDVO.taahhutNo.ToString(), MessageIconEnum.InformationMessage);
                            txtSonucMesajiTaahhutKaydet.Text = _taahhutCevapDVO.sonucMesaji;
                            txtAlınanTaahhutNo.Text  = _taahhutCevapDVO.taahhutNo.ToString();
                            string uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Diş Taahhüt Raporu", "Kaydedilen diş taahhüt raporunun çıktısını almak ister misiniz?");
                            if (uKey == "E")
                                this.PrintTaahhut(_taahhutCevapDVO);
                            else
                                throw new Exception("İşlemden vazgeçildi.");
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(_taahhutCevapDVO.sonucMesaji) == false)
                            {
                                txtSonucMesajiTaahhutKaydet.Text = _taahhutCevapDVO.sonucMesaji;
                                throw new TTUtils.TTException("Hastanın taahhüt bilgilerini kaydetme işleminde hata var.Hata Mesajı: "+_taahhutCevapDVO.sonucMesaji);
                            }
                            else
                                throw new TTUtils.TTException("Hastanın taahhüt bilgilerini kaydetme işleminde hata var.Sonuç Mesajı boş!");
                        }
                    }
                    else
                        throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                    throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex.Message);
            }
#endregion MedulaDisTaahhutIslemleri_buttonDisTaahhutKaydet_Click
        }

        private void buttonTaahhutNoileTaahhutOku_Click()
        {
#region MedulaDisTaahhutIslemleri_buttonTaahhutNoileTaahhutOku_Click
   try{
                
                txtSonucKoduTaahhutNoileSorgula.Text = "";
                txtSonucMesajiTaahhutNoileSorgula.Text = "";
                panelMedulaSonuc.Visible = true;
                this.TabMedulaSonuc.HideTabPage(tabTaahhutKaydetSonuc);
                this.TabMedulaSonuc.ShowTabPage(tabTaahhutNumarasiIleSorgulama);
                this.TabMedulaSonuc.HideTabPage(tabTaahhutSilSonuc);
                this.TabMedulaSonuc.HideTabPage(tabTCKimlikNoIleSorgulamaSonuc);
                
                TaahhutIslemleri.taahhutOkuDVO _taahhutOkuDVO = new TaahhutIslemleri.taahhutOkuDVO();
                _taahhutOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _taahhutOkuDVO.taahhutNo = Convert.ToInt32(txtboxOkunacakTaahhutNumarasi.Text.Trim());// Convert.ToInt32(txtboxSilinecekTaahhutNo.Text.Trim());
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TaahhutIslemleri.taahhutCevapDVO _taahhutCevapDVO = TaahhutIslemleri.WebMethods.okuDisTaahhut(siteID, _taahhutOkuDVO);
                
                if(_taahhutCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(_taahhutCevapDVO.sonucKodu) == false)
                    {
                        txtSonucKoduTaahhutNoileSorgula.Text = _taahhutCevapDVO.sonucKodu;
                        if(_taahhutCevapDVO.sonucKodu.Equals("0000")){
                            InfoBox.Show( " Taahhüt okunması işlemi başarılı şekilde yapıldı.Taahhüt Numarası: "+ _taahhutCevapDVO.taahhutNo, MessageIconEnum.InformationMessage);
                            txtSonucMesajiTaahhutNoileSorgula.Text = _taahhutCevapDVO.sonucMesaji;
                             string uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Diş Taahhüt Raporu", "Sorgulanan diş taahhütün raporunun çıktısını almak ister misiniz?");
                            if (uKey == "E")
                                this.PrintTaahhut(_taahhutCevapDVO);
                            else
                                throw new Exception("İşlemden vazgeçildi.");    
                            
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(_taahhutCevapDVO.sonucMesaji) == false)
                            {
                                throw new TTUtils.TTException("Hastaya ait girilen taahhütün okunması işleminde hata var.Hata Mesajı: " + _taahhutCevapDVO.sonucMesaji);
                                //txtSonucMesajiTaahhutNoileSorgula.Text = _taahhutCevapDVO.sonucMesaji;
                            } 
                            else
                                throw new TTUtils.TTException("Hastaya ait girilen taahhütün okunması işleminde hata var.Sonuç Mesajı boş!");
                        }
                    }
                    else
                        throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                {
                    throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            catch(Exception ex)
            {
                 InfoBox.Show(ex.Message);
            }
#endregion MedulaDisTaahhutIslemleri_buttonTaahhutNoileTaahhutOku_Click
        }

        private void buttonTaahhutSil_Click()
        {
#region MedulaDisTaahhutIslemleri_buttonTaahhutSil_Click
   try{
                txtSonucMesajiTaahhutSil.Text ="";
                txtSonucKoduTaahhutSil.Text ="";
                panelMedulaSonuc.Visible = true;
                this.TabMedulaSonuc.HideTabPage(tabTaahhutKaydetSonuc);
                this.TabMedulaSonuc.HideTabPage(tabTaahhutNumarasiIleSorgulama);
                this.TabMedulaSonuc.ShowTabPage(tabTaahhutSilSonuc);
                this.TabMedulaSonuc.HideTabPage(tabTCKimlikNoIleSorgulamaSonuc);
                
                TaahhutIslemleri.taahhutOkuDVO _taahhutOkuDVO = new TaahhutIslemleri.taahhutOkuDVO();
                _taahhutOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _taahhutOkuDVO.taahhutNo = Convert.ToInt32(txtboxSilinecekTaahhutNo.Text.Trim());
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString()); 
                TaahhutIslemleri.taahhutCevapDVO _taahhutCevapDVO = TaahhutIslemleri.WebMethods.silDisTaahhut(siteID, _taahhutOkuDVO);
                
                if(_taahhutCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(_taahhutCevapDVO.sonucKodu) == false)
                    {
                         txtSonucKoduTaahhutSil.Text = _taahhutCevapDVO.sonucKodu;
                        if(_taahhutCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoBox.Show( " taahhüt silme işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
                            txtSonucMesajiTaahhutSil.Text = _taahhutCevapDVO.sonucMesaji;
                        }
                         else
                         {
                             if(string.IsNullOrEmpty(_taahhutCevapDVO.sonucMesaji) == false)
                             {
                                 txtSonucMesajiTaahhutSil.Text = _taahhutCevapDVO.sonucMesaji;
                                 throw new TTUtils.TTException("Hastaya ait girilen taahhütün silinmesi işleminde hata var.Hata Mesajı: " + _taahhutCevapDVO.sonucMesaji);
                             } 
                             else
                                 throw new TTUtils.TTException("Hastaya ait girilen taahhütün silinmesi işleminde hata var.Sonuç Mesajı boş!");
                        }
                    }
                    else
                        throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                {
                    throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            catch(Exception ex)
            {
                 InfoBox.Show(ex.Message);
            }
#endregion MedulaDisTaahhutIslemleri_buttonTaahhutSil_Click
        }

        private void buttonTCKimlikNoIleTaahhutSorgula_Click()
        {
#region MedulaDisTaahhutIslemleri_buttonTCKimlikNoIleTaahhutSorgula_Click
   try{
                if(string.IsNullOrEmpty(txtTCKNo.Text))
                {
                    InfoBox.Show("TC Kimlik No / YUPASS No boş olamaz.");
                    return;
                }
                
                txtSonucKoduTCKimlikNoileSorgula.Text ="";
                txtSonucMesajTCKimlikNoileSorgula.Text ="";
                panelMedulaSonuc.Visible = true;
                this.TabMedulaSonuc.HideTabPage(tabTaahhutKaydetSonuc);
                this.TabMedulaSonuc.HideTabPage(tabTaahhutNumarasiIleSorgulama);
                this.TabMedulaSonuc.HideTabPage(tabTaahhutSilSonuc);
                this.TabMedulaSonuc.ShowTabPage(tabTCKimlikNoIleSorgulamaSonuc);
                
                ((ITTGrid) this.ttgridTaahhutNo).Rows.Clear();
                TaahhutIslemleri.taahhutKisiOkuDVO _taahhutKisiOkuDVO = new TaahhutIslemleri.taahhutKisiOkuDVO();
                _taahhutKisiOkuDVO.saglikTesisKodu = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX"));
                _taahhutKisiOkuDVO.tcKimlikNo = (long)Convert.ToInt64(txtTCKNo.Text.Trim());
                Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                TaahhutIslemleri.taahhutKisiCevapDVO _taahhutKisiCevapDVO = TaahhutIslemleri.WebMethods.okuKisiDisTaahhut(siteID, _taahhutKisiOkuDVO);
                
                if(_taahhutKisiCevapDVO != null)
                {
                    if(string.IsNullOrEmpty(_taahhutKisiCevapDVO.sonucKodu) == false)
                    {
                        txtSonucKoduTCKimlikNoileSorgula.Text = _taahhutKisiCevapDVO.sonucKodu;
                        if(_taahhutKisiCevapDVO.sonucKodu.Equals("0000"))
                        {
                            InfoBox.Show( _taahhutKisiOkuDVO.tcKimlikNo.ToString() +" TC Kimlik No'lu hastanın taahhütlerini sorgulama işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
                            txtSonucMesajTCKimlikNoileSorgula.Text = _taahhutKisiCevapDVO.sonucMesaji;
                            for (int i = 0; i < _taahhutKisiCevapDVO.taahhutNo.Length; i++)
                            {
                                ITTGridRow row = this.ttgridTaahhutNo.Rows.Add();
                                row.Cells[TaahhutNo.Name].Value = _taahhutKisiCevapDVO.taahhutNo[i].ToString();
                            }
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(_taahhutKisiCevapDVO.sonucMesaji) == false)
                            {
                                txtSonucMesajTCKimlikNoileSorgula.Text = _taahhutKisiCevapDVO.sonucMesaji;
                                throw new TTUtils.TTException("Hastaya ait taahhütlerinin okunması işleminde hata var.Hata Mesajı: "+_taahhutKisiCevapDVO.sonucMesaji);
                            }
                            else
                                throw new TTUtils.TTException("Hastaya ait taahhütlerinin okunması işleminde hata var.Sonuç Mesajı boş!");
                        }
                    }
                    else
                        throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                {
                    throw new TTUtils.TTException("Medula ile iletişim kurulamadı. Lütfen daha sonra tekrar deneyiniz.");
                }
            }
            catch(Exception ex)
            {
                 InfoBox.Show(ex.Message);
            }
#endregion MedulaDisTaahhutIslemleri_buttonTCKimlikNoIleTaahhutSorgula_Click
        }

        private void chkTCKimlikNoIleSorgula_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_chkTCKimlikNoIleSorgula_CheckedChanged
   if (((TTVisual.TTCheckBox)(lockCheckboxes)).Checked == false)
            {
                ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = true;
                this.TTListBox.Required = false; 
                //txtboxAdresIlPlaka.Required = false;
                txtboxAdresIlce.Required = false;
                txtboxAdresPostaKodu.Required = false;
                txtboxAdresCaddeSokak.Required = false;
                txtboxAdresDisKapiNo.Required = false;
                txtboxAdresIcKapiNo.Required = false;
                txtboxAdresTelefon.Required = false;
                txtboxEposta.Required = false;
                txtboxTaahhutAlanAdi.Required = false;
                txtboxTaahhutAlanSoyadi.Required = false;
                txtboxSilinecekTaahhutNo.Required = false;
                txtboxOkunacakTaahhutNumarasi.Required = false;
                txtboxTakipNo.Required = false;
                panelMedulaSonuc.Visible = false;

                if (((TTVisual.TTCheckBox)(chkTCKimlikNoIleSorgula)).Checked)
                {
                    tabTahhutIslemleri.Visible = true;

                    this.tabTahhutIslemleri.HideTabPage(TaahhutNumarasiIleTaahhutOku);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutKayit);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutSil);
                    this.tabTahhutIslemleri.ShowTabPage(TCKimlikNoIleTaahhutOku);


                }
                else
                {
                    tabTahhutIslemleri.Visible = false;

                }

                ((TTVisual.TTCheckBox)(chkTaahhutKaydet)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTaahhutSil)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTaahhutNoIleSorgula)).Checked = false;
            }
            ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = false;
#endregion MedulaDisTaahhutIslemleri_chkTCKimlikNoIleSorgula_CheckedChanged
        }

        private void chkTaahhutSil_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_chkTaahhutSil_CheckedChanged
   if (((TTVisual.TTCheckBox)(lockCheckboxes)).Checked == false)
            {
                ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = true;
                this.TTListBox.Required = false; 
                //txtboxAdresIlPlaka.Required = false;
                txtboxAdresIlce.Required = false;
                txtboxAdresPostaKodu.Required = false;
                txtboxAdresCaddeSokak.Required = false;
                txtboxAdresDisKapiNo.Required = false;
                txtboxAdresIcKapiNo.Required = false;
                txtboxAdresTelefon.Required = false;
                txtboxEposta.Required = false;
                txtboxTaahhutAlanAdi.Required = false;
                txtboxTaahhutAlanSoyadi.Required = false;
                txtboxOkunacakTaahhutNumarasi.Required = false;
                txtboxTakipNo.Required = false;
                panelMedulaSonuc.Visible = false;

                if (((TTVisual.TTCheckBox)(chkTaahhutSil)).Checked)
                {
                    tabTahhutIslemleri.Visible = true;

                    this.tabTahhutIslemleri.ShowTabPage(TaahhutSil);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutKayit);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutNumarasiIleTaahhutOku);
                    this.tabTahhutIslemleri.HideTabPage(TCKimlikNoIleTaahhutOku);

                    txtboxSilinecekTaahhutNo.Required = true;

                }
                else
                {
                    tabTahhutIslemleri.Visible = false;

                }

                ((TTVisual.TTCheckBox)(chkTaahhutKaydet)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTaahhutNoIleSorgula)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTCKimlikNoIleSorgula)).Checked = false;
            }
            ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = false;
#endregion MedulaDisTaahhutIslemleri_chkTaahhutSil_CheckedChanged
        }

        private void chkTaahhutNoIleSorgula_CheckedChanged()
        {
#region MedulaDisTaahhutIslemleri_chkTaahhutNoIleSorgula_CheckedChanged
   if (((TTVisual.TTCheckBox)(lockCheckboxes)).Checked == false)
            {
                ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = true;
                this.TTListBox.Required = false; 
               // txtboxAdresIlPlaka.Required = false;
                txtboxAdresIlce.Required = false;
                txtboxAdresPostaKodu.Required = false;
                txtboxAdresCaddeSokak.Required = false;
                txtboxAdresDisKapiNo.Required = false;
                txtboxAdresIcKapiNo.Required = false;
                txtboxAdresTelefon.Required = false;
                txtboxEposta.Required = false;
                txtboxTaahhutAlanAdi.Required = false;
                txtboxTaahhutAlanSoyadi.Required = false;
                txtboxSilinecekTaahhutNo.Required = false;
                txtboxTakipNo.Required = false;
                panelMedulaSonuc.Visible = false;

                if (((TTVisual.TTCheckBox)(chkTaahhutNoIleSorgula)).Checked)
                {
                    tabTahhutIslemleri.Visible = true;

                    this.tabTahhutIslemleri.ShowTabPage(TaahhutNumarasiIleTaahhutOku);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutKayit);
                    this.tabTahhutIslemleri.HideTabPage(TaahhutSil);
                    this.tabTahhutIslemleri.HideTabPage(TCKimlikNoIleTaahhutOku);

                    txtboxOkunacakTaahhutNumarasi.Required = true;

                }
                else
                {
                    tabTahhutIslemleri.Visible = false;

                }

                ((TTVisual.TTCheckBox)(chkTaahhutKaydet)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTaahhutSil)).Checked = false;
                ((TTVisual.TTCheckBox)(chkTCKimlikNoIleSorgula)).Checked = false;
            }
            ((TTVisual.TTCheckBox)(lockCheckboxes)).Checked = false;
#endregion MedulaDisTaahhutIslemleri_chkTaahhutNoIleSorgula_CheckedChanged
        }

        private void cmdSearchPatient_Click()
        {
#region MedulaDisTaahhutIslemleri_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();
                List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
                string[] adSoyad;
                adSoyad = Common.CurrentUser.FullName.Split(' ');
                int i = 0;
                if (patient != null)
                {
                    retList = patient.GetActiveSGKSEPs(Common.RecTime(), Common.RecTime());
                    panelSearchResult.Visible = true;
                    panelMedulaSonuc.Visible = false;
                    txtName.Text = patient.Name;
                    txtSurname.Text = patient.Surname;
                    if(txtboxTaahhutAlanAdi.Text =="" && txtboxTaahhutAlanSoyadi.Text == "" )
                    {
                        foreach (string item in adSoyad)
                        {
                            
                            if (i == 0)
                                txtboxTaahhutAlanAdi.Text = adSoyad[i];//patient.Name;
                            else
                                txtboxTaahhutAlanSoyadi.Text += adSoyad[i] +" ";// patient.Surname;
                            i++;
                            
                        }
                    }
                    if (patient.YUPASSNO != null)
                    {
                        lblKimlikNo.Text = "YUPASS No";
                        txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                    }
                    else
                    {
                        lblKimlikNo.Text = "TC Kimlik Numarası";
                        txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                    }
                    txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                    if (patient.Sex != null)
                    {


                        if (patient.Sex.ADI == "ERKEK")
                            txtSex.Text = "Erkek";
                        else
                            txtSex.Text = "Bayan";
                    }
                }
                else
                {
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                    panelSearchResult.Visible = false;
                    panelMedulaSonuc.Visible = false;
                    txtSex.Text = "";
                    txtBirthDate.Text = "";
                    txtTCKNo.Text = "";
                    txtSurname.Text = "";
                    txtName.Text = "";
                }
                
                foreach( SubEpisodeProtocol item in  retList)
                {
                    if (!string.IsNullOrEmpty(item.MedulaTakipNo))
                    {
                        if(item.MedulaProvizyonTarihi >= DateTime.Now.AddDays(-30))
                        {
                            if(item.Brans.Code == "5600" || item.Brans.Code == "5300" || item.Brans.Code == "5500" || item.Brans.Code == "5150" || item.Brans.Code == "5400" || item.Brans.Code == "5700" || item.Brans.Code == "5100")
                            {
                                ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                                newRow.Cells[txtTakipNo1.Name].Value = item.MedulaTakipNo;
                                newRow.Cells[txtBrans1.Name].Value = item.Brans.Name_Shadow;
                                newRow.Cells[txtProvizyonTarihi1.Name].Value = item.MedulaProvizyonTarihi.ToString();
                                newRow.Cells[txtBasvuruNumarasi1.Name].Value = item.MedulaBasvuruNo;
                                newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Episode.HospitalProtocolNo;
                                newRow.Cells[txtVakaAcilisTarihi1.Name].Value  = item.Episode.OpeningDate;
                                newRow.Cells[txtBransKodu1.Name].Value  = item.Brans.Code;
                            }
                        }
                    }
                }
            }
#endregion MedulaDisTaahhutIslemleri_cmdSearchPatient_Click
        }

#region MedulaDisTaahhutIslemleri_Methods
        public MedulaDisTaahhutIslemleri(Patient patient) : base("MedulaDisTaahhutIslemleri") {
            List<SubEpisodeProtocol> retList = new List<SubEpisodeProtocol>();
            string[] adSoyad;
            adSoyad = Common.CurrentUser.FullName.Split(' ');
            int i = 0;
            if (patient != null)
            {
                retList = patient.GetActiveSGKSEPs(Common.RecTime(), Common.RecTime());
                panelSearchResult.Visible = true;
                panelMedulaSonuc.Visible = false;
                txtName.Text = patient.Name;
                txtSurname.Text = patient.Surname;
                if(txtboxTaahhutAlanAdi.Text =="" && txtboxTaahhutAlanSoyadi.Text == "" )
                {
                    foreach (string item in adSoyad)
                    {
                        
                        if (i == 0)
                            txtboxTaahhutAlanAdi.Text = adSoyad[i];//patient.Name;
                        else
                            txtboxTaahhutAlanSoyadi.Text += adSoyad[i] +" ";// patient.Surname;
                        i++;
                        
                    }
                }
                if(patient.YUPASSNO != null)
                {
                   lblKimlikNo.Text = "YUPASS No";
                   txtTCKNo.Text = patient.YUPASSNO != null ? (patient.YUPASSNO.Value.ToString() + "") : "";
                }
                else
                {
                    lblKimlikNo.Text = "TC Kimlik Numarası";
                    txtTCKNo.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
                }
                txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
                if (patient.Sex != null)
                {

                    if (patient.Sex.ADI == "KADIN")
                        txtSex.Text = "Bayan";
                    else
                        txtSex.Text = "Erkek";
                }
            }
            else
            {
                InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
                panelSearchResult.Visible = false;
                panelMedulaSonuc.Visible = false;
                txtSex.Text = "";
                txtBirthDate.Text = "";
                txtTCKNo.Text = "";
                txtSurname.Text = "";
                txtName.Text = "";
            }
            
            foreach(SubEpisodeProtocol item in  retList)
            {
                if (!string.IsNullOrEmpty(item.MedulaTakipNo))
                {
                    if(item.MedulaProvizyonTarihi >= DateTime.Now.AddDays(-30))
                    {
                        if(item.Brans.Code == "5600" || item.Brans.Code == "5300" || item.Brans.Code == "5500" || item.Brans.Code == "5150" || item.Brans.Code == "5400" || item.Brans.Code == "5700" || item.Brans.Code == "5100")
                        {
                            ITTGridRow newRow = gridHastaAktifTakipleri.Rows.Add();
                            newRow.Cells[txtTakipNo1.Name].Value = item.MedulaTakipNo;
                            newRow.Cells[txtBrans1.Name].Value = item.Brans.Name_Shadow;
                            newRow.Cells[txtProvizyonTarihi1.Name].Value = item.MedulaProvizyonTarihi.ToString();
                            newRow.Cells[txtBasvuruNumarasi1.Name].Value = item.MedulaBasvuruNo;
                            newRow.Cells[txtXXXXXXProtocolNo1.Name].Value = item.Episode.HospitalProtocolNo;
                            newRow.Cells[txtVakaAcilisTarihi1.Name].Value  = item.Episode.OpeningDate;
                            newRow.Cells[txtBransKodu1.Name].Value  = item.Brans.Code;
                        }
                    }
                }
            }
            chkTaahhutKaydet.Value = true;
        }
        
        
        
        
        public void CheckBoxControl(TTVisual.TTCheckBox checkedCheckBox, bool tumu)
        {
            List<TTVisual.TTCheckBox> checkBoxes = new  List<TTVisual.TTCheckBox>();
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch1)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch2)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch3)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch4)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch5)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch6)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch7)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch11)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch12)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch13)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch14)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch15)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch16)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch17)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch18)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch21)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch22)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch23)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch24)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch25)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch26)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch27)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch28)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch31)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch32)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch33)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch34)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch35)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch36)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch37)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch38)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch41)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch42)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch43)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch44)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch45)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch46)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch47)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch48)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch51)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch52)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch53)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch54)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch55)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch61)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch62)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch63)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch64)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch65)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch71)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch72)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch73)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch74)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch75)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch81)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch82)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch83)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch84)));
            checkBoxes.Add(((TTVisual.TTCheckBox)(ch85)));


            foreach (TTVisual.TTCheckBox item in checkBoxes)
            {
                if (tumu ==false && item != checkedCheckBox)
                {
                    item.Checked = false;
                }
                if (tumu == true)
                    item.Checked = false;
            }
            
            
        }
        
        public void PrintTaahhut(TaahhutIslemleri.taahhutCevapDVO taahhutCevapDVO)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.DefaultExt = "pdf";
            //saveFileDialog.Filter = "Adobe PDF Files (*.pdf)|*.pdf";
            //saveFileDialog.FileName = TTUtils.Globals.MakeFileName(taahhutCevapDVO.taahhutNo.ToString());
            //DialogResult dialogResult = saveFileDialog.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            //    try
            //    {
            //        if (taahhutCevapDVO.taahhutCikti == null)
            //            throw new TTException("Taahhüt Çıktı verisi olmadığından PDF dönüştürme işlemi gerçekleştirilemedi");

            //        byte[] buff = (byte[])taahhutCevapDVO.taahhutCikti;
            //        System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            //        System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            //        bw.Write(buff);
            //        bw.Close();

            //        System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //        proc.EnableRaisingEvents = false;
            //        proc.StartInfo.FileName = saveFileDialog.FileName;
            //        proc.StartInfo.WorkingDirectory = saveFileDialog.InitialDirectory;
            //        proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            //        proc.Start();
            //        proc.WaitForExit();
            //    }
            //    catch (Exception ex)
            //    {
            //        InfoBox.Show(ex);
            //    }
            //}
            var a = 1;
        }
        
#endregion MedulaDisTaahhutIslemleri_Methods
    }
}