using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouWatch
{
    public class General
    {
        public static bool IsUrlValidForYouTube(string pURL)
        {
            string pattern = @"^(https?\:\/\/)?(www\.)?(youtube\.com|youtu\.?be)\/.+$";

            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return reg.IsMatch(pURL);
        }

        public static string ReadURLFromClipboard()
        {
            string clip = Clipboard.GetText();

            if (!string.IsNullOrEmpty(clip))
            {
                if (!IsUrlValidForYouTube(clip))
                {
                    clip = string.Empty;
                }
            }

            return clip;
        }

    }
}
