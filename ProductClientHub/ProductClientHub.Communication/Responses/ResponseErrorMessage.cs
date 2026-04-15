using System.Drawing;

namespace ProductClientHub.Communication.Responses
{
    public class ResponseErrorMessage
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessage(string message)
        {
            Errors = [message];
        }

        public ResponseErrorMessage(List<string> messages )
        {
            Errors = messages;
        }

    }
}
