using Infrastructure.Models;
using Newtonsoft.Json;
using System;

namespace Core.Models.TestProject
{
    public class Obje
    {
        public object[] Dizi
        {
            get;
            set;
        }
    }

    public class GridTestViewModel
    {
        public object Value { get; set; }
        public object[] Items { get; set; }
    }

    public class DummyModel
    {
        public object dataMember { get; set; }
    }

    public class TestProjectModel
    {
        public string Rtf
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }

        public DateTime? Date
        {
            get;
            set;
        }

        public bool ? Value
        {
            get;
            set;
        }

        public object ComboValue
        {
            get;
            set;
        }

        public object ListBoxValue
        {
            get;
            set;
        }

        public Guid ListBoxGuid
        {
            get;
            set;
        }

        public Guid? ListBoxNullGuid
        {
            get;
            set;
        }

        public object[] Items
        {
            get;
            set;
        }

        public Obje Obje
        {
            get;
            set;
        }
    }
}