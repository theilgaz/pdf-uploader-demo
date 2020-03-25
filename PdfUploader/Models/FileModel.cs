using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PdfUploader.Models
{
    public class FileModel
    {  
        public HttpPostedFileBase PdfFile { get; set; }
    }

    public class MessageModel
    {
        public string Message { get; set; }
    }
}