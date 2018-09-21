using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitJsonXmlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Ini();
        }
        private void Ini()
        {
            INIHelper.IniWriteValue("节点1", "测试", "你好");
            INIHelper.IniWriteValue("节点1", "测试", "你好");
        }
        private void Seri()
        {

            
        }
    }
}
