using System.Web;

namespace RequestFilter
{
    public interface IFilter
    {
        bool CanProceed(HttpRequestBase request);
    }
}