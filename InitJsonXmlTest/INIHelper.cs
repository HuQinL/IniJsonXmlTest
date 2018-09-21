using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InitJsonXmlTest
{
    /// <summary>
    /// INI文件读取类
    /// </summary>
    public class INIHelper
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public static string str = "setting.ini";
        /// <summary>
        /// 文件路径
        /// </summary>
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory + str;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        /// <summary>
        /// 写INI文件
        /// </summary>
        /// <param name="Section">节点名称</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="Section">节点名称</param>
        /// <param name="Key">键</param>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string path)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static byte[] IniReadValues(string section, string key)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp;

        }
        /// <summary>
        /// 删除ini文件下所有节点
        /// </summary>
        public static void ClearAllSection()
        {
            IniWriteValue(null, null, null);
        }
        /// <summary>
        /// 删除ini文件指点节点下的所有键
        /// </summary>
        /// <param name="Section"></param>
        public static void ClearSection(string Section)
        {
            IniWriteValue(Section, null, null);
        }
    }

}
