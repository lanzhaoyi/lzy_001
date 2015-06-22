using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MPS_A1.FormFunc
{
    /// <summary>
    /// 验证类
    /// </summary>
    public class VerificationFunc
    {
        /// <summary>
        /// 非空验证(不带提示)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool VerNullOrEmpty(string text)
        {
            if (string.IsNullOrEmpty(text.Trim()))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 非空验证(带提示)
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool VerNullOrEmpty(Control control, string text)
        {
            string controlText = string.Empty;

            if (control.GetType() == typeof(ComboBox))
            {
                if (string.IsNullOrEmpty(control.Text.Trim()) || control.Text.Trim() == "[请选择]")
                {
                    MsgFunc.ShowMsgWarning(string.Format("请选择{0}", text));
                    control.Focus();
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(control.Text.Trim()))
                {
                    MsgFunc.ShowMsgWarning(string.Format("请输入{0}", text));
                    control.Focus();
                    return false;
                }
            }

            return true;
        }

        public static bool VerNullOrEmpty(string controltext, string msg)
        {
            if (string.IsNullOrEmpty(controltext) || controltext.Trim() == "[请选择]")
            {
                MsgFunc.ShowMsgWarning(string.Format("请选择{0}", msg));
                return false;
            }


            return true;
        }

        /// <summary>
        /// 正整数验证
        /// </summary>
        /// <param name="text"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool VerPositiveInteger(string text)
        {
            if (!Regex.IsMatch(text, @"^[0-9]*[1-9][0-9]*$"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 正整数验证
        /// </summary>
        /// <param name="text"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool VerPositiveInteger(Control control, string msg)
        {
            if (!Regex.IsMatch(control.Text.Trim(), @"^[0-9]+$"))
            {
                MsgFunc.ShowMsgWarning(string.Format("{0}必须为正整数", msg));
                return false;
            }
            return true;
        }


        /// <summary>
        /// 浮点数验证
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool VerDecimal(string text)
        {
            if (!Regex.IsMatch(text, @"^(-?\d+)(\.\d+)?$"))//"^[0-9]+(\.[0-9]+){0,1}$"
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 浮点数验证
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool VerDecimal(Control control, string text)
        {
            if (!Regex.IsMatch(control.Text.Trim(), @"^(-?\d+)(\.\d+)?$"))//"^[0-9]+(\.[0-9]+){0,1}$"
            {
                MsgFunc.ShowMsgWarning(string.Format("{0}格式输入错误", text));
                control.Focus();
                return false;
            }
            return true;
        }
    }
}
