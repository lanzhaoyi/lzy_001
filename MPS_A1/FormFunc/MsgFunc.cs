using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPS_A1.FormFunc
{
    /// <summary>
    /// 消息提示类
    /// </summary>
    public class MsgFunc
    {
        /// <summary>
        /// 展示消息(信息)
        /// </summary>
        /// <param name="text"></param>
        public static void ShowMsgInfo(string text)
        {
            MessageBox.Show(string.Format("{0}!", text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 展示消息(警告)
        /// </summary>
        /// <param name="text"></param>
        public static void ShowMsgWarning(string text)
        {
            MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 展示消息(错误)
        /// </summary>
        /// <param name="text"></param>
        public static void ShowMsgError(string text)
        {
            MessageBox.Show(text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 展示消息(问题)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ShowMsgQuestion(string text)
        {
            if (MessageBox.Show(text, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                return true;
            return false;
        }

        /// <summary>
        /// 成功失败展示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="text"></param>
        public static void ShowMsgSuccessFail(bool result, string text)
        {
            MessageBox.Show(text + (result ? "成功" : "失败"), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
