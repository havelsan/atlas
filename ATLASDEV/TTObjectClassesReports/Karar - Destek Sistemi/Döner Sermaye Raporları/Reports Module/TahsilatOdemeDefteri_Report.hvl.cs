
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// TahsilatOdemeDefteri
    /// </summary>
    public partial class TahsilatOdemeDefteri : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public TahsilatOdemeDefteri MyParentReport
            {
                get { return (TahsilatOdemeDefteri)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField REPORTHEADER1111 { get {return Header().REPORTHEADER1111;} }
            public TTReportField REPORTHEADER11111 { get {return Header().REPORTHEADER11111;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public TahsilatOdemeDefteri MyParentReport
                {
                    get { return (TahsilatOdemeDefteri)ParentReport; }
                }
                
                public TTReportField REPORTHEADER1111;
                public TTReportField REPORTHEADER11111; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTHEADER1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 11, 196, 18, false);
                    REPORTHEADER1111.Name = "REPORTHEADER1111";
                    REPORTHEADER1111.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPORTHEADER1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER1111.TextFont.Size = 12;
                    REPORTHEADER1111.TextFont.Bold = true;
                    REPORTHEADER1111.TextFont.CharSet = 162;
                    REPORTHEADER1111.Value = @"MUTEMETLİKLER TAHSİLAT VE ÖDEME DEFTERİ";

                    REPORTHEADER11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 4, 196, 11, false);
                    REPORTHEADER11111.Name = "REPORTHEADER11111";
                    REPORTHEADER11111.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPORTHEADER11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER11111.TextFont.Size = 12;
                    REPORTHEADER11111.TextFont.Bold = true;
                    REPORTHEADER11111.TextFont.CharSet = 162;
                    REPORTHEADER11111.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTHEADER1111.CalcValue = REPORTHEADER1111.Value;
                    REPORTHEADER11111.CalcValue = REPORTHEADER11111.Value;
                    return new TTReportObject[] { REPORTHEADER1111,REPORTHEADER11111};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public TahsilatOdemeDefteri MyParentReport
                {
                    get { return (TahsilatOdemeDefteri)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class LISTGroup : TTReportGroup
        {
            public TahsilatOdemeDefteri MyParentReport
            {
                get { return (TahsilatOdemeDefteri)ParentReport; }
            }

            new public LISTGroupHeader Header()
            {
                return (LISTGroupHeader)_header;
            }

            new public LISTGroupFooter Footer()
            {
                return (LISTGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField11112112 { get {return Header().NewField11112112;} }
            public TTReportField NewField121121111 { get {return Header().NewField121121111;} }
            public TTReportField NewField121121112 { get {return Header().NewField121121112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField lblAmeliyatAnestezi { get {return Header().lblAmeliyatAnestezi;} }
            public TTReportField lblyatakrefakat1 { get {return Header().lblyatakrefakat1;} }
            public TTReportField lblilac { get {return Header().lblilac;} }
            public TTReportField lblilac1 { get {return Header().lblilac1;} }
            public TTReportField lblilac11 { get {return Header().lblilac11;} }
            public TTReportField lblilac111 { get {return Header().lblilac111;} }
            public TTReportField lblilac1111 { get {return Header().lblilac1111;} }
            public TTReportField lblilac11111 { get {return Header().lblilac11111;} }
            public TTReportField lblilac111111CX { get {return Header().lblilac111111CX;} }
            public TTReportField lbl1111111X23 { get {return Header().lbl1111111X23;} }
            public TTReportField lblilac1111111X2 { get {return Header().lblilac1111111X2;} }
            public TTReportField lbl11111111X { get {return Header().lbl11111111X;} }
            public TTReportField lbl111111112 { get {return Header().lbl111111112;} }
            public TTReportField lbl1211111 { get {return Header().lbl1211111;} }
            public TTReportField lbl11111121 { get {return Header().lbl11111121;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField1122 { get {return Footer().NewField1122;} }
            public TTReportField NewField11211 { get {return Footer().NewField11211;} }
            public TTReportField NewField111212 { get {return Footer().NewField111212;} }
            public TTReportField NewField11112113 { get {return Footer().NewField11112113;} }
            public TTReportField NewField111121111 { get {return Footer().NewField111121111;} }
            public TTReportField NewField1111121111 { get {return Footer().NewField1111121111;} }
            public TTReportField NewField1111121121 { get {return Footer().NewField1111121121;} }
            public TTReportField NewField11112 { get {return Footer().NewField11112;} }
            public TTReportField Newd11121 { get {return Footer().Newd11121;} }
            public TTReportField NewField112111 { get {return Footer().NewField112111;} }
            public TTReportField lblAmeliyatAnestezi11 { get {return Footer().lblAmeliyatAnestezi11;} }
            public TTReportField lblyatakrefakat111 { get {return Footer().lblyatakrefakat111;} }
            public TTReportField lblilac12 { get {return Footer().lblilac12;} }
            public TTReportField lbl111 { get {return Footer().lbl111;} }
            public TTReportField lbl1111 { get {return Footer().lbl1111;} }
            public TTReportField lbl11111 { get {return Footer().lbl11111;} }
            public TTReportField lbl111111 { get {return Footer().lbl111111;} }
            public TTReportField lbl1111112 { get {return Footer().lbl1111112;} }
            public TTReportField lbl11111112 { get {return Footer().lbl11111112;} }
            public TTReportField lbl111111111 { get {return Footer().lbl111111111;} }
            public TTReportField lbl111111113 { get {return Footer().lbl111111113;} }
            public TTReportField lbl1111111111 { get {return Footer().lbl1111111111;} }
            public TTReportField field13 { get {return Footer().field13;} }
            public TTReportField field12 { get {return Footer().field12;} }
            public TTReportField Field11 { get {return Footer().Field11;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public LISTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LISTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LISTGroupHeader(this);
                _footer = new LISTGroupFooter(this);

            }

            public partial class LISTGroupHeader : TTReportSection
            {
                public TahsilatOdemeDefteri MyParentReport
                {
                    get { return (TahsilatOdemeDefteri)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField111211;
                public TTReportField NewField1112111;
                public TTReportField NewField11112111;
                public TTReportField NewField11112112;
                public TTReportField NewField121121111;
                public TTReportField NewField121121112;
                public TTReportField NewField1211;
                public TTReportField lblAmeliyatAnestezi;
                public TTReportField lblyatakrefakat1;
                public TTReportField lblilac;
                public TTReportField lblilac1;
                public TTReportField lblilac11;
                public TTReportField lblilac111;
                public TTReportField lblilac1111;
                public TTReportField lblilac11111;
                public TTReportField lblilac111111CX;
                public TTReportField lbl1111111X23;
                public TTReportField lblilac1111111X2;
                public TTReportField lbl11111111X;
                public TTReportField lbl111111112;
                public TTReportField lbl1211111;
                public TTReportField lbl11111121; 
                public LISTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 5, 296, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"BİLGİLER";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 10, 13, 34, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Tarih";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 10, 25, 34, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Makbuz
 No";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 10, 60, 34, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Geliş No / 
Hasta Adı Soyadı";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 10, 67, 34, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.CrossTabRole = CrosstabRoleEnum.ctrColumnHeader;
                    NewField5.TextFont.Size = 6;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Ödeme
Türü";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 10, 79, 34, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 6;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Ayaktan 
hasta 
muayene,
konsültasyon 
ve rapor 
gelirleri
600.01.01.02";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 10, 91, 34, false);
                    NewField121.Name = "NewField121";
                    NewField121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121.FontAngle = 1;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 6;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Yatan 
hasta 
muayene,
konsültasyon 
ve rapor 
gelirleri
600.01.01.02";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 10, 103, 34, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1121.FontAngle = 1;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Size = 6;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Ayaktan 
Hasta 
Laboratuvar 
Gelirleri
600.01.02.01";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 10, 115, 34, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Size = 6;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Yatan 
Hasta 
Laboratuvar 
Gelirleri
600.01.02.02";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 10, 127, 34, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112111.TextFont.Size = 6;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Ayaktan 
Hasta 
Radioloji
Görüntüleme 
Gelirleri
600.01.03.01";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 10, 139, 34, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112111.TextFont.Size = 6;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Yatan 
Hasta 
Radioloji
Görüntüleme 
Gelirleri
600.01.03.02";

                    NewField11112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 10, 151, 34, false);
                    NewField11112112.Name = "NewField11112112";
                    NewField11112112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11112112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11112112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112112.TextFont.Size = 6;
                    NewField11112112.TextFont.CharSet = 162;
                    NewField11112112.Value = @"Ayaktan 
Hasta 
Tıbbi
Uygulama 
Gelirleri
600.01.04.01";

                    NewField121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 10, 163, 34, false);
                    NewField121121111.Name = "NewField121121111";
                    NewField121121111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121121111.TextFont.Size = 6;
                    NewField121121111.TextFont.CharSet = 162;
                    NewField121121111.Value = @"Yatan 
Hasta 
Tıbbi
Uygulama 
Gelirleri
600.01.04.02";

                    NewField121121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 10, 175, 34, false);
                    NewField121121112.Name = "NewField121121112";
                    NewField121121112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121121112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121121112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121121112.TextFont.Size = 6;
                    NewField121121112.TextFont.CharSet = 162;
                    NewField121121112.Value = @"Ayaktan 
Hasta 
Genel 
Uygulama
ve Girişim
Gelirleri
600.01.05.01";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 10, 187, 34, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Size = 6;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Yatan 
Hasta 
Genel 
Uygulama
ve Girişim
Gelirleri
600.01.05.02";

                    lblAmeliyatAnestezi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 10, 199, 34, false);
                    lblAmeliyatAnestezi.Name = "lblAmeliyatAnestezi";
                    lblAmeliyatAnestezi.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblAmeliyatAnestezi.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblAmeliyatAnestezi.MultiLine = EvetHayirEnum.ehEvet;
                    lblAmeliyatAnestezi.TextFont.Size = 6;
                    lblAmeliyatAnestezi.TextFont.CharSet = 162;
                    lblAmeliyatAnestezi.Value = @"Yatan
Hasta 
Ameliyat
ve Anestezi
Gelirleri
600.01.06.01";

                    lblyatakrefakat1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 10, 211, 34, false);
                    lblyatakrefakat1.Name = "lblyatakrefakat1";
                    lblyatakrefakat1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblyatakrefakat1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblyatakrefakat1.MultiLine = EvetHayirEnum.ehEvet;
                    lblyatakrefakat1.TextFont.Size = 6;
                    lblyatakrefakat1.TextFont.CharSet = 162;
                    lblyatakrefakat1.Value = @"Yatan
Hasta 
Yatak
ve Refakat
Gelirleri
600.01.07.01";

                    lblilac = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 10, 223, 34, false);
                    lblilac.Name = "lblilac";
                    lblilac.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac.TextFont.Size = 6;
                    lblilac.TextFont.CharSet = 162;
                    lblilac.Value = @"İlaç
Gelirleri
600.01.08.01";

                    lblilac1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 10, 235, 34, false);
                    lblilac1.Name = "lblilac1";
                    lblilac1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac1.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac1.TextFont.Size = 6;
                    lblilac1.TextFont.CharSet = 162;
                    lblilac1.Value = @"Tıbbi
Sarf
Malzemesi
Gelirleri
600.01.08.02";

                    lblilac11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 10, 244, 34, false);
                    lblilac11.Name = "lblilac11";
                    lblilac11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac11.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac11.TextFont.Size = 6;
                    lblilac11.TextFont.CharSet = 162;
                    lblilac11.Value = @"Diğer
Sağlık
Hizmetleri
Gelirleri
600.01.99";

                    lblilac111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 10, 254, 34, false);
                    lblilac111.Name = "lblilac111";
                    lblilac111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac111.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac111.TextFont.Size = 6;
                    lblilac111.TextFont.CharSet = 162;
                    lblilac111.Value = @"Alınan
Geçici
İhale
Teminatları
326.01.01";

                    lblilac1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 10, 263, 34, false);
                    lblilac1111.Name = "lblilac1111";
                    lblilac1111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac1111.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac1111.TextFont.Size = 6;
                    lblilac1111.TextFont.CharSet = 162;
                    lblilac1111.Value = @"Alınan
Kesin
Teminatlar
326.01.02";

                    lblilac11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 10, 271, 34, false);
                    lblilac11111.Name = "lblilac11111";
                    lblilac11111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac11111.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac11111.TextFont.Size = 6;
                    lblilac11111.TextFont.CharSet = 162;
                    lblilac11111.Value = @"Tedavi
Avansları
340.01";

                    lblilac111111CX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 10, 281, 34, false);
                    lblilac111111CX.Name = "lblilac111111CX";
                    lblilac111111CX.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac111111CX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac111111CX.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac111111CX.TextFont.Size = 6;
                    lblilac111111CX.TextFont.CharSet = 162;
                    lblilac111111CX.Value = @"Aylık
ve 
Ücretlerden
Kesilen
Damga
Vergisi
360.03.01";

                    lbl1111111X23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 281, 10, 288, 34, false);
                    lbl1111111X23.Name = "lbl1111111X23";
                    lbl1111111X23.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1111111X23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1111111X23.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1111111X23.TextFont.Size = 6;
                    lbl1111111X23.TextFont.CharSet = 162;
                    lbl1111111X23.Value = @"Katılım 
Payları
336.06";

                    lblilac1111111X2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 10, 297, 34, false);
                    lblilac1111111X2.Name = "lblilac1111111X2";
                    lblilac1111111X2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac1111111X2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac1111111X2.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac1111111X2.TextFont.Size = 6;
                    lblilac1111111X2.TextFont.CharSet = 162;
                    lblilac1111111X2.Value = @"Provizyon
Alınan
SGK
Katılım
Payları
336.06.01";

                    lbl11111111X = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 10, 307, 34, false);
                    lbl11111111X.Name = "lbl11111111X";
                    lbl11111111X.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111111X.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl11111111X.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111111X.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111111X.TextFont.Size = 6;
                    lbl11111111X.TextFont.CharSet = 162;
                    lbl11111111X.Value = @"Provizyon
