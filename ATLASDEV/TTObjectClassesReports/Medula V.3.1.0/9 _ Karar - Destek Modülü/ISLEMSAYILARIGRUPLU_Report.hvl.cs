
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
    public partial class ISLEMSAYILARIGRUPLU : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue("23:59");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public ISLEMSAYILARIGRUPLU MyParentReport
            {
                get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public TTReportField ReportName11 { get {return Header().ReportName11;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11131 { get {return Header().NewField11131;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField CurrentUser11 { get {return Footer().CurrentUser11;} }
            public TTReportField PageNumber11 { get {return Footer().PageNumber11;} }
            public TTReportField PrintDate11 { get {return Footer().PrintDate11;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                
                public TTReportField LOGO11;
                public TTReportField ReportName11;
                public TTReportField NewField1111;
                public TTReportField NewField1131;
                public TTReportField NewField11131;
                public TTReportField NewField11411;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 50, 34, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.Value = @"";

                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 14, 200, 34, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Size = 15;
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"İŞLEM SAYILARI TİPİNE GÖRE";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 34, 41, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Başlangıç Tarihi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 34, 46, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Bitiş Tarihi";

                    NewField11131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 36, 36, 41, false);
                    NewField11131.Name = "NewField11131";
                    NewField11131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11131.TextFont.Bold = true;
                    NewField11131.TextFont.CharSet = 162;
                    NewField11131.Value = @":";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 41, 36, 46, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 36, 61, 41, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    STARTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.NoClip = EvetHayirEnum.ehEvet;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 41, 61, 46, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO11.CalcValue = LOGO11.Value;
                    ReportName11.CalcValue = ReportName11.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11131.CalcValue = NewField11131.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { LOGO11,ReportName11,NewField1111,NewField1131,NewField11131,NewField11411,STARTDATE,ENDDATE};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                
                public TTReportField CurrentUser11;
                public TTReportField PageNumber11;
                public TTReportField PrintDate11;
                public TTReportShape NewLine1111; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 0, 112, 5, false);
                    CurrentUser11.Name = "CurrentUser11";
                    CurrentUser11.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser11.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser11.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser11.TextFont.Size = 8;
                    CurrentUser11.TextFont.CharSet = 162;
                    CurrentUser11.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : """"";

                    PageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 200, 5, false);
                    PageNumber11.Name = "PageNumber11";
                    PageNumber11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber11.TextFont.Size = 8;
                    PageNumber11.TextFont.CharSet = 162;
                    PageNumber11.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
                    PrintDate11.Name = "PrintDate11";
                    PrintDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11.TextFormat = @"dd/MM/yyyy";
                    PrintDate11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate11.TextFont.Size = 8;
                    PrintDate11.TextFont.CharSet = 162;
                    PrintDate11.Value = @"{@printdate@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 200, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber11.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate11.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser11.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.FullName : "";
                    return new TTReportObject[] { PageNumber11,PrintDate11,CurrentUser11};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public ISLEMSAYILARIGRUPLU MyParentReport
            {
                get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField12111112 { get {return Header().NewField12111112;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportField NewField111111121 { get {return Header().NewField111111121;} }
            public TTReportField NewField1121111113 { get {return Header().NewField1121111113;} }
            public TTReportField NewField1121111114 { get {return Header().NewField1121111114;} }
            public TTReportField NewField1121111111 { get {return Header().NewField1121111111;} }
            public TTReportField NewField1121111112 { get {return Header().NewField1121111112;} }
            public TTReportField NewField12111111 { get {return Header().NewField12111111;} }
            public TTReportField NewField1111112 { get {return Header().NewField1111112;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                
                public TTReportField NewField12111112;
                public TTReportField NewField9;
                public TTReportField NewField19;
                public TTReportField NewField191;
                public TTReportField NewField1191;
                public TTReportField NewField11911;
                public TTReportField NewField111111121;
                public TTReportField NewField1121111113;
                public TTReportField NewField1121111114;
                public TTReportField NewField1121111111;
                public TTReportField NewField1121111112;
                public TTReportField NewField12111111;
                public TTReportField NewField1111112;
                public TTReportField NewField1111111;
                public TTReportField NewField111112;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportShape NewLine11; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField12111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 1, 106, 45, false);
                    NewField12111112.Name = "NewField12111112";
                    NewField12111112.FontAngle = 900;
                    NewField12111112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12111112.TextFont.Bold = true;
                    NewField12111112.TextFont.CharSet = 162;
                    NewField12111112.Value = @"Y.Donör Hasta Kabul";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 1, 170, 45, false);
                    NewField9.Name = "NewField9";
                    NewField9.FontAngle = 900;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Hasta Çıkış İptal";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 1, 178, 45, false);
                    NewField19.Name = "NewField19";
                    NewField19.FontAngle = 900;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Hasta Yatış Oku";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 186, 45, false);
                    NewField191.Name = "NewField191";
                    NewField191.FontAngle = 900;
                    NewField191.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Başvuru Takip Oku";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 1, 194, 45, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.FontAngle = 900;
                    NewField1191.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Geriye Dönük Yatış Kabul";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 1, 202, 45, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.FontAngle = 900;
                    NewField11911.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11911.TextFont.Bold = true;
                    NewField11911.TextFont.CharSet = 162;
                    NewField11911.Value = @"Sevk Bildir";

                    NewField111111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 122, 45, false);
                    NewField111111121.Name = "NewField111111121";
                    NewField111111121.FontAngle = 900;
                    NewField111111121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111111121.TextFont.Bold = true;
                    NewField111111121.TextFont.CharSet = 162;
                    NewField111111121.Value = @"Hasta Kabul Oku";

                    NewField1121111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 1, 154, 45, false);
                    NewField1121111113.Name = "NewField1121111113";
                    NewField1121111113.FontAngle = 900;
                    NewField1121111113.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121111113.TextFont.Bold = true;
                    NewField1121111113.TextFont.CharSet = 162;
                    NewField1121111113.Value = @"Hasta Çıkış Kayıt";

                    NewField1121111114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 162, 45, false);
                    NewField1121111114.Name = "NewField1121111114";
                    NewField1121111114.FontAngle = 900;
                    NewField1121111114.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121111114.TextFont.Bold = true;
                    NewField1121111114.TextFont.CharSet = 162;
                    NewField1121111114.Value = @"Hasta Çıkış Tarihi Değiştir";

                    NewField1121111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 1, 130, 45, false);
                    NewField1121111111.Name = "NewField1121111111";
                    NewField1121111111.FontAngle = 900;
                    NewField1121111111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121111111.TextFont.Bold = true;
                    NewField1121111111.TextFont.CharSet = 162;
                    NewField1121111111.Value = @"H.K. Tedavi Tipi Değiştir";

                    NewField1121111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 138, 45, false);
                    NewField1121111112.Name = "NewField1121111112";
                    NewField1121111112.FontAngle = 900;
                    NewField1121111112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121111112.TextFont.Bold = true;
                    NewField1121111112.TextFont.CharSet = 162;
                    NewField1121111112.Value = @"H.K. Provizyon Tipi Değiştir";

                    NewField12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 1, 114, 45, false);
                    NewField12111111.Name = "NewField12111111";
                    NewField12111111.FontAngle = 900;
                    NewField12111111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12111111.TextFont.Bold = true;
                    NewField12111111.TextFont.CharSet = 162;
                    NewField12111111.Value = @"İ.Takip Hasta Kabul";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 98, 45, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.FontAngle = 900;
                    NewField1111112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Y.Doğan Hasta Kabul";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 1, 146, 45, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.FontAngle = 900;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Hasta Kabul İptal";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 37, 78, 42, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"Tesis Adı";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 37, 27, 42, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Tesis Kodu";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 1, 90, 45, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.FontAngle = 900;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Yeni Hasta Kabul";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 42, 200, 42, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12111112.CalcValue = NewField12111112.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField111111121.CalcValue = NewField111111121.Value;
                    NewField1121111113.CalcValue = NewField1121111113.Value;
                    NewField1121111114.CalcValue = NewField1121111114.Value;
                    NewField1121111111.CalcValue = NewField1121111111.Value;
                    NewField1121111112.CalcValue = NewField1121111112.Value;
                    NewField12111111.CalcValue = NewField12111111.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    return new TTReportObject[] { NewField12111112,NewField9,NewField19,NewField191,NewField1191,NewField11911,NewField111111121,NewField1121111113,NewField1121111114,NewField1121111111,NewField1121111112,NewField12111111,NewField1111112,NewField1111111,NewField111112,NewField11111,NewField111111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public ISLEMSAYILARIGRUPLU MyParentReport
            {
                get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField TESISKODU { get {return Header().TESISKODU;} }
            public TTReportField TESISADI { get {return Header().TESISADI;} }
            public TTReportField YENIHASTAKABUL { get {return Header().YENIHASTAKABUL;} }
            public TTReportField HASTAKABULIPTAL { get {return Header().HASTAKABULIPTAL;} }
            public TTReportField YENIDOGANHASTAKABUL { get {return Header().YENIDOGANHASTAKABUL;} }
            public TTReportField ILISKILITAKIPHASTAKABUL { get {return Header().ILISKILITAKIPHASTAKABUL;} }
            public TTReportField HASTAKABULOKU { get {return Header().HASTAKABULOKU;} }
            public TTReportField HASTAKABULTEDAVITIPIDEGISTIR { get {return Header().HASTAKABULTEDAVITIPIDEGISTIR;} }
            public TTReportField HASTAKABULPROVIZYONDEGISTIR { get {return Header().HASTAKABULPROVIZYONDEGISTIR;} }
            public TTReportField YENIDONORHASTAKABUL { get {return Header().YENIDONORHASTAKABUL;} }
            public TTReportField HASTACIKISKAYIT { get {return Header().HASTACIKISKAYIT;} }
            public TTReportField HASTACIKISTARIHIDEGISTIR { get {return Header().HASTACIKISTARIHIDEGISTIR;} }
            public TTReportField HASTACIKISIPTAL { get {return Header().HASTACIKISIPTAL;} }
            public TTReportField HASTAYATISOKU { get {return Header().HASTAYATISOKU;} }
            public TTReportField BASVURUTAKIPOKU { get {return Header().BASVURUTAKIPOKU;} }
            public TTReportField GERIYEDONUKYATISKABUL { get {return Header().GERIYEDONUKYATISKABUL;} }
            public TTReportField SEVKBILDIR { get {return Header().SEVKBILDIR;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class>("SAGLIKTESISLERIReportQuery", SaglikTesisi.SAGLIKTESISLERIReportQuery());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                
                public TTReportField TESISKODU;
                public TTReportField TESISADI;
                public TTReportField YENIHASTAKABUL;
                public TTReportField HASTAKABULIPTAL;
                public TTReportField YENIDOGANHASTAKABUL;
                public TTReportField ILISKILITAKIPHASTAKABUL;
                public TTReportField HASTAKABULOKU;
                public TTReportField HASTAKABULTEDAVITIPIDEGISTIR;
                public TTReportField HASTAKABULPROVIZYONDEGISTIR;
                public TTReportField YENIDONORHASTAKABUL;
                public TTReportField HASTACIKISKAYIT;
                public TTReportField HASTACIKISTARIHIDEGISTIR;
                public TTReportField HASTACIKISIPTAL;
                public TTReportField HASTAYATISOKU;
                public TTReportField BASVURUTAKIPOKU;
                public TTReportField GERIYEDONUKYATISKABUL;
                public TTReportField SEVKBILDIR; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 56;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TESISKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 7, 48, 12, false);
                    TESISKODU.Name = "TESISKODU";
                    TESISKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESISKODU.Value = @"{#TESISKODU#}";

                    TESISADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 7, 74, 12, false);
                    TESISADI.Name = "TESISADI";
                    TESISADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESISADI.Value = @"{#TESISADI#}";

                    YENIHASTAKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 2, 133, 7, false);
                    YENIHASTAKABUL.Name = "YENIHASTAKABUL";
                    YENIHASTAKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIHASTAKABUL.Value = @"YENIHASTAKABUL";

                    HASTAKABULIPTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 44, 133, 49, false);
                    HASTAKABULIPTAL.Name = "HASTAKABULIPTAL";
                    HASTAKABULIPTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKABULIPTAL.Value = @"HASTAKABULIPTAL";

                    YENIDOGANHASTAKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 8, 133, 13, false);
                    YENIDOGANHASTAKABUL.Name = "YENIDOGANHASTAKABUL";
                    YENIDOGANHASTAKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIDOGANHASTAKABUL.Value = @"YENIDOGANHASTAKABUL";

                    ILISKILITAKIPHASTAKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 20, 133, 25, false);
                    ILISKILITAKIPHASTAKABUL.Name = "ILISKILITAKIPHASTAKABUL";
                    ILISKILITAKIPHASTAKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILISKILITAKIPHASTAKABUL.Value = @"ILISKILITAKIPHASTAKABUL";

                    HASTAKABULOKU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 26, 133, 31, false);
                    HASTAKABULOKU.Name = "HASTAKABULOKU";
                    HASTAKABULOKU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKABULOKU.Value = @"HASTAKABULOKU";

                    HASTAKABULTEDAVITIPIDEGISTIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 32, 133, 37, false);
                    HASTAKABULTEDAVITIPIDEGISTIR.Name = "HASTAKABULTEDAVITIPIDEGISTIR";
                    HASTAKABULTEDAVITIPIDEGISTIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKABULTEDAVITIPIDEGISTIR.Value = @"HASTAKABULTEDAVITIPIDEGISTIR";

                    HASTAKABULPROVIZYONDEGISTIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 38, 133, 43, false);
                    HASTAKABULPROVIZYONDEGISTIR.Name = "HASTAKABULPROVIZYONDEGISTIR";
                    HASTAKABULPROVIZYONDEGISTIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKABULPROVIZYONDEGISTIR.Value = @"HASTAKABULPROVIZYONDEGISTIR";

                    YENIDONORHASTAKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 14, 133, 19, false);
                    YENIDONORHASTAKABUL.Name = "YENIDONORHASTAKABUL";
                    YENIDONORHASTAKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIDONORHASTAKABUL.Value = @"YENIDONORHASTAKABUL";

                    HASTACIKISKAYIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 2, 183, 7, false);
                    HASTACIKISKAYIT.Name = "HASTACIKISKAYIT";
                    HASTACIKISKAYIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTACIKISKAYIT.Value = @"HASTACIKISKAYIT";

                    HASTACIKISTARIHIDEGISTIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 8, 183, 13, false);
                    HASTACIKISTARIHIDEGISTIR.Name = "HASTACIKISTARIHIDEGISTIR";
                    HASTACIKISTARIHIDEGISTIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTACIKISTARIHIDEGISTIR.Value = @"HASTACIKISTARIHIDEGISTIR";

                    HASTACIKISIPTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 14, 183, 19, false);
                    HASTACIKISIPTAL.Name = "HASTACIKISIPTAL";
                    HASTACIKISIPTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTACIKISIPTAL.Value = @"HASTACIKISIPTAL";

                    HASTAYATISOKU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 20, 183, 25, false);
                    HASTAYATISOKU.Name = "HASTAYATISOKU";
                    HASTAYATISOKU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAYATISOKU.Value = @"HASTAYATISOKU";

                    BASVURUTAKIPOKU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 26, 183, 31, false);
                    BASVURUTAKIPOKU.Name = "BASVURUTAKIPOKU";
                    BASVURUTAKIPOKU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASVURUTAKIPOKU.Value = @"BASVURUTAKIPOKU";

                    GERIYEDONUKYATISKABUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 32, 183, 37, false);
                    GERIYEDONUKYATISKABUL.Name = "GERIYEDONUKYATISKABUL";
                    GERIYEDONUKYATISKABUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    GERIYEDONUKYATISKABUL.Value = @"GERIYEDONUKYATISKABUL";

                    SEVKBILDIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 38, 183, 43, false);
                    SEVKBILDIR.Name = "SEVKBILDIR";
                    SEVKBILDIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKBILDIR.Value = @"SEVKBILDIR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SaglikTesisi.SAGLIKTESISLERIReportQuery_Class dataset_SAGLIKTESISLERIReportQuery = ParentGroup.rsGroup.GetCurrentRecord<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class>(0);
                    TESISKODU.CalcValue = (dataset_SAGLIKTESISLERIReportQuery != null ? Globals.ToStringCore(dataset_SAGLIKTESISLERIReportQuery.tesisKodu) : "");
                    TESISADI.CalcValue = (dataset_SAGLIKTESISLERIReportQuery != null ? Globals.ToStringCore(dataset_SAGLIKTESISLERIReportQuery.tesisAdi) : "");
                    YENIHASTAKABUL.CalcValue = @"YENIHASTAKABUL";
                    HASTAKABULIPTAL.CalcValue = @"HASTAKABULIPTAL";
                    YENIDOGANHASTAKABUL.CalcValue = @"YENIDOGANHASTAKABUL";
                    ILISKILITAKIPHASTAKABUL.CalcValue = @"ILISKILITAKIPHASTAKABUL";
                    HASTAKABULOKU.CalcValue = @"HASTAKABULOKU";
                    HASTAKABULTEDAVITIPIDEGISTIR.CalcValue = @"HASTAKABULTEDAVITIPIDEGISTIR";
                    HASTAKABULPROVIZYONDEGISTIR.CalcValue = @"HASTAKABULPROVIZYONDEGISTIR";
                    YENIDONORHASTAKABUL.CalcValue = @"YENIDONORHASTAKABUL";
                    HASTACIKISKAYIT.CalcValue = @"HASTACIKISKAYIT";
                    HASTACIKISTARIHIDEGISTIR.CalcValue = @"HASTACIKISTARIHIDEGISTIR";
                    HASTACIKISIPTAL.CalcValue = @"HASTACIKISIPTAL";
                    HASTAYATISOKU.CalcValue = @"HASTAYATISOKU";
                    BASVURUTAKIPOKU.CalcValue = @"BASVURUTAKIPOKU";
                    GERIYEDONUKYATISKABUL.CalcValue = @"GERIYEDONUKYATISKABUL";
                    SEVKBILDIR.CalcValue = @"SEVKBILDIR";
                    return new TTReportObject[] { TESISKODU,TESISADI,YENIHASTAKABUL,HASTAKABULIPTAL,YENIDOGANHASTAKABUL,ILISKILITAKIPHASTAKABUL,HASTAKABULOKU,HASTAKABULTEDAVITIPIDEGISTIR,HASTAKABULPROVIZYONDEGISTIR,YENIDONORHASTAKABUL,HASTACIKISKAYIT,HASTACIKISTARIHIDEGISTIR,HASTACIKISIPTAL,HASTAYATISOKU,BASVURUTAKIPOKU,GERIYEDONUKYATISKABUL,SEVKBILDIR};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ISLEMSAYILARIGRUPLU MyParentReport
            {
                get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TESISKODU { get {return Body().TESISKODU;} }
            public TTReportField TESISADI { get {return Body().TESISADI;} }
            public TTReportField YENIHASTAKABULIS { get {return Body().YENIHASTAKABULIS;} }
            public TTReportField HASTAKABULIPTALIS { get {return Body().HASTAKABULIPTALIS;} }
            public TTReportField YENIDOGANHASTAKABULIS { get {return Body().YENIDOGANHASTAKABULIS;} }
            public TTReportField ILISKILITAKIPHASTAKABULIS { get {return Body().ILISKILITAKIPHASTAKABULIS;} }
            public TTReportField YENIDONORHASTAKABULIS { get {return Body().YENIDONORHASTAKABULIS;} }
            public TTReportField HASTAKABULOKUIS { get {return Body().HASTAKABULOKUIS;} }
            public TTReportField HASTAKABULTEDAVITIPIDEGISTIRIS { get {return Body().HASTAKABULTEDAVITIPIDEGISTIRIS;} }
            public TTReportField HASTAKABULPROVIZYONDEGISTIRIS { get {return Body().HASTAKABULPROVIZYONDEGISTIRIS;} }
            public TTReportField HASTACIKISKAYITIS { get {return Body().HASTACIKISKAYITIS;} }
            public TTReportField HASTACIKISTARIHIDEGISTIRIS { get {return Body().HASTACIKISTARIHIDEGISTIRIS;} }
            public TTReportField HASTACIKISIPTALIS { get {return Body().HASTACIKISIPTALIS;} }
            public TTReportField HASTAYATISOKUIS { get {return Body().HASTAYATISOKUIS;} }
            public TTReportField BASVURUTAKIPOKUIS { get {return Body().BASVURUTAKIPOKUIS;} }
            public TTReportField GERIYEDONUKYATISKABULIS { get {return Body().GERIYEDONUKYATISKABULIS;} }
            public TTReportField SEVKBILDIRIS { get {return Body().SEVKBILDIRIS;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[15];
                list[0] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("YENIHASTAKABULQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.YENIHASTAKABUL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[1] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTAKABULIPTALQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTAKABULIPTAL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[2] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("YENIDOGANHASTAKABULQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.YENIDOGANHASTAKABUL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[3] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("ILISKILITAKIPHASTAKABULQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.ILISKILITAKIPHASTAKABUL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[4] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("YENIDONORHASTAKABULQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.YENIDONORHASTAKABUL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[5] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTAKABULOKUQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTAKABULOKU.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[6] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTAKABULTEDAVITIPIDEGISTIRQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTAKABULTEDAVITIPIDEGISTIR.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[7] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTAKABULPROVIZYONDEGISTIRQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTAKABULPROVIZYONDEGISTIR.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[8] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTACIKISKAYITQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTACIKISKAYIT.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[9] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTACIKISTARIHIDEGISTIRQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTACIKISTARIHIDEGISTIR.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[10] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTACIKISIPTALQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTACIKISIPTAL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[11] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("HASTAYATISOKUQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.HASTAYATISOKU.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[12] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("BASVURUTAKIPOKUQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.BASVURUTAKIPOKU.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[13] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("GERIYEDONUKYATISKABULQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.GERIYEDONUKYATISKABUL.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[14] = new TTReportNqlData<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>("SEVKBILDIRQ", BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer_"].ConvertValue(MyParentReport.PARTA.TESISKODU.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["String_100"].ConvertValue(MyParentReport.PARTA.SEVKBILDIR.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public ISLEMSAYILARIGRUPLU MyParentReport
                {
                    get { return (ISLEMSAYILARIGRUPLU)ParentReport; }
                }
                
                public TTReportField TESISKODU;
                public TTReportField TESISADI;
                public TTReportField YENIHASTAKABULIS;
                public TTReportField HASTAKABULIPTALIS;
                public TTReportField YENIDOGANHASTAKABULIS;
                public TTReportField ILISKILITAKIPHASTAKABULIS;
                public TTReportField YENIDONORHASTAKABULIS;
                public TTReportField HASTAKABULOKUIS;
                public TTReportField HASTAKABULTEDAVITIPIDEGISTIRIS;
                public TTReportField HASTAKABULPROVIZYONDEGISTIRIS;
                public TTReportField HASTACIKISKAYITIS;
                public TTReportField HASTACIKISTARIHIDEGISTIRIS;
                public TTReportField HASTACIKISIPTALIS;
                public TTReportField HASTAYATISOKUIS;
                public TTReportField BASVURUTAKIPOKUIS;
                public TTReportField GERIYEDONUKYATISKABULIS;
                public TTReportField SEVKBILDIRIS;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TESISKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 27, 5, false);
                    TESISKODU.Name = "TESISKODU";
                    TESISKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESISKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESISKODU.Value = @"{#PARTA.TESISKODU#}";

                    TESISADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 0, 78, 5, false);
                    TESISADI.Name = "TESISADI";
                    TESISADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESISADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESISADI.Value = @"{#PARTA.TESISADI#}";

                    YENIHASTAKABULIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 88, 5, false);
                    YENIHASTAKABULIS.Name = "YENIHASTAKABULIS";
                    YENIHASTAKABULIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIHASTAKABULIS.TextFormat = @"#,##0";
                    YENIHASTAKABULIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    YENIHASTAKABULIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YENIHASTAKABULIS.TextFont.Size = 8;
                    YENIHASTAKABULIS.TextFont.CharSet = 162;
                    YENIHASTAKABULIS.Value = @"{#ISLEMSAYISI#}";

                    HASTAKABULIPTALIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 144, 5, false);
                    HASTAKABULIPTALIS.Name = "HASTAKABULIPTALIS";
                    HASTAKABULIPTALIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAKABULIPTALIS.TextFormat = @"#,##0";
                    HASTAKABULIPTALIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTAKABULIPTALIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAKABULIPTALIS.TextFont.Size = 8;
                    HASTAKABULIPTALIS.TextFont.CharSet = 162;
                    HASTAKABULIPTALIS.Value = @"{#ISLEMSAYISI!HASTAKABULIPTALQ#}";

                    YENIDOGANHASTAKABULIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 96, 5, false);
                    YENIDOGANHASTAKABULIS.Name = "YENIDOGANHASTAKABULIS";
                    YENIDOGANHASTAKABULIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIDOGANHASTAKABULIS.TextFormat = @"#,##0";
                    YENIDOGANHASTAKABULIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    YENIDOGANHASTAKABULIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YENIDOGANHASTAKABULIS.TextFont.Size = 8;
                    YENIDOGANHASTAKABULIS.TextFont.CharSet = 162;
                    YENIDOGANHASTAKABULIS.Value = @"{#ISLEMSAYISI!YENIDOGANHASTAKABULQ#}";

                    ILISKILITAKIPHASTAKABULIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 112, 5, false);
                    ILISKILITAKIPHASTAKABULIS.Name = "ILISKILITAKIPHASTAKABULIS";
                    ILISKILITAKIPHASTAKABULIS.FieldType = ReportFieldTypeEnum.ftExpression;
                    ILISKILITAKIPHASTAKABULIS.TextFormat = @"#,##0";
                    ILISKILITAKIPHASTAKABULIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ILISKILITAKIPHASTAKABULIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ILISKILITAKIPHASTAKABULIS.TextFont.Size = 8;
                    ILISKILITAKIPHASTAKABULIS.TextFont.CharSet = 162;
                    ILISKILITAKIPHASTAKABULIS.Value = @"{#ISLEMSAYISI!ILISKILITAKIPHASTAKABULQ#}";

                    YENIDONORHASTAKABULIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 104, 5, false);
                    YENIDONORHASTAKABULIS.Name = "YENIDONORHASTAKABULIS";
                    YENIDONORHASTAKABULIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YENIDONORHASTAKABULIS.TextFormat = @"#,##0";
                    YENIDONORHASTAKABULIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    YENIDONORHASTAKABULIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YENIDONORHASTAKABULIS.TextFont.Size = 8;
                    YENIDONORHASTAKABULIS.TextFont.CharSet = 162;
                    YENIDONORHASTAKABULIS.Value = @"{#ISLEMSAYISI!YENIDONORHASTAKABULQ#}";

                    HASTAKABULOKUIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 120, 5, false);
                    HASTAKABULOKUIS.Name = "HASTAKABULOKUIS";
                    HASTAKABULOKUIS.FieldType = ReportFieldTypeEnum.ftExpression;
                    HASTAKABULOKUIS.TextFormat = @"#,##0";
                    HASTAKABULOKUIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTAKABULOKUIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAKABULOKUIS.TextFont.Size = 8;
                    HASTAKABULOKUIS.TextFont.CharSet = 162;
                    HASTAKABULOKUIS.Value = @"{#ISLEMSAYISI!HASTAKABULOKUQ#}";

                    HASTAKABULTEDAVITIPIDEGISTIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 128, 5, false);
                    HASTAKABULTEDAVITIPIDEGISTIRIS.Name = "HASTAKABULTEDAVITIPIDEGISTIRIS";
                    HASTAKABULTEDAVITIPIDEGISTIRIS.FieldType = ReportFieldTypeEnum.ftExpression;
                    HASTAKABULTEDAVITIPIDEGISTIRIS.TextFormat = @"#,##0";
                    HASTAKABULTEDAVITIPIDEGISTIRIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTAKABULTEDAVITIPIDEGISTIRIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAKABULTEDAVITIPIDEGISTIRIS.TextFont.Size = 8;
                    HASTAKABULTEDAVITIPIDEGISTIRIS.TextFont.CharSet = 162;
                    HASTAKABULTEDAVITIPIDEGISTIRIS.Value = @"{#ISLEMSAYISI!HASTAKABULTEDAVITIPIDEGISTIRQ#}";

                    HASTAKABULPROVIZYONDEGISTIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 136, 5, false);
                    HASTAKABULPROVIZYONDEGISTIRIS.Name = "HASTAKABULPROVIZYONDEGISTIRIS";
                    HASTAKABULPROVIZYONDEGISTIRIS.FieldType = ReportFieldTypeEnum.ftExpression;
                    HASTAKABULPROVIZYONDEGISTIRIS.TextFormat = @"#,##0";
                    HASTAKABULPROVIZYONDEGISTIRIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTAKABULPROVIZYONDEGISTIRIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAKABULPROVIZYONDEGISTIRIS.TextFont.Size = 8;
                    HASTAKABULPROVIZYONDEGISTIRIS.TextFont.CharSet = 162;
                    HASTAKABULPROVIZYONDEGISTIRIS.Value = @"{#ISLEMSAYISI!HASTAKABULPROVIZYONDEGISTIRQ#}";

                    HASTACIKISKAYITIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 152, 5, false);
                    HASTACIKISKAYITIS.Name = "HASTACIKISKAYITIS";
                    HASTACIKISKAYITIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTACIKISKAYITIS.TextFormat = @"#,##0";
                    HASTACIKISKAYITIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTACIKISKAYITIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTACIKISKAYITIS.TextFont.Size = 8;
                    HASTACIKISKAYITIS.TextFont.CharSet = 162;
                    HASTACIKISKAYITIS.Value = @"{#ISLEMSAYISI!HASTACIKISKAYITQ#}";

                    HASTACIKISTARIHIDEGISTIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 160, 5, false);
                    HASTACIKISTARIHIDEGISTIRIS.Name = "HASTACIKISTARIHIDEGISTIRIS";
                    HASTACIKISTARIHIDEGISTIRIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTACIKISTARIHIDEGISTIRIS.TextFormat = @"#,##0";
                    HASTACIKISTARIHIDEGISTIRIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTACIKISTARIHIDEGISTIRIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTACIKISTARIHIDEGISTIRIS.TextFont.Size = 8;
                    HASTACIKISTARIHIDEGISTIRIS.TextFont.CharSet = 162;
                    HASTACIKISTARIHIDEGISTIRIS.Value = @"{#ISLEMSAYISI!HASTACIKISTARIHIDEGISTIRQ#}";

                    HASTACIKISIPTALIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 168, 5, false);
                    HASTACIKISIPTALIS.Name = "HASTACIKISIPTALIS";
                    HASTACIKISIPTALIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTACIKISIPTALIS.TextFormat = @"#,##0";
                    HASTACIKISIPTALIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTACIKISIPTALIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTACIKISIPTALIS.TextFont.Size = 8;
                    HASTACIKISIPTALIS.TextFont.CharSet = 162;
                    HASTACIKISIPTALIS.Value = @"{#ISLEMSAYISI!HASTACIKISIPTALQ#}";

                    HASTAYATISOKUIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 176, 5, false);
                    HASTAYATISOKUIS.Name = "HASTAYATISOKUIS";
                    HASTAYATISOKUIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAYATISOKUIS.TextFormat = @"#,##0";
                    HASTAYATISOKUIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    HASTAYATISOKUIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAYATISOKUIS.TextFont.Size = 8;
                    HASTAYATISOKUIS.TextFont.CharSet = 162;
                    HASTAYATISOKUIS.Value = @"{#ISLEMSAYISI!HASTAYATISOKUQ#}";

                    BASVURUTAKIPOKUIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 184, 5, false);
                    BASVURUTAKIPOKUIS.Name = "BASVURUTAKIPOKUIS";
                    BASVURUTAKIPOKUIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASVURUTAKIPOKUIS.TextFormat = @"#,##0";
                    BASVURUTAKIPOKUIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BASVURUTAKIPOKUIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASVURUTAKIPOKUIS.TextFont.Size = 8;
                    BASVURUTAKIPOKUIS.TextFont.CharSet = 162;
                    BASVURUTAKIPOKUIS.Value = @"{#ISLEMSAYISI!BASVURUTAKIPOKUQ#}";

                    GERIYEDONUKYATISKABULIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 192, 5, false);
                    GERIYEDONUKYATISKABULIS.Name = "GERIYEDONUKYATISKABULIS";
                    GERIYEDONUKYATISKABULIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    GERIYEDONUKYATISKABULIS.TextFormat = @"#,##0";
                    GERIYEDONUKYATISKABULIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GERIYEDONUKYATISKABULIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GERIYEDONUKYATISKABULIS.TextFont.Size = 8;
                    GERIYEDONUKYATISKABULIS.TextFont.CharSet = 162;
                    GERIYEDONUKYATISKABULIS.Value = @"{#ISLEMSAYISI!GERIYEDONUKYATISKABULQ#}";

                    SEVKBILDIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 200, 5, false);
                    SEVKBILDIRIS.Name = "SEVKBILDIRIS";
                    SEVKBILDIRIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKBILDIRIS.TextFormat = @"#,##0";
                    SEVKBILDIRIS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SEVKBILDIRIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SEVKBILDIRIS.TextFont.Size = 8;
                    SEVKBILDIRIS.TextFont.CharSet = 162;
                    SEVKBILDIRIS.Value = @"{#ISLEMSAYISI!SEVKBILDIRQ#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 6, 200, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_YENIHASTAKABULQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(0);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTAKABULIPTALQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(1);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_YENIDOGANHASTAKABULQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(2);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_ILISKILITAKIPHASTAKABULQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(3);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_YENIDONORHASTAKABULQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(4);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTAKABULOKUQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(5);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTAKABULTEDAVITIPIDEGISTIRQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(6);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTAKABULPROVIZYONDEGISTIRQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(7);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTACIKISKAYITQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(8);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTACIKISTARIHIDEGISTIRQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(9);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTACIKISIPTALQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(10);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_HASTAYATISOKUQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(11);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_BASVURUTAKIPOKUQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(12);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_GERIYEDONUKYATISKABULQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(13);
                    BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class dataset_SEVKBILDIRQ = ParentGroup.rsGroup.GetCurrentRecord<BaseMedulaWLAction.ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class>(14);
                    SaglikTesisi.SAGLIKTESISLERIReportQuery_Class dataset_SAGLIKTESISLERIReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<SaglikTesisi.SAGLIKTESISLERIReportQuery_Class>(0);
                    TESISKODU.CalcValue = (dataset_SAGLIKTESISLERIReportQuery != null ? Globals.ToStringCore(dataset_SAGLIKTESISLERIReportQuery.tesisKodu) : "");
                    TESISADI.CalcValue = (dataset_SAGLIKTESISLERIReportQuery != null ? Globals.ToStringCore(dataset_SAGLIKTESISLERIReportQuery.tesisAdi) : "");
                    YENIHASTAKABULIS.CalcValue = (dataset_YENIHASTAKABULQ != null ? Globals.ToStringCore(dataset_YENIHASTAKABULQ.Islemsayisi) : "");
                    HASTAKABULIPTALIS.CalcValue = (dataset_HASTAKABULIPTALQ != null ? Globals.ToStringCore(dataset_HASTAKABULIPTALQ.Islemsayisi) : "");
                    YENIDOGANHASTAKABULIS.CalcValue = (dataset_YENIDOGANHASTAKABULQ != null ? Globals.ToStringCore(dataset_YENIDOGANHASTAKABULQ.Islemsayisi) : "");
                    YENIDONORHASTAKABULIS.CalcValue = (dataset_YENIDONORHASTAKABULQ != null ? Globals.ToStringCore(dataset_YENIDONORHASTAKABULQ.Islemsayisi) : "");
                    HASTACIKISKAYITIS.CalcValue = (dataset_HASTACIKISKAYITQ != null ? Globals.ToStringCore(dataset_HASTACIKISKAYITQ.Islemsayisi) : "");
                    HASTACIKISTARIHIDEGISTIRIS.CalcValue = (dataset_HASTACIKISTARIHIDEGISTIRQ != null ? Globals.ToStringCore(dataset_HASTACIKISTARIHIDEGISTIRQ.Islemsayisi) : "");
                    HASTACIKISIPTALIS.CalcValue = (dataset_HASTACIKISIPTALQ != null ? Globals.ToStringCore(dataset_HASTACIKISIPTALQ.Islemsayisi) : "");
                    HASTAYATISOKUIS.CalcValue = (dataset_HASTAYATISOKUQ != null ? Globals.ToStringCore(dataset_HASTAYATISOKUQ.Islemsayisi) : "");
                    BASVURUTAKIPOKUIS.CalcValue = (dataset_BASVURUTAKIPOKUQ != null ? Globals.ToStringCore(dataset_BASVURUTAKIPOKUQ.Islemsayisi) : "");
                    GERIYEDONUKYATISKABULIS.CalcValue = (dataset_GERIYEDONUKYATISKABULQ != null ? Globals.ToStringCore(dataset_GERIYEDONUKYATISKABULQ.Islemsayisi) : "");
                    SEVKBILDIRIS.CalcValue = (dataset_SEVKBILDIRQ != null ? Globals.ToStringCore(dataset_SEVKBILDIRQ.Islemsayisi) : "");
                    ILISKILITAKIPHASTAKABULIS.CalcValue = (dataset_ILISKILITAKIPHASTAKABULQ != null ? Globals.ToStringCore(dataset_ILISKILITAKIPHASTAKABULQ.Islemsayisi) : "");
                    HASTAKABULOKUIS.CalcValue = (dataset_HASTAKABULOKUQ != null ? Globals.ToStringCore(dataset_HASTAKABULOKUQ.Islemsayisi) : "");
                    HASTAKABULTEDAVITIPIDEGISTIRIS.CalcValue = (dataset_HASTAKABULTEDAVITIPIDEGISTIRQ != null ? Globals.ToStringCore(dataset_HASTAKABULTEDAVITIPIDEGISTIRQ.Islemsayisi) : "");
                    HASTAKABULPROVIZYONDEGISTIRIS.CalcValue = (dataset_HASTAKABULPROVIZYONDEGISTIRQ != null ? Globals.ToStringCore(dataset_HASTAKABULPROVIZYONDEGISTIRQ.Islemsayisi) : "");
                    return new TTReportObject[] { TESISKODU,TESISADI,YENIHASTAKABULIS,HASTAKABULIPTALIS,YENIDOGANHASTAKABULIS,YENIDONORHASTAKABULIS,HASTACIKISKAYITIS,HASTACIKISTARIHIDEGISTIRIS,HASTACIKISIPTALIS,HASTAYATISOKUIS,BASVURUTAKIPOKUIS,GERIYEDONUKYATISKABULIS,SEVKBILDIRIS,ILISKILITAKIPHASTAKABULIS,HASTAKABULOKUIS,HASTAKABULTEDAVITIPIDEGISTIRIS,HASTAKABULPROVIZYONDEGISTIRIS};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (string.IsNullOrEmpty(YENIHASTAKABULIS.CalcValue))
                YENIHASTAKABULIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTAKABULIPTALIS.CalcValue))
                HASTAKABULIPTALIS.CalcValue = "0";

            if (string.IsNullOrEmpty(YENIDOGANHASTAKABULIS.CalcValue))
                YENIDOGANHASTAKABULIS.CalcValue = "0";

            if (string.IsNullOrEmpty(YENIDONORHASTAKABULIS.CalcValue))
                YENIDONORHASTAKABULIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTACIKISKAYITIS.CalcValue))
                HASTACIKISKAYITIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTACIKISTARIHIDEGISTIRIS.CalcValue))
                HASTACIKISTARIHIDEGISTIRIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTACIKISIPTALIS.CalcValue))
                HASTACIKISIPTALIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTAYATISOKUIS.CalcValue))
                HASTAYATISOKUIS.CalcValue = "0";

            if (string.IsNullOrEmpty(BASVURUTAKIPOKUIS.CalcValue))
                BASVURUTAKIPOKUIS.CalcValue = "0";

            if (string.IsNullOrEmpty(GERIYEDONUKYATISKABULIS.CalcValue))
                GERIYEDONUKYATISKABULIS.CalcValue = "0";

            if (string.IsNullOrEmpty(SEVKBILDIRIS.CalcValue))
                SEVKBILDIRIS.CalcValue = "0";

            if (string.IsNullOrEmpty(ILISKILITAKIPHASTAKABULIS.CalcValue))
                ILISKILITAKIPHASTAKABULIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTAKABULOKUIS.CalcValue))
                HASTAKABULOKUIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTAKABULTEDAVITIPIDEGISTIRIS.CalcValue))
                HASTAKABULTEDAVITIPIDEGISTIRIS.CalcValue = "0";

            if (string.IsNullOrEmpty(HASTAKABULPROVIZYONDEGISTIRIS.CalcValue))
                HASTAKABULPROVIZYONDEGISTIRIS.CalcValue = "0";

            this.ParentReport.ChartDataTable.Rows.Add(TESISADI.CalcValue, Convert.ToInt32(YENIHASTAKABULIS.CalcValue),
                Convert.ToInt32(YENIDOGANHASTAKABULIS.CalcValue),
                Convert.ToInt32(YENIDONORHASTAKABULIS.CalcValue),
                Convert.ToInt32(ILISKILITAKIPHASTAKABULIS.CalcValue),
                Convert.ToInt32(HASTAKABULOKUIS.CalcValue),
                Convert.ToInt32(HASTAKABULTEDAVITIPIDEGISTIRIS.CalcValue),
                Convert.ToInt32(HASTAKABULPROVIZYONDEGISTIRIS.CalcValue),
                Convert.ToInt32(HASTAKABULIPTALIS.CalcValue),
                Convert.ToInt32(HASTACIKISKAYITIS.CalcValue),
                Convert.ToInt32(HASTACIKISTARIHIDEGISTIRIS.CalcValue),
                Convert.ToInt32(HASTACIKISIPTALIS.CalcValue),
                Convert.ToInt32(HASTAYATISOKUIS.CalcValue),
                Convert.ToInt32(BASVURUTAKIPOKUIS.CalcValue),
                Convert.ToInt32(GERIYEDONUKYATISKABULIS.CalcValue),
                Convert.ToInt32(SEVKBILDIRIS.CalcValue));
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ISLEMSAYILARIGRUPLU()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("bf3434a5-9f3d-4dba-87cf-ad0a1662d342"));
            reportParameter = Parameters.Add("ENDDATE", "23:59", "Bitiş Tarihi", @"", true, true, false, new Guid("bf3434a5-9f3d-4dba-87cf-ad0a1662d342"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime_"].ConvertValue(parameters["ENDDATE"]);
            Name = "ISLEMSAYILARIGRUPLU";
            Caption = "İşlem Sayıları Tipine Göre";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
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
            fd.TextFont.CharSet = 1;
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


        protected override void RunPreScript()
        {
#region ISLEMSAYILARIGRUPLU_PreScript
            this.ChartDataTable = new DataTable();
            this.ChartDataTable.Columns.Add("Sağlık Tesisi Adı", typeof(string));
            this.ChartDataTable.Columns.Add("Yeni Hasta Kabul", typeof(int));
            this.ChartDataTable.Columns.Add("Yeni Doğan Hasta Kabul", typeof(int));
            this.ChartDataTable.Columns.Add("Yeni Donör Hasta Kabul", typeof(int));
            this.ChartDataTable.Columns.Add("İlişkili Takip Hasta Kabul", typeof(int));
            this.ChartDataTable.Columns.Add("Hasta Kabul Oku", typeof(int));
            this.ChartDataTable.Columns.Add("H.K. Tedavi Tipi Değiştir", typeof(int));
            this.ChartDataTable.Columns.Add("H.K. Provizyon Tipi Değiştir", typeof(int));
            this.ChartDataTable.Columns.Add("Hasta Kabul İptal", typeof(int));
            this.ChartDataTable.Columns.Add("Hasta Çıkış Kayıt", typeof(int));
            this.ChartDataTable.Columns.Add("Hasta Çıkış Tarihi Değiştir", typeof(int));
            this.ChartDataTable.Columns.Add("Hasta Çıkış İptal", typeof(int));
            this.ChartDataTable.Columns.Add("Hasta Yatış Oku", typeof(int));
            this.ChartDataTable.Columns.Add("Başvuru Takip Oku", typeof(int));
            this.ChartDataTable.Columns.Add("Geriye Dönük Yatış Kabul", typeof(int));
            this.ChartDataTable.Columns.Add("Sevk Bildir", typeof(int));
#endregion ISLEMSAYILARIGRUPLU_PreScript
        }
    }
}