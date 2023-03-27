
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
    public partial class TaahhutDisDVODisSemasiForm : TTForm
    {
        override protected void BindControlEvents()
        {
            buttonTumAgiz2.Click += new TTControlEventDelegate(buttonTumAgiz2_Click);
            button3.Click += new TTControlEventDelegate(button3_Click);
            button91.Click += new TTControlEventDelegate(button91_Click);
            button7.Click += new TTControlEventDelegate(button7_Click);
            button6.Click += new TTControlEventDelegate(button6_Click);
            button55.Click += new TTControlEventDelegate(button55_Click);
            button2.Click += new TTControlEventDelegate(button2_Click);
            button54.Click += new TTControlEventDelegate(button54_Click);
            buttonTumAgiz1.Click += new TTControlEventDelegate(buttonTumAgiz1_Click);
            button53.Click += new TTControlEventDelegate(button53_Click);
            button5.Click += new TTControlEventDelegate(button5_Click);
            button52.Click += new TTControlEventDelegate(button52_Click);
            button4.Click += new TTControlEventDelegate(button4_Click);
            button51.Click += new TTControlEventDelegate(button51_Click);
            button75.Click += new TTControlEventDelegate(button75_Click);
            button74.Click += new TTControlEventDelegate(button74_Click);
            button92.Click += new TTControlEventDelegate(button92_Click);
            button73.Click += new TTControlEventDelegate(button73_Click);
            button72.Click += new TTControlEventDelegate(button72_Click);
            button61.Click += new TTControlEventDelegate(button61_Click);
            button71.Click += new TTControlEventDelegate(button71_Click);
            button62.Click += new TTControlEventDelegate(button62_Click);
            button63.Click += new TTControlEventDelegate(button63_Click);
            button94.Click += new TTControlEventDelegate(button94_Click);
            button64.Click += new TTControlEventDelegate(button64_Click);
            button65.Click += new TTControlEventDelegate(button65_Click);
            button81.Click += new TTControlEventDelegate(button81_Click);
            button18.Click += new TTControlEventDelegate(button18_Click);
            button82.Click += new TTControlEventDelegate(button82_Click);
            button17.Click += new TTControlEventDelegate(button17_Click);
            button83.Click += new TTControlEventDelegate(button83_Click);
            button16.Click += new TTControlEventDelegate(button16_Click);
            button84.Click += new TTControlEventDelegate(button84_Click);
            button15.Click += new TTControlEventDelegate(button15_Click);
            button85.Click += new TTControlEventDelegate(button85_Click);
            button14.Click += new TTControlEventDelegate(button14_Click);
            button13.Click += new TTControlEventDelegate(button13_Click);
            button93.Click += new TTControlEventDelegate(button93_Click);
            button12.Click += new TTControlEventDelegate(button12_Click);
            button11.Click += new TTControlEventDelegate(button11_Click);
            button38.Click += new TTControlEventDelegate(button38_Click);
            button21.Click += new TTControlEventDelegate(button21_Click);
            button37.Click += new TTControlEventDelegate(button37_Click);
            button22.Click += new TTControlEventDelegate(button22_Click);
            button36.Click += new TTControlEventDelegate(button36_Click);
            button23.Click += new TTControlEventDelegate(button23_Click);
            button35.Click += new TTControlEventDelegate(button35_Click);
            button24.Click += new TTControlEventDelegate(button24_Click);
            button34.Click += new TTControlEventDelegate(button34_Click);
            button25.Click += new TTControlEventDelegate(button25_Click);
            button33.Click += new TTControlEventDelegate(button33_Click);
            button26.Click += new TTControlEventDelegate(button26_Click);
            button32.Click += new TTControlEventDelegate(button32_Click);
            button27.Click += new TTControlEventDelegate(button27_Click);
            button31.Click += new TTControlEventDelegate(button31_Click);
            button28.Click += new TTControlEventDelegate(button28_Click);
            button41.Click += new TTControlEventDelegate(button41_Click);
            button48.Click += new TTControlEventDelegate(button48_Click);
            button42.Click += new TTControlEventDelegate(button42_Click);
            button47.Click += new TTControlEventDelegate(button47_Click);
            button43.Click += new TTControlEventDelegate(button43_Click);
            button46.Click += new TTControlEventDelegate(button46_Click);
            button44.Click += new TTControlEventDelegate(button44_Click);
            button45.Click += new TTControlEventDelegate(button45_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            buttonTumAgiz2.Click -= new TTControlEventDelegate(buttonTumAgiz2_Click);
            button3.Click -= new TTControlEventDelegate(button3_Click);
            button91.Click -= new TTControlEventDelegate(button91_Click);
            button7.Click -= new TTControlEventDelegate(button7_Click);
            button6.Click -= new TTControlEventDelegate(button6_Click);
            button55.Click -= new TTControlEventDelegate(button55_Click);
            button2.Click -= new TTControlEventDelegate(button2_Click);
            button54.Click -= new TTControlEventDelegate(button54_Click);
            buttonTumAgiz1.Click -= new TTControlEventDelegate(buttonTumAgiz1_Click);
            button53.Click -= new TTControlEventDelegate(button53_Click);
            button5.Click -= new TTControlEventDelegate(button5_Click);
            button52.Click -= new TTControlEventDelegate(button52_Click);
            button4.Click -= new TTControlEventDelegate(button4_Click);
            button51.Click -= new TTControlEventDelegate(button51_Click);
            button75.Click -= new TTControlEventDelegate(button75_Click);
            button74.Click -= new TTControlEventDelegate(button74_Click);
            button92.Click -= new TTControlEventDelegate(button92_Click);
            button73.Click -= new TTControlEventDelegate(button73_Click);
            button72.Click -= new TTControlEventDelegate(button72_Click);
            button61.Click -= new TTControlEventDelegate(button61_Click);
            button71.Click -= new TTControlEventDelegate(button71_Click);
            button62.Click -= new TTControlEventDelegate(button62_Click);
            button63.Click -= new TTControlEventDelegate(button63_Click);
            button94.Click -= new TTControlEventDelegate(button94_Click);
            button64.Click -= new TTControlEventDelegate(button64_Click);
            button65.Click -= new TTControlEventDelegate(button65_Click);
            button81.Click -= new TTControlEventDelegate(button81_Click);
            button18.Click -= new TTControlEventDelegate(button18_Click);
            button82.Click -= new TTControlEventDelegate(button82_Click);
            button17.Click -= new TTControlEventDelegate(button17_Click);
            button83.Click -= new TTControlEventDelegate(button83_Click);
            button16.Click -= new TTControlEventDelegate(button16_Click);
            button84.Click -= new TTControlEventDelegate(button84_Click);
            button15.Click -= new TTControlEventDelegate(button15_Click);
            button85.Click -= new TTControlEventDelegate(button85_Click);
            button14.Click -= new TTControlEventDelegate(button14_Click);
            button13.Click -= new TTControlEventDelegate(button13_Click);
            button93.Click -= new TTControlEventDelegate(button93_Click);
            button12.Click -= new TTControlEventDelegate(button12_Click);
            button11.Click -= new TTControlEventDelegate(button11_Click);
            button38.Click -= new TTControlEventDelegate(button38_Click);
            button21.Click -= new TTControlEventDelegate(button21_Click);
            button37.Click -= new TTControlEventDelegate(button37_Click);
            button22.Click -= new TTControlEventDelegate(button22_Click);
            button36.Click -= new TTControlEventDelegate(button36_Click);
            button23.Click -= new TTControlEventDelegate(button23_Click);
            button35.Click -= new TTControlEventDelegate(button35_Click);
            button24.Click -= new TTControlEventDelegate(button24_Click);
            button34.Click -= new TTControlEventDelegate(button34_Click);
            button25.Click -= new TTControlEventDelegate(button25_Click);
            button33.Click -= new TTControlEventDelegate(button33_Click);
            button26.Click -= new TTControlEventDelegate(button26_Click);
            button32.Click -= new TTControlEventDelegate(button32_Click);
            button27.Click -= new TTControlEventDelegate(button27_Click);
            button31.Click -= new TTControlEventDelegate(button31_Click);
            button28.Click -= new TTControlEventDelegate(button28_Click);
            button41.Click -= new TTControlEventDelegate(button41_Click);
            button48.Click -= new TTControlEventDelegate(button48_Click);
            button42.Click -= new TTControlEventDelegate(button42_Click);
            button47.Click -= new TTControlEventDelegate(button47_Click);
            button43.Click -= new TTControlEventDelegate(button43_Click);
            button46.Click -= new TTControlEventDelegate(button46_Click);
            button44.Click -= new TTControlEventDelegate(button44_Click);
            button45.Click -= new TTControlEventDelegate(button45_Click);
            base.UnBindControlEvents();
        }

        private void buttonTumAgiz2_Click()
        {
#region TaahhutDisDVODisSemasiForm_buttonTumAgiz2_Click
   _TaahhutDisDVO.disNo = 1;
#endregion TaahhutDisDVODisSemasiForm_buttonTumAgiz2_Click
        }

        private void button3_Click()
        {
#region TaahhutDisDVODisSemasiForm_button3_Click
   _TaahhutDisDVO.disNo = 3;
#endregion TaahhutDisDVODisSemasiForm_button3_Click
        }

        private void button91_Click()
        {
#region TaahhutDisDVODisSemasiForm_button91_Click
   _TaahhutDisDVO.disNo = 91;
#endregion TaahhutDisDVODisSemasiForm_button91_Click
        }

        private void button7_Click()
        {
#region TaahhutDisDVODisSemasiForm_button7_Click
   _TaahhutDisDVO.disNo = 7;
#endregion TaahhutDisDVODisSemasiForm_button7_Click
        }

        private void button6_Click()
        {
#region TaahhutDisDVODisSemasiForm_button6_Click
   _TaahhutDisDVO.disNo = 6;
#endregion TaahhutDisDVODisSemasiForm_button6_Click
        }

        private void button55_Click()
        {
#region TaahhutDisDVODisSemasiForm_button55_Click
   _TaahhutDisDVO.disNo = 55;
#endregion TaahhutDisDVODisSemasiForm_button55_Click
        }

        private void button2_Click()
        {
#region TaahhutDisDVODisSemasiForm_button2_Click
   _TaahhutDisDVO.disNo = 2;
#endregion TaahhutDisDVODisSemasiForm_button2_Click
        }

        private void button54_Click()
        {
#region TaahhutDisDVODisSemasiForm_button54_Click
   _TaahhutDisDVO.disNo = 54;
#endregion TaahhutDisDVODisSemasiForm_button54_Click
        }

        private void buttonTumAgiz1_Click()
        {
#region TaahhutDisDVODisSemasiForm_buttonTumAgiz1_Click
   _TaahhutDisDVO.disNo = 1;
#endregion TaahhutDisDVODisSemasiForm_buttonTumAgiz1_Click
        }

        private void button53_Click()
        {
#region TaahhutDisDVODisSemasiForm_button53_Click
   _TaahhutDisDVO.disNo = 53;
#endregion TaahhutDisDVODisSemasiForm_button53_Click
        }

        private void button5_Click()
        {
#region TaahhutDisDVODisSemasiForm_button5_Click
   _TaahhutDisDVO.disNo = 5;
#endregion TaahhutDisDVODisSemasiForm_button5_Click
        }

        private void button52_Click()
        {
#region TaahhutDisDVODisSemasiForm_button52_Click
   _TaahhutDisDVO.disNo = 52;
#endregion TaahhutDisDVODisSemasiForm_button52_Click
        }

        private void button4_Click()
        {
#region TaahhutDisDVODisSemasiForm_button4_Click
   _TaahhutDisDVO.disNo = 4;
#endregion TaahhutDisDVODisSemasiForm_button4_Click
        }

        private void button51_Click()
        {
#region TaahhutDisDVODisSemasiForm_button51_Click
   _TaahhutDisDVO.disNo = 51;
#endregion TaahhutDisDVODisSemasiForm_button51_Click
        }

        private void button75_Click()
        {
#region TaahhutDisDVODisSemasiForm_button75_Click
   _TaahhutDisDVO.disNo = 75;
#endregion TaahhutDisDVODisSemasiForm_button75_Click
        }

        private void button74_Click()
        {
#region TaahhutDisDVODisSemasiForm_button74_Click
   _TaahhutDisDVO.disNo = 74;
#endregion TaahhutDisDVODisSemasiForm_button74_Click
        }

        private void button92_Click()
        {
#region TaahhutDisDVODisSemasiForm_button92_Click
   _TaahhutDisDVO.disNo = 92;
#endregion TaahhutDisDVODisSemasiForm_button92_Click
        }

        private void button73_Click()
        {
#region TaahhutDisDVODisSemasiForm_button73_Click
   _TaahhutDisDVO.disNo = 73;
#endregion TaahhutDisDVODisSemasiForm_button73_Click
        }

        private void button72_Click()
        {
#region TaahhutDisDVODisSemasiForm_button72_Click
   _TaahhutDisDVO.disNo = 72;
#endregion TaahhutDisDVODisSemasiForm_button72_Click
        }

        private void button61_Click()
        {
#region TaahhutDisDVODisSemasiForm_button61_Click
   _TaahhutDisDVO.disNo = 61;
#endregion TaahhutDisDVODisSemasiForm_button61_Click
        }

        private void button71_Click()
        {
#region TaahhutDisDVODisSemasiForm_button71_Click
   _TaahhutDisDVO.disNo = 71;
#endregion TaahhutDisDVODisSemasiForm_button71_Click
        }

        private void button62_Click()
        {
#region TaahhutDisDVODisSemasiForm_button62_Click
   _TaahhutDisDVO.disNo = 62;
#endregion TaahhutDisDVODisSemasiForm_button62_Click
        }

        private void button63_Click()
        {
#region TaahhutDisDVODisSemasiForm_button63_Click
   _TaahhutDisDVO.disNo = 63;
#endregion TaahhutDisDVODisSemasiForm_button63_Click
        }

        private void button94_Click()
        {
#region TaahhutDisDVODisSemasiForm_button94_Click
   _TaahhutDisDVO.disNo = 94;
#endregion TaahhutDisDVODisSemasiForm_button94_Click
        }

        private void button64_Click()
        {
#region TaahhutDisDVODisSemasiForm_button64_Click
   _TaahhutDisDVO.disNo = 64;
#endregion TaahhutDisDVODisSemasiForm_button64_Click
        }

        private void button65_Click()
        {
#region TaahhutDisDVODisSemasiForm_button65_Click
   _TaahhutDisDVO.disNo = 65;
#endregion TaahhutDisDVODisSemasiForm_button65_Click
        }

        private void button81_Click()
        {
#region TaahhutDisDVODisSemasiForm_button81_Click
   _TaahhutDisDVO.disNo = 81;
#endregion TaahhutDisDVODisSemasiForm_button81_Click
        }

        private void button18_Click()
        {
#region TaahhutDisDVODisSemasiForm_button18_Click
   _TaahhutDisDVO.disNo = 18;
#endregion TaahhutDisDVODisSemasiForm_button18_Click
        }

        private void button82_Click()
        {
#region TaahhutDisDVODisSemasiForm_button82_Click
   _TaahhutDisDVO.disNo = 82;
#endregion TaahhutDisDVODisSemasiForm_button82_Click
        }

        private void button17_Click()
        {
#region TaahhutDisDVODisSemasiForm_button17_Click
   _TaahhutDisDVO.disNo = 17;
#endregion TaahhutDisDVODisSemasiForm_button17_Click
        }

        private void button83_Click()
        {
#region TaahhutDisDVODisSemasiForm_button83_Click
   _TaahhutDisDVO.disNo = 83;
#endregion TaahhutDisDVODisSemasiForm_button83_Click
        }

        private void button16_Click()
        {
#region TaahhutDisDVODisSemasiForm_button16_Click
   _TaahhutDisDVO.disNo = 16;
#endregion TaahhutDisDVODisSemasiForm_button16_Click
        }

        private void button84_Click()
        {
#region TaahhutDisDVODisSemasiForm_button84_Click
   _TaahhutDisDVO.disNo = 84;
#endregion TaahhutDisDVODisSemasiForm_button84_Click
        }

        private void button15_Click()
        {
#region TaahhutDisDVODisSemasiForm_button15_Click
   _TaahhutDisDVO.disNo = 15;
#endregion TaahhutDisDVODisSemasiForm_button15_Click
        }

        private void button85_Click()
        {
#region TaahhutDisDVODisSemasiForm_button85_Click
   _TaahhutDisDVO.disNo = 85;
#endregion TaahhutDisDVODisSemasiForm_button85_Click
        }

        private void button14_Click()
        {
#region TaahhutDisDVODisSemasiForm_button14_Click
   _TaahhutDisDVO.disNo = 14;
#endregion TaahhutDisDVODisSemasiForm_button14_Click
        }

        private void button13_Click()
        {
#region TaahhutDisDVODisSemasiForm_button13_Click
   _TaahhutDisDVO.disNo = 13;
#endregion TaahhutDisDVODisSemasiForm_button13_Click
        }

        private void button93_Click()
        {
#region TaahhutDisDVODisSemasiForm_button93_Click
   _TaahhutDisDVO.disNo = 93;
#endregion TaahhutDisDVODisSemasiForm_button93_Click
        }

        private void button12_Click()
        {
#region TaahhutDisDVODisSemasiForm_button12_Click
   _TaahhutDisDVO.disNo = 12;
#endregion TaahhutDisDVODisSemasiForm_button12_Click
        }

        private void button11_Click()
        {
#region TaahhutDisDVODisSemasiForm_button11_Click
   _TaahhutDisDVO.disNo = 11;
#endregion TaahhutDisDVODisSemasiForm_button11_Click
        }

        private void button38_Click()
        {
#region TaahhutDisDVODisSemasiForm_button38_Click
   _TaahhutDisDVO.disNo = 38;
#endregion TaahhutDisDVODisSemasiForm_button38_Click
        }

        private void button21_Click()
        {
#region TaahhutDisDVODisSemasiForm_button21_Click
   _TaahhutDisDVO.disNo = 21;
#endregion TaahhutDisDVODisSemasiForm_button21_Click
        }

        private void button37_Click()
        {
#region TaahhutDisDVODisSemasiForm_button37_Click
   _TaahhutDisDVO.disNo = 37;
#endregion TaahhutDisDVODisSemasiForm_button37_Click
        }

        private void button22_Click()
        {
#region TaahhutDisDVODisSemasiForm_button22_Click
   _TaahhutDisDVO.disNo = 22;
#endregion TaahhutDisDVODisSemasiForm_button22_Click
        }

        private void button36_Click()
        {
#region TaahhutDisDVODisSemasiForm_button36_Click
   _TaahhutDisDVO.disNo = 36;
#endregion TaahhutDisDVODisSemasiForm_button36_Click
        }

        private void button23_Click()
        {
#region TaahhutDisDVODisSemasiForm_button23_Click
   _TaahhutDisDVO.disNo = 23;
#endregion TaahhutDisDVODisSemasiForm_button23_Click
        }

        private void button35_Click()
        {
#region TaahhutDisDVODisSemasiForm_button35_Click
   _TaahhutDisDVO.disNo = 35;
#endregion TaahhutDisDVODisSemasiForm_button35_Click
        }

        private void button24_Click()
        {
#region TaahhutDisDVODisSemasiForm_button24_Click
   _TaahhutDisDVO.disNo = 24;
#endregion TaahhutDisDVODisSemasiForm_button24_Click
        }

        private void button34_Click()
        {
#region TaahhutDisDVODisSemasiForm_button34_Click
   _TaahhutDisDVO.disNo = 34;
#endregion TaahhutDisDVODisSemasiForm_button34_Click
        }

        private void button25_Click()
        {
#region TaahhutDisDVODisSemasiForm_button25_Click
   _TaahhutDisDVO.disNo = 25;
#endregion TaahhutDisDVODisSemasiForm_button25_Click
        }

        private void button33_Click()
        {
#region TaahhutDisDVODisSemasiForm_button33_Click
   _TaahhutDisDVO.disNo = 33;
#endregion TaahhutDisDVODisSemasiForm_button33_Click
        }

        private void button26_Click()
        {
#region TaahhutDisDVODisSemasiForm_button26_Click
   _TaahhutDisDVO.disNo = 26;
#endregion TaahhutDisDVODisSemasiForm_button26_Click
        }

        private void button32_Click()
        {
#region TaahhutDisDVODisSemasiForm_button32_Click
   _TaahhutDisDVO.disNo = 32;
#endregion TaahhutDisDVODisSemasiForm_button32_Click
        }

        private void button27_Click()
        {
#region TaahhutDisDVODisSemasiForm_button27_Click
   _TaahhutDisDVO.disNo = 27;
#endregion TaahhutDisDVODisSemasiForm_button27_Click
        }

        private void button31_Click()
        {
#region TaahhutDisDVODisSemasiForm_button31_Click
   _TaahhutDisDVO.disNo = 31;
#endregion TaahhutDisDVODisSemasiForm_button31_Click
        }

        private void button28_Click()
        {
#region TaahhutDisDVODisSemasiForm_button28_Click
   _TaahhutDisDVO.disNo = 28;
#endregion TaahhutDisDVODisSemasiForm_button28_Click
        }

        private void button41_Click()
        {
#region TaahhutDisDVODisSemasiForm_button41_Click
   _TaahhutDisDVO.disNo = 41;
#endregion TaahhutDisDVODisSemasiForm_button41_Click
        }

        private void button48_Click()
        {
#region TaahhutDisDVODisSemasiForm_button48_Click
   _TaahhutDisDVO.disNo = 48;
#endregion TaahhutDisDVODisSemasiForm_button48_Click
        }

        private void button42_Click()
        {
#region TaahhutDisDVODisSemasiForm_button42_Click
   _TaahhutDisDVO.disNo = 42;
#endregion TaahhutDisDVODisSemasiForm_button42_Click
        }

        private void button47_Click()
        {
#region TaahhutDisDVODisSemasiForm_button47_Click
   _TaahhutDisDVO.disNo = 47;
#endregion TaahhutDisDVODisSemasiForm_button47_Click
        }

        private void button43_Click()
        {
#region TaahhutDisDVODisSemasiForm_button43_Click
   _TaahhutDisDVO.disNo = 43;
#endregion TaahhutDisDVODisSemasiForm_button43_Click
        }

        private void button46_Click()
        {
#region TaahhutDisDVODisSemasiForm_button46_Click
   _TaahhutDisDVO.disNo = 46;
#endregion TaahhutDisDVODisSemasiForm_button46_Click
        }

        private void button44_Click()
        {
#region TaahhutDisDVODisSemasiForm_button44_Click
   _TaahhutDisDVO.disNo = 44;
#endregion TaahhutDisDVODisSemasiForm_button44_Click
        }

        private void button45_Click()
        {
#region TaahhutDisDVODisSemasiForm_button45_Click
   _TaahhutDisDVO.disNo = 45;
#endregion TaahhutDisDVODisSemasiForm_button45_Click
        }
    }
}