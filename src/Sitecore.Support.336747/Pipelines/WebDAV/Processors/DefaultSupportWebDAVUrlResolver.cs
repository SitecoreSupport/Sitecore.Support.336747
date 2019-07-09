using Sitecore.Pipelines.WebDAV;
using System.Web;

namespace Sitecore.Support.Pipelines.WebDAV.Processors
{
    public class DefaultSupportWebDAVUrlResolver
    {
        public void Process(WebDAVPipelineArgs<Tristate> args)
        {
            HttpContext context = args.Context;
            if (((context == null) || (context.Request == null)) || string.IsNullOrEmpty(context.Request.UserAgent))
            {
                args.Result = Tristate.True;
            }

            #region added additional check for 'Windows NT 10.0'

            else if ((context.Request.UserAgent.ToLowerInvariant().Contains("Windows NT 6.1".ToLowerInvariant()) || (context.Request.UserAgent.ToLowerInvariant().Contains("Windows NT 6.2".ToLowerInvariant()) || context.Request.UserAgent.ToLowerInvariant().Contains("Windows NT 6.3".ToLowerInvariant()))) || context.Request.UserAgent.ToLowerInvariant().Contains("Microsoft-WebDAV-MiniRedir/6.1".ToLowerInvariant()) || context.Request.UserAgent.ToLowerInvariant().Contains("Windows NT 10.0".ToLowerInvariant()))
            {
                args.Result = Tristate.False;
            }

            #endregion
            else
            {
                args.Result = Tristate.True;
            }
        }
    }
}