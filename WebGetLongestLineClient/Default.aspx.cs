using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGetLongestLineClient.ServiceReference1;

namespace WebGetLongestLineClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (!FileUpload1.PostedFile.ContentType.ToLower().Equals("text/plain"))
                {
                    lblInfo.Text = FileUpload1.FileName + " is not a text file.";
                    lblInfo.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                ServiceReference1.ITransferService clientUpload = new ServiceReference1.TransferServiceClient();
                ServiceReference1.RemoteFileInfo uploadRequestInfo = new ServiceReference1.RemoteFileInfo();

                uploadRequestInfo.FileName = FileUpload1.FileName;
                uploadRequestInfo.Length = FileUpload1.PostedFile.ContentLength;
                uploadRequestInfo.FileByteStream = FileUpload1.FileContent;
                var retType = new ReturnType();
                retType = clientUpload.UploadFileAndReturnLongestLine(uploadRequestInfo);
                if (retType.Status.Equals(true))
                    lblInfo.Text = retType.LongestLine;
                else
                {
                    lblInfo.Text = retType.ErrorMessage;
                    lblInfo.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}