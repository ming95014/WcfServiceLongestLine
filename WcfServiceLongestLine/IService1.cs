using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceLongestLine
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITransferService
    {
        [OperationContract]
        ReturnType UploadFileAndReturnLongestLine(RemoteFileInfo request); 
    }

    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageHeader(MustUnderstand = true)]
        public long Length;

        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }

    [MessageContract]
    public class ReturnType
    {
        bool boolStatus = true;
        string strLongestLine = string.Empty;
        string strErrorMsg = string.Empty;

        [MessageHeader(MustUnderstand = true)]
        public bool Status
        {
            get { return boolStatus; }
            set { boolStatus = value; }
        }

        [MessageHeader(MustUnderstand = true)]
        public string LongestLine
        {
            get { return strLongestLine; }
            set { strLongestLine = value; }
        }

        [MessageHeader(MustUnderstand = true)]
        public string ErrorMessage
        {
            get { return strErrorMsg; }
            set { strErrorMsg = value; }
        }
    }
}