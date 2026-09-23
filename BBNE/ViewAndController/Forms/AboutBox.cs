using BibleBooksNE.ViewAndController.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BibleBooksNE
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            SetValues(new string[0]);
        }

        public AboutBox(string[] otherDescription)
        {
            InitializeComponent();
            SetValues(otherDescription);
        }

        private void SetValues(string[] otherDescription)
        {
            Assemblies assemblies = new Assemblies();
            Text += Assemblies.AssemblyTitle;
            labelProductName.Text += Assemblies.AssemblyProduct;
            labelVersion.Text += Assemblies.AssemblyVersion;
            labelCopyright.Text += Assemblies.AssemblyCopyright;
            labelCompanyName.Text += Assemblies.AssemblyCompany;
            textBoxDescription.Lines = SetDescription(Assemblies.AssemblyDescription, otherDescription);
        }

        private string[] SetDescription(string description, string[] other)
        {
            List<string> list = new List<string> {
                textBoxDescription.Text,
                description,
                Environment.NewLine
            };
            list.AddRange(other);
            return list.ToArray();
        }
    }
}
