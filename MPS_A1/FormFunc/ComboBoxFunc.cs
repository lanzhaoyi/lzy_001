using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPS_A1.FormFunc
{
    /// <summary>
    /// ComboBox控件处理类
    /// </summary>
    public class ComboBoxFunc
    {
        /// <summary>
        /// 加载ComboxBox数据
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public static void LoadComboxBoxData(ComboBox cb, DataTable data)
        {
            DataRow row = data.NewRow();
            row["ID"] = 0;
            row["Name"] = "[请选择]";
            data.Rows.InsertAt(row, 0);
            cb.DataSource = data;
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }
        /// <summary>
        /// 加载ComboxBox数据
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        public static void LoadComboxBoxData(ComboBox cb, DataTable data, string displayMember, string valueMember)
        {
            DataRow row = data.NewRow();
            row["ID"] = 0;
            row["Name"] = "[请选择]";
            data.Rows.InsertAt(row, 0);
            cb.DataSource = data;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;
        }

        /// <summary>
        /// 加载ComboxBox数据
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public static void LoadComboxBoxData<T>(ComboBox cb, IList<T> data, T obj)
        {
            if (data == null)
                return;
            if (obj != null)
                data.Insert(0, obj);
            cb.DataSource = data;
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }

        public static void LoadComboxBoxData<T>(ComboBox cb, IList<T> data, T obj, string displayMember, string valueMember)
        {
            if (data == null)
                return;
            if (obj != null)
                data.Insert(0, obj);
            cb.DataSource = data;
            cb.DisplayMember = displayMember;
            cb.ValueMember = valueMember;
        }

        /// <summary>
        /// 加载ComboxBox数据
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public static void LoadToolStripComboBoxData(ToolStripComboBox cb, DataTable data)
        {
            DataRow row = data.NewRow();
            row["ID"] = 0;
            row["Name"] = "[请选择]";
            data.Rows.InsertAt(row, 0);
            cb.ComboBox.DataSource = data;
            cb.ComboBox.DisplayMember = "Name";
            cb.ComboBox.ValueMember = "ID";
        }
        /// <summary>
        /// 加载ComboxBox数据
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        public static void LoadToolStripComboBoxData<T>(ToolStripComboBox cb, IList<T> data, T obj)
        {
            if (data == null)
                return;
            data.Insert(0, obj);
            cb.ComboBox.DataSource = data;
            cb.ComboBox.DisplayMember = "Name";
            cb.ComboBox.ValueMember = "ID";
        }
        /// <summary>
        /// 加载ComboxBox数据
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="data"></param>
        /// <param name="displayMember"></param>
        /// <param name="valueMember"></param>
        public static void LoadToolStripComboBoxData(ToolStripComboBox cb, DataTable data, string displayMember, string valueMember)
        {
            DataRow row = data.NewRow();
            row[displayMember] = 0;
            row[valueMember] = "[请选择]";
            data.Rows.InsertAt(row, 0);
            cb.ComboBox.DataSource = data;
            cb.ComboBox.DisplayMember = displayMember;
            cb.ComboBox.ValueMember = valueMember;
        }

        public static string GetSelectedpComboBoxValue(ComboBox cb, string ValueMember)
        {
            if (cb.SelectedValue == null)
                return "0";
            return cb.SelectedValue.ToString();
        }

        /// <summary>
        /// 得到选中下拉列表的key值
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static string GetSelectedToolStripComboBoxValue(ToolStripComboBox cb, string ValueMember)
        {
            if (cb.ComboBox.SelectedValue == null)
                return "0";
            return cb.ComboBox.SelectedValue.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="key"></param>
        public static void SelectedComboBox(ComboBox cb, string key)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SelectedIndex = i;
                string value = cb.SelectedValue.ToString();
                if (value == key.Trim())
                {
                    break;
                }
                cb.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 选择对应的ToolStripComboBox
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="key"></param>
        public static void SelectedToolStripComboBox(ToolStripComboBox cb, string key)
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SelectedIndex = i;
                string value = cb.ComboBox.SelectedValue.ToString();
                if (value == key.Trim())
                {
                    break;
                }
                cb.SelectedIndex = 0;
            }
        }
    }
}
