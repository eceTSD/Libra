using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Libra.App_Start
{
    public class menu
    {
        private string name;
        private string title;
        private string Description;
        private string PicUrl;
        private string Url;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description1
        {
            get
            {
                return Description;
            }

            set
            {
                Description = value;
            }
        }

        public string PicUrl1
        {
            get
            {
                return PicUrl;
            }

            set
            {
                PicUrl = value;
            }
        }

        public string Url1
        {
            get
            {
                return Url;
            }

            set
            {
                Url = value;
            }
        }
    }
}