Alınamayan
SGK
Katılım
Payları
336.06.02";

                    lbl111111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 10, 316, 34, false);
                    lbl111111112.Name = "lbl111111112";
                    lbl111111112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl111111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111111112.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111111112.TextFont.Size = 6;
                    lbl111111112.TextFont.CharSet = 162;
                    lbl111111112.Value = @"Şartname
Gelirleri
649.05";

                    lbl1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 10, 325, 34, false);
                    lbl1211111.Name = "lbl1211111";
                    lbl1211111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl1211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1211111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1211111.TextFont.Size = 6;
                    lbl1211111.TextFont.CharSet = 162;
                    lbl1211111.Value = @"Otelcilik
Gelirleri
600.07.04";

                    lbl11111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 10, 334, 34, false);
                    lbl11111121.Name = "lbl11111121";
                    lbl11111121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl11111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111121.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111121.TextFont.Size = 6;
                    lbl11111121.TextFont.Bold = true;
                    lbl11111121.TextFont.CharSet = 162;
                    lbl11111121.Value = @"Genel
Toplam";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField11112112.CalcValue = NewField11112112.Value;
                    NewField121121111.CalcValue = NewField121121111.Value;
                    NewField121121112.CalcValue = NewField121121112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    lblAmeliyatAnestezi.CalcValue = lblAmeliyatAnestezi.Value;
                    lblyatakrefakat1.CalcValue = lblyatakrefakat1.Value;
                    lblilac.CalcValue = lblilac.Value;
                    lblilac1.CalcValue = lblilac1.Value;
                    lblilac11.CalcValue = lblilac11.Value;
                    lblilac111.CalcValue = lblilac111.Value;
                    lblilac1111.CalcValue = lblilac1111.Value;
                    lblilac11111.CalcValue = lblilac11111.Value;
                    lblilac111111CX.CalcValue = lblilac111111CX.Value;
                    lbl1111111X23.CalcValue = lbl1111111X23.Value;
                    lblilac1111111X2.CalcValue = lblilac1111111X2.Value;
                    lbl11111111X.CalcValue = lbl11111111X.Value;
                    lbl111111112.CalcValue = lbl111111112.Value;
                    lbl1211111.CalcValue = lbl1211111.Value;
                    lbl11111121.CalcValue = lbl11111121.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField5,NewField12,NewField121,NewField1121,NewField111211,NewField1112111,NewField11112111,NewField11112112,NewField121121111,NewField121121112,NewField1211,lblAmeliyatAnestezi,lblyatakrefakat1,lblilac,lblilac1,lblilac11,lblilac111,lblilac1111,lblilac11111,lblilac111111CX,lbl1111111X23,lblilac1111111X2,lbl11111111X,lbl111111112,lbl1211111,lbl11111121};
                }
            }
            public partial class LISTGroupFooter : TTReportSection
            {
                public TahsilatOdemeDefteri MyParentReport
                {
                    get { return (TahsilatOdemeDefteri)ParentReport; }
                }
                
                public TTReportField NewField151;
                public TTReportField NewField1122;
                public TTReportField NewField11211;
                public TTReportField NewField111212;
                public TTReportField NewField11112113;
                public TTReportField NewField111121111;
                public TTReportField NewField1111121111;
                public TTReportField NewField1111121121;
                public TTReportField NewField11112;
                public TTReportField Newd11121;
                public TTReportField NewField112111;
                public TTReportField lblAmeliyatAnestezi11;
                public TTReportField lblyatakrefakat111;
                public TTReportField lblilac12;
                public TTReportField lbl111;
                public TTReportField lbl1111;
                public TTReportField lbl11111;
                public TTReportField lbl111111;
                public TTReportField lbl1111112;
                public TTReportField lbl11111112;
                public TTReportField lbl111111111;
                public TTReportField lbl111111113;
                public TTReportField lbl1111111111;
                public TTReportField field13;
                public TTReportField field12;
                public TTReportField Field11;
                public TTReportField NewField6; 
                public LISTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    RepeatCount = 0;
                    
                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 5, 67, 13, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.CrossTabRole = CrosstabRoleEnum.ctrColumnHeader;
                    NewField151.TextFont.Size = 6;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 5, 79, 13, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122.TextFont.Size = 6;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 5, 91, 13, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11211.FontAngle = 1;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Size = 6;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 5, 103, 13, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111212.FontAngle = 1;
                    NewField111212.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111212.TextFont.Size = 6;
                    NewField111212.TextFont.CharSet = 162;
                    NewField111212.Value = @"";

                    NewField11112113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 5, 115, 13, false);
                    NewField11112113.Name = "NewField11112113";
                    NewField11112113.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11112113.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11112113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112113.TextFont.Size = 6;
                    NewField11112113.TextFont.CharSet = 162;
                    NewField11112113.Value = @"";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 5, 127, 13, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121111.TextFont.Size = 6;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 5, 139, 13, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1111121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121111.TextFont.Size = 6;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @"";

                    NewField1111121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 5, 151, 13, false);
                    NewField1111121121.Name = "NewField1111121121";
                    NewField1111121121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1111121121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111121121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121121.TextFont.Size = 6;
                    NewField1111121121.TextFont.CharSet = 162;
                    NewField1111121121.Value = @"";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 5, 163, 13, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112.TextFont.Size = 6;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"";

                    Newd11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 5, 175, 13, false);
                    Newd11121.Name = "Newd11121";
                    Newd11121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Newd11121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    Newd11121.MultiLine = EvetHayirEnum.ehEvet;
                    Newd11121.TextFont.Size = 6;
                    Newd11121.TextFont.CharSet = 162;
                    Newd11121.Value = @"";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 5, 187, 13, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Size = 6;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"";

                    lblAmeliyatAnestezi11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 5, 199, 13, false);
                    lblAmeliyatAnestezi11.Name = "lblAmeliyatAnestezi11";
                    lblAmeliyatAnestezi11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblAmeliyatAnestezi11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblAmeliyatAnestezi11.MultiLine = EvetHayirEnum.ehEvet;
                    lblAmeliyatAnestezi11.TextFont.Size = 6;
                    lblAmeliyatAnestezi11.TextFont.CharSet = 162;
                    lblAmeliyatAnestezi11.Value = @"";

                    lblyatakrefakat111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 5, 211, 13, false);
                    lblyatakrefakat111.Name = "lblyatakrefakat111";
                    lblyatakrefakat111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblyatakrefakat111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblyatakrefakat111.MultiLine = EvetHayirEnum.ehEvet;
                    lblyatakrefakat111.TextFont.Size = 6;
                    lblyatakrefakat111.TextFont.CharSet = 162;
                    lblyatakrefakat111.Value = @"";

                    lblilac12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 5, 223, 13, false);
                    lblilac12.Name = "lblilac12";
                    lblilac12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac12.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac12.TextFont.Size = 6;
                    lblilac12.TextFont.CharSet = 162;
                    lblilac12.Value = @"";

                    lbl111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 5, 235, 13, false);
                    lbl111.Name = "lbl111";
                    lbl111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111.TextFont.Size = 6;
                    lbl111.TextFont.CharSet = 162;
                    lbl111.Value = @"";

                    lbl1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 5, 244, 13, false);
                    lbl1111.Name = "lbl1111";
                    lbl1111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1111.TextFont.Size = 6;
                    lbl1111.TextFont.CharSet = 162;
                    lbl1111.Value = @"";

                    lbl11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 5, 254, 13, false);
                    lbl11111.Name = "lbl11111";
                    lbl11111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111.TextFont.Size = 6;
                    lbl11111.TextFont.CharSet = 162;
                    lbl11111.Value = @"";

                    lbl111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 5, 263, 13, false);
                    lbl111111.Name = "lbl111111";
                    lbl111111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111111.TextFont.Size = 6;
                    lbl111111.TextFont.CharSet = 162;
                    lbl111111.Value = @"";

                    lbl1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 5, 271, 13, false);
                    lbl1111112.Name = "lbl1111112";
                    lbl1111112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1111112.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1111112.TextFont.Size = 6;
                    lbl1111112.TextFont.CharSet = 162;
                    lbl1111112.Value = @"";

                    lbl11111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 5, 281, 13, false);
                    lbl11111112.Name = "lbl11111112";
                    lbl11111112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111112.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111112.TextFont.Size = 6;
                    lbl11111112.TextFont.CharSet = 162;
                    lbl11111112.Value = @"";

                    lbl111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 281, 5, 288, 13, false);
                    lbl111111111.Name = "lbl111111111";
                    lbl111111111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111111111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111111111.TextFont.Size = 6;
                    lbl111111111.TextFont.CharSet = 162;
                    lbl111111111.Value = @"";

                    lbl111111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 5, 297, 13, false);
                    lbl111111113.Name = "lbl111111113";
                    lbl111111113.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111111113.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111111113.TextFont.Size = 6;
                    lbl111111113.TextFont.CharSet = 162;
                    lbl111111113.Value = @"";

                    lbl1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 5, 307, 13, false);
                    lbl1111111111.Name = "lbl1111111111";
                    lbl1111111111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl1111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1111111111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1111111111.TextFont.Size = 6;
                    lbl1111111111.TextFont.CharSet = 162;
                    lbl1111111111.Value = @"";

                    field13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 5, 316, 13, false);
                    field13.Name = "field13";
                    field13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    field13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    field13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    field13.MultiLine = EvetHayirEnum.ehEvet;
                    field13.TextFont.Size = 6;
                    field13.TextFont.CharSet = 162;
                    field13.Value = @"";

                    field12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 5, 325, 13, false);
                    field12.Name = "field12";
                    field12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    field12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    field12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    field12.MultiLine = EvetHayirEnum.ehEvet;
                    field12.TextFont.Size = 6;
                    field12.TextFont.CharSet = 162;
                    field12.Value = @"";

                    Field11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 5, 334, 13, false);
                    Field11.Name = "Field11";
                    Field11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Field11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Field11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Field11.MultiLine = EvetHayirEnum.ehEvet;
                    Field11.TextFont.Size = 6;
                    Field11.TextFont.Bold = true;
                    Field11.TextFont.CharSet = 162;
                    Field11.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 5, 60, 13, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.TextFont.Size = 12;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"TOPLAM";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField151.CalcValue = NewField151.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField11112113.CalcValue = NewField11112113.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField1111121121.CalcValue = NewField1111121121.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    Newd11121.CalcValue = Newd11121.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    lblAmeliyatAnestezi11.CalcValue = lblAmeliyatAnestezi11.Value;
                    lblyatakrefakat111.CalcValue = lblyatakrefakat111.Value;
                    lblilac12.CalcValue = lblilac12.Value;
                    lbl111.CalcValue = lbl111.Value;
                    lbl1111.CalcValue = lbl1111.Value;
                    lbl11111.CalcValue = lbl11111.Value;
                    lbl111111.CalcValue = lbl111111.Value;
                    lbl1111112.CalcValue = lbl1111112.Value;
                    lbl11111112.CalcValue = lbl11111112.Value;
                    lbl111111111.CalcValue = lbl111111111.Value;
                    lbl111111113.CalcValue = lbl111111113.Value;
                    lbl1111111111.CalcValue = lbl1111111111.Value;
                    field13.CalcValue = field13.Value;
                    field12.CalcValue = field12.Value;
                    Field11.CalcValue = Field11.Value;
                    NewField6.CalcValue = NewField6.Value;
                    return new TTReportObject[] { NewField151,NewField1122,NewField11211,NewField111212,NewField11112113,NewField111121111,NewField1111121111,NewField1111121121,NewField11112,Newd11121,NewField112111,lblAmeliyatAnestezi11,lblyatakrefakat111,lblilac12,lbl111,lbl1111,lbl11111,lbl111111,lbl1111112,lbl11111112,lbl111111111,lbl111111113,lbl1111111111,field13,field12,Field11,NewField6};
                }
            }

        }

        public LISTGroup LIST;

        public partial class MAINGroup : TTReportGroup
        {
            public TahsilatOdemeDefteri MyParentReport
            {
                get { return (TahsilatOdemeDefteri)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField NewField121121111 { get {return Body().NewField121121111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField Newd1211 { get {return Body().Newd1211;} }
            public TTReportField NewField11121 { get {return Body().NewField11121;} }
            public TTReportField lblAmeliyatAnestezi1 { get {return Body().lblAmeliyatAnestezi1;} }
            public TTReportField lblyatakrefakat11 { get {return Body().lblyatakrefakat11;} }
            public TTReportField lblilac1 { get {return Body().lblilac1;} }
            public TTReportField lbl11 { get {return Body().lbl11;} }
            public TTReportField lbl111 { get {return Body().lbl111;} }
            public TTReportField lbl1111G { get {return Body().lbl1111G;} }
            public TTReportField lbl11111F { get {return Body().lbl11111F;} }
            public TTReportField lbl111111H { get {return Body().lbl111111H;} }
            public TTReportField lbl1111111G { get {return Body().lbl1111111G;} }
            public TTReportField lbl11111111T { get {return Body().lbl11111111T;} }
            public TTReportField lbl11111111C { get {return Body().lbl11111111C;} }
            public TTReportField lbl111111111RR { get {return Body().lbl111111111RR;} }
            public TTReportField field3 { get {return Body().field3;} }
            public TTReportField field2 { get {return Body().field2;} }
            public TTReportField Field1 { get {return Body().Field1;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public TahsilatOdemeDefteri MyParentReport
                {
                    get { return (TahsilatOdemeDefteri)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField1112111;
                public TTReportField NewField11112111;
                public TTReportField NewField111121111;
                public TTReportField NewField121121111;
                public TTReportField NewField1111;
                public TTReportField Newd1211;
                public TTReportField NewField11121;
                public TTReportField lblAmeliyatAnestezi1;
                public TTReportField lblyatakrefakat11;
                public TTReportField lblilac1;
                public TTReportField lbl11;
                public TTReportField lbl111;
                public TTReportField lbl1111G;
                public TTReportField lbl11111F;
                public TTReportField lbl111111H;
                public TTReportField lbl1111111G;
                public TTReportField lbl11111111T;
                public TTReportField lbl11111111C;
                public TTReportField lbl111111111RR;
                public TTReportField field3;
                public TTReportField field2;
                public TTReportField Field1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 2, 13, 10, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 25, 10, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 2, 60, 10, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 2, 67, 10, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.CrossTabRole = CrosstabRoleEnum.ctrColumnHeader;
                    NewField15.TextFont.Size = 6;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 2, 79, 10, false);
                    NewField121.Name = "NewField121";
                    NewField121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 6;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 2, 91, 10, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1121.FontAngle = 1;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Size = 6;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 2, 103, 10, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11211.FontAngle = 1;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Size = 6;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 2, 115, 10, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112111.TextFont.Size = 6;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 2, 127, 10, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11112111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112111.TextFont.Size = 6;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 2, 139, 10, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121111.TextFont.Size = 6;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"";

                    NewField121121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 2, 151, 10, false);
                    NewField121121111.Name = "NewField121121111";
                    NewField121121111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField121121111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121121111.TextFont.Size = 6;
                    NewField121121111.TextFont.CharSet = 162;
                    NewField121121111.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 2, 163, 10, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Size = 6;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"";

                    Newd1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 2, 175, 10, false);
                    Newd1211.Name = "Newd1211";
                    Newd1211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Newd1211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    Newd1211.MultiLine = EvetHayirEnum.ehEvet;
                    Newd1211.TextFont.Size = 6;
                    Newd1211.TextFont.CharSet = 162;
                    Newd1211.Value = @"";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 2, 187, 10, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Size = 6;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"";

                    lblAmeliyatAnestezi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 2, 199, 10, false);
                    lblAmeliyatAnestezi1.Name = "lblAmeliyatAnestezi1";
                    lblAmeliyatAnestezi1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblAmeliyatAnestezi1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblAmeliyatAnestezi1.MultiLine = EvetHayirEnum.ehEvet;
                    lblAmeliyatAnestezi1.TextFont.Size = 6;
                    lblAmeliyatAnestezi1.TextFont.CharSet = 162;
                    lblAmeliyatAnestezi1.Value = @"";

                    lblyatakrefakat11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 2, 211, 10, false);
                    lblyatakrefakat11.Name = "lblyatakrefakat11";
                    lblyatakrefakat11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblyatakrefakat11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    lblyatakrefakat11.MultiLine = EvetHayirEnum.ehEvet;
                    lblyatakrefakat11.TextFont.Size = 6;
                    lblyatakrefakat11.TextFont.CharSet = 162;
                    lblyatakrefakat11.Value = @"";

                    lblilac1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 2, 223, 10, false);
                    lblilac1.Name = "lblilac1";
                    lblilac1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lblilac1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblilac1.MultiLine = EvetHayirEnum.ehEvet;
                    lblilac1.TextFont.Size = 6;
                    lblilac1.TextFont.CharSet = 162;
                    lblilac1.Value = @"";

                    lbl11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 2, 235, 10, false);
                    lbl11.Name = "lbl11";
                    lbl11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11.TextFont.Size = 6;
                    lbl11.TextFont.CharSet = 162;
                    lbl11.Value = @"";

                    lbl111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 2, 244, 10, false);
                    lbl111.Name = "lbl111";
                    lbl111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111.TextFont.Size = 6;
                    lbl111.TextFont.CharSet = 162;
                    lbl111.Value = @"";

                    lbl1111G = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 2, 254, 10, false);
                    lbl1111G.Name = "lbl1111G";
                    lbl1111G.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1111G.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1111G.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1111G.TextFont.Size = 6;
                    lbl1111G.TextFont.CharSet = 162;
                    lbl1111G.Value = @"";

                    lbl11111F = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 2, 263, 10, false);
                    lbl11111F.Name = "lbl11111F";
                    lbl11111F.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111F.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111F.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111F.TextFont.Size = 6;
                    lbl11111F.TextFont.CharSet = 162;
                    lbl11111F.Value = @"";

                    lbl111111H = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 2, 271, 10, false);
                    lbl111111H.Name = "lbl111111H";
                    lbl111111H.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111111H.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111111H.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111111H.TextFont.Size = 6;
                    lbl111111H.TextFont.CharSet = 162;
                    lbl111111H.Value = @"";

                    lbl1111111G = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 2, 281, 10, false);
                    lbl1111111G.Name = "lbl1111111G";
                    lbl1111111G.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl1111111G.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl1111111G.MultiLine = EvetHayirEnum.ehEvet;
                    lbl1111111G.TextFont.Size = 6;
                    lbl1111111G.TextFont.CharSet = 162;
                    lbl1111111G.Value = @"";

                    lbl11111111T = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 281, 2, 288, 10, false);
                    lbl11111111T.Name = "lbl11111111T";
                    lbl11111111T.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111111T.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111111T.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111111T.TextFont.Size = 6;
                    lbl11111111T.TextFont.CharSet = 162;
                    lbl11111111T.Value = @"";

                    lbl11111111C = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 2, 297, 10, false);
                    lbl11111111C.Name = "lbl11111111C";
                    lbl11111111C.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl11111111C.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl11111111C.MultiLine = EvetHayirEnum.ehEvet;
                    lbl11111111C.TextFont.Size = 6;
                    lbl11111111C.TextFont.CharSet = 162;
                    lbl11111111C.Value = @"";

                    lbl111111111RR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 297, 2, 307, 10, false);
                    lbl111111111RR.Name = "lbl111111111RR";
                    lbl111111111RR.CaseFormat = CaseFormatEnum.fcTitleCase;
                    lbl111111111RR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl111111111RR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl111111111RR.MultiLine = EvetHayirEnum.ehEvet;
                    lbl111111111RR.TextFont.Size = 6;
                    lbl111111111RR.TextFont.CharSet = 162;
                    lbl111111111RR.Value = @"";

                    field3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 306, 2, 315, 10, false);
                    field3.Name = "field3";
                    field3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    field3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    field3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    field3.MultiLine = EvetHayirEnum.ehEvet;
                    field3.TextFont.Size = 6;
                    field3.TextFont.CharSet = 162;
                    field3.Value = @"";

                    field2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 315, 2, 324, 10, false);
                    field2.Name = "field2";
                    field2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    field2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    field2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    field2.MultiLine = EvetHayirEnum.ehEvet;
                    field2.TextFont.Size = 6;
                    field2.TextFont.CharSet = 162;
                    field2.Value = @"";

                    Field1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 324, 2, 333, 10, false);
                    Field1.Name = "Field1";
                    Field1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Field1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Field1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Field1.MultiLine = EvetHayirEnum.ehEvet;
                    Field1.TextFont.Size = 6;
                    Field1.TextFont.Bold = true;
                    Field1.TextFont.CharSet = 162;
                    Field1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField121121111.CalcValue = NewField121121111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    Newd1211.CalcValue = Newd1211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    lblAmeliyatAnestezi1.CalcValue = lblAmeliyatAnestezi1.Value;
                    lblyatakrefakat11.CalcValue = lblyatakrefakat11.Value;
                    lblilac1.CalcValue = lblilac1.Value;
                    lbl11.CalcValue = lbl11.Value;
                    lbl111.CalcValue = lbl111.Value;
                    lbl1111G.CalcValue = lbl1111G.Value;
                    lbl11111F.CalcValue = lbl11111F.Value;
                    lbl111111H.CalcValue = lbl111111H.Value;
                    lbl1111111G.CalcValue = lbl1111111G.Value;
                    lbl11111111T.CalcValue = lbl11111111T.Value;
                    lbl11111111C.CalcValue = lbl11111111C.Value;
                    lbl111111111RR.CalcValue = lbl111111111RR.Value;
                    field3.CalcValue = field3.Value;
                    field2.CalcValue = field2.Value;
                    Field1.CalcValue = Field1.Value;
                    return new TTReportObject[] { NewField12,NewField13,NewField14,NewField15,NewField121,NewField1121,NewField11211,NewField1112111,NewField11112111,NewField111121111,NewField121121111,NewField1111,Newd1211,NewField11121,lblAmeliyatAnestezi1,lblyatakrefakat11,lblilac1,lbl11,lbl111,lbl1111G,lbl11111F,lbl111111H,lbl1111111G,lbl11111111T,lbl11111111C,lbl111111111RR,field3,field2,Field1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TahsilatOdemeDefteri()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            LIST = new LISTGroup(HEADER,"LIST");
            MAIN = new MAINGroup(LIST,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "TAHSILATODEMEDEFTERI";
            Caption = "TahsilatOdemeDefteri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 0;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